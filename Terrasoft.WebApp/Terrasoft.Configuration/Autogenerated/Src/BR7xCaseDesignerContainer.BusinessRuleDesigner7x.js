 define("BR7xCaseDesignerContainer", ["BR7xCaseDesignerContainerResources"], function(resources) {

		Ext.define("Terrasoft.controls.BR7xCaseDesignerContainer", {
			extend: "Terrasoft.Container",
			alternateClassName: "Terrasoft.BR7xCaseDesignerContainer",

			/**
			 * @var {String} Condition header class name.
			 */
			conditionHeaderClass: "business-rule-case-condition-header",

			/**
			 * @var {String} Condition header icon class name.
			 */
			conditionHeaderIconClass: "business-rule-case-condition-header-icon",

			/**
			 * @var {String} Condition container class name.
			 */
			conditionContainerClass: "business-rule-case-condition-container",

			/**
			 * @var {String} Add condition button container class name.
			 */
			caseAddConditionClass: "business-rule-case-add-condition-button-wrapper",

			/**
			 * @var {String} Tagger container class name.
			 */
			caseElementTagger: "business-rule-case-element-tagger",

			/**
			 * @var {Array} Condition group view item.
			 */
			conditionGroup: null,

			/**
			 * @var {Object} Add condition button.
			 */
			addConditionButton: null,

			/**
			 * @inheritdoc Terrasoft.AbstractContainer#getTpl
			 * @overridden
			 */
			getTpl: function() {
				return [
					"<div id=\"{id}-wrap\" class=\"{wrapClass}\" style=\"{wrapStyle}\">",
						"<div id=\"{id}-conditionGroup\" class=\"{conditionContainerClass}\">",
							"{%this.renderViewItemsProperty(out, values, 'conditionGroup')%}",
							"<div id=\"{id}-addConditionButton\" class=\"{caseAddConditionClass}\">",
								"<label class=\"{caseElementTagger}\">",
									"{%this.renderViewItemsProperty(out, values, 'addConditionButton')%}",
								"</label>",
							"</div>",
						"</div>",
					"</div>"
				];
			},

			/**
			 * @inheritdoc Terrasoft.AbstractContainer#getViewItemsPropertyNames
			 * @overridden
			 */
			getViewItemsPropertyNames: function() {
				var viewItemsPropertyNames = this.callParent(arguments);
				viewItemsPropertyNames.push("conditionGroup", "addConditionButton");
				return viewItemsPropertyNames;
			},

			/**
			 * Returns a selectors of the control.
			 * @protected
			 * @return {Object} Selectors of the control.
			 */
			getSelectors: function() {
				return {
					wrapEl: "#" + this.id + "-wrap",
				};
			},

			/**
			 * @inheritdoc Terrasoft.Component#getTplData
			 * @overridden
			 */
			getTplData: function() {
				var tplData = this.callParent(arguments);
				var caseTplData = {
					itemsLength: this.items.length
				};
				var wrapClasses = ["business-rule-case"];
				if (this.wrapClass) {
					wrapClasses.push(this.wrapClass);
				}
				caseTplData.wrapClass = wrapClasses;
				caseTplData.conditionHeaderClass = this.conditionHeaderClass;
				caseTplData.conditionHeaderIconClass = this.conditionHeaderIconClass;
				caseTplData.conditionContainerClass = this.conditionContainerClass;
				caseTplData.caseAddConditionClass = this.caseAddConditionClass;
				caseTplData.caseElementTagger = this.caseElementTagger;
				Ext.apply(caseTplData, tplData, {});
				this.selectors = this.getSelectors();
				return caseTplData;
			}

			//endregion

		});
		return Terrasoft.BR7xCaseDesignerContainer;
	});
