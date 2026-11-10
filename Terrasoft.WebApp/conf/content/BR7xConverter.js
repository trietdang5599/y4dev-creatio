Terrasoft.configuration.Structures["BR7xConverter"] = {innerHierarchyStack: ["BR7xConverter"]};
define("BR7xConverter", ["BusinessRuleModule", "ToMetaItemBR7xConverter",
	"FromMetaItemBR7xConverter"], function(BusinessRuleModule) {

		/**
		 * @class Terrasoft.configuration.BR7xConverter
		 * BR7xConverter class.
		 */
		Ext.define("Terrasoft.configuration.BR7xConverter", {
			extend: "Terrasoft.BaseObject",
			alternateClassName: "Terrasoft.BR7xConverter",

			// region Properties: Private

			/**
			 * Entity schema.
			 * @private
			 * @type {Terrasoft.BaseEntitySchema}
			 */
			entitySchema: null,

			/**
			 * Page schema.
			 * @private
			 * @type {Object}
			 */
			pageSchema: null,

			// endregion

			// region Methods: Private

			/**
			 * Prepares parameters for constructor.
			 * @return {Object} Parameters for constructor.
			 */
			prepareConstructorParameters: function() {
				return {
					expressionTypeMap: {
						"ConstantBusinessRuleExpression": BusinessRuleModule.enums.ValueType.CONSTANT,
						"ColumnBusinessRuleExpression": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"AttributeBusinessRuleExpression": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"SysSettingBusinessRuleExpression": BusinessRuleModule.enums.ValueType.SYSSETTING,
						"SysValueBusinessRuleExpression": BusinessRuleModule.enums.ValueType.SYSVALUE,
						"ParameterBusinessRuleExpression": BusinessRuleModule.enums.ValueType.PARAMETER,
						"FormulaBusinessRuleExpression": BusinessRuleModule.enums.ValueType.FORMULA
					},
					entitySchema: this.entitySchema,
					pageSchema: this.pageSchema
				};
			},

			// endregion

			// region Methods: Public

			/**
			 * Converts old business rule config to metaItem config.
			 * @param {Object} config Old business rule config.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			convertToMetaItemConfig: function(config, callback, scope) {
				const converter = new Terrasoft.ToMetaItemBR7xConverter(this.prepareConstructorParameters());
				converter.convertToMetaItemConfig(config, callback, scope);
			},

			/**
			 * Converts metaItems to old business rule config.
			 * @param {Terrasoft.BusinessRuleSchema} rule Rule.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			convertFromMetaItems: function(rule, callback, scope) {
				const converter = new Terrasoft.FromMetaItemBR7xConverter(this.prepareConstructorParameters());
				converter.convertFromMetaItems(rule, callback, scope);
			}

			// endregion

		});
		return Terrasoft.BR7xConverter;
	});


