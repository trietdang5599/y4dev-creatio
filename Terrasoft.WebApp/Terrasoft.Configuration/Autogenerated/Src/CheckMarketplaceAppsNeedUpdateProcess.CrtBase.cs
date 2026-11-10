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
	using Terrasoft.Core.Applications.Abstractions.Marketplace;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: CheckMarketplaceAppsNeedUpdateProcessMethodsWrapper

	/// <exclude/>
	public class CheckMarketplaceAppsNeedUpdateProcessMethodsWrapper : ProcessModel
	{

		public CheckMarketplaceAppsNeedUpdateProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ResolveAppsDuplicatesScriptTaskExecute", ResolveAppsDuplicatesScriptTaskExecute);
			AddScriptTaskMethod("CheckFeatureScriptTaskExecute", CheckFeatureScriptTaskExecute);
			AddScriptTaskMethod("SetRandomDelayValueScriptTaskExecute", SetRandomDelayValueScriptTaskExecute);
			AddScriptTaskMethod("SetsAppsWithNewUpdateAvailableExecute", SetsAppsWithNewUpdateAvailableExecute);
		}

		#region Methods: Private

		private bool ResolveAppsDuplicatesScriptTaskExecute(ProcessExecutingContext context) {
			var duplicateResolver = ClassFactory.Get<IInstalledMarketplaceAppsDuplicateResolver>();
			duplicateResolver.ResolveAppsDuplicates();
			return true;
		}

		private bool CheckFeatureScriptTaskExecute(ProcessExecutingContext context) {
			bool checkApplicationUpdatesFeatureValue = Features.GetIsEnabled("AppsFeatures.CheckApplicationUpdates");
			Set("CheckApplicationUpdates", checkApplicationUpdatesFeatureValue);
			return true;
		}

		private bool SetRandomDelayValueScriptTaskExecute(ProcessExecutingContext context) {
			Set("DelayBeforeStarting", new Random().Next(0, Get<int>("DelayMaxValue")));
			return true;
		}

		private bool SetsAppsWithNewUpdateAvailableExecute(ProcessExecutingContext context) {
			SetAppsWithNewUpdateAvailable(
				Get<ICompositeObjectList<ICompositeObject>>("ReadAppsWithAvailableUpdatesBeforeCheck.ResultCompositeObjectList"),
				Get<ICompositeObjectList<ICompositeObject>>("ReadAppsWithAvailableUpdatesAfterCheck.ResultCompositeObjectList"));
			return true;
		}

			private void SetAppsWithNewUpdateAvailable(ICompositeObjectList<ICompositeObject> appsWithUpdateAvailableBeforeCheck,
					ICompositeObjectList<ICompositeObject> appsWithUpdateAvailableAfterCheck) {
				IEnumerable<CompositeObject> newUpdateAvailable = appsWithUpdateAvailableAfterCheck
					.Where(appAfter => {
						appAfter.TryGetValue("Id", out Guid appAfterId);
						return !appsWithUpdateAvailableBeforeCheck.Any(appBefore => {
							appBefore.TryGetValue<Guid>("Id", out Guid appBeforeId);
							return appAfterId == appBeforeId;
						});
					})
					.Select(appAfter => (CompositeObject)appAfter);
				Set("AppsToNotifyAboutUpdateAvailable", new CompositeObjectList<CompositeObject>(newUpdateAvailable));
			}

		#endregion

	}

	#endregion

}

