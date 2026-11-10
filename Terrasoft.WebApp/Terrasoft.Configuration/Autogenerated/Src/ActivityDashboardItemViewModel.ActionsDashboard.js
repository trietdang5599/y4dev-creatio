define("ActivityDashboardItemViewModel", ["ActivityDashboardItemViewModelResources", "ProcessModuleUtilities",
		"ConfigurationConstants", "EntityDashboardItemViewModel", "MiniPageUtilities"],
	function(resources, ProcessModuleUtilities, ConfigurationConstants) {
		Ext.define("Terrasoft.configuration.ActivityDashboardItemViewModel", {
			extend: "Terrasoft.EntityDashboardItemViewModel",
			alternateClassName: "Terrasoft.ActivityDashboardItemViewModel",

			Ext: null,
			sandbox: null,
			Terrasoft: null,

			columns: {
				/**
				 * Process element identifier.
				 */
				"ProcessElementId": {
					type: Terrasoft.ViewModelColumnType.ENTITY_COLUMN,
					dataValueType: Terrasoft.DataValueType.STRING
				},
				/**
				 * Indicates if button "Execute" was clicked.
				 */
				"ExecuteButtonClick": {
					type: Terrasoft.ViewModelColumnType.ENTITY_COLUMN,
					dataValueType: Terrasoft.DataValueType.BOOLEAN
				}
			},

			/**
			 * @inheritdoc Terrasoft.BaseDashboardItemViewModel#initIconSrc
			 * @overridden
			 */
			initIconSrc: function() {
				var iconSrc = resources.localizableImages.IconImage;
				this.set("IconSrc", iconSrc);
			},

			/**
			 * @inheritdoc Terrasoft.EntityDashboardItemViewModel#addQueryColumns
			 * @overridden
			 */
			addQueryColumns: function(esq) {
				this.callParent(arguments);
				esq.addColumn("Title", "Caption");
				esq.addColumn("Type");
				esq.addColumn("StartDate", "Date");
				esq.addColumn("Owner.Name", "Owner");
				esq.addColumn("ProcessElementId");
			},

			/**
			 * @inheritdoc Terrasoft.BaseDashboardItemViewModel#getProcessElementUId
			 * @overridden
			 */
			getProcessElementUId: function() {
				return this.get("ProcessElementId");
			},

			/**
			 * @inheritdoc Terrasoft.BaseDashboardItemViewModel#execute
			 * @overridden
			 */
			execute: function(options) {
				var schemaName = this.get("EntitySchemaName");
				var hasMiniPage;
				const parentMethodArguments = arguments;
				const parentMethod = this.getParentMethod();
				Terrasoft.chain(
					function(next) {
						this.showBodyMask();
						if (Terrasoft.Features.getIsEnabled("OpenEditPageInDcm")) {
							this.hasMiniPageForMode(schemaName, Terrasoft.ConfigurationEnums.CardOperation.VIEW, next, this);
							return;
						}
						hasMiniPage = this.hasMiniPage(schemaName);
						next(hasMiniPage);
					},
					function(next, hasMiniPage) {
						this.hideBodyMask();
						if (!this._isEmailActivity() && this.isActivity() && hasMiniPage) {
							this.showMiniPage(options);
							return;
						}
						var elementUId = this.get("ProcessElementId");
						var recordId = this.get("Id");
						var config = {
							procElUId: elementUId,
							recordId: recordId,
							scope: this,
							parentMethodArguments: parentMethodArguments,
							parentMethod: parentMethod
						};
						if (ProcessModuleUtilities.tryShowProcessCard.call(this, config)) {
							return;
						}
						parentMethod.call(this, parentMethodArguments);
					},
					this
				);


			},

			/**
			 * Returns true if it is task activity entity.
			 * @private
			 * @return {Boolean} True if it is task activity entity.
			 */
			isActivity: function() {
				var executionData = this.get("ExecutionData");
				var schemaName = this.get("EntitySchemaName");
				return this.Ext.isEmpty(executionData) ||
					(executionData && schemaName === executionData.entitySchemaName);
			},

			////TODO #CRM-33987
			/**
			 * Returns if current activity is email.
			 * @returns {Boolean} Returns if current activity is email.
			 */
			_isEmailActivity: function() {
				var activityTypes = ConfigurationConstants.Activity.Type;
				var typeLookup = this.get("Type");
				return typeLookup.value === activityTypes.Email;
			},

			/**
			 * @inheritdoc Terrasoft.BaseDashboardItemViewModel#onExecuteButtonClick
			 * @overridden
			 */
			onExecuteButtonClick: function() {
				this.set("ExecuteButtonClick", true);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.BaseDashboardItemViewModel#onCaptionClick
			 * @overridden
			 */
			onCaptionClick: function() {
				this.set("ExecuteButtonClick", false);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.MiniPageUtilities#openMiniPage
			 * @overridden
			 */
			openMiniPage: function(config) {
				if (this.get("ExecuteButtonClick")) {
					var status = {
						name: "ActivityMiniPageStatus",
						value: "Done"
					};
					if (config && this.Ext.isArray(config.valuePairs)) {
						config.valuePairs.push(status);
					} else {
						config.valuePairs = [status];
					}
				}
				this.callParent(arguments);
			}
		});
	});
