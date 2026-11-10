namespace Terrasoft.Configuration
{
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;

	#region Class: ContactMLangBinder

	/// <summary>
	/// Contact multilanguage class binder.
	/// </summary>
	public class ContactMLangBinder : AppEventListenerBase
	{

		#region Methods: Public

		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			ClassFactory.Bind<ILanguageIterator, ContactLanguageIterator>("Contact");
		}

		#endregion

	}

	#endregion

}
