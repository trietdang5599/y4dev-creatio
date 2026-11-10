namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using global::Common.Logging;
	using OmnichannelMessaging.Utilities;
	using OmnichannelProviders.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using Terrasoft.Configuration.FileUpload;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: OmnichannelMessageFileLoader

	[DefaultBinding(typeof(IOmnichannelMessageFileLoader), Name = "OmnichannelMessage")]
	public class OmnichannelMessageFileLoader : IOmnichannelMessageFileLoader
	{

		#region Class: OmnichannelMessageUploadInfo

		protected class OmnichannelMessageUploadInfo : FileEntityUploadInfo
		{

			#region Public: Constructors

			/// <summary>
			/// Initializes new instance of <see cref="OmnichannelMessageUploadInfo"/>. 
			/// </summary>
			public OmnichannelMessageUploadInfo(string entitySchemaName, Guid fileId, MessageAttachment attachment)
					: base(entitySchemaName, fileId, attachment.FileName) {
				MessageId = attachment.MessageId;
			}

			#endregion

			#region Properties: Public

			public Guid MessageId { get; set; }

			#endregion
		}

		#endregion

		#region Class: OmnichannelMessageFileRepository

		protected class OmnichannelMessageFileRepository : FileRepository
		{

			#region Class: OmnichannelMessageUploader

			protected class OmnichannelMessageUploader : FileUploader
			{

				#region Constructors: Public

				/// <summary>
				/// Creates instance of type <see cref="OmnichannelMessageUploader"/>.
				/// </summary>
				/// <param name="userConnection">User connection.</param>
				public OmnichannelMessageUploader(UserConnection userConnection) : base(userConnection) {
				}

				#endregion

				#region Methods: Protected

				protected override void FillAttributes(Dictionary<string, object> attributes, IFileUploadInfo fileUploadInfo,
						bool isSetBaseAttributes) {
					base.FillAttributes(attributes, fileUploadInfo, isSetBaseAttributes);
					if (isSetBaseAttributes && (fileUploadInfo is OmnichannelMessageUploadInfo fileInfo)) {
						attributes["MessageId"] = fileInfo.MessageId;
					}
				}

				#endregion

			}

			#endregion

			#region Constructors: Public

			/// <summary>
			/// Creates instance of type <see cref="OmnichannelMessageFileRepository"/>.
			/// </summary>
			/// <param name="userConnection">User connection.</param>
			public OmnichannelMessageFileRepository(UserConnection userConnection) : base(userConnection) {
			}

			#endregion

			#region Methods: Public

			/// <summary>
			/// Uploads file.
			/// </summary>
			/// <param name="fileUploadInfo">File upload information.</param>
			/// <param name="isSetCustomColumns">Is set custom columns.</param>
			/// <returns>Is operation successful.</returns>
			public override bool UploadFile(IFileUploadInfo fileUploadInfo, bool isSetCustomColumns) {
				var uploader = new OmnichannelMessageUploader(UserConnection);
				uploader.UploadFile(fileUploadInfo, isSetCustomColumns);
				return true;
			}

			#endregion
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection { get; }

		protected OmnichannelMessageFileRepository FileRepository { get; }

		private ILog _log;
		protected ILog Log
		{
			get
			{
				return _log ?? (_log = LogManager.GetLogger("OmnichannelMessageHandler"));
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="OmnichannelMessageFileLoader"/>. 
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public OmnichannelMessageFileLoader(UserConnection userConnection) {
			UserConnection = userConnection;
			FileRepository = new OmnichannelMessageFileRepository(userConnection);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Upload message attachment file.
		/// </summary>
		/// <param name="attachment">Message attachment.</param>
		/// <param name="ms">Stream of file content.</param>
		public void UploadFile(MessageAttachment attachment, MemoryStream ms) {
			Guid fileId = Guid.Parse(attachment.FileId);
			ms.Position = 0;
			var fileEntityInfo = new OmnichannelMessageUploadInfo("OmnichannelMessageFile", fileId, attachment);
			fileEntityInfo.TotalFileLength = attachment.FileSize > 0 ? attachment.FileSize : ms.Length;
			Log.Debug($"Total length of file with Id = {fileId} is {fileEntityInfo.TotalFileLength}. File size is {attachment.FileSize}.");
			fileEntityInfo.Content = ms;
			FileRepository.UploadFile(fileEntityInfo, true);
		}

		/// <summary>
		/// Checks is need to use file api.
		/// </summary>
		/// <returns>Is need to use file api.</returns>
		public bool IsFileApiEnabled() {
			return UserConnection.GetIsFeatureEnabled("UseFileApiInChats");
		}

		#endregion

	}

	#endregion

}
