define("SocialContactPage", ["ViewUtilities", "ConfigurationFileApi"], function(ViewUtilities) {
	return {
		entitySchemaName: "Contact",
		attributes: {
			/*
			 * ######### ########## ######## ## ######## ######## # ###. #####.
			 */
			ContactImages: {
				dataValueType: Terrasoft.DataValueType.COLLECTION
			},

			Name: {
				/*
				 * ####### ########### ## ############## ########.
				 */
				isRequired: false
			}
		},
		details: /**SCHEMA_DETAILS*/{
			ContactSocialCommunication: {
				schemaName: "ContactSocialCommunicationDetail",
				filter: {
					masterColumn: "Id",
					detailColumn: "Contact"
				}
			},
			ContactSocialAddress: {
				schemaName: "ContactSocialAddressDetail",
				filter: {
					masterColumn: "Id",
					detailColumn: "Contact"
				}
			},
			ContactSocialAnniversary: {
				schemaName: "ContactSocialAnniversaryDetail",
				filter: {
					masterColumn: "Id",
					detailColumn: "Contact"
				}
			}
		}/**SCHEMA_DETAILS*/,
		methods: {

			/**
			 * @inheritdoc Terrasoft.BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.addCurrentContactImage();
			},

			/**
			 * ######### ####### ########## ######## # ######### ########## ########.
			 * @private
			 */
			addCurrentContactImage: function() {
				var primaryImageColumnValue = this.get(this.primaryImageColumnName);
				var contactImageConfig = {
					index: 0,
					defaultImage: true,
					markerValue: "DefaultContactPhoto",
					image: {
						value: primaryImageColumnValue.value,
						url: this.getContactImageUrl(primaryImageColumnValue),
						source: this.Terrasoft.ImageSources.URL
					}
				};
				this.addContactImage(contactImageConfig);
			},

			/**
			 * ########## web-##### ########## ########.
			 * @param {String} primaryImageColumnValue ######## ####### ########### #######.
			 * @private
			 * @return {String} Web-##### ########## ########.
			 */
			getContactImageUrl: function(primaryImageColumnValue) {
				if (primaryImageColumnValue) {
					return this.getSchemaImageUrl(primaryImageColumnValue);
				}
				return this.getContactDefaultImageUrl();
			},

			/**
			 * ########## web-##### ########## ######## ## #########.
			 * @private
			 * @return {String} Web-##### ########## ######## ## #########.
			 */
			getContactDefaultImageUrl: function() {
				return this.Terrasoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.DefaultPhoto"));
			},

			/**
			 * ######### #### # ######### ########## ########.
			 * @protected
			 * @param {Object} config ############# ############ ##########.
			 * @param {String} config.id ############# ############ ########## # #########.
			 * @param {Object} config.image.source ### ######### ##########.
			 * @param {Object} config.image.url ##### ######### ##########.
			 * @param {Object} config.logo.source ### ######### ######## ##########.
			 * @param {Object} config.logo.url ##### ######### ######## ##########.
			 * @param {Number} config.index ####### # #########.
			 * @param {String} config.defaultImage ####### ############# ########## ## #########.
			 * @param {Number} config.markerValue ######## ########## DOM-######## data-item-marker.
			 * @param {Boolean} config.isEmptyImage ####### ####, ### #### - ### #### ## ######### ## ###. ####.
			 */
			addContactImage: function(config) {
				var defaultImage = config.defaultImage;
				var image = config.image;
				var id = config.id || this.Terrasoft.generateGUID();
				var vm = this.Ext.create("Terrasoft.BaseViewModel");
				vm.sandbox = this.sandbox;
				vm.set("Id", id);
				vm.set("IsDefaultImage", (defaultImage === true));
				vm.set("IsEmptyImage", config.isEmptyImage);
				vm.set("Image", image);
				vm.set("Logo", config.logo);
				vm.set("MarkerValue", config.markerValue);
				vm.on("change:ImageChecked", this.onItemImageChecked, this);
				vm.getEnabled = function() {
					return !this.get("IsEmptyImage") || this.get("IsDefaultImage");
				};
				vm.onSelectImage = function() {
					this.set("ImageChecked", true);
				};
				vm.onUnselectImage = function() {
					this.set("ImageChecked", false);
				};
				vm.getLogoButtonMarkerValue = function() {
					return Ext.String.format("{0} {1}", this.get("MarkerValue"), "Logo");
				};
				if (defaultImage) {
					vm.set("ImageChecked", "SelectedImage");
				}
				var index = config.index;
				var photos = this.get("ContactImages");
				if (index) {
					photos.add(id, vm, index);
				} else {
					photos.add(id, vm);
				}
				photos.loadAll();
			},

			/**
			 * ########## ######### ########## ######## # ######## ########## ########.
			 * @private
			 * @param {Object} model ###### ########## ########.
			 * @param {String} checkedValue ######## ########## ########.
			 */
			onItemImageChecked: function(model, checkedValue) {
				if (checkedValue !== "SelectedImage") {
					return;
				}
				var contactImages = this.get("ContactImages");
				var selectItemId = model.get("Id");
				contactImages.each(function(item) {
					var id = item.get("Id");
					if (id !== selectItemId) {
						item.onUnselectImage();
					}
				});
				var image = model.get("IsEmptyImage") ? null : model.get("Image");
				if (image || model.get("IsDefaultImage")) {
					this.changeContactImage(image);
				}
			},

			/*
			 * ######### # ############# ########## ########.
			 * @private
			 * @param {Object} image ############ ########### ##########.
			 * @param {Object} image.value ############# ### ########### ##########.
			 * @param {Object} image.url ##### ######### ##########.
			 */
			changeContactImage: function(image) {
				if (Ext.isEmpty(image) || image.hasOwnProperty("value")) {
					this.setContactImage(image ? image.value : null);
				} else {
					var uploadComplete = function(imageId) {
						image.value = imageId;
						this.setContactImage(imageId);
					};
					this.Terrasoft.ConfigurationFileApi.getImageFile(image.url, function(file) {
						this.Terrasoft.ImageApi.upload({
							file: file,
							onComplete: uploadComplete,
							onError: this.Terrasoft.emptyFn,
							scope: this
						});
					}, this);
				}
			},

			/*
			 * ############# ########## ########.
			 * @private
			 * @param {String} imageId ############# ##########.
			 */
			setContactImage: function(imageId) {
				var imageData = null;
				if (imageId) {
					imageData = {
						value: imageId,
						displayValue: "Photo"
					};
				}
				this.set(this.primaryImageColumnName, imageData);
			},

			/**
			 * ########## ############ ### ######### DOM ######## ############# #### ## ###### ########## ########.
			 * @private
			 */
			createPreviewImageButtonConfig: function() {
				return {
					className: "Terrasoft.Button",
					style: Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					tag: "previewImage",
					imageConfig: {bindTo: "Image"},
					classes: {
						wrapperClass: ["image-preview"]
					}
				};
			},

			/**
			 * ########## ############ ### ######### DOM ######## ############# ######## ###. #### ##### ####.
			 * @private
			 */
			createLogoButtonConfig: function() {
				return {
					className: "Terrasoft.Button",
					style: Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					tag: "logoUrl",
					imageConfig: {bindTo: "Logo"},
					classes: {
						wrapperClass: ["logo-image"]
					},
					markerValue: {
						bindTo: "getLogoButtonMarkerValue"
					}
				};
			},

			/**
			 * ########## ############ ### ######### DOM ######## ###### #### ## ###### ########## ########.
			 * @private
			 */
			createRadioButtonConfig: function() {
				return {
					className: "Terrasoft.RadioButton",
					markerValue: {bindTo: "MarkerValue"},
					tag: "SelectedImage",
					enabled: {bindTo: "getEnabled"},
					checked: {bindTo: "ImageChecked"}
				};
			},

			/**
			 * ########## ################ ############ ######## DOM ######### ### ###### ########## ########.
			 * @protected
			 * @param {Object} containerListItemConfig ############ ########.
			 * @param {Terrasoft.BaseViewModel} item ####### #########.
			 */
			getItemImageListViewConfig: function(containerListItemConfig, item) {
				var itemContainer =
					ViewUtilities.getContainerConfig("images-list-item-container", ["images-list-item-container"]);
				var containerItems = itemContainer.items;
				var previewImageButton = this.createPreviewImageButtonConfig(item);
				containerItems.push(previewImageButton);
				if (item.get("Logo")) {
					var logoButton = this.createLogoButtonConfig(item);
					containerItems.push(logoButton);
				}
				var radioButton = this.createRadioButtonConfig(item);
				containerItems.push(radioButton);
				containerListItemConfig.config = itemContainer;
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Name",
				"values": {
					"caption": {"bindTo": "CaptionName"},
					"enabled": false,
					"layout": {"column": 0, "row": 0, "colSpan": 12}
				}
			},
			{
				"operation": "insert",
				"parentName": "CardContentContainer",
				"propertyName": "items",
				"name": "ImageListContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["header-container-margin-bottom", "width-auto"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ContactImageList",
				"parentName": "ImageListContainer",
				"propertyName": "items",
				"values": {
					"generateId": true,
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "Id",
					"collection": "ContactImages",
					"onGetItemConfig": "getItemImageListViewConfig",
					"dataItemIdPrefix": "image-item",
					"classes": {
						wrapClassName: ["contact-image-list"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "CardContentContainer",
				"propertyName": "items",
				"name": "ContactSocialCommunication",
				"values": {
					"itemType": Terrasoft.ViewItemType.DETAIL,
					"classes": {
						wrapClassName: ["social-communication-detail-container"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "CardContentContainer",
				"propertyName": "items",
				"name": "ContactSocialAddress",
				"values": {
					"itemType": Terrasoft.ViewItemType.DETAIL,
					"classes": {
						wrapClassName: ["social-address-detail-container"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "CardContentContainer",
				"propertyName": "items",
				"name": "ContactSocialAnniversary",
				"values": {
					"itemType": Terrasoft.ViewItemType.DETAIL,
					"classes": {
						wrapClassName: ["social-Anniversary-detail-container"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "NotesControlGroup",
				"parentName": "CardContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": {"bindTo": "Resources.Strings.NotesControlGroupCaption"}
				}
			},
			{
				"operation": "insert",
				"name": "Notes",
				"parentName": "NotesControlGroup",
				"propertyName": "items",
				"values": {
					"contentType": Terrasoft.ContentType.RICH_TEXT,
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"labelConfig": {
						"visible": false
					},
					markerValue: "Notes"
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
