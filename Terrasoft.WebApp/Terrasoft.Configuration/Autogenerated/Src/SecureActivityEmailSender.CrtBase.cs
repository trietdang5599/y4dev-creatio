namespace Terrasoft.Mail.Sender
{
	using System;
	using System.Text.RegularExpressions;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;

	#region Class: SecureActivityEmailSender

	[Obsolete("Use SecureActivityEmailSenderBase class. The current class is left for backward compatibility")]
	public class SecureActivityEmailSender : ActivityEmailSender
	{

		#region Fields: Private

		private readonly SecureActivityEmailSenderBase _baseSender;

		#endregion
		
		#region Properties: Protected

		/// <summary>
		/// Work with security token.
		/// instance of the <see cref="SecurityTokenUtilities"/> class
		/// </summary>
		protected SecurityTokenUtilities SecurityTokenUtilities	{
			get; set;
		}

		/// <summary>
		/// Email body with replaced token.
		/// </summary>
		protected string EmailBody {
			get; set;
		}

		#endregion
		
		#region Constructors: Public

		/// <summary><see cref="ActivityEmailSender"/> ctor.</summary>
		/// <param name="emailClientFactory">An instance of the mail client factory.</param>
		/// <param name="userConnection">An instance of the user connection.</param>
		public SecureActivityEmailSender(IEmailClientFactory emailClientFactory, UserConnection userConnection)
			: base(emailClientFactory, userConnection) {
			_baseSender = new SecureActivityEmailSenderBase(emailClientFactory, userConnection);
			SecurityTokenUtilities = new SecurityTokenUtilities(userConnection);
		}

		#endregion
		
		#region Methods: Protected

		/// <summary>
		/// Replace token parameters to token.
		/// </summary>
		/// <param name="text">Text which may have token parameters.</param>
		protected virtual string ReplaceParametersToToken(string text) {
			string pattern = @"\[\?([^\]]*)\?\]";
			var matches = Regex.Matches(text, pattern);
			var result = text;
			foreach (Match match in matches) {
				var tokenItemParams = match.Groups[1].Value;
				var token = SecurityTokenUtilities.CreateToken(System.Text.Encoding.UTF8.GetBytes(tokenItemParams));
				result = text.Replace(match.Value, token);
			}
			return result;
		}

		/// <inheritdoc />
		protected override void SetActivityColumnValues(Entity entity) {
			base.SetActivityColumnValues(entity);
			if (EmailBody.IsNotNullOrEmpty()) {
				entity.SetColumnValue("MailHash", 
					ActivityUtils.GetEmailHash(
						UserConnection,
						entity.SafeGetColumnValue<DateTime>("SendDate"),
						entity.SafeGetColumnValue<string>("Title"),
						EmailBody,
						UserConnection.CurrentUser.TimeZone));
			}
		}

		#endregion
		
		
		#region Methods: Public

		/// <summary>
		/// Send e-mail message..
		/// </summary>
		/// <param name="message">E-mail message</param>
		/// <param name="isHtml">Flag that indicates whether that message written in html format.</param>
		/// <param name="ignoreRights">Flag that indicates whether to ignore rights.</param>
		public override void Send(EmailMessage message, bool isHtml, bool ignoreRights) {
			message.Body = ReplaceParametersToToken(message.Body);
			EmailBody = message.Body;
			base.Send(message, ignoreRights);
		}

		#endregion

	}

	#endregion

}
