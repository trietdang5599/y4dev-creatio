define("BaseDataView", ["RightUtilities", "DuplicatesSearchUtilitiesV2", "DuplicatesMergeHelper", "SectionMergeHelper"],
	function(RightUtilities) {
		return {
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
			mixins: {
				DuplicatesSearchUtilities: "Terrasoft.DuplicatesSearchUtilitiesV2",
				DuplicatesMergeHelper: "Terrasoft.DuplicatesMergeHelper",
				SectionMergeHelper: "Terrasoft.SectionMergeHelper"
			},
			messages: {
				/**
				 * @message Merge
				 * Merge records.
				 * @param {Object} Merge config.
				 */
				"Merge": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {
				/**
				 * True if user has search duplicates operation permissions.
				 */
				CanSearchDuplicatesOperation: {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * True if enabled old deduplication feature.
				 */
				DeduplicationEnabled: {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * True if enabled new bulk deduplication feature.
				 */
				BulkDeduplicationEnabled: {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * True if 'search duplicates' button visible.
				 */
				canSearchDuplicates: {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * True if user has merge duplicates operation permissions.
				 */
				CanMergeDuplicates: {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: false
				}
			},
			methods: {
				/**
				 * @inheritdoc Terrasoft.BaseSectionV2#init
				 * @overridden
				 */
				init: function() {
					this.checkCanSearchDuplicates();
					RightUtilities.checkCanExecuteOperation({
						operation: "CanMergeDuplicates"
					}, function(canExecute) {
						this.$CanMergeDuplicates = canExecute;
					}.bind(this), this);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc Terrasoft.SectionMergeHelper#isMergeVisible
				 * @overridden
				 */
				isMergeVisible: function() {
					const canMergeDuplicates = Boolean(this.$CanMergeDuplicates);
					const baseIsMergeVisible = this.mixins.SectionMergeHelper.isMergeVisible.apply(this, arguments);
					return canMergeDuplicates && baseIsMergeVisible;
				},

				/**
				 * Checks can search duplicates operation.
				 * Sets 'canSearchDuplicates' attribute to viewmodel.
				 */
				checkCanSearchDuplicates: function() {
					this.fetchCanDeduplicationOperationPermission()
						.then(this.setCanSearchDuplicatesAttributes.bind(this));
				},

				/**
				 * Sets dependents attributes to viewmodel.
				 * @protected
				 */
				setCanSearchDuplicatesAttributes: function(canSearchDuplicatesOperation) {
					this.set("CanSearchDuplicatesOperation", canSearchDuplicatesOperation);
					this.set("BulkDeduplicationEnabled", this.getIsBulkDeduplicationEnabled());
					const isEnabled = canSearchDuplicatesOperation && this.$BulkDeduplicationEnabled;
					this.set("canSearchDuplicates", isEnabled);
				},

				/**
				 * @inheritdoc
				 * @overridden
				 */
				openDuplicatesModule: function() {
					this.mixins.DuplicatesSearchUtilities.openDuplicatesModule.call(this, this.entitySchemaName);
				},

				/**
				 * @inheritdoc Terrasoft.BaseSection#getSectionActions
				 * @overriden
				 */
				getSectionActions: function() {
					let actionMenuItems = this.callParent(arguments);
					if (this.getIsDeduplicationEnable()) {
						this.addDuplicatesActionButton(actionMenuItems);
						this.addMergeActionButton(actionMenuItems);
					}
					return actionMenuItems;
				},

				/**
				 * Added duplicate action button to menu.
				 * @protected
				 * @param {Terrasoft.BaseViewModelCollection} actionMenuItems menu items.
				 */
				addDuplicatesActionButton: function(actionMenuItems) {
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Click": {"bindTo": "openDuplicatesModule"},
						"Caption": {"bindTo": "addDuplicatesActionButtonCaption"},
						"Visible": {"bindTo": "canSearchDuplicates"},
						"ImageConfig": this.get("Resources.Images.ShowDuplicatesBtnImage")
					}));
				},

				/**
				 * Gets caption of the action duplicate button.
				 * @protected
				 * @return {String} caption of the action duplicate button.
				 */
				addDuplicatesActionButtonCaption: function() {
					const moduleCaption = this.getModuleCaption() || Terrasoft.emptyString;
					const duplicatesActionCaptionPattern = this.get("Resources.Strings.DuplicatesActionCaptionPattern");
					const pattern = duplicatesActionCaptionPattern || Terrasoft.emptyString;
					return Ext.String.format(pattern, moduleCaption);
				},

				/**
				 * @inheritdoc Terrasoft.BaseSection#subscribeSandboxEvents
				 * @overriden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					const moduleId = this.getMergeModuleId();
					this.sandbox.subscribe("Merge", function(config) {
						this.mergeRecords(config);
					}, this, [moduleId]);
				}
			}
		};
	}
);
