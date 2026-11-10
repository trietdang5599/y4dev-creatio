 define("JoinLinkGenerationMixin", ["terrasoft"],
	function(Terrasoft) {
	 
		/**
		 * @class Terrasoft.configuration.mixins.JoinLinkGenerationMixin
		 * The mixin can generate join link.
		 */
		Ext.define("Terrasoft.configuration.mixins.JoinLinkGenerationMixin", {
			alternateClassName: "Terrasoft.JoinLinkGenerationMixin",
			// region Methods: Private

			/**
			 * Join link
			 * @private
			 */
			_joinLink: "",

			/**
			 * Get a list of meeting service link masks.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 * @private
			 */
			_getMeetingServicesLinkMasks: function(callback, scope) {
				if (!this.getIsFeatureEnabled("NewMeetingIntegration")) {
					return;
				}
				const linkMasks = [];
				const esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: "MeetingServiceLink",
					clientESQCacheParameters: {
						cacheLevel: Terrasoft.ESQServerCacheLevels.SESSION,
						cacheGroup: "MeetingServiceLink" + Terrasoft.SysValue.CURRENT_USER.value,
						cacheItemName: "MeetingServiceLink"
					}
				});
				esq.addColumn("LinkMask");
				esq.getEntityCollection(function(response) {
					if (response.success && response.collection) {
						Terrasoft.each(response.collection.getItems(), function(item) {
							linkMasks.push(item.get("LinkMask"));
						}, this);
					}
					Ext.callback(callback, scope || this, [linkMasks]);
				}, this);
			},

			/**
			 * Get regexp for meeting services links.
			 * @private
			 * @param {Array} links List of meeting services links.
			 * @returns {Object} Regexp. 
			 */
			_getMeetingLinksRegex: function(links) {
				let expression = Ext.String.format("({0})", links.join('|'));
				return new RegExp(expression, 'g');
			},

			// endregion

			// region Methods: Protected

			/**
			 * Generating a link to connect to the meeting service.
			 * @protected
			 */
			initMeetingServicesJoinLink: function(callback, scope) {
				const urls = this.getUrlsFromNotes();
				if (!urls.length) {
					callback.call(scope || this, "");
					return;
				}
				Terrasoft.chain(
					function(next) {
						this._getMeetingServicesLinkMasks(next, this);
					},
					function(next, linkMasks) {
						if (linkMasks.length) {
							const linksRegex = this._getMeetingLinksRegex(linkMasks);
							for (const url of urls) {
								if (linksRegex.test(url)) {
									this._joinLink = url;
									break;
								}
							}
						}
						if (callback) {
							callback.call(scope || this, this._joinLink);
						}
					}, this
				);
			},

			/**
			 * Get all links from activity notes.
			 * @protected 
			 */
			getUrlsFromNotes: function() {
				const notes = this.get("Notes");
				return notes ? Terrasoft.getUrls(notes) : [];
			},

			/**
			* Open the link to the meeting service.
			* @protected
			*/
			openMeetingServiceLink: function() {
				window.open(this._joinLink, "_blank");
			}
			// endregion 
		});
	});