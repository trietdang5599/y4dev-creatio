namespace Terrasoft.Configuration
{
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;

	#region Class: EmailUserTaskMLangBinder

	/// <summary>
	/// Email template user task multilanguage class binder.
	/// </summary>
	public class EmailTemplateUserTaskMLangBinder: AppEventListenerBase
	{

		#region Methods: Public

		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			ClassFactory.Bind<ILanguageIterator, EmailTemplateUserTaskLanguageIterator>("EmailTemplateUserTask");
		}

		#endregion

	}

	#endregion

}
