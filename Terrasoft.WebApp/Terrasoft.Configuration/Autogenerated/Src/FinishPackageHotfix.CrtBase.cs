namespace Terrasoft.Core.Process
{

	using Creatio.FeatureToggling;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Packages;
	using Terrasoft.Core.Packages.Editability;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: FinishPackageHotfixMethodsWrapper

	/// <exclude/>
	public class FinishPackageHotfixMethodsWrapper : ProcessModel
	{

		public FinishPackageHotfixMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("CheckFeatureTaskExecute", CheckFeatureTaskExecute);
			AddScriptTaskMethod("CallEditabilityMutatorTaskExecute", CallEditabilityMutatorTaskExecute);
		}

		#region Methods: Private

		private bool CheckFeatureTaskExecute(ProcessExecutingContext context) {
			bool isEnabled = Features.GetIsEnabled<PackageFeatures.AllowPackageHotfixMode>();
			Set("IsAllowedPackageHotfixMode", isEnabled);
			return true;
		}

		private bool CallEditabilityMutatorTaskExecute(ProcessExecutingContext context) {
			IEnumerable<Guid> packageUIds = GetPackageUIdsToFinishHotfix();
			IPackageEditabilityMutator mutator = ClassFactory.Get<IPackageEditabilityMutator>();
			mutator.FinishHotfixWhereStarted(packageUIds);
			return true;
		}

			private IEnumerable<Guid> GetPackageUIdsToFinishHotfix() {
				EntitySchemaQuery esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysPackageHotfixInfo");
				esq.AddColumn("Package.UId").Name = "PackageUId";
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Less, "EndDate", DateTime.UtcNow));
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsUnderHotfix", true));
				return esq.GetEntityCollection(UserConnection).Select(u => u.GetTypedColumnValue<Guid>("PackageUId"));
			}

		#endregion

	}

	#endregion

}

