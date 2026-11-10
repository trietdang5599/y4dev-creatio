namespace Terrasoft.Core.Process
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Configuration.RelationshipDesigner;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: MigratingDataToRelationshipDesignerProcessMethodsWrapper

	/// <exclude/>
	public class MigratingDataToRelationshipDesignerProcessMethodsWrapper : ProcessModel
	{

		public MigratingDataToRelationshipDesignerProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			MigrationData();
			return true;
		}

			public void MigrationData() {
				var userConnection = Get<UserConnection>("UserConnection");
				var relationshipDesignerDataMigrator = ClassFactory.Get<RelationshipDesignerDataMigrator>(
								new ConstructorArgument("userConnection", userConnection));;
				relationshipDesignerDataMigrator.StartMigration();
				
			}

		#endregion

	}

	#endregion

}

