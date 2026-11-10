Terrasoft.configuration.Structures["SysProcessEntityDetailV2"] = {innerHierarchyStack: ["SysProcessEntityDetailV2"], structureParent: "BaseGridDetailV2"};
define('SysProcessEntityDetailV2Structure', ['SysProcessEntityDetailV2Resources'], function(resources) {return {schemaUId:'5774be56-04b9-4471-a60e-ea26e7781ff0',schemaCaption: "SysProcessEntityDetailV2", parentSchemaName: "BaseGridDetailV2", packageName: "CrtUIv2", schemaName:'SysProcessEntityDetailV2',parentSchemaUId:'01eb38ee-668a-42f0-999d-c2534f979089',extendParent:false,type:Terrasoft.SchemaType.GRID_DETAIL_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("SysProcessEntityDetailV2", ["terrasoft", "ModuleUtils"],
	function() {
		return {
			entitySchemaName: "VwSysProcessEntity",
			attributes: {},
			methods: {

				/**
				 * @inheritdoc BaseGridDetailV2#addRecordOperationsMenuItems
				 * @overridden
				 */
				addRecordOperationsMenuItems: this.Terrasoft.emptyFn,

				/**
				 * @inheritdoc BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: this.Terrasoft.emptyFn,

				/**
				 * @inheritdoc BaseGridDetailV2#getSwitchGridModeMenuItem
				 * @overridden
				 */
				getSwitchGridModeMenuItem: this.Terrasoft.emptyFn,

				/**
				 * @inheritdoc GridUtilitiesV2#linkClicked
				 * @overridden
				 */
				linkClicked: this.Terrasoft.emptyFn,

				/**
				 * @inheritdoc BaseDetailV2#initDetailOptions
				 * @overridden
				 */
				initDetailOptions: function() {
					this.set("IsDetailCollapsed", true);
					this.callParent();
				},

				/**
				 * @inheritdoc GridUtilitiesV2#getGridDataColumns
				 * @overridden
				 */
				getGridDataColumns: function() {
					const config = this.callParent();
					const columns = ["EntityId", "ReferenceSchemaName"];
					Terrasoft.each(columns, function(column) {
						config[column] = {path: column};
					}, this);
					return config;
				},

				/**
				 * @private
				 */
				_createEntityDisplayValueLink: function(item, referenceSchemaName, displayValueColumnPath,
						idColumnPath) {
					const recordId = item.get(idColumnPath);
					const displayValue = item.get(displayValueColumnPath);
					if (!(recordId && displayValue)) {
						return "";
					}
					if (Terrasoft.Features.getIsEnabled("ProcessLog.DisableAdvancedEntityDisplayValueLink")) {
						return this.createLink(referenceSchemaName, displayValueColumnPath, displayValue, recordId);
					}
					return this.mixins.GridUtilities.createLink.call(item, referenceSchemaName, displayValueColumnPath,
						displayValue, recordId);
				},

				/**
				 * @private
				 */
				_setEntityAttributeValues: function(queryResult, row) {
					const resultRow = queryResult.rows[0];
					const displayColumnPath = this.entitySchema.primaryDisplayColumnName;
					row.set("RecordNotFound", !resultRow);
					if (!resultRow) {
						row.set(displayColumnPath, this.get("Resources.Strings.ReferenceEntityNotFound"));
						return;
					}
					if (row.get("EntityId") !== resultRow.Id) {
						return;
					}
					const rowTitle = resultRow.Name ? resultRow.Name : Terrasoft.formatGUID(resultRow.Id, "B");
					row.set(displayColumnPath, rowTitle);
					const referenceSchemaName = row.get("ReferenceSchemaName");
					const typeColumnPath = Terrasoft.ModuleUtils.getTypeColumn(referenceSchemaName)?.path;
					if (typeColumnPath && resultRow[typeColumnPath]) {
						row.set(typeColumnPath, resultRow[typeColumnPath]);
					} 
				},

				/**
				 * @private
				 */
				_getSchemaNamesBatchQuery: function(items, callback, scope) {
					const batchQuery = Ext.create("Terrasoft.BatchQuery");
					const chainArguments = [];
					items.each(function(item) {
						chainArguments.push(function(next) {
							const referenceSchemaName = item.get("ReferenceSchemaName");
							this.getEntitySchemaByName(referenceSchemaName, function(schema) {
								const entityId = item.get("EntityId");
								const esq = this._getEntityAttributesESQ(schema, entityId);
								batchQuery.add(esq);
								next();
							});
						});
					}, this);
					chainArguments.push(function() {
						callback.call(scope, batchQuery);
					});
					Terrasoft.chain.apply(this, chainArguments);
				},

				/**
				 * @private
				 */
				_getEntityAttributesESQ: function(schema, entityId) {
					const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchemaName: schema.name
					});
					if (schema.primaryDisplayColumn) {
						esq.addColumn(schema.primaryDisplayColumn.name, "Name");
					}
					const typeColumnPath = Terrasoft.ModuleUtils.getTypeColumn(schema.name)?.path;
					if (typeColumnPath) {
						esq.addColumn(typeColumnPath);
					}
					const filter = esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL, "Id", entityId);
					esq.filters.add(filter);
					return esq;
				},

				/**
				 * @inheritdoc GridUtilitiesV2#updateLoadedGridData
				 * @overridden
				 */
				updateLoadedGridData: function(response, callback, scope) {
					const rows = response.collection;
					this._getSchemaNamesBatchQuery(rows, function(batchQuery) {
						batchQuery.execute(function(result) {
							if (result.queryResults) {
								Terrasoft.each(result.queryResults, function(queryResult, queryResultIndex) {
									const row = rows.getByIndex(queryResultIndex);
									scope._setEntityAttributeValues(queryResult, row);
								});
							}
							callback.call(scope, response);
						}, this);
					}, this);
				},

				/**
				 * @inheritdoc GridUtilitiesV2#addColumnLink
				 * @overridden
				 */
				addColumnLink: function(item, column) {
					if (item.get("RecordNotFound")){
						return;
					}
					const columnPath = column.columnPath;
					if (columnPath !== "EntityDisplayValue") {
						this.callParent(arguments);
						return;
					}
					const onColumnLinkClickHandler = "on" + columnPath + "LinkClick";
					const referenceSchemaName = item.get("ReferenceSchemaName");
					const entitySchemaConfig = Terrasoft.configuration.ModuleStructure[referenceSchemaName];
					const scope = this;
					if (entitySchemaConfig) {
						item[onColumnLinkClickHandler] = function() {
							return scope._createEntityDisplayValueLink(item, referenceSchemaName, columnPath,
								"EntityId");
						};
					}
				},
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "listed",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "EntityDisplayValueListedGridColumn",
									"bindTo": "EntityDisplayValue",
									"position": {
										"column": 1,
										"colSpan": 12
									}
								},
								{
									"name": "SysSchemaListedGridColumn",
									"bindTo": "SysSchema",
									"position": {
										"column": 13,
										"colSpan": 12
									}
								}
							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": {
								"columns": 24,
								"rows": 3
							},
							"items": [
								{
									"name": "EntityDisplayValueTiledGridColumn",
									"bindTo": "EntityDisplayValue",
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 12
									}
								},
								{
									"name": "SysSchemaTiledGridColumn",
									"bindTo": "SysSchema",
									"position": {
										"row": 1,
										"column": 13,
										"colSpan": 12
									}
								}
							]
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);


