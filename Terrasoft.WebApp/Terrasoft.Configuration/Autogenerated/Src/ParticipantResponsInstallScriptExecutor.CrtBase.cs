namespace Terrasoft.Configuration
{
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;

	#region Class: ParticipantResponsInstallScriptExecutor

	internal class ParticipantResponsInstallScriptExecutor : IInstallScriptExecutor
	{

		#region Methods: Public

		public void Execute(UserConnection userConnection) {
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			Entity participantResponse = entitySchemaManager.GetEntityByName("ParticipantResponse", userConnection);
			if (participantResponse.FetchFromDB(ActivityConsts.ParticipantResponseInDoubtId)) {
				var participantResponseName = new LocalizableString();
				var enCulture = new CultureInfo("en-US");
				participantResponseName.SetCultureValue(enCulture, "Tentative");
				participantResponse.SetColumnValue("Name", participantResponseName);
				participantResponse.Save();
			}
		}

		#endregion

	}

	#endregion

}

