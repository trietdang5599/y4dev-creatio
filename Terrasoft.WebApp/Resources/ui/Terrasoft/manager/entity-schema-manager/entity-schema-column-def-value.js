/**
 */
Ext.define("Terrasoft.manager.EntitySchemaColumnDefValue", {
    extend: "Terrasoft.core.BaseObject",
    alternateClassName: "Terrasoft.EntitySchemaColumnDefValue",

    mixins: {
        serializable: "Terrasoft.Serializable"
    },

    //region Properties: Protected

    /**
     * List of serializable parameters.
     * @protected
     * @type {String[]}
     */
    serializableProperties: ["valueSourceType", "value", "valueSource", "sequencePrefix", "sequenceNumberOfChars"],

    //endregion

    //region Properties: Public
    
    /**
     * Source type of default value.
     * @type {Terrasoft.EntitySchemaColumnDefSource}
     */
    valueSourceType: Terrasoft.EntitySchemaColumnDefSource.NONE,
    
    /**
     * Object containing default value.
     * @type {Object}
     */
    value: null,
    
    /**
     * Source of default value as string.
     * @type {String}
     */
    valueSource: null,
    
    /**
     * Prefix of sequence default value.
     * @type {String}
     */
    sequencePrefix: null,
    
    /**
     * Number of digits in sequence default value.
     * @type {Number}
     */
    sequenceNumberOfChars: null,
    
    //endregion

});
