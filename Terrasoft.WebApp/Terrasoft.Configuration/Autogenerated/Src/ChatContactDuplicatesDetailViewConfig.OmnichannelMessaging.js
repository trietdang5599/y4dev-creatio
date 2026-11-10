define("ChatContactDuplicatesDetailViewConfig", ["DuplicatesDetailViewConfigV2Resources", "DuplicatesDetailViewConfigV2", "ControlGridModule"],
	function(resources) {
		Ext.define("Terrasoft.configuration.ChatContactDuplicatesDetailViewConfig", {
			extend: "Terrasoft.DuplicatesDetailViewConfig",
			alternateClassName: "Terrasoft.ChatContactDuplicatesDetailViewConfig",

			/**
			 * @protected
			 */
			getDuplicatesDetailGridViewConfig: function () {
				const config = this.callParent(arguments);
				return Ext.apply(config, {
					"className": "Terrasoft.ControlGrid",
					"applyControlConfig": {"bindTo": "applyControlConfig"},
					"controlColumnName": "Name",
				});
			}
		});
	});
