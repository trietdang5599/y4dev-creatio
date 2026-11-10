define("EntityColumnPropertiesPageModule", [
		"ModalBox",
		"EntityColumnPropertiesPageModuleResources",
		"MaskHelper",
		"BasePropertiesPageModule",
	],
	function(
		ModalBox,
		resources,
		MaskHelper,
		) {
	Ext.define("Terrasoft.EntityColumnPropertiesPageModule", {
		extend: "Terrasoft.BasePropertiesPageModule",

		mixins: {
			customEvent: "Terrasoft.CustomEventDomMixin"
		},

		messages: {
			"ChangeHeaderCaption": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},

			"GetColumnConfig": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},

			"GetSchemaColumnsNames": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},

			"GetDesignerDisplayConfig": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},

			"GetNewLookupPackageUId": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},

			"OnDesignerSaved": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},

			"GetEntitySchemaName": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			}
		},

		// region Methods: Private

		initCustomEvents: function() {
			this.callParent(arguments);
			const customEvent = this.mixins.customEvent;
			const packageUId = this.getCurrentPackageUId();
			customEvent.subscribeOnSandbox(this.sandbox, "GetColumnConfig", this.getColumnConfig, this).subscribe();
			customEvent.subscribe("GetLookupList").subscribe(this.getLookupList.bind(this, {packageUId}));
			customEvent.subscribe("GetLookupNameList").subscribe(this.getLookupNameList.bind(this, {packageUId}));
			customEvent.subscribe("CheckLookupPrimaryDisplayColumn").subscribe(this._checkLookupPrimaryDisplayColumn.bind(this));
			customEvent.subscribe("GetLookupInfo").subscribe(function(schemaUId) {this.getLookupInfo({schemaUId, packageUId})}.bind(this));
		},

		/**
		 * @private
		 */
		_getSchemaColumnsNamesWithoutCurrent: function(currentSchemaName) {
			const schemaColumnsNames = this.sandbox.publish("GetSchemaColumnsNames", null, [this.sandbox.id]);
			return schemaColumnsNames.filter(function(schemaName) {
				return schemaName !== currentSchemaName;
			});
		},

		/**
		 * @private
		 */
		_getValidationColumnConfig: function(viewModel) {
			const schemaColumnsNames = this._getSchemaColumnsNamesWithoutCurrent(viewModel.column.name);
			const maxColumnNameLength = Terrasoft.EntitySchemaManager.getMaxEntitySchemaNameWithPrefix();
			return {
				isInherited: viewModel.column.isInherited,
				schemaNamePrefix: Terrasoft.ClientUnitSchemaManager.schemaNamePrefix,
				schemaColumnsNames: schemaColumnsNames,
				maxColumnNameLength: maxColumnNameLength,
				maxColumnCaptionLength: Terrasoft.DesignTimeEnums.EntitySchemaColumnSizes.MAX_CAPTION_SIZE
			};
		},

		/**
		 * @private
		 */
		_updateModelItem: function(modelItem, data) {
			const itemConfig = modelItem.itemConfig;
			this._updateLabelConfig(itemConfig, data);
			if (Terrasoft.Features.getIsDisabled("DisableEntityColumnTooltipField")) {
				this._updateTipConfig(itemConfig, data);
			}
			itemConfig.enabled = !data.readOnly;
			this._updateLookupConfig(modelItem, data);
			this._updateNameConfig(modelItem, data);
			this._updateIsRequiredConfig(modelItem, data);
			this._updateMultilineTextConfig(modelItem, data);
			this._updateDateValueTypeConfig(modelItem, data);
		},

		/**
		 * @private
		 */
		_updateDateValueTypeConfig: function(modelItem, data) {
			const column = modelItem.column;
			const itemConfig = modelItem.itemConfig;
			if (itemConfig.dataValueType && data.dataValueType !== column.dataValueType ) {
				itemConfig.dataValueType = data.dataValueType;
			}
		},

		/**
		 * @private
		 */
		_updateLookupConfig: function(modelItem, data) {
			const dataValueType = modelItem.column.dataValueType;
			const itemConfig = modelItem.itemConfig;
			if (dataValueType === Terrasoft.DataValueType.LOOKUP) {
				itemConfig.contentType = data.isSimpleLookup
					? Terrasoft.ContentType.ENUM
					: Terrasoft.ContentType.LOOKUP;
			}
		},

		/**
		 * @private
		 */
		_updateMultilineTextConfig: function(modelItem, data) {
			const itemConfig = modelItem.itemConfig;
				if (Terrasoft.isTextDataValueType(data.dataValueType)) {
				if (data.isMultilineText) {
					itemConfig.contentType = Terrasoft.ContentType.LONG_TEXT;
				} else {
					delete itemConfig.contentType;
					modelItem.set("rowSpan", 1);
				}
			}
		},

		/**
		 * @private
		 */
		_updateNameConfig: function(modelItem, data) {
			const itemConfig = modelItem.itemConfig;
			const columnName = data.name;
			if (itemConfig.bindTo) {
				const dataViewModel = modelItem.parentViewModel;
				itemConfig.bindTo = dataViewModel.getColumnPath(columnName);
			} else {
				itemConfig.name = columnName;
			}
		},

		/**
		 * @private
		 */
		_updateIsRequiredConfig: function(modelItem, data) {
			const itemConfig = modelItem.itemConfig;
			modelItem.$isRequired = data.isRequired;
			if (data.isRequiredOnPage) {
				itemConfig.isRequired = true;
			} else {
				delete itemConfig.isRequired;
			}
		},

		/**
		 * @private
		 */
		_updateLabelConfig: function(itemConfig, data) {
			const labelConfig = this._getLabelConfig(itemConfig, data);
			if (!Terrasoft.isEmptyObject(labelConfig)) {
				itemConfig.labelConfig = labelConfig;
			} else {
				delete itemConfig.labelConfig;
			}
		},

		/**
		 * @private
		 */
		_updateTipConfig: function(itemConfig, data) {
			const tipConfig = this._getTipConfig(itemConfig, data);
			if (!Terrasoft.isEmptyObject(tipConfig) && tipConfig.tipLocalizableValue.hasAnyCultureValue()) {
				itemConfig.tip = tipConfig;
			} else {
				delete itemConfig.tip;
			}
		},

		/**
		 * @private
		 */
		_getLabelConfig: function(itemConfig, data) {
			const labelCaption = data.captionLabel;
			const columnCaption = data.caption;
			if (labelCaption === columnCaption) {
				return null;
			}
			const labelConfig = Ext.clone(itemConfig.labelConfig) || {};
			if (labelCaption) {
				const labelCaptionCultureValues = this.getCultureValues(labelCaption);
				labelConfig.captionLocalizableValue = new Terrasoft.LocalizableString({
					cultureValues: this.getSomeNotEmptyCultureValue(labelCaptionCultureValues)
						? labelCaptionCultureValues
						: {}
				});
				labelConfig.captionValue = labelConfig.captionLocalizableValue.getValue();
			}
			if (data.hideCaption) {
				labelConfig.visible = false;
			} else {
				delete labelConfig.visible;
			}
			return labelConfig;
		},

		/**
		 * @private
		 */
		_sanitizeCultureValues: function (cultureValues) {
			cultureValues.forEach((culture) => {
				culture.value = Terrasoft.sanitizeHTML(culture.value);
			});
		},

		/**
		 * @private
		 */
		_getTipConfig: function(itemConfig, data) {
			const tip = data.tip;
			const tipConfig = Ext.clone(itemConfig.tip) || {};
			if (tip) {
				this._sanitizeCultureValues(tip);
				const tipCultureValues = this.getCultureValues(tip);
				tipConfig.tipLocalizableValue = new Terrasoft.LocalizableString({
					cultureValues: this.getSomeNotEmptyCultureValue(tipCultureValues)
						? tipCultureValues
						: {}
				});
				tipConfig.tipValue = tipConfig.tipLocalizableValue.getValue();
			}
			return tipConfig;
		},

		/**
		 * @private
		 */
		_initReferenceSchemaBeforeSave: function(modelItem, data, callback, scope) {
			const column = modelItem.column;
			const dataValueType = column.dataValueType;
			const lookupData = data.lookup;
			const isNewLookup = lookupData?.isNewLookup;
			if (Terrasoft.isLookupDataValueType(dataValueType)) {
				if (isNewLookup && !column.isInherited) {
					const packageUId = this.getCurrentPackageUId();
					const createSchemaConfig = {
						name: lookupData.newLookupName,
						caption: lookupData.newLookupCaption,
						packageUId: packageUId
					};
					this._createReferenceEntitySchema(createSchemaConfig, callback, scope);
				} else {
					if (lookupData?.newLookupName || lookupData?.newLookupCaption) {
						const entitySchemaUId = lookupData.value;
						this._updateLookupNameByEntitySchemaUId(entitySchemaUId, lookupData.newLookupName);
						this._updateEntitySchemaManagerItemNameByUId(entitySchemaUId, lookupData.newLookupName);
						this._updateEntitySchemaManagerItemCaptionByUId(entitySchemaUId, lookupData.newLookupCaption);
					}
					data.referenceSchemaCaption = lookupData.name;
					data.referenceSchemaUId = lookupData.value;
					callback.call(scope);
				}
			} else {
				callback.call(scope);
			}
		},

		/**
		 * @private
		 */
		_updateLookupNameByEntitySchemaUId: function(uId, newName) {
			const lookup = Terrasoft.LookupManager.findItemBySysEntitySchemaUId(uId);
			lookup.setName(newName);
		},

		/**
		 * @private
		 */
		_updateEntitySchemaManagerItemNameByUId: function(uId, newName) {
			const managetItem = Terrasoft.EntitySchemaManager.get(uId);
			managetItem.setPropertyValue('name', newName);
		},

		/**
		 * @private
		 */
		_updateEntitySchemaManagerItemCaptionByUId: function(uId, newCaption) {
			const managerItem = Terrasoft.EntitySchemaManager.get(uId);
			for (const cultureValue of newCaption) {
				const cultureName = cultureValue.cultureName;
				const value = cultureValue.value;
				managerItem.setLocalizableStringPropertyValue("caption", value, cultureName);
			}
		},

		/**
		 * @private
		 */
		_createReferenceEntitySchema: function(config, callback, scope) {
			const name = config.name;
			const packageUId = config.packageUId;
			Terrasoft.EntitySchemaManager.initialize(function() {
				const newEntityUId = Terrasoft.generateGUID();
				const newSchema = Terrasoft.EntitySchemaManager.createSchema({
					uId: newEntityUId,
					name: name,
					packageUId: packageUId,
					caption: {}
				});
				for (const cultureValue of config.caption) {
					const cultureName = cultureValue.cultureName;
					const value = cultureValue.value;
					newSchema.setLocalizableStringPropertyValue("caption", value, cultureName);
				}
				const baseLookupUId = Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_LOOKUP;
				newSchema.setParent(baseLookupUId, function() {
					const entitySchemaManagerItem = Terrasoft.EntitySchemaManager.addSchema(newSchema);
					Terrasoft.DataManager.initEntitySchemaDataCollection(name);
					newSchema.define();
					Terrasoft.ApplicationStructureWizardUtils.createLookupManagerItem(newSchema, function() {
						callback.call(scope, entitySchemaManagerItem);
					}, this);
				}, this);
			}, this);
		},

		/**
		 * @private
		 */
		_setCreatedReferenceSchema: function (data, entitySchema) {
			if (!entitySchema) {
				return;
			}
			data.referenceSchemaCaption = entitySchema.getCaption();
			data.referenceSchemaUId = entitySchema.getUId();
		},

		/**
		 * @private
		 */
		_getColumnCaption: function() {
			const config = this.sandbox.publish("GetDesignerDisplayConfig", null, [this.sandbox.id]);
			const columnConfig = this.sandbox.publish("GetColumnConfig", null, [this.sandbox.id]);
			const parentViewModel = columnConfig.parentViewModel;
			let caption = config && config.isNewColumn
				? this.resources.localizableStrings.NewColumnCaption
				: this.resources.localizableStrings.DesignerCaption;
			if (!parentViewModel.get("IsPrimary")) {
				caption += " (" + parentViewModel.get("Caption") + ")";
			}
			return caption;
		},

		/**
		 * @private
		 */
		_updateLookupFields: function (column, data, callback, scope) {
			if (Terrasoft.isLookupDataValueType(column.dataValueType)) {
				const referenceSchemaUId = data.referenceSchemaUId;
				column.setPropertyValue("isCascade", data.isCascade);
				column.setPropertyValue("isSimpleLookup", data.isSimpleLookup);
				column.setPropertyValue("referenceSchemaCaption", data.referenceSchemaCaption);
				column.setPropertyValue("referenceSchemaUId", referenceSchemaUId);
				Terrasoft.EntitySchemaManager.getInstanceByUId(referenceSchemaUId, (instance) => {
					const isDBView = instance.isDBView;
					column.setPropertyValue("isIndexed", !isDBView);
					column.setPropertyValue("isWeakReference",isDBView);
					Ext.callback(callback, scope);
				})
			} else {
				Ext.callback(callback, scope);
			}
		},

		/**
		 * @private
		 */
		_updateColumn: function(column, data, callback, scope) {
			column.setPropertyValue("name", data.name);
			column.setPropertyValue("dataValueType", data.dataValueType);
			column.setPropertyValue("isRequired", data.isRequired);
			column.setPropertyValue("isValueCloneable", data.isValueCloneable);
			const caption = new Terrasoft.LocalizableString({
				cultureValues: this.getCultureValues(data.caption)
			});
			column.setPropertyValue("caption", caption);
			this._updateLookupFields(column, data, () => {
				column.fireEvent("changed", {}, this);
				Ext.callback(callback, scope);
			});
		},

		/**
		 * @private
		 */
		_supportIsRequiredOnPage: function(viewModel) {
			const designer = viewModel.designSchema;
			return designer.$SupportParametersDataModel;
		},

		/**
		 * @private
		 */
		_getDataValueType: function(column) {
			let type;
			switch (column.dataValueType) {
				case Terrasoft.DataValueType.TEXT:
					type = Terrasoft.DataValueType.MEDIUM_TEXT;
					break;
				case Terrasoft.DataValueType.FLOAT:
					type = Terrasoft.DataValueType.FLOAT2;
					break;
				default:
					type = column.dataValueType;
			}
			return type;
		},

		/**
		 * @private
		 */
		_checkLookupPrimaryDisplayColumn: function(config) {
			Terrasoft.chain(
				function(next) {
					const packageUId = this.getCurrentPackageUId();
					Terrasoft.EntitySchemaManager.findBundleSchemaInstance({
						schemaUId: config.value,
						packageUId: packageUId
					}, next, this);
				},
				function(next, schema) {
					const customEvent = this.mixins.customEvent;
					customEvent.publish("CheckLookupPrimaryDisplayColumn", schema && schema.primaryDisplayColumn);
				},
				this
			);
		},

		/**
		 * @private
		 */
		_getReferenceSchemaConfig: function(uId) {
			let caption = "";
			let allowEdit = false;
			if (uId && !Terrasoft.isEmptyGUID(uId)) {
				const schema = Terrasoft.EntitySchemaManager.get(uId);
				caption = schema.caption;
				allowEdit = schema.isNew();
			}
			return {
				caption,
				uId,
				allowEdit
			};
		},

		/**
		 * @private
		 */
		_getDataValueTypeTranslations: function() {
			return {
				"DataValueType.DateCaption": Terrasoft.data.constants.DataValueTypeConfig.DATE.displayValue,
				"DataValueType.DateTimeCaption": Terrasoft.data.constants.DataValueTypeConfig.DATE_TIME.displayValue,
				"DataValueType.TimeCaption": Terrasoft.data.constants.DataValueTypeConfig.TIME.displayValue,
				"DataValueType.ShortTextCaption": Terrasoft.data.constants.DataValueTypeConfig.SHORT_TEXT.displayValue,
				"DataValueType.PhoneTextCaption": Terrasoft.data.constants.DataValueTypeConfig.PHONE_TEXT.displayValue,
				"DataValueType.WebTextCaption": Terrasoft.data.constants.DataValueTypeConfig.WEB_TEXT.displayValue,
				"DataValueType.EmailTextCaption": Terrasoft.data.constants.DataValueTypeConfig.EMAIL_TEXT.displayValue,
				"DataValueType.RichCaption": Terrasoft.data.constants.DataValueTypeConfig.RICH_TEXT.displayValue,
				"DataValueType.MediumTextCaption": Terrasoft.data.constants.DataValueTypeConfig.MEDIUM_TEXT.displayValue,
				"DataValueType.LongTextCaption": Terrasoft.data.constants.DataValueTypeConfig.LONG_TEXT.displayValue,
				"DataValueType.MaxSizeTextCaption": Terrasoft.data.constants.DataValueTypeConfig.MAXSIZE_TEXT.displayValue,
				"DataValueType.IntegerCaption": Terrasoft.data.constants.DataValueTypeConfig.INTEGER.displayValue,
				"DataValueType.MoneyCaption": Terrasoft.data.constants.DataValueTypeConfig.MONEY.displayValue,
				"DataValueType.Money0Caption": Terrasoft.data.constants.DataValueTypeConfig.MONEY0.displayValue,
				"DataValueType.Money1Caption": Terrasoft.data.constants.DataValueTypeConfig.MONEY1.displayValue,
				"DataValueType.Money3Caption": Terrasoft.data.constants.DataValueTypeConfig.MONEY3.displayValue,
				"DataValueType.FLOAT0Caption": Terrasoft.data.constants.DataValueTypeConfig.FLOAT0.displayValue,
				"DataValueType.FLOAT1Caption": Terrasoft.data.constants.DataValueTypeConfig.FLOAT1.displayValue,
				"DataValueType.FLOAT2Caption": Terrasoft.data.constants.DataValueTypeConfig.FLOAT2.displayValue,
				"DataValueType.FLOAT3Caption": Terrasoft.data.constants.DataValueTypeConfig.FLOAT3.displayValue,
				"DataValueType.FLOAT4Caption": Terrasoft.data.constants.DataValueTypeConfig.FLOAT4.displayValue,
				"DataValueType.FLOAT8Caption": Terrasoft.data.constants.DataValueTypeConfig.FLOAT8.displayValue,
			};
		},

		/**
		 * @private
		 */
		_getPageDateValueTypeMessage() {
			const columnConfig = this.sandbox.publish("GetColumnConfig", null, [this.sandbox.id]);
			const column = columnConfig.column;
			let message;
			const type = Terrasoft.getBaseDataValueType(column.dataValueType);
			switch (type) {
				case Terrasoft.DataValueType.TEXT:
					message = this.resources.localizableStrings.LenghtMessage;
					break;
				case Terrasoft.DataValueType.FLOAT:
					message = this.resources.localizableStrings.PrecisionMessage;
					break;
				case Terrasoft.DataValueType.DATE_TIME:
				case Terrasoft.DataValueType.TIME:
				case Terrasoft.DataValueType.DATE:
					message = this.resources.localizableStrings.DateMessage;
					break;
			}
			return message;
		},

		// endregion

		//region Methods: Protected

		/**
		 * Return a type of editable page item.
		 * @protected
		 * @return {String} Page item type.
		 */
		getPageItemType: function() {
			return "entityColumn";
		},

		/**
		 * Returned column config.
		 * @param {Terrasoft.model.BaseViewModel} viewModel View model
		 * @protected
		 * @return {Object} Column config.
		 */
		getColumnConfig: function(viewModel) {
			const {itemConfig, column} = viewModel;
			const {labelConfig, tip} = itemConfig;
			const validationColumnConfig = this._getValidationColumnConfig(viewModel);
			const status = column.getStatus();
			const captionLabel = labelConfig && labelConfig.captionLocalizableValue;
			const initialConfig = column.initialConfig;
			const dataValueType = this._getDataValueType(column);
			const pageDataValueType = itemConfig.dataValueType;
			const needShowPageDataValueTypeMessage = pageDataValueType && pageDataValueType !== dataValueType;
			const isEnabledTooltip = Terrasoft.Features.getIsDisabled("DisableEntityColumnTooltipField");
			const tipValue = isEnabledTooltip ? this.toLocalizableStringModel(tip?.tipLocalizableValue) : null;
			const schema = viewModel.designSchema.$Schema;
			const isReplacementColumn = column.isInherited && schema.extendParent;
			return Object.assign({}, Ext.decode(column.serialize()), {
				caption: this.toLocalizableStringModel(column.caption),
				captionLabel: this.toLocalizableStringModel(captionLabel),
				tip: tipValue,
				hideCaption: labelConfig && labelConfig.visible === false,
				readOnly: itemConfig.enabled === false,
				validationConfig: validationColumnConfig,
				isNew: status === Terrasoft.ModificationStatus.NEW,
				disableNameEditing: viewModel.column.isInherited,
				itemType: this.getPageItemType(),
				isRequiredOnPage: itemConfig.isRequired,
				supportIsRequiredOnPage: this._supportIsRequiredOnPage(viewModel),
				dataValueType,
				isMultilineText: itemConfig.contentType === Terrasoft.ContentType.LONG_TEXT,
				isSimpleLookup: itemConfig.contentType === Terrasoft.ContentType.ENUM,
				referenceSchemaConfig: column.referenceSchemaUId && this._getReferenceSchemaConfig(column.referenceSchemaUId),
				initialDataValueType: initialConfig.dataValueType,
				needShowPageDataValueTypeMessage,
				showTooltipField: isEnabledTooltip,
				isReplacementColumn
			});
		},


		/**
		 * @inheritdoc BasePropertiesPageModule#getPropertiesPageTranslation
		 * @override
		 */
		getPropertiesPageTranslation: function() {
			const baseConfig = this.callParent(arguments);
			const caption = this._getColumnCaption();
			const pageDataValueTypeTypeMessage = this._getPageDateValueTypeMessage();
			const entitySchemaName = this.sandbox.publish("GetEntitySchemaName", null, [this.sandbox.id]);
			const blockDeletionCaption = Ext.String.format(this.resources.localizableStrings.BlockDeletionCaption, entitySchemaName);
			const deleteRecordsCaption = Ext.String.format(this.resources.localizableStrings.DeleteRecordsCaption, entitySchemaName);
			const config = {
				"captionLabelLabel": this.resources.localizableStrings.LabelCaption,
				"isRequiredLabel": this.resources.localizableStrings.IsRequired,
				"isRequiredOnPageLabel": resources.localizableStrings.IsRequiredOnPageLabel,
				"readOnlyLabel": this.resources.localizableStrings.ReadOnly,
				"isMultilineTextLabel": this.resources.localizableStrings.isMultilineTextLabel,
				"hideCaptionLabel": this.resources.localizableStrings.HideTitle,
				"isValueCloneableLabel": this.resources.localizableStrings.MakeCopy,
				"caption": caption,
				"wrongPrefix": this.resources.localizableStrings.WrongPrefixMessage,
				"duplicateColumnName": this.resources.localizableStrings.DuplicateColumnNameMessage,
				"columnFormat": this.resources.localizableStrings.DateTypeCaption,
				"columnTextFormat": this.resources.localizableStrings.TextDateTypeCaption,
				"columnNumberFormat": this.resources.localizableStrings.NumberDataTypeCaption,
				"editabilityCaption": this.resources.localizableStrings.EditabilityCaption,
				"appearenceCaption": this.resources.localizableStrings.AppearenceCaption,
				"advancedCaption": this.resources.localizableStrings.AdvancedCaption,
				"changeTypeMessage": this.resources.localizableStrings.ChangeTypeMessage,
				"undoButtonCaption": this.resources.localizableStrings.UndoButtonCaption,
				"dataSource": this.resources.localizableStrings.DataSourceCaption,
				"lookupView": this.resources.localizableStrings.LookupViewCaption,
				"selectionWindow": this.resources.localizableStrings.SelectionWindowCaption,
				"list": this.resources.localizableStrings.ListCaption,
				"lookup": this.resources.localizableStrings.LookupCaption,
				"lookupValueDeletion": this.resources.localizableStrings.LookupValueDeletionCaption,
				"blockDeletionCaption": blockDeletionCaption,
				"DeleteRecordsCaption": deleteRecordsCaption,
				"newLookupCaption": this.resources.localizableStrings.NewLookupCaption,
				"editLookupCaption": this.resources.localizableStrings.EditLookupCaption,
				"editCaption": this.resources.localizableStrings.EditCaption,
				"lookupSchemaDoesNotHavePrimaryDisplayColumnMsg": this.resources.localizableStrings.LookupSchemaDoesNotHavePrimaryDisplayColumnMsg,
				"selectValueCaption": this.resources.localizableStrings.SelectValueCaption,
				"pageDataValueTypeTypeMessage": pageDataValueTypeTypeMessage,
				"editLookupTooltipCaption": this.resources.localizableStrings.EditLookupTooltipCaption,
				"createLookupTooltipCaption": this.resources.localizableStrings.CreateLookupTooltipCaption,
				...this._getDataValueTypeTranslations()
			};
			return Object.assign({}, baseConfig, config);
		},

		/**
		 * @inheritdoc BasePropertiesPageModule#save
		 * @override
		 */
		save: function(data) {
			this.callParent(arguments);
			const modelItem = this.sandbox.publish("GetColumnConfig", null, [this.sandbox.id]);
			this._initReferenceSchemaBeforeSave(modelItem, data, function(entitySchema) {
				this._setCreatedReferenceSchema(data, entitySchema);
				this._updateModelItem(modelItem, data);
				this._updateColumn(modelItem.column, data, () => {
					this.sandbox.publish("OnDesignerSaved", modelItem, [this.sandbox.id]);
					ModalBox.close();
				});
			}, this);
		},

		// endregion

		//region Methods: Public

		/**
		 * @override
		 */
		init: function() {
			this.initResources(resources);
			this.callParent(arguments);
		}

		// endregion

	});
	return Terrasoft.EntityColumnPropertiesPageModule;
});
