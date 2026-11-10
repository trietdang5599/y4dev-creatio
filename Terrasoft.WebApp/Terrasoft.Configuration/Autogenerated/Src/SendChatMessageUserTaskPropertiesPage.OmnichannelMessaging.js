define("SendChatMessageUserTaskPropertiesPage", ["SendChatMessageUserTaskPropertiesPageResources",
        "EntityColumnMappingMixin"],
    function(resources) {
        const TEMPLATE_TYPE_CHAT = '62215de1-23e0-4037-88c9-65ccf72904a4';

        /**
         * @enum MessageType
         * Message type enumeration.
         */
        const MessageType = {
            /**
             * Template message type.
             */
            Template: "0",
            /**
             * Custom message type.
             */
            Custom: "1"
        };

        return {
            mixins: {
                entityColumnMappingMixin: "Terrasoft.EntityColumnMappingMixin"
            },
            messages: {},
            attributes: {
                /**
                 * Chat channel identifier (From field).
                 */
                Channel: {
                    dataValueType: Terrasoft.DataValueType.MAPPING,
                    isRequired: true,
                    parameterBindConfig: {
                        onInit: "initProperty",
                        onSave: "saveParameter"
                    },
                    mappingWindowConfig: {
                        filterMethod: "getChannelFilter"
                    }
                },
                /**
                 * Contact identity (To field).
                 */
                Contact: {
                    dataValueType: Terrasoft.DataValueType.MAPPING,
                    isRequired: true,
                    parameterBindConfig: {
                        onInit: "initProperty",
                        onSave: "saveParameter"
                    },
                    mappingWindowConfig: {
                        filterMethod: "getContactFilter"
                    }
                },
                /**
                 * Message type (Template or Custom).
                 */
                MessageType: {
                    dataValueType: Terrasoft.DataValueType.LOOKUP,
                    isRequired: true,
                    parameterBindConfig: {
                        onInit: "_initMessageType",
                        onSave: "saveParameter"
                    }
                },
                /**
                 * Message type enum config object.
                 */
                MessageTypeEnum: {
                    dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
                    value: {
                        Template: {
                            value: MessageType.Template,
                            displayValue: resources.localizableStrings.TemplateMessageCaption
                        },
                        Custom: {
                            value: MessageType.Custom,
                            displayValue: resources.localizableStrings.CustomMessageCaption
                        }
                    }
                },
                /**
                 * Message template identifier (displays if Template message type is selected).
                 */
                Template: {
                    dataValueType: Terrasoft.DataValueType.MAPPING,
                    parameterBindConfig: {
                        onInit: "initProperty",
                        onSave: "saveParameter"
                    },
                    mappingWindowConfig: {
                        filterMethod: "getTemplateFilter"
                    }
                },
                /**
                 * Message text.
                 */
                Message: {
                    dataValueType: Terrasoft.DataValueType.MAPPING,
                    parameterBindConfig: {
                        onInit: "initProperty",
                        onSave: "saveParameter"
                    }
                },
                /**
                 * Ignore errors flag.
                 */
                IgnoreErrors: {
                    dataValueType: Terrasoft.DataValueType.BOOLEAN,
                    parameterBindConfig: {
                        onInit: "initProperty",
                        onSave: "saveParameter"
                    }
                },
                /**
                 * Channel provider identifier (internal attribute, not saved to process).
                 */
                ChannelProvider: {
                    dataValueType: Terrasoft.DataValueType.GUID
                }
            },
            methods: {

                /**
                 * Init MessageType attribute.
                 * @private
                 * @param {Terrasoft.manager.ProcessSchemaParameter} parameter Process parameter.
                 */
                _initMessageType: function(parameter) {
                    const source = parameter.getValueSource();
                    if (source !== Terrasoft.ProcessSchemaParameterValueSource.None) {
                        const enumConfig = this.get("MessageTypeEnum");
                        const value = parameter.getValue();
                        const item = Terrasoft.findWhere(enumConfig, {value: value});
                        this.set("MessageType", item);
                    }
                },

                /**
                 * Returns visibility of MessageTemplate field.
                 * @private
                 * @return {Boolean} True if MessageType is Template.
                 */
                _getIsMessageTemplateVisible: function() {
                    const messageType = this.get("MessageType");
                    return messageType && messageType.value === MessageType.Template;
                },

                /**
                 * Returns whether Message field should be readonly.
                 * @private
                 * @return {Boolean} True if MessageType is Template.
                 */
                _getIsMessageReadonly: function() {
                    const messageType = this.get("MessageType");
                    return !(messageType && messageType.value === MessageType.Template);
                },

                /**
                 * Handles MessageType change and clears Template field if Custom is selected.
                 * @private
                 */
                _onMessageTypeChanged: function() {
                    const messageType = this.get("MessageType");
                    if (messageType && messageType.value === MessageType.Custom) {
                        this.set("Template", null);
                    }
                },

                /**
                 * Handles Template change and loads multi-language template text.
                 * @private
                 */
                _onTemplateChanged: function() {
                    const template = this.get("Template");
                    if (template && template.value) {
                        const templateId = Terrasoft.FormulaParserUtils.getLookupValue(template.value);
                        this._loadTemplateMessage(templateId);
                    }
                },

                /**
                 * Handles Channel change and loads channel provider.
                 * @private
                 */
                _onChannelChanged: function() {
                    const channel = this.get("Channel");

                    if (channel && channel.value) {
                        const isLookup = this.getIsLookupMappingValue(channel.value);

                        if (isLookup) {
                            const channelId = Terrasoft.FormulaParserUtils.getLookupValue(channel.value);
                            if (!Terrasoft.isEmptyGUID(channelId)) {
                                this._loadChannelProvider(channelId);
                                return;
                            }
                        }
                    }

                    this.set("ChannelProvider", null);
                },

                /**
                 * Loads channel provider by channel ID.
                 * @private
                 * @param {String} channelId Channel identifier.
                 */
                _loadChannelProvider: function(channelId) {
                    const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
                        rootSchemaName: "Channel"
                    });
                    esq.addColumn("Provider");
                    esq.filters.add("IdFilter", esq.createColumnFilterWithParameter(
                        Terrasoft.ComparisonType.EQUAL,
                        "Id",
                        channelId
                    ));

                    esq.getEntityCollection(function(result) {
                        if (result && result.success && result.collection.getCount() > 0) {
                            const channelEntity = result.collection.getByIndex(0);
                            const provider = channelEntity.get("Provider");
                            const providerId = provider && provider.value ? provider.value : provider;
                            this.set("ChannelProvider", providerId);
                        } else {
                            this.set("ChannelProvider", null);
                        }
                    }, this);
                },

                /**
                 * Loads template message text using EntitySchemaQuery.
                 * @private
                 * @param {String} templateId Template identifier.
                 */
                _loadTemplateMessage: function(templateId) {
                    if (Terrasoft.isEmptyGUID(templateId)) {
                        return;
                    }
                    this.getEsqTemplateBody(templateId, function(result) {
                        if (result && result.success) {
                            const items = result.collection.getItems();
                            if (items.length > 0) {
                                const body = items[0].get("Body");
                                const plainBody = Terrasoft.removeHtmlTags(body);
                                this.set("Message", {
                                    value: plainBody,
                                    displayValue: plainBody,
                                    source: Terrasoft.ProcessSchemaParameterValueSource.ConstValue,
                                    dataValueType: Terrasoft.DataValueType.TEXT
                                });
                            }
                        }
                    }, this);
                },

                /**
                 * Gets template body using EntitySchemaQuery.
                 * @private
                 * @param {String} id Template identifier.
                 * @param {Function} callback Callback function.
                 * @param {Object} scope Execution scope.
                 */
                getEsqTemplateBody: function(id, callback, scope) {
                    if (id === undefined || id === null) {
                        return Ext.callback(callback, scope, [null]);
                    }

                    const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
                        rootSchemaName: "EmailTemplate"
                    });
                    esq.addColumn("Body");
                    const idFilter = esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
                        "Id", id);
                    esq.filters.add("IdFilter", idFilter);
                    esq.getEntityCollection(function(result) {
                        return Ext.callback(callback, scope, [result]);
                    }, this);
                },

                /**
                 * @inheritdoc Terrasoft.BaseProcessSchemaElementPropertiesPage#onElementDataLoad
                 * @override
                 */
                onElementDataLoad: function(element, callback, scope) {
                    this.callParent([element, function() {
                        this.on("change:MessageType", this._onMessageTypeChanged, this);
                        this.on("change:Template", this._onTemplateChanged, this);
                        this.on("change:Channel", this._onChannelChanged, this);
                        // Load provider for initially selected channel
                        this._onChannelChanged();
                        this.initEntityColumnMappingMixin(element, callback, scope);
                    }, this]);
                },

                /**
                 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveParameters
                 * @override
                 */
                saveParameters: function(element) {
                    this.callParent(arguments);
                    this.saveEntityColumnMappings(element);
                },

                /**
                 * Returns OmniChat entity schema UId used by EntityColumnMappingMixin
                 * to load available OmniChat columns for the column-value block.
                 * @override
                 * @return {String} OmniChat entity schema UId.
                 */
                getEntityColumnMappingSchemaUId: function() {
                    return "af1f685c-315b-4b44-a957-c5094417a57a";
                },

                /**
                 * Prepares message type list.
                 * @param {Object} filter Filters for data preparation.
                 * @param {Terrasoft.Collection} list List of message types.
                 */
                onPrepareMessageTypeList: function(filter, list) {
                    if (Terrasoft.isEmptyObject(list)) {
                        return;
                    }
                    const enumConfig = this.get("MessageTypeEnum");
                    list.clear();
                    list.loadAll(enumConfig);
                },

                /**
                 * Returns filter for channel selection, filters channels by Active = true.
                 * @returns {Terrasoft.FilterGroup}
                 */
                getChannelFilter: function() {
                    const filters = Ext.create("Terrasoft.FilterGroup");
                    filters.addItem(Terrasoft.createColumnFilterWithParameter(
                        Terrasoft.ComparisonType.EQUAL,
                        "IsActive",
                        true
                    ));
                    return filters;
                },

                /**
                 * Returns filter for message template selection, filters templates by chat message type.
                 * @returns {Terrasoft.FilterGroup}
                 */
                getTemplateFilter: function() {
                    const filters = Ext.create("Terrasoft.FilterGroup");
                    filters.addItem(Terrasoft.createColumnFilterWithParameter("TemplateType", TEMPLATE_TYPE_CHAT));
                    return filters;
                },

                getIsLookupMappingValue(value) {
                    const parameterRegex = Terrasoft.process.constants.PARAMETER_REGEX;
                    const match = parameterRegex.exec(value);
                    parameterRegex.lastIndex = 0;
                    if (match && match.length === 2) {
                        const macrosBody = match[1];
                        return Terrasoft.FormulaParserUtils.getIsLookupMappingValue(macrosBody);
                    }
                    return false;
                },

                /**
                 * Returns list of provider IDs that don't require ContactIdentity filtering.
                 * @returns {String[]} Array of provider GUIDs.
                 */
                getProvidersWithNoIdentityRequired: function() {
                    return [
                        "21af0484-eee0-4f61-8822-f8789838ba66" // SMS Provider
                    ];
                },

                /**
                 * Returns filter for contact selection, filters contacts by ContactIdentity with matching Channel.
                 * Exception: if Channel.Provider is in the list of providers without identity requirement, no filtering is applied.
                 * @returns {Terrasoft.FilterGroup}
                 */
                getContactFilter: function() {
                    const filters = Ext.create("Terrasoft.FilterGroup");
                    const channelProvider = this.get("ChannelProvider");
                    const providersWithNoIdentity = this.getProvidersWithNoIdentityRequired();
                    if (channelProvider && Terrasoft.contains(providersWithNoIdentity, channelProvider)) {
                        return filters;
                    }
                    const channel = this.get("Channel");
                    if (channel && channel.value) {
                        const isLookup = this.getIsLookupMappingValue(channel.value);
                        if (isLookup) {
                            const channelId = Terrasoft.FormulaParserUtils.getLookupValue(channel.value);
                            if (!Terrasoft.isEmptyGUID(channelId)) {
                                const subFilters = Ext.create("Terrasoft.FilterGroup");
                                subFilters.addItem(Terrasoft.createColumnFilterWithParameter(
                                    Terrasoft.ComparisonType.EQUAL,
                                    "Channel",
                                    channelId
                                ));

                                const existsFilter = Terrasoft.createExistsFilter(
                                    "[ContactIdentity:Contact:Id].Id",
                                    subFilters
                                );
                                filters.addItem(existsFilter);
                            }
                        }
                    }

                    return filters;
                }
            },
            diff: [
                {
                    "operation": "insert",
                    "parentName": "EditorsContainer",
                    "name": "UserTaskContainer",
                    "propertyName": "items",
                    "className": "Terrasoft.GridLayoutEdit",
                    "values": {
                        "itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
                        "items": []
                    }
                },
                {
                    "operation": "insert",
                    "parentName": "UserTaskContainer",
                    "name": "MessageContainer",
                    "propertyName": "items",
                    "className": "Terrasoft.GridLayoutEdit",
                    "values": {
                        "layout": {"column": 0, "row": 0, "colSpan": 24},
                        "itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
                        "items": []
                    }
                },
                {
                    "operation": "insert",
                    "parentName": "MessageContainer",
                    "name": "Channel",
                    "propertyName": "items",
                    "values": {
                        "layout": {"column": 0, "row": 0, "colSpan": 24},
                        "wrapClass": ["top-caption-control"],
                        "caption": {
                            "bindTo": "Resources.Strings.ChannelCaption"
                        }
                    }
                },
                {
                    "operation": "insert",
                    "parentName": "MessageContainer",
                    "name": "Contact",
                    "propertyName": "items",
                    "values": {
                        "layout": {"column": 0, "row": 1, "colSpan": 24},
                        "wrapClass": ["top-caption-control"],
                        "caption": {
                            "bindTo": "Resources.Strings.ContactCaption"
                        }
                    }
                },
                {
                    "operation": "insert",
                    "parentName": "MessageContainer",
                    "name": "MessageType",
                    "propertyName": "items",
                    "values": {
                        "layout": {"column": 0, "row": 2, "colSpan": 24},
                        "wrapClass": ["top-caption-control"],
                        "caption": {
                            "bindTo": "Resources.Strings.MessageTypeCaption"
                        },
                        "contentType": Terrasoft.ContentType.ENUM,
                        "controlConfig": {
                            "prepareList": {
                                "bindTo": "onPrepareMessageTypeList"
                            }
                        }
                    }
                },
                {
                    "operation": "insert",
                    "parentName": "MessageContainer",
                    "name": "Template",
                    "propertyName": "items",
                    "values": {
                        "layout": {"column": 0, "row": 3, "colSpan": 24},
                        "wrapClass": ["top-caption-control"],
                        "caption": {
                            "bindTo": "Resources.Strings.TemplateCaption"
                        },
                        "visible": {
                            "bindTo": "MessageType",
                            "bindConfig": {
                                "converter": "_getIsMessageTemplateVisible"
                            }
                        }
                    }
                },
                {
                    "operation": "insert",
                    "parentName": "MessageContainer",
                    "name": "Message",
                    "propertyName": "items",
                    "values": {
                        "layout": {"column": 0, "row": 4, "colSpan": 24},
                        "wrapClass": ["top-caption-control"],
                        "caption": {
                            "bindTo": "Resources.Strings.MessageCaption"
                        },
                        "enabled": {
                            "bindTo": "MessageType",
                            "bindConfig": {
                                "converter": "_getIsMessageReadonly"
                            }
                        }
                    }
                },
                {
                    "operation": "insert",
                    "parentName": "MessageContainer",
                    "name": "IgnoreErrors",
                    "propertyName": "items",
                    "values": {
                        "layout": {"column": 0, "row": 5, "colSpan": 24},
                        "wrapClass": ["t-checkbox-control"],
                        "caption": {
                            "bindTo": "Resources.Strings.IgnoreErrorsCaption"
                        }
                    }
                },
                {
                    "operation": "insert",
                    "parentName": "UserTaskContainer",
                    "name": "ChatColumnValuesContainer",
                    "propertyName": "items",
                    "values": {
                        "layout": {"column": 0, "row": 1, "colSpan": 24},
                        "itemType": Terrasoft.ViewItemType.CONTAINER,
                        "items": [],
                        "classes": {
                            "wrapClassName": ["base-data-modification-user-task-properties-page"]
                        }
                    }
                },
                {
                    "operation": "insert",
                    "parentName": "ChatColumnValuesContainer",
                    "name": "ChatColumnValuesLabel",
                    "propertyName": "items",
                    "values": {
                        "itemType": Terrasoft.ViewItemType.LABEL,
                        "caption": {"bindTo": "Resources.Strings.ChatColumnValuesCaption"},
                        "classes": {
                            "labelClass": ["t-title-label-proc"]
                        }
                    }
                },
                {
                    "operation": "insert",
                    "parentName": "ChatColumnValuesContainer",
                    "name": "RecordColumnValuesContainer",
                    "propertyName": "items",
                    "values": {
                        "generator": "ConfigurationItemGenerator.generateContainerList",
                        "idProperty": "Id",
                        "collection": "EntityColumnMappingsControls",
                        "onGetItemConfig": "getEntityColumnMappingsControlViewConfig",
                        "classes": {
                            "wrapClassName": ["record-column-values-container", "grid-layout"]
                        }
                    }
                },
                {
                    "operation": "insert",
                    "parentName": "ChatColumnValuesContainer",
                    "name": "AddChatColumnValuesButton",
                    "propertyName": "items",
                    "values": {
                        "itemType": Terrasoft.ViewItemType.BUTTON,
                        "caption": {
                            "bindTo": "Resources.Strings.EntityColumnMapping_AddRecordColumnValuesButtonCaption"
                        },
                        "style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
                        "imageConfig": {"bindTo": "Resources.Images.AddButtonImage"},
                        "classes": {
                            "wrapperClass": ["add-record-column-values-button"]
                        },
                        "click": {"bindTo": "onAddEntityColumnMappings"}
                    }
                }
            ]
        };
    });
