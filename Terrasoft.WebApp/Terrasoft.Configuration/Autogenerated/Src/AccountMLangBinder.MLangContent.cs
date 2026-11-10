namespace Terrasoft.Configuration
{
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;

	#region Class: AccountMLangBinder

	/// <summary>
	/// Account multilanguage class binder.
	/// </summary>
	public class AccountMLangBinder : AppEventListenerBase
	{

		#region Methods: Public

		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			ClassFactory.Bind<ILanguageIterator, AccountLanguageIterator>("Account");
		}

		#endregion

	}

	#endregion

}
