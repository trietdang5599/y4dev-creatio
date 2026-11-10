namespace Terrasoft.MobileSyncSettings
{
    using System;
    using global::Common.Logging;
    using Newtonsoft.Json.Linq;
    using Terrasoft.Common;
    using Terrasoft.Configuration.DesignService;
    using Terrasoft.Core;
    using Terrasoft.Core.Entities;
    using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Packages.DependencyActualizer;
    using Terrasoft.Mobile;
    using Terrasoft.Nui.ServiceModel.WebService;

    #region Class: MobileSyncSettingsEventListener

    [EntityEventListener(SchemaName = "MobileSyncSett")]
    public class MobileSyncSettingsEventListener : BaseEntityEventListener
    {
        #region Properties: Private
        
        private const String DefaultManifestTemplate = "{\"CustomSchemas\":[],\"SyncOptions\": {\"ModelDataImportConfig\":[]},\"Modules\":{},\"Models\":{}}";

		private Guid _customPackageUId = new Guid("a00051f4-cde3-4f3f-b08e-c5ad1a5c735a");

        private ILog _log = LogManager.GetLogger("MobileSyncSettingsEventListener");
        
        #endregion

        #region Methods: Private

        private JToken GetModelDataImportConfig(JObject manifest) {
            JToken syncOptions = manifest["SyncOptions"];
            return syncOptions?["ModelDataImportConfig"];
        }

        private void SetImportConfigProperties(JToken modelDataImportConfig, String entityName, Boolean ignore,
                String filter) {
            JObject filterMap = GetFilterObject(filter);
            if (modelDataImportConfig != null) {
                bool found = false;
                foreach (JToken importConfig in modelDataImportConfig) {
                    if (importConfig is JValue && ((String)((JValue)importConfig).Value).Equals(entityName)) {
                        found = true;
                        JObject newImportConfig = new JObject {
                            ["Name"] = entityName,
                            ["Ignore"] = ignore
                        };
                        newImportConfig["QueryFilter"] = filterMap;
                        newImportConfig["SyncFilter"] = null;
                        importConfig.Replace(newImportConfig);
                        break;
                    }
                    if (importConfig.HasProperty("Name") && ((String)importConfig["Name"]).Equals(entityName)) {
                        found = true;
                        importConfig["Ignore"] = ignore;
                        importConfig["QueryFilter"] = filterMap;
                        importConfig["SyncFilter"] = null;
                        break;
                    }
                }
                if (!found) {
                    JArray items = (JArray)modelDataImportConfig;
                    JObject newImportConfig = new JObject {
                        ["Name"] = entityName,
                        ["Ignore"] = ignore,
                        ["QueryFilter"] = filterMap,
                        ["SyncFilter"] = null
                    };
                    items.Add(newImportConfig);
                }
            }
        }

        private JObject GetFilterObject(String filter) {
            JObject filterMap = null;
            try {
                filterMap = JObject.Parse(filter);
            } catch (Exception e) {
                _log.DebugFormat("There is a wrong filter string that can not be parsed as JObject: {0} Error: {1}",
                    filter, e.Message);
            }
            return filterMap;
        }

        private void CreateManifest(ISchemaManagerItem designItem) {
            var newSchema = (ClientUnitSchema)designItem.Instance;
            newSchema.Body = DefaultManifestTemplate;
        }

        private void ClearPreviousFilters(JObject manifest, String entityName) {
            if (manifest["Remove"] == null) {
                manifest["Remove"] = JObject.Parse("{\"SyncOptions\": {\"ModelDataImportConfig\":[]}}");
            } else if (manifest["Remove"]["SyncOptions"] == null) {
                manifest["Remove"]["SyncOptions"] = JObject.Parse("{\"ModelDataImportConfig\":[]}");
            } else if (manifest["Remove"]["SyncOptions"]["ModelDataImportConfig"] == null) {
                manifest["Remove"]["SyncOptions"]["ModelDataImportConfig"] = new JArray();
            }
            JToken removingModelDataImportConfig = GetModelDataImportConfig((JObject)manifest["Remove"]);
            bool found = false;
            foreach (JToken importConfig in removingModelDataImportConfig) {
                if (importConfig.HasProperty("Name") && ((String)importConfig["Name"]).Equals(entityName)) {
                    found = true;
                    importConfig["QueryFilter"] = null;
                }
            }
            if (!found) {
                JArray items = (JArray)removingModelDataImportConfig;
                JObject newImportConfig = new JObject {
                    ["Name"] = entityName,
                    ["QueryFilter"] = null
                };
                items.Add(newImportConfig);
            }
        }

        #endregion

        #region Methods: Public

        public virtual Guid GetCurrentPackageUId(UserConnection userConnection) {
            var schemaDesignerUtilities = new SchemaDesignerUtilities(userConnection);
            return schemaDesignerUtilities.ForceGetCurrentPackageUId();
        }

        public virtual void SaveManifest(UserConnection userConnection, ClientUnitSchema schema) {
            Guid schemaUId = schema.UId;
            Guid schemaId = schema.Id;
            Guid packageUId = schema.PackageUId;
            ClientUnitSchemaManager clientSchemaManager = userConnection.ClientUnitSchemaManager;
            clientSchemaManager.SaveDesignedItemIdInSessionData(userConnection, schemaUId, schemaId);
            clientSchemaManager.SaveDesignedItemPackageUIdInSessionData(userConnection, schemaUId, packageUId);
            clientSchemaManager.SaveDesignedItemInSessionData(userConnection, schema, schemaUId);
            clientSchemaManager.SaveSchema(schemaUId, true, userConnection);
        }

        public virtual ClientUnitSchema GetManifestSchema(UserConnection userConnection, string manifestName,
                Guid currentPackageId) {
            (Guid schemaUId, Guid schemaId) = DesignService.DesignServiceUtilities.GetSchemaUIdInPackage(userConnection,
                manifestName, currentPackageId);
            ISchemaManagerItem designItem;
            bool manifestExists = schemaUId != Guid.Empty;
            if (!manifestExists) {
                Guid rootManifestUId = new MobileUtilities(userConnection).GetRootManifestUId(manifestName);
                designItem =
                    userConnection.ClientUnitSchemaManager.CreateDesignSchema(userConnection, rootManifestUId,
                        currentPackageId, true);
                CreateManifest(designItem);
                return (ClientUnitSchema)designItem.Instance;
            } else {
                designItem = userConnection.ClientUnitSchemaManager.DesignItem(userConnection, schemaUId);
                designItem.Id = schemaId;
                var schema = (ClientUnitSchema)designItem.Instance;
                schema.Id = schemaId;
                return schema;
            }
        }

        /// <inheritdoc />
        public override void OnSaving(object sender, EntityBeforeEventArgs e) {
            base.OnSaving(sender, e);
            Entity entity = (Entity)sender;
            UserConnection userConnection = entity.UserConnection;
            string entityName = entity.GetTypedColumnValue<string>("EntityName");
            if (entityName == null) {
                return;
            }
            string workplaceCode = entity.GetTypedColumnValue<string>("WorkplaceCode") ?? "DefaultWorkplace";
            MobileUtilities mobileUtilities = new MobileUtilities(userConnection);
            String manifestName = mobileUtilities.GetManifestName(workplaceCode);
            Guid currentPackageId = GetCurrentPackageUId(userConnection);
            var schema = GetManifestSchema(userConnection, manifestName, currentPackageId);
            JObject manifest = JObject.Parse(schema.Body);
            ClearPreviousFilters(manifest, entityName);
            JToken modelDataImportConfig = GetModelDataImportConfig(manifest);
            Boolean isEnabled = entity.GetTypedColumnValue<Boolean>("IsEnabled");
            String filter = entity.GetTypedColumnValue<String>("FilterData");
            SetImportConfigProperties(modelDataImportConfig, entityName, !isEnabled, filter);
            schema.Body = manifest.ToString();
            SaveManifest(userConnection, schema);
            mobileUtilities.ClearMobileManifests();
            if (_customPackageUId.Equals(currentPackageId)) {
                IPackageElementDependencyHelper helper = ClassFactory.Get<IPackageElementDependencyHelper>();
                helper.AddClientUnitSchemaFullHierarchyDependenciesToPackage(new [] {schema.Name}, currentPackageId);
            }
        }

        #endregion

    }

    #endregion

}

