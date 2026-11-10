/**
 * Parent: SubProcessPropertiesPage
 */
define("UserTaskPropertiesPage", ["terrasoft", "UserTaskPropertiesPageResources", "ProcessModuleUtilities"],
		function(Terrasoft, resources, Utilities) {
	return {
		properties: {
			/**
			 * @inheritdoc RootUserTaskPropertiesPage.properties#schemaManagerName
			 * @override
			 */
			schemaManagerName: "ProcessUserTaskSchemaManager"
		},
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc SubProcessPropertiesPage#initSchema
			 * @override
			 */
			initSchema: function(element, callback, scope) {
				this.on("change:Schema", this.onBeforeSchemaChanged, this);
				const schemaUId = element.schemaUId;
				if (Terrasoft.isEmpty(schemaUId)) {
					callback.call(scope);
					return;
				}
				this.getSchemaByUId(schemaUId, function(schema) {
					this.set("Schema", schema, {silent: true});
					callback.call(scope);
				}, this);
			},

			/**
			 * @inheritdoc SubProcessPropertiesPage#getSchemaListFilter
			 * @override
			 */
			getSchemaListFilter: function(callback) {
				this.callParent([function(filter) {
					const esq = new Terrasoft.EntitySchemaQuery("SysProcessUserTask");
					esq.addColumn("SysUserTaskSchemaUId");
					esq.getEntityCollection(function(result) {
						const collection = result.collection;
						if (collection && collection.getCount() > 0) {
							const excludedSchemas = filter.ExcludedSchemas;
							collection.each(function(row) {
								excludedSchemas.push(row.get("SysUserTaskSchemaUId"));
							}, this);
							callback(filter);
						}
					}, this);
				}]);
			},

			/**
			 * @inheritdoc SubProcessPropertiesPage#getSchemaList
			 * @override
			 */
			getSchemaList: function(callback, scope) {
				scope = scope || this;
				this.getSchemaListFilter(function(filter) {
					Utilities.getSchemasByFilter(filter, callback, scope);
				});
			},

			/**
			 * @inheritdoc SubProcessPropertiesPage#onOpenSchemaDesignerButtonClick
			 * @override
			 */
			onOpenSchemaDesignerButtonClick: function() {
				const schemaUId = this.get("Schema").value;
				Utilities.showUserTaskSchemaDesigner(schemaUId);
			},

			/**
			 * @inheritdoc SubProcessPropertiesPage#synchronizeParameters
			 * @override
			 */
			synchronizeParameters: function(processElement, userTaskSchema) {
				this.callParent(arguments);
				this.initIsAfterActivitySaveScriptEditVisible(userTaskSchema, Terrasoft.emptyFn, this);
			},

			/**
			 * @inheritdoc SubProcessPropertiesPage#getSchemaInstance
			 * @override
			 */
			getSubProcessSchemaInstance: function(schemaUId, callback, scope) {
				if (Terrasoft.isEmpty(schemaUId)) {
					Ext.callback(callback, scope);
				} else {
					Terrasoft.ProcessUserTaskSchemaManager.forceGetInstanceByUId(schemaUId, callback, scope);
				}
			}

			//endregion
		},
		diff: /**SCHEMA_DIFF*/[
			{
			"operation": "merge",
			"name": "OpenSchemaDesignerButton",
			"values": {
					"hint": {"bindTo": "Resources.Strings.OpenSchemaButtonHintCaption"},
					"imageConfig": {"bindTo": "Resources.Images.OpenButtonImage"},
					"enabled": {"bindTo": "Schema"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
