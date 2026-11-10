 define("AuthInfoPasswordValuePage", [], function() {
	return {
		attributes: {
			/**
			 * Name of property in auth info.
			 */
			AuthInfoPropertyName: {
				value: "password"
			}
		},
		methods: {

			/**
			 * @inheritdoc Terrasoft.BaseServiceParameterValuePage#getSysSettingsDataValueTypeFilter
			 * @protected
			 * @override
			 */
			getSysSettingsDataValueTypeFilter: function() {
				return Terrasoft.createColumnInFilterWithParameters("ValueTypeName", ["SecureText"]);
			}

		},
		diff: [
			{
				operation: "merge",
				name: "ValueCaption",
				values: {
					className: "Terrasoft.TipLabel",
					click: "$showTipOnLabelClick",
					tag: "PasswordHintVisible",
					tips: [{
						content: "$Resources.Strings.PasswordHint",
						visible: { bindTo: "PasswordHintVisible" }
					}]
				}
			},
			{
				operation: "merge",
				name: "TextValue",
				values: {controlConfig: {protect: true}}
			}
		]
	};
});
