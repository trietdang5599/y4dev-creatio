namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Creatio.Copilot.Designer.Commands;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;

	#region Class: MigrateRetiredLlmModelsInstallScript

	public class MigrateRetiredLlmModelsInstallScript : IInstallScriptExecutor
	{

		#region Class: ModelMigration

		private sealed class ModelMigration
		{

			#region Constructors: Public

			public ModelMigration(string retiredCode, string replacementCode, bool removeRetiredLookupRow) {
				RetiredCode = retiredCode;
				ReplacementCode = replacementCode;
				RemoveRetiredLookupRow = removeRetiredLookupRow;
			}

			#endregion

			#region Properties: Public

			public string RetiredCode { get; }

			public string ReplacementCode { get; }

			/// <summary>When true, the retired code's <c>LlmModel</c> lookup row is deleted after
			/// every schema has been migrated off it. Set to false if the retired code should
			/// linger in the lookup for backward-compatibility reasons</summary>
			public bool RemoveRetiredLookupRow { get; }

			#endregion

		}

		#endregion

		#region Fields: Private

		/// <summary>ENG-87801 and future model retirements add one entry per retired model</summary>
		private static readonly IReadOnlyList<ModelMigration> _migrations = new[] {
			new ModelMigration("gpt-4o-creatio", "gpt-5.2-creatio", removeRetiredLookupRow: true)
		};

		#endregion

		#region Methods: Public

		public void Execute(UserConnection userConnection) {
			foreach (ModelMigration migration in _migrations) {
				bool retiredCodeNoLongerUsed =
					new MigrateIntentLlmModelCommand(userConnection, migration.RetiredCode,
						migration.ReplacementCode).Execute();
				if (migration.RemoveRetiredLookupRow && retiredCodeNoLongerUsed) {
					new Delete(userConnection)
						.From("LlmModel")
						.Where("Code").IsEqual(Column.Parameter(migration.RetiredCode))
						.Execute();
				}
			}
		}

		#endregion

	}

	#endregion

}

