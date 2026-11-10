Terrasoft.configuration.Structures["ProcessParameterSelectionPage"] = {innerHierarchyStack: ["ProcessParameterSelectionPage"], structureParent: "ProcessMappingPage"};
define('ProcessParameterSelectionPageStructure', ['ProcessParameterSelectionPageResources'], function(resources) {return {schemaUId:'b8040a33-ad4a-4d41-b557-661d32347255',schemaCaption: "ProcessParameterSelectionPage", parentSchemaName: "ProcessMappingPage", packageName: "CrtProcessDesigner", schemaName:'ProcessParameterSelectionPage',parentSchemaUId:'04752e37-8cdc-40a6-8f73-0efec22738e1',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
/**
 * Parent: ProcessMappingPage
 */
define("ProcessParameterSelectionPage", ["terrasoft", "ProcessParameterSelectionPageResources", "MappingEnums"],
	function(Terrasoft) {
		return {
			attributes: {

				/**
				 * Indicates if return value needs conversion to display value.
				 * @protected
				 * @type {Boolean}
				 */
				"ConvertToDisplayValue": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				},

				/**
				 * Determines whether the save button should be active or not.
				 */
				"IsSaveButtonActive": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				}
			},
			messages: {

				/**
				 * @message SetParametersInfo
				 * Passes parameters data.
				 */
				"SetParametersInfo": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message GetSelectedProcessParameter
				 * Returns selected process parameter.
				 */
				"GetSelectedProcessParameter": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message GetParameterMappingInfo
				 * Returns the parameter mapping data.
				 */
				"GetParameterMappingInfo": {
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE,
					mode: Terrasoft.MessageMode.PTP
				}
			},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			methods: {

				/**
				 *  Inits mapping type parameter if it is null.
				 *  @private
				 */
				subscribeGetParameterMappingInfo: function(viewModel) {
					const tabName = viewModel.get("Name");
					const sandbox = this.sandbox;
					const pageId = sandbox.id + tabName;
					sandbox.subscribe("GetParameterMappingInfo", function() {
						return {
							schemaElementUId: this.get("SchemaElementUId"),
							parameterUId: this.get("ParameterUId"),
							entityColumnUId: this.get("EntityColumnUId")
						};
					}, this, [pageId]);
				},

				/**
				 * Returns default active tab name.
				 * @protected
				 * return {String}
				 */
				getDefActiveTabName: function() {
					let tabName = "TabElementsMapping";
					const mappingType = this.get("MappingType");
					if (mappingType === Terrasoft.MappingEnums.MappingType.LOOKUP) {
						tabName = "TabValueMapping";
					} else if (mappingType === Terrasoft.MappingEnums.MappingType.SYSTEM_SETTINGS) {
						tabName = "TabSysSettingsMapping";
					}
					return tabName;
				},

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#getProfile
				 * @overridden
				 */
				getProfile: function() {
					const profile = this.callParent(arguments);
					const parameterUId = this.get("ParameterUId");
					if (!parameterUId || this.Terrasoft.isEmptyGUID(parameterUId)) {
						this.initDefProfileActiveTabName(profile);
						return profile;
					}
					const schemaElementUId = this.get("SchemaElementUId");
					profile.activeTabName = schemaElementUId && !this.Terrasoft.isEmptyGUID(schemaElementUId)
						? this.getDefActiveTabName()
						: "TabParametersMapping";
					return profile;
				},

				/**
				 * @inheritdoc Terrasoft.ProcessMappingPage#loadModule
				 * @overridden
				 */
				loadModule: function(viewModel) {
					this.subscribeGetParameterMappingInfo(viewModel);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc Terrasoft.ProcessMappingPage#addQuote
				 * @overridden
				 */
				addQuote: Ext.emptyFn,

				/**
				 * @inheritdoc Terrasoft.ProcessMappingPage#initFormulaParameters
				 * @overridden
				 */
				initFormulaParameters: Ext.emptyFn,

				/**
				 * @inheritdoc Terrasoft.ProcessMappingPage#onSaveClick
				 * @overridden
				 */
				onSaveClick: function() {
					const selectedResult = this.get("ActiveRowLookupValueResult");
					if (selectedResult) {
						const mappingType = this.get("MappingType");
						let result = selectedResult;
						if (mappingType !==
								Terrasoft.MappingEnums.MappingType.COMPOSITE_OBJECT_CONFIGURATION) {
							result = selectedResult.selectedRows?.getByIndex(0);
						} 
						this.publishSetParameterInfoMessage(result);
						return;
					}
					this.close();
				},

				/**
				 * @inheritdoc Terrasoft.ProcessMappingPage#getPreparedFormulaResult
				 * @overridden
				 * @param {String} displayValue display value.
				 * @param {String} value The formula source value.
				 * @return {Object} Selected data.
				 * @return {String} return.value Resulted value.
				 * @return {String} return.displayValue Resulted display value.
				 * @return {Number} return.source Resulted parameter value source.
				 * @return {GUID} return.referenceSchemaUId Resulted reference schema identifier.
				 */
				getPreparedFormulaResult: function(displayValue, value) {
					const result = {
						value: value,
						isValid: true,
						displayValue: displayValue,
						source: Ext.isEmpty(value)
							? Terrasoft.ProcessSchemaParameterValueSource.None
							: Terrasoft.ProcessSchemaParameterValueSource.Script,
						dataValueType: this.get("DataValueType")
					};
					const lookupSchema = this.get("LookupSchema");
					if (lookupSchema) {
						result.referenceSchemaUId = lookupSchema.value;
					}
					return this.applyInvokerResultConfig(result);
				},

				/**
				 * @inheritdoc Terrasoft.ProcessMappingPage#getFormulaValue
				 * @overridden
				 * @param {String} displayValue display value.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function scope.
				 */
				getFormulaValue: function(displayValue, callback, scope) {
					const schema = this.get("ProcessSchema");
					const dataValueType = this.get("DataValueType");
					const parameterName = this.get("ParameterName");
					const elementName = this.get("ElementName");
					const config = {
						displayValue: displayValue,
						schema: schema,
						dataValueType: dataValueType,
						parameterName: parameterName,
						elementName: elementName
					};
					Terrasoft.FormulaParserUtils.parseFormulaValue(config, callback, scope);
				},

				/**
				 * Published setParameterInfo Message.
				 * @private
				 * @param {Object) data selected value parameters.
				 */
				publishSetParameterInfoMessage: function(data) {
					if (!data) {
						this.close();
						return;
					}
					const sandbox = this.sandbox;
					let displayValue = null;
					if (this.get("ConvertToDisplayValue")) {
						const parameterValues = this.getParameterValues(data);
						displayValue = Terrasoft.ProcessSchemaDesignerUtilities.addParameterMask(
							parameterValues.displayValue);
						this.getFormulaValue(displayValue, function(result) {
							const parameterInfo = this.getPreparedFormulaResult(displayValue, result.value);
							sandbox.publish("SetParametersInfo", parameterInfo, [sandbox.id]);
						}, this);
					} else {
						sandbox.publish("SetParametersInfo", data, [sandbox.id]);
					}
				},

				/**
				 * @inheritdoc Terrasoft.ProcessMappingPage#onResultSelectedRows
				 * @overridden
				 */
				onResultSelectedRows: function(lookupValueResult) {
					const selectedRows = lookupValueResult.selectedRows;
					if (selectedRows) {
						const activeRows = this.get("ActiveRowLookupValueResult");
						const selectedRow = activeRows && activeRows.selectedRows
							? activeRows.selectedRows.getByIndex(0)
							: selectedRows.getByIndex(0);
						if (selectedRow) {
							this.publishSetParameterInfoMessage(selectedRow);
						}
					}
				},

				/**
				 * Initializes default profile active tab name.
				 * @param {Object} profile Page profile.
				 */
				initDefProfileActiveTabName: function(profile) {
					var tabs = this.get("TabsCollection");
					if (!tabs.find(profile.activeTabName)) {
						profile.activeTabName = this.getDefActiveTabName();
					}
				},

				/**
				 * @inheritdoc Terrasoft.ProcessMappingPage#onResultActiveRow
				 * @overridden
				 */
				onResultActiveRow: function(lookupValueResult) {
					this.callParent(arguments);
					this.$IsSaveButtonActive = lookupValueResult?.isSaveAllowed ?? true;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"parentName": "center-area-editPage",
					"name": "FormulaEdit"
				},
				{
					"operation": "merge",
					"name": "SaveButton",
					"values": {
						"enabled": {"bindTo": "IsSaveButtonActive"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});


