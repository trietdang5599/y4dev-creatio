namespace Terrasoft.Configuration.Reporting.WordReporting
{
	using Terrasoft.Common;
	using Terrasoft.Configuration.Reporting.Word.Worker;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;

	#region Class: WordReportingAppEventListener

	public class WordReportingAppEventListener : AppEventListenerBase
	{

		#region Properties: Private

		private UserConnection UserConnection => ClassFactory.Get<UserConnection>();

		#endregion

		#region Public: Methods

		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			ClassFactory.Bind<IWordReportDesignWorker>(() => new WordReportingDesignWorker(UserConnection));
		}

		#endregion

	}

	#endregion

}

