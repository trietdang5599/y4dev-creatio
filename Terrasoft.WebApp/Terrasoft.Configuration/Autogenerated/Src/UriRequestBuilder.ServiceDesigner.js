define("UriRequestBuilder", ["UriJsonConverter"], function() {
	return {
		attributes: {

			/**
			 * Request URI.
			 */
			Uri: {
				dataValueType: Terrasoft.DataValueType.TEXT
			},

			/**
			 * Indicates if response parameters can be set up.
			 */
			SetupMethodType: { value: false }

		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_getUriParametersJson: function() {
				const uriConverter = new Terrasoft.UriJsonConverter();
				return uriConverter.convert(this.$Uri);
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.ServiceMethodBuilder#getMergeOptions
			 * @override
			 */
			getMergeOptions: function() {
				return {
					skipUri: false,
					skipHttpMethodType: true
				};
			},

			/**
			 * @inheritdoc Terrasoft.ServiceMethodBuilder#parseMethod
			 * @override
			 */
			parseMethod: function() {
				var method;
				const metaDataConverter = this.Ext.create("Terrasoft.JsonServiceMetaDataConverter", {
					codePrefix: Terrasoft.ServiceSchemaManager.schemaNamePrefix
				});
				method = metaDataConverter.convert(this._getUriParametersJson());
				this.prepareUri(method);
				return method;
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritDoc Terrasoft.ModalBoxSchemaModule#init.
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([
					function() {
						var moduleInfo = this.get("moduleInfo") || {};
						this.$Uri = moduleInfo.uri;
						this.parse();
						Ext.callback(callback, scope);
					}, this
				]);
			}

			//endregion
		}
	};
});
