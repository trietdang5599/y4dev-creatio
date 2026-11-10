define("Angular7xDetailModule", ["@creatio-devkit/common", "Base7xViewElement"], function(sdk, Base7xViewElement) {
    class CrtAngular7xDetailViewElement extends Base7xViewElement {
        set defaultValues(value) {
            if (!value) {
                return;
            }
            this._defaultValues = value;
            this._init();
        }
        get defaultValues() {
            return this._defaultValues?.map((defaulValue) => ({
                name: defaulValue.name,
                value: defaulValue.value?.value || defaulValue.value
            })) || [];
        }

        set config(value) {
            if (!value) {
                return;
            }
            this._config = value;
            this._init();
        }
        get config() {
            return this._config || [];
        }

        constructor() {
            super("Angular7xDetail");
        }

        _init() {
            if (!this._isValidConfig()) {
                return;
            }
            const element = this;
            if (this._initTimeout) {
                clearTimeout(this._initTimeout);
            }
            this._initTimeout = setTimeout(() => {
                this.initContext(() => {
                    this._moduleId = this._getSandboxModuleId();
                    this._subscribeOnEvents(element);
                    this._loadDetailModule();
                });
            }, 200)
        }

        _isValidConfig() {
            return !!this._getValueFromConfig('detailName') && !!this._getValueFromConfig('masterRecordId');
        }

        _getSandboxModuleId() {
            const moduleIdSuffix = this._getValueFromConfig('moduleIdSuffix')
            if (!moduleIdSuffix) {
                return this.sandbox.id + "_module_Angular7xDetailModule";
            }
            return this.sandbox.id + moduleIdSuffix;
        }

        _subscribeOnEvents(element) {
            this._subscribeOnGetDetailInfo();
            this._subscribeOnUpdateCardProperty(element);
        }

        _subscribeOnGetDetailInfo() {
            const scope = this;
            this.sandbox.subscribe("GetDetailInfo", function() {
                return {
                    detailName: scope._getValueFromConfig('detailName'),
                    schemaName: scope._getValueFromConfig('schemaName'),
                    masterRecordId: scope._getValueFromConfig('masterRecordId'),
                    defaultValues: scope.defaultValues,
                    isEnabled: true,
                    isFormPage: true
                };
            }, null, [this._moduleId]);
        }

        _subscribeOnUpdateCardProperty(element) {
            const scope = this;
            this.sandbox.subscribe("UpdateCardProperty", function(config) {
                if (scope._isNeedToFireDetailChanged(config)) {
                    const detailChangedEvent = new CustomEvent('detailChanged', { detail: scope._createDetailChangedEventData(scope) });
                    element.dispatchEvent(detailChangedEvent);
                }
            }, null, [this._moduleId]);
        }

        _loadDetailModule() {
            this.destroyed = new Promise((resolve) => {
                this.resolveDestroyedFn = function() {
                    resolve();
                };
            });
            this.sandbox.loadModule("DetailModuleV2", {
                renderTo: this._renderTo,
                id: this._moduleId,
            });
        }

        _saveDetail() {
            this.sandbox.publish("SaveDetail", null, [this._moduleId]);
        }

        _discardChangeDetail() {
            this.sandbox.publish("DiscardChanges", null, [this._moduleId]);
        }

        _isCurrentDetailInValue(value) {
            return Array.isArray(value) && value.includes(this._moduleId);
        }

        _isNeedToFireDetailChanged(config) {
            return (config.key == 'ShowSaveButton' || config.key == 'ShowDiscardButton') && config.value == true;
        }

        _createDetailChangedEventData(scope) {
            const moduleId = scope._moduleId;
            return {
                detailId: moduleId,
                saveChanges: () => {
                    return new Promise(function(resolve, reject) {
                        scope.sandbox.subscribe("DetailSaved", function(result) {
                            scope.sandbox.unsubscribePtp("DetailSaved", [moduleId]);
                            if (result.success) {
                                resolve();
                            } else {
                                reject(result);
                            }
                        }, null, [moduleId]);
                        scope._saveDetail();
                    });
                },
                discardChanges: () => {
                    scope._discardChangeDetail();
                    return Promise.resolve();
                },
                destroyed: () => {
                    return scope.destroyed;
                }
            }
        }

        _getValueFromConfig(propertyName) {
            return this.config.find((value) => value.name === propertyName)?.value;
        }

        disconnectedCallback() {
            this.sandbox.unloadModule(this._moduleId, this._renderTo);
            this.resolveDestroyedFn();
            super.disconnectedCallback();
        }

        getMessages() {
            const messages = super.getMessages();
            return Object.assign(messages, {
                "GetDetailInfo": {
                    mode: Terrasoft.MessageMode.PTP,
                    direction: Terrasoft.MessageDirectionType.SUBSCRIBE
                },
                "UpdateCardProperty": {
                    mode: Terrasoft.MessageMode.PTP,
                    direction: Terrasoft.MessageDirectionType.SUBSCRIBE
                },
                "DetailSaved": {
                    mode: Terrasoft.MessageMode.PTP,
                    direction: Terrasoft.MessageDirectionType.SUBSCRIBE
                },
                "SaveDetail": {
                    mode: Terrasoft.MessageMode.PTP,
                    direction: Terrasoft.MessageDirectionType.PUBLISH
                },
                "DiscardChanges": {
                    mode: Terrasoft.MessageMode.BROADCAST,
                    direction: Terrasoft.MessageDirectionType.PUBLISH
                }
            });
        }
    }

    customElements.define('crt-angular-7x-detail', CrtAngular7xDetailViewElement);
    sdk.registerViewElement({
        type: 'crt.Angular7XDetail',
        selector: 'crt-angular-7x-detail',
        inputs: {
            defaultValues: [],
            config: []
        },
        outputs: {
            detailChanged: {}
        }
    });

    return Terrasoft.Angular7xDetailModule;
});