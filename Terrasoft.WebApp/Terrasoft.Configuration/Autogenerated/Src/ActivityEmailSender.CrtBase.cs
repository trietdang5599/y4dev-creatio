namespace Terrasoft.Mail.Sender
{
	using System;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;

	#region Class: ActivityEmailSender

	/// <summary> Represents the sender class of the object's mail messages <see cref="Activity"/>.</summary>
	public class ActivityEmailSender : ActivityEmailSenderBase
	{

		#region Constructors : Public

		/// <summary><see cref="ActivityEmailSender"/> ctor.</summary>
		/// <param name="emailClientFactory">An instance of the mail client factory.</param>
		/// <param name="userConnection">An instance of the user connection.</param>
		public ActivityEmailSender(IEmailClientFactory emailClientFactory, UserConnection userConnection)
			: base(emailClientFactory, userConnection) {
		}

		#endregion

		#region Methods: Protected

		protected virtual Activity Send(Guid activityId, Activity sourceActivity, EmailMessage message,
				bool ignoreRights = false) =>
			(Activity)base.Send(activityId, sourceActivity, message, ignoreRights);

		protected virtual void CompleteSending(Activity activity) => base.CompleteSending(activity);

		#endregion

		#region Methods: Public

		public new Activity Send(Guid activityId) => (Activity)base.Send(activityId);

		#endregion

	}

	#endregion

}
