define("BaseMiniPage", [],
	function() {
		return {
			messages: {
				"EntityInitialized": {
					"mode": Terrasoft.MessageMode.BROADCAST,
					"direction": Terrasoft.MessageDirectionType.BIDIRECTIONAL
				}
			},
			methods: {

				//region Methods: Protected

				/**
				 * @inheritdoc BaseMiniPage#onEntityInitialized
				 * @protected
				 * @overridden
				 */
				onEntityInitialized: function(callback, scope) {
					this.callParent([function() {
						if (this.entitySchemaName === "Activity") {
							this.$OldStartDate =  this.$StartDate;
						}
						this.sandbox.publish("EntityInitialized", null, [this.sandbox.id]);
						Ext.callback(callback, scope);
					}, this]);
				},

				//endregion

				//region Methods: Public

				/**
				 * Cancel save user action.
				 */
				cancelSave: function () {
					this.close();
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
