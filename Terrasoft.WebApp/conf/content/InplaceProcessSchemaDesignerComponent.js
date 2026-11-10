Terrasoft.configuration.Structures["InplaceProcessSchemaDesignerComponent"] = {innerHierarchyStack: ["InplaceProcessSchemaDesignerComponent"]};
define("InplaceProcessSchemaDesignerComponent", ["@creatio-devkit/common", "Base7xViewElement",
		"InplaceProcessSchemaDesignerViewModel", "InplaceProcessSchemaDesigner",
		"css!InplaceProcessSchemaDesignerComponent"],
	function(sdk, CrtBase7xViewComponent) {
		class CrtInplaceProcessSchemaDesignerComponent extends CrtBase7xViewComponent {

			//region Constructors: Public

			/**
			 * Creates a new instance of the class.
			 */
			constructor() {
				super("CrtInplaceProcessSchemaDesignerComponent");
			}

			//endregion

			//region Properties: Private

			_processSchemaUId;
			_actualVersionSchemaUId;
			_packageUId;
			_designer;
			_designerInstanceId;
			_processName;
			_processCode;
			_processDescription;
			_schemaIsLoaded = false;
			_schemaIsChanged = false;
			_schemaIsNew = false;
			_preCreateParameters = [];

			//endregion

			//region Properties: Public

			get processSchemaUId() {
				return this._processSchemaUId;
			}

			set processSchemaUId(value) {
				this._processSchemaUId = value;
				this._render();
			}

			get packageUId() {
				return this._packageUId;
			}

			set packageUId(value) {
				this._packageUId = value;
			}

			get designerInstanceId() {
				return this._designerInstanceId;
			}

			set designerInstanceId(value) {
				this._designerInstanceId = value;
				this._render();
			}

			get preCreateParameters() {
				return this._preCreateParameters;
			}

			set preCreateParameters(value) {
				this._preCreateParameters = value;
			}

			set processName(value) {
				if (this._processName !== value) {
					this._processName = value;
					this._setSchemaTextValue("SchemaCaption", value);
				}
			}

			set processCode(value) {
				if (this._processCode !== value) {
					this._processCode = value;
					this._setSchemaTextValue("SchemaCode", value);
				}
			}

			set processDescription(value) {
				if (this._processDescription !== value) {
					this._processDescription = value;
					this._setSchemaTextValue("SchemaDescription", value);
				}
			}

			get schemaIsLoaded() {
				return this._schemaIsLoaded;
			}

			set schemaIsLoaded(value){
				if (this._schemaIsLoaded !== value) {
					this._schemaIsLoaded = value;
					this._notifyOutputChanged('schemaIsLoadedChange', this.schemaIsLoaded);
				}
			}

			get schemaIsChanged() {
				return this._schemaIsChanged;
			}

			set schemaIsChanged(value) {
				if (this._schemaIsChanged !== value) {
					this._schemaIsChanged = value;
					this._notifyOutputChanged('schemaIsChangedChange', this.schemaIsChanged);
				}
			}

			get schemaIsNew() {
				return this._schemaIsNew;
			}

			set schemaIsNew(value) {
				if (this._schemaIsNew !== value) {
					this._schemaIsNew = value;
					this._notifyOutputChanged('schemaIsNewChange', this.schemaIsNew);
				}
			}

			//endregion

			//region Methods: Private

			_setSchemaTextValue(propertyName, value) {
				if (this._designer && this.schemaIsLoaded) {
					this._designer.setSchemaTextValue(propertyName, value);
				}
			}

			/**
			 * @private
			 */
			_getIsCreatedNewSchema() {
				return Terrasoft.isEmptyGUID(this._processSchemaUId);
			}

			/**
			 * @private
			 */
			_render() {
				if (!this._designerInstanceId || !this._processSchemaUId) {
					return;
				}
				if (this._getIsCreatedNewSchema()) {
					this._processSchemaUId = null;
					this._actualVersionSchemaUId = null;
					this.schemaIsNew = true;
				}
				this.initContext(async () => {
					if (Boolean(this._designer)) {
						return;
					}
					if (!this._processSchemaUId) {
						this._initAndRenderDesigner();
						return;
					}
					Terrasoft.ProcessSchemaManager.getActualVersionUId(this._processSchemaUId, function(result) {
						this._actualVersionSchemaUId = result.actualVersionSchemaUId;
						this._initAndRenderDesigner();
					}, this);
				});
			}

			/**
			 * @private
			 */
			_initAndRenderDesigner() {
				this._initDesigner();
				this._renderDesigner();
			}

			_initDesigner() {
				this._designer = this.ext.create("Terrasoft.InplaceProcessSchemaDesigner", {
					sandbox: this.sandbox,
					isDesignerHeaderVisible: false,
					schemaUId: this._actualVersionSchemaUId,
					designerInstanceId: this._designerInstanceId,
					designPackageUId: this._packageUId,
					preCreateParameters: this._preCreateParameters,
					handlePropertiesChange: this._onDesignerPropertiesChange.bind(this),
					settings: {
						processSchemaParameterOptions: {
							IsRequiredVisible: true,
						},
						newParameterDirection: Terrasoft.process.constants.ParameterDirectionConfig.IN,
						processSchemaOptions: {
							useUserPermissions: true,
							useSystemSecurityContext: false
						}
					}
				});
				this._designer.on('loadcomplete', this._onSchemaLoadComplete, this);
				this._designer.on("loadStart", this._onLoadStart, this);
			}

			/**
			 * @private
			 */
			_onLoadStart() {
				this.schemaIsLoaded = false;
			}

			/**
			 * @private
			 */
			_onDesignerPropertiesChange({ name, value }) {
				let eventName;
				switch (name) {
					case 'SchemaCaption':
						if (this._processName !== value) {
							eventName = 'processNameChange';
							this._processName = value;
						}
						break;
					case 'SchemaDescription':
						if (this._processDescription !== value) {
							eventName = 'processDescriptionChange';
							this._processDescription = value;
						}
						break;
					case 'SchemaCode':
						if (this._processCode !== value) {
							eventName = 'processCodeChange';
							this._processCode = value;
						}
						break;
					case 'SchemaUId':
						if (!this._processSchemaUId && !this._actualVersionSchemaUId) {
							eventName = 'processSchemaUIdChange';
							this._processSchemaUId = value;
							this._actualVersionSchemaUId = value;
						}
						break;
					case 'IsSchemaChanged':
						if (this._schemaIsChanged !== value) {
							eventName = 'schemaIsChangedChange';
							this._schemaIsChanged = value;
						}
						break;
					case 'SchemaIsNew':
						if (this._schemaIsNew !== value) {
							eventName = 'schemaIsNewChange';
							this._schemaIsNew = value;
						}
						break;
				}
				if (eventName) {
					this._notifyOutputChanged(eventName, value);
				}
			}

			/**
			 * @private
			 */
			_notifyOutputChanged(outputName, value) {
				const changeEvent = new CustomEvent(outputName, {
					detail: value
				});
				this.dispatchEvent(changeEvent);
			}

			/**
			 * @private
			 */
			_onSchemaLoadComplete() {
				this.schemaIsLoaded = true;
			}

			/**
			 * @private
			 */
			_renderDesigner() {
				if (this._renderTo) {
					this._designer.render({
						renderTo: Ext.get(this._renderTo),
						sandbox: this.sandbox
					});
				}
			}

			//endregion

			//region Methods: Public

			getMessages() {
				const messages = super.getMessages();
				return Object.assign(messages, {});
			}

			connectedCallback() {
				super.connectedCallback();
			}

			disconnectedCallback() {
				if (this._designer) {
					this._designer.un('loadcomplete', this._onSchemaLoadComplete, this);
					this._designer.un('loadStart', this._onLoadStart, this);
					this._designer.destroy();
				}
				super.disconnectedCallback();
			}

			//endregion

		}

		if (!customElements.get('crt-inplace-process-schema-designer')) {
			customElements.define('crt-inplace-process-schema-designer', CrtInplaceProcessSchemaDesignerComponent);
			sdk.registerViewElement({
				type: 'crt.InplaceProcessSchemaDesigner',
				selector: 'crt-inplace-process-schema-designer',
				inputs: {
					processSchemaUId: {},
					designerInstanceId: {},
					processName: {},
					processCode: {},
					processDescription: {},
					schemaIsLoaded: {},
					schemaIsChanged: {},
					schemaIsNew: {},
					packageUId: {},
					preCreateParameters: {}
				},
				outputs: {
					processNameChange: {},
					processCodeChange: {},
					processDescriptionChange: {},
					processSchemaUIdChange: {},
					schemaIsLoadedChange: {},
					schemaIsChangedChange: {},
					schemaIsNewChange: {},
				}
			});
		}
		return CrtInplaceProcessSchemaDesignerComponent;
});


