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
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.Web.Security.CustomHttpHeader;

	#region Class: SysHttpHeader_ClearCacheMethodsWrapper

	/// <exclude/>
	public class SysHttpHeader_ClearCacheMethodsWrapper : ProcessModel
	{

		public SysHttpHeader_ClearCacheMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ClearCacheExecute", ClearCacheExecute);
		}

		#region Methods: Private

		private bool ClearCacheExecute(ProcessExecutingContext context) {
			var userConnection = this.Get<UserConnection>("UserConnection");
			var repositoryCache = ClassFactory.Get<IHttpHeaderRepositoryCache>(new ConstructorArgument("userConnection", userConnection));
			repositoryCache.ClearCache();
			return true;
		}

		#endregion

	}

	#endregion

}

