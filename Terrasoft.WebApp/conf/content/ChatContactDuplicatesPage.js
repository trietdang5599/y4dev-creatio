Terrasoft.configuration.Structures["ChatContactDuplicatesPage"] = {innerHierarchyStack: ["ChatContactDuplicatesPage"], structureParent: "DuplicatesPageV2"};
define('ChatContactDuplicatesPageStructure', ['ChatContactDuplicatesPageResources'], function(resources) {return {schemaUId:'2a62cd84-117f-4b65-bc4b-ad998cbbe3f8',schemaCaption: "Page for contact duplicates in chat", parentSchemaName: "DuplicatesPageV2", packageName: "OmnichannelMessaging", schemaName:'ChatContactDuplicatesPage',parentSchemaUId:'3bb66e30-50a3-4707-bbeb-5b9b13316887',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
 define("ChatContactDuplicatesPage", ["ChatContactDuplicatesDetailViewConfig", "ChatContactDuplicatesDetailViewModel"],
		function() {
			return {
				methods: {

					// region Methods: Private

					/**
					 * @private
					 */
					_addContactColumns: function(esq) {
						const columns = this.getDuplicatesColumns();
						this.Terrasoft.each(columns, function(column) {
							esq.addColumn(column);
						}, this);
					},

					/**
					 * @private
					 */
					_getDuplicatesContactData: function(duplicatesContacts) {
						let rows = [];
						const items = duplicatesContacts.getItems();
						this.Terrasoft.each(items, function(item) {
							rows.push(item.values);
						}, this);
						return {
							"groups": [
								{
									"groupId": 1,
									"rows": rows
								}
							],
							"rowConfig": duplicatesContacts.rowConfig
						};
					},

					// endregion

					// region Methods: Protected

					/**
					 * Returns query to Contact entity.
					 * @protected
					 * @param {Array} contactsId Identifiers of contacts.
					 * @returns {Object} Query to Contact entity
					 */
					getDuplicatesContactEsq: function(contactsId) {
						const esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
							rootSchemaName: "Contact"
						});
						this._addContactColumns(esq);
						const filter = this.Terrasoft.createColumnInFilterWithParameters("Id", contactsId);
						filter.comparisonType = this.Terrasoft.ComparisonType.EQUAL;
						esq.filters.add("contactFilter", filter);
						return esq;
					},
					
					/**
					 * @inheritdoc DuplicatesPageV2#getDeduplicationResultsCallback
					 * @overridden
					 */
					getDeduplicationResultsCallback: function() {
						const state = this.sandbox.publish("GetHistoryState").state;
						const contacts = state.DuplicatesContacts;
						const esq =  this.getDuplicatesContactEsq(contacts);
						esq.getEntityCollection(function(result) {
							if (result.success) {
								const data = this._getDuplicatesContactData(result.collection);
								this.processDeduplicationResults(data);
							}
						}, this);
					},

					/**
					 * @inheritdoc DuplicatesPageV2#getDuplicatesDetailModuleRootContainerId
					 * @overridden
					 */
					getDuplicatesDetailModuleRootContainerId: function (id) {
						return Ext.String.format("ChatContactDuplicatesPageDuplicateContainerContainer-{0}-listItem",
						id);
					},

					/**
					 * @inheritdoc DuplicatesPageV2#getDuplicatesGroupDetailConfig
					 * @overridden
					 */
					getDuplicatesGroupDetailConfig: function() {
						const config = this.callParent(arguments);
						const state = this.sandbox.publish("GetHistoryState").state;
						config.viewConfigClassName = this.getDuplicatesDetailViewConfigClassName();
						config.viewModelClassName = this.getDuplicatesDetailViewModelClassName();
						config.currentContactId = state.CurrentContactId;
						return config;
					},

					/**
					 * Returns name of detail viewConfig class.
					 * @protected
					 * @returns {String} Name of detail viewConfig class.
					 */
					getDuplicatesDetailViewConfigClassName: function() {
						return "Terrasoft.ChatContactDuplicatesDetailViewConfig";
					},

					/**
					 * Returns name of detail viewModel class.
					 * @protected
					 * @returns {String} Name of detail viewModel class.
					 */
					getDuplicatesDetailViewModelClassName: function() {
						return "Terrasoft.ChatContactDuplicatesDetailViewModel";
					},

					/**
					 * @override
					 */
					isBulkESDeduplicationEnabled: function () {
						return false;
					}

					// endregion

				}
			};
		});


