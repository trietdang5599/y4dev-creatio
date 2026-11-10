namespace Terrasoft.Mail.Sender
{
	using System;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;

	#region Class: ActivityEmailSenderExtensions

	public static class ActivityEmailSenderExtensions
	{
		public static Activity Send(this ActivityEmailSender source, Guid activityId)
			=> (Activity)source.Send(activityId);
	}

	#endregion

}
