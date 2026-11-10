define("SocialAnniversaryDetail", [], function() {
	return {
		methods: {

			/**
			 * @inheritdoc Terrasoft.SocialAnniversaryDetail#createSocialEntityDataRows
			 * @overridden
			 */
			createSocialEntityDataRows: function(config) {
				if (!config) {
					return;
				}
				var socialNetworkData = config.socialNetworkData;
				if (this.Ext.isEmpty(socialNetworkData)) {
					return;
				}
				var collection = this.Ext.create("Terrasoft.Collection");
				this.addFoundedInformation(collection, socialNetworkData);
				config.callback.call(config.scope || this, collection);
			},

			/**
			 * ######### ########## # ############## ######## ## ######## ####### # #########, ####### ##### #########
			 * ######.
			 * @protected
			 * @param {Terrasoft.Collection} collection #########.
			 * @param {Array} entities ########## # ######### ## ######## #######.
			 */
			addFoundedInformation: function(collection, entities) {
				this.Terrasoft.each(entities, function(entity) {
					var founded = entity.founded;
					if (!founded) {
						return;
					}
					var date = new Date(founded);
					if (isNaN(date.getDate())) {
						return;
					}
					collection.add({
						Date: date
					});
				}, this);
			}

		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
