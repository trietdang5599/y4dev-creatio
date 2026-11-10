namespace Terrasoft.Core.Process
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Attributes;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.Web.Common;
	using Terrasoft.Web.Common.ServiceRouting;

	#region Class: GetCustomerSspServiceListMethodsWrapper

	/// <exclude/>
	public class GetCustomerSspServiceListMethodsWrapper : ProcessModel
	{

		public GetCustomerSspServiceListMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTaskExecute", ScriptTaskExecute);
		}

		#region Methods: Private

		private bool ScriptTaskExecute(ProcessExecutingContext context) {
			string webAppPath = AppDomain.CurrentDomain.BaseDirectory;
			string sspServicesDir = Path.Combine(webAppPath, "SspServices");
			string file = Path.Combine(sspServicesDir, "CustomerSspServiceList.txt");
			
			var userConnection = Get<UserConnection>("UserConnection");
			Terrasoft.Core.Configuration.SysWorkspace workspace = userConnection.Workspace;
			if (!workspace.IsWorkspaceAssemblyInitialized) {
				return true;
			}
			
			var collector = ClassFactory.Get<IWorkspaceAssemblyCollector>();
			var assemblies = collector.GetAssemblies(workspace, RefAssemblyMarker.ServiceRoutes);
			var loader = ClassFactory.Get<IAssemblyTypeLoader>();
			var types = loader.GetTypes(assemblies);
			var parser = new CustomServicesParser(types.ToList());
			var serviceNames = new HashSet<string>(parser.Services.Keys.Union(parser.WebServices.Keys));
			var repo = ClassFactory.Get<IServiceConfigRepository>();
			var customerServiceNames = serviceNames
				.Where(name => !repo.ContainsService(name, includeRestricted: true))
				.ToList();
			
			if (!customerServiceNames.Any()) {
				return true;
			}
			
			string header = $"# List of services appended on {DateTime.Now}";
			File.AppendAllLines(file, customerServiceNames.OrderBy(n => n).Prepend(header));
			return true;
		}

		#endregion

	}

	#endregion

}

