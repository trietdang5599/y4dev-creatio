using Terrasoft.Core.Configuration;
 using Terrasoft.Core.Security;

 namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Packages;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.UserLevel;
	using Terrasoft.Core.Feature;
	using Creatio.FeatureToggling;

	#region Class: SysFreedomDashboardQueryExecutor

	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "SysFreedomDashboardQueryExecutor")]
	public class SysFreedomDashboardQueryExecutor : IEntityQueryExecutor
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly ISchemaManagerItemsRightsFilter _schemaManagerItemsRightsFilter;

		#endregion

		#region Constructors: Public

		public SysFreedomDashboardQueryExecutor(UserConnection userConnection) {
			_userConnection = userConnection;
			_schemaManagerItemsRightsFilter = ClassFactory.Get<ISchemaManagerItemsRightsFilter>();
		}

		#endregion

		#region Methods: Private

		private EntitySchemaQueryFilter FindColumnFilter(EntitySchemaQueryFilterCollection filters, string schemaName,
				string columnName) {
			foreach (var filterItem in filters.OfType<IEntitySchemaQueryFilterItem>()) {
				if (filterItem is EntitySchemaQueryFilterCollection subFilters) {
					var result = FindColumnFilter(subFilters, schemaName, columnName);
					if (result != null) {
						return result;
					}
				}
				if (filterItem is EntitySchemaQueryFilter filter &&
						filter.LeftExpression?.ExpressionType == EntitySchemaQueryExpressionType.SchemaColumn &&
							filter.LeftExpression?.SchemaColumn?.ParentMetaSchema.Name == schemaName &&
								filter.LeftExpression?.SchemaColumn?.Name == columnName) {
					return filter;
				}
			}
			return null;
		}

		private IEnumerable<ISchemaManagerItem<ClientUnitSchema>> GetFilteredItems(
				IEnumerable<ISchemaManagerItem<ClientUnitSchema>> items, EntitySchemaQueryFilterCollection filters,
				string entitySchemaName) {
			var dashboardsElementNameFilter = FindColumnFilter(filters, entitySchemaName, "DashboardsElementName");
			var clientUnitSchemaUIdFilter =
				FindColumnFilter(filters, entitySchemaName, "DashboardsClientUnitSchemaUId");
			return items.Where(item => {
				var group = item.ExtraProperties.GetByName("Group")?.GetValue(string.Empty);
				if (group == "DashboardPage") {
					var optionalProperties = item.ExtraProperties.GetByName("OptionalProperties")
						?.GetValue(new Dictionary<string, object>());
					var dashboardsElementName = dashboardsElementNameFilter?.RightExpressions?.FirstOrDefault()
						?.ParameterValue?.ToString();
					if (optionalProperties.ContainsKey("DashboardsElementName") &&
					    optionalProperties["DashboardsElementName"]?.ToString() == dashboardsElementName)
					{
						var dashboardsClientUnitSchemaUId =
							clientUnitSchemaUIdFilter?.RightExpressions?.FirstOrDefault()
								?.ParameterValue?.ToString();
						if (optionalProperties.ContainsKey("DashboardsClientUnitSchemaUId") &&
						    optionalProperties["DashboardsClientUnitSchemaUId"]?.ToString() ==
						    dashboardsClientUnitSchemaUId)
						{
							return true;
						}
						if (optionalProperties.ContainsKey("DashboardsClientUnitSchemaName"))
						{
							var dashboardsClientUnitSchemaName =
								optionalProperties["DashboardsClientUnitSchemaName"]?.ToString();
							var uId = _userConnection.ClientUnitSchemaManager
								.GetItemByName(dashboardsClientUnitSchemaName)
								?.UId.ToString();
							if (dashboardsClientUnitSchemaUId == uId)
							{
								return true;
							}
						}
					}
				}
				return false;
			});
		}

		private void AddUserLevelSchemaItems(EntityCollection collection,
				IEnumerable<ISchemaManagerItem<ClientUnitSchema>> availableUserLeveItems, EntitySchema entitySchema) {
			foreach (var item in availableUserLeveItems) {
				var entity = entitySchema.CreateEntity(_userConnection);
				entity.SetColumnValue("Id", item.RealUId);
				entity.SetColumnValue("UId", item.UId);
				entity.SetColumnValue("Name", item.Caption);
				entity.SetColumnValue("Code", item.Name);
				entity.SetColumnValue("ExtendParent", item.ExtendParent);
				entity.SetColumnValue("PackageUId", item.PackageUId);
				entity.SetColumnValue("UserLevelSchema", true);
				collection.Add(entity);
			}
		}

		#endregion

		#region Methods: Public

		public virtual int GetPackagePosition(UserConnection userConnection, Guid packageUId) {
			IDictionary<Guid, int> positions =
				WorkspaceUtilities.GetTopologyPackagePositions(userConnection, userConnection.Workspace.Id);
			return DictionaryUtilities.GetValueOrDefault(positions, packageUId, int.MaxValue);
		}

		public EntityCollection GetEntityCollection(EntitySchemaQuery esq) {
			var entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName("SysFreedomDashboard");
			var collection = new EntityCollection(_userConnection, entitySchema);
			var packageUIdFilter = FindColumnFilter(esq.Filters, entitySchema.Name, "PackageUId");
			var schemaManager = _userConnection.ClientUnitSchemaManager;
			var allowedPosition = int.MaxValue;
			if (packageUIdFilter != null) {
				var packageUId = packageUIdFilter?.RightExpressions?.FirstOrDefault()?.ParameterValue?.ToString();
				allowedPosition = GetPackagePosition(_userConnection, Guid.Parse(packageUId));
			}
			bool userLevelSchemaFeature = Features.GetIsEnabled<UseUserLevelSchema>();
			var userLevelSchemaFilter = FindColumnFilter(esq.Filters, entitySchema.Name, "UserLevelSchema");
			var userLevelSchemaFilterValue = bool.TryParse(userLevelSchemaFilter?.RightExpressions?.FirstOrDefault()?.ParameterValue?.ToString(), out var userLevelSchemaFilterOutValue) && userLevelSchemaFilterOutValue;
			bool useUserLevelSchema = userLevelSchemaFeature && userLevelSchemaFilterValue;
			if (useUserLevelSchema) {
				var userLevelSchemaManager = ClassFactory.Get<IUserLevelSchemaManager<ClientUnitSchema>>();
				IEnumerable<ISchemaManagerItem<ClientUnitSchema>> availableUserLeveItems =
					GetFilteredItems(userLevelSchemaManager.GetItems(_userConnection.CurrentUser.Id), esq.Filters, entitySchema.Name);
				var filteredUserLevelItems = 
					_schemaManagerItemsRightsFilter.ApplyRights(availableUserLeveItems, _userConnection.CurrentUser.Id,
						new RightsFilterOptions {
							Operation = EntitySchemaRecordRightOperation.Read,
							AdminUnitRoleSources = esq.AdminUnitRoleSources
						});
				AddUserLevelSchemaItems(collection, filteredUserLevelItems, entitySchema);
			}
			IEnumerable<ISchemaManagerItem<ClientUnitSchema>> availableItems = GetFilteredItems(schemaManager.GetItems(),
				esq.Filters, entitySchema.Name);
			var filteredItems =
				_schemaManagerItemsRightsFilter.ApplyRights(availableItems, _userConnection.CurrentUser.Id, 
					new RightsFilterOptions {
						Operation = EntitySchemaRecordRightOperation.Read,
						AdminUnitRoleSources = esq.AdminUnitRoleSources
					});
			foreach (var item in filteredItems) {
				var entity = entitySchema.CreateEntity(_userConnection);
				var itemsHierarchy = schemaManager.GetItemHierarchy(item.UId)
					.Where(itm => itm.PackagePosition <= allowedPosition);
				var allowedItems = GetFilteredItems(itemsHierarchy,
					esq.Filters, entitySchema.Name).ToList();
				if (allowedItems.IsEmpty()) {
					continue;
				}
				var lastItemInHierarchy = allowedItems.Last();
				if (useUserLevelSchema) {
					if (collection.Any(x => x.GetTypedColumnValue<string>("Code") == lastItemInHierarchy.Name)) {
						continue;
					}
				}
				var optionalProperties = item.ExtraProperties.GetByName("OptionalProperties")
						?.GetValue(new Dictionary<string, object>()); 
				var dashboardsEntitySchemaName = optionalProperties.ContainsKey("DashboardsEntitySchemaName") ?
						(optionalProperties["DashboardsEntitySchemaName"]?.ToString() ?? null) : null;
				entity.SetColumnValue("Id", lastItemInHierarchy.RealUId);
				entity.SetColumnValue("UId", lastItemInHierarchy.UId);
				entity.SetColumnValue("Name", lastItemInHierarchy.Caption);
				entity.SetColumnValue("Code", lastItemInHierarchy.Name);
				entity.SetColumnValue("ExtendParent", item.ExtendParent);
				entity.SetColumnValue("PackageUId", item.PackageUId);
				entity.SetColumnValue("DashboardsEntitySchemaName", dashboardsEntitySchemaName);
				entity.SetColumnValue("UserLevelSchema", false);
				collection.Add(entity);
			}
			collection.Order("Name", OrderDirection.Ascending);
			return collection;
		}

		#endregion

	}

	#endregion

}
