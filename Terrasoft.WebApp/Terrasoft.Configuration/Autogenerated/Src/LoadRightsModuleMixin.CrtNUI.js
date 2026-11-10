define("LoadRightsModuleMixin", [], function() {
    Ext.define("Terrasoft.configuration.mixins.LoadRightsModuleMixin", {
        alternateClassName: "Terrasoft.LoadRightsModuleMixin",

        /**
         * @public
         */
        loadRightsModule: function ({ payload }) {
            const {
                entitySchemaName,
                entitySchemaCaption,
                primaryColumnValue,
                primaryDisplayColumnValue,
				hideAdditionalLookupButtons
            } = payload;
            const sandboxId = this.sandbox.id + "_Rights";
            this.sandbox.subscribe("GetRecordInfo", function() {
                return {
                    entitySchemaName,
                    entitySchemaCaption,
                    primaryColumnValue,
                    primaryDisplayColumnValue,
					hideAdditionalLookupButtons
                };
            }, [sandboxId]);
            this.sandbox.loadModule("Rights", {
                renderTo: "centerPanel",
                id: sandboxId,
                keepAlive: true
            });
        },
    });
    
    return Terrasoft.LoadRightsModuleMixin;
});