namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;

	#region Interface: IWebhookJobDispatcher

	/// <summary>
	/// Represents methods for jobs' management.
	/// </summary>
	public interface IWebhookJobDispatcher
	{

		#region Methods: Public

		/// <summary>
		/// Schedule next job for the specified webhooks batch.
		/// </summary>
		/// <param name="batchId">The unique identifier of batch.</param>
		void ScheduleJob(Guid batchId);

		/// <summary>
		/// Schedule jobs for the specified webhooks batches.
		/// </summary>
		/// <param name="batchIds"></param>
		void ScheduleJobs(List<Guid> batchIds);

		#endregion

	}

	#endregion

}

