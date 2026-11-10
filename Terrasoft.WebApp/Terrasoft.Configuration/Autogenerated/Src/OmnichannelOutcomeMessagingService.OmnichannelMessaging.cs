namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using Newtonsoft.Json;
	using OmnichannelMessaging.Utilities;
	using OmnichannelProviders.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
	using System.Linq;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common.ServiceRouting;
	using MessageType = OmnichannelProviders.Domain.Entities.MessageType;
	
#if NETSTANDARD2_0
	using TS = Terrasoft.Web.Http.Abstractions;
#endif
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[DefaultServiceRoute]
	public class OmnichannelOutcomeMessagingService : OmnichannelMessagingService
	{

		#region Constants: Private 

		private const string OmnichannelMessageSendErrorMetricName = "omnichannel_messaging_message_send_error_count";

		#endregion

		#region Properties: Protected

		private IOmnichannelMessageFileLoader _fileLoader;

		protected IOmnichannelMessageFileLoader FileLoader {
			get
			{
				if (_fileLoader != null) {
					return _fileLoader;
				}
				_fileLoader = ClassFactory.Get<IOmnichannelMessageFileLoader>("OmnichannelMessage",
				new ConstructorArgument("userConnection", UserConnection));
				return _fileLoader;
			}
		}

		#endregion

		#region Constructors: Public

		public OmnichannelOutcomeMessagingService(UserConnection userConnection) : base(userConnection) {
		}

		public OmnichannelOutcomeMessagingService() : base() {
		}

		#endregion

		#region Methods: Private

		private void SaveFile(MessageAttachment attachment) {
			if (FileLoader.IsFileApiEnabled()) {
				FileLoader.UploadFile(attachment, attachment.Content);
			} else {
				SaveFileToDb(attachment);
			}
		}

		private void SaveFileToDb(MessageAttachment attachment) {
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("OmnichannelMessageFile");
			var entity = entitySchema.CreateEntity(UserConnection);
			entity.SetColumnValue("Id", attachment.FileId);
			entity.SetColumnValue("MessageId", attachment.MessageId);
			entity.SetColumnValue("Name", attachment.FileName);
			entity.SetColumnValue("TypeId", Guid.Parse("529BC2F8-0EE0-DF11-971B-001D60E938C6"));
			entity.SetColumnValue("Size", attachment.Content.Length);
			entity.SetStreamValue("Data", attachment.Content);
			entity.Save(false);
			attachment.Content.Dispose();
		}

#if NETSTANDARD2_0
		private TS.HttpRequest GetRequest() {
			return HttpContextAccessor.GetInstance().Request;
		}
#else
		private HttpRequestWrapper GetRequest() {
			return new HttpRequestWrapper(System.Web.HttpContext.Current.Request);
		}
#endif
		private MessagingMessage AddAttachments(MessagingMessage message) {
			message.Attachments = new List<MessageAttachment>();
			var request = GetRequest();
			var files = request.Files;
#if NETSTANDARD2_0
			foreach (string fileKey in files.AllKeys) {
				TS.HttpPostedFile file = files[fileKey];
#else
			foreach (string fileKey in files) {
				HttpPostedFileBase file = files[fileKey];
#endif
				MessageType fileType = Enum.TryParse(file.ContentType.Split('/')[0], true, out fileType) && fileType != MessageType.Text
					? fileType
					: MessageType.File;
				message.MessageType = fileType;
				MemoryStream ms = new MemoryStream();
				file.InputStream.CopyTo(ms);
				var attachment = new MessageAttachment {
					FileId = Guid.NewGuid().ToString(),
					FileName = file.FileName,
					MimeType = file.ContentType,
					FileType = fileType,
					Content = ms
				};
				message.Attachments.Add(attachment);
			}
			return message;
		}

		private long GetCurrentTime() {
			return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;
		}

		private OmnichannelMessagingServiceResponse SendAndClearTextMessage(MessagingMessage message) {
			var response = SendMessage(message);
			message.Message = string.Empty;
			return response;
		}

		private void NotifyMessageDeliveryStatusChanged(MessagingMessage message) {
			OperatorNotifier.MessageDeliveryStatusChangedNotify(UserConnection.CurrentUser.Id, message.Id,
				message.Status, message.DeliveryError);
		}

		private void SaveAttachments(MessagingMessage message) {
			message.Attachments.ForEach((att) => {
				att.MessageId = message.Id;
				SaveFile(att);
			});
		}

		private bool IsError(string response) {
			return response.Contains("error");
		}

		private OmnichannelMessagingMessageMetric GetMetric() {
			return new OmnichannelMessagingMessageMetric {
				Direction = OmnichannelProviders.Domain.Entities.MessageDirection.Outcoming
			};
		}

		private HashSet<string> GetFailedAttachmentFileNames(string result) {
			var failedNames = new HashSet<string>();
			if (string.IsNullOrEmpty(result) || !result.TrimStart().StartsWith("{")) {
				return failedNames;
			}
			try {
				var responseObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
				if (responseObj != null && responseObj.ContainsKey("attachmentErrors")) {
					var attachmentErrorsArray = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(
						responseObj["attachmentErrors"].ToString()
					);
					if (attachmentErrorsArray != null) {
						foreach (var error in attachmentErrorsArray) {
							if (error.TryGetValue("FileName", out var fileName) && fileName != null) {
								failedNames.Add(fileName.ToString());
							}
						}
					}
				}
			} catch {
			}
			return failedNames;
		}

		#endregion


		#region Methods: Public

		/// <summary>
		/// Sends message to integration api.
		/// </summary>
		/// <param name="message">Unified messaging message.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		  ResponseFormat = WebMessageFormat.Json)]
		public OmnichannelMessagingServiceResponse SendMessage(MessagingMessage message) {
			message.IsStandBy = false;
			var response = new OmnichannelMessagingServiceResponse();
			message.Timestamp = GetCurrentTime();
			Stopwatch stopWatch = new Stopwatch();
			var metric = GetMetric();
			try {
				stopWatch.Start();
				var result = InternalSend(message);
				NotifyMessageDeliveryStatusChanged(message);
				stopWatch.Stop();
				metric.Duration = stopWatch.ElapsedMilliseconds;
				metric.Size = message.GetSize();
				if (IsError(result)) {
					response = GetSendingError(message.Source, result);
					Log.ErrorFormat("Error while sending the message to contact {0} in chat {1}: {2}",
						message.ContactId, message.ChatId, result);
					metric.ErrorType = MessageSendingError.Messenger;
				} else {
					response.Success = true;
					response.ChatId = message.ChatId;
				}
			} catch (Exception e) {
				stopWatch.Stop();
				metric.Duration = stopWatch.ElapsedMilliseconds;
				metric.ErrorType = MessageSendingError.Internal;
				response = GetSendingError();
				Log.ErrorFormat("Error while sending the message. Error info: {0}, StackTrace: {1}", e.Message, e.StackTrace);
			}
			MetricReporter.Report(metric);
			if (!response.Success) {
				MetricReporter.Gauge(OmnichannelMessageSendErrorMetricName, 1);
			}
			return response;
		}

		/// <summary>
		/// Sends message with attachments.
		/// </summary>
		/// <param name="message">Unified messaging message.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		  ResponseFormat = WebMessageFormat.Json)]
		public OmnichannelMessagingServiceResponse SendMessageWithAttachments() {
			var response = new OmnichannelMessagingServiceResponse();
			MessagingMessage message = JsonConvert.DeserializeObject<MessagingMessage>(GetRequest().Form["message"]);
			if (message.Id == Guid.Empty) {
				message.Id = Guid.NewGuid();
			}
			message.Timestamp = GetCurrentTime();
			Stopwatch stopWatch = new Stopwatch();
			var metric = GetMetric();
			try {
				if (message.Message.Length > 0) {
					response = SendAndClearTextMessage(message);
					if (!response.Success) {
						return response;
					}
				}
				stopWatch.Start();
				AddAttachments(message);
				metric.Type = message.MessageType;
				message.Id = Guid.NewGuid();
				// Mirror InternalSend: let a registered IOutboundMessageInterceptor (e.g. the channel
				// preview) claim the message first. When intercepted, the reply is routed to the admin's
				// preview WebSocket and the native gateway send is skipped — without this an operator file
				// leaked to the real WebChat gateway (BadRequest) and the message was never persisted.
				// For non-preview chats the interceptor returns false, so behaviour is unchanged.
				string result;
				if (TryInterceptOutboundMessage(message)) {
					message.Status = message.Status ?? MessageDeliveryStatus.Sent;
					result = message.Status.ToString();
				} else {
					result = MessageManager.Send(message, message.ChannelName);
				}
				NotifyMessageDeliveryStatusChanged(message);

				stopWatch.Stop();
				metric.Duration = stopWatch.ElapsedMilliseconds;
				metric.Size = message.GetSize();
				var failedFileNames = GetFailedAttachmentFileNames(result);
				message.Attachments = message.Attachments
					.Where(a => !failedFileNames.Contains(a.FileName))
					.ToList();
				if (message.Attachments.Any() || !string.IsNullOrEmpty(message.Message)) {
					message.ChatId = ChatRepository.AddMessage(message, out bool isNewChat).ToString();
					if (message.Attachments.Any()) {
						SaveAttachments(message);
					}
					OperatorNotifier.NewConversationMessageNotify(message as UnifiedMessage);
				}
				if (IsError(result)) {
					metric.ErrorType = MessageSendingError.Messenger;
					response = GetSendingError(message.Source, result);
					Log.ErrorFormat("Error while sending the message with attachments to contact {0} in chat {1}: {2}",
						message.ContactId, message.ChatId, result);
				} else {
					response.ChatId = message.ChatId;
				}
			} catch (Exception e) {
				stopWatch.Stop();
				metric.Duration = stopWatch.ElapsedMilliseconds;
				metric.ErrorType = MessageSendingError.Internal;
				metric.Type = message.MessageType;
				response = GetSendingError();
				Log.ErrorFormat("Error while sending the message with attachments. Error info: {0}, StackTrace: {1}", e.Message, e.StackTrace);
			}
			MetricReporter.Report(metric);
			if (!response.Success) {
				MetricReporter.Gauge(OmnichannelMessageSendErrorMetricName, 1);
			}
			return response;
		}

		#endregion

	}
}
