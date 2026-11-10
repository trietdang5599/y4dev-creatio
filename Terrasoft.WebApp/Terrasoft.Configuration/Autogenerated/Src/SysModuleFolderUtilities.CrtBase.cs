namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Store;

	public static class SysModuleFolderUtilities
	{
		public static class CacheItemNames
		{
			public static string SysModulesPattern {
				get {
					return "CreateModuleFolderTab_{0}";
				}
			}
			
			public static string SysModuleActionsPattern {
				get {
					return "SysModuleActions_{0}";
				}
			}
		}

		public static void ResetWorkspacesCache(ICacheStore cacheStore) {
			cacheStore.Remove(Terrasoft.Configuration.CacheUtilities.WorkspaceCacheGroup);
		}

		public static void ResetModulesCache(Guid sysModuleFolderId, ICacheStore cacheStore) {
			var cacheItemName = string.Format(CacheItemNames.SysModulesPattern, sysModuleFolderId);
			cacheStore.Remove(cacheItemName);
		}
		
		public static void ResetSysModuleActionCache(Guid sysModuleId, ICacheStore cacheStore) {
			var cacheItemName = string.Format(CacheItemNames.SysModuleActionsPattern, sysModuleId);
			cacheStore.Remove(cacheItemName);
		}
		
		public static void ResetAnalyticsReportCache(ICacheStore cacheStore) {
			cacheStore.Remove(Terrasoft.Configuration.CacheUtilities.AnalyticsReportCache);
		}
		
		public static void ResetModuleReportCache(ICacheStore cacheStore) {
			cacheStore.Remove(Terrasoft.Configuration.CacheUtilities.ReportsCache);
		}
	}
}

