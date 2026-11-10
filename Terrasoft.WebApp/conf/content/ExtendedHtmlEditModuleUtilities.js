Terrasoft.configuration.Structures["ExtendedHtmlEditModuleUtilities"] = {innerHierarchyStack: ["ExtendedHtmlEditModuleUtilities"]};
define("ExtendedHtmlEditModuleUtilities", [], function() {

	/**
	 * @class Terrasoft.configuration.ExtendedHtmlEditModuleUtilities
	 */
	Ext.define("Terrasoft.configuration.mixins.ExtendedHtmlEditModuleUtilities", {
		alternateClassName: "Terrasoft.ExtendedHtmlEditModuleUtilities",

		//region Methods: Private
		_getTemplateBody: function(args, callback, scope) {
			const selectedItems = args.selectedRows.getItems();
			if (!selectedItems.length) {
				return Ext.callback(callback, scope, [args]);
			}
			const item = selectedItems[0];
		
			this.getEsqTemplateBody(item.Id, function(result) {
				const items = result.collection.getItems();
				item.Body =items[0].$Body;
				return Ext.callback(callback, scope, [args]);
			}, this);
		},

		getEsqTemplateBody: function(id, callback, scope) {
			if (id === undefined || id === null) {
				return Ext.callback(callback, scope, [null]);
			}

			const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
				rootSchemaName: "EmailTemplate"
			});
			esq.addColumn("Body");
			const idFilter = esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
				"Id", id);
			esq.filters.add("IdFilter", idFilter);
			esq.getEntityCollection(function(result) {
				return Ext.callback(callback, scope, [result]);
			}, this);
		},

		//endregion

		/**
		 * @inheritdoc Terrasoft.BasePageV2#init
		 * @overridden
		 */
		init: function() {
			var entitiesList = this.Ext.create("Terrasoft.Collection");
			this.set("entitiesList", entitiesList);
		},

		/**
		 * Fills entities list.
		 * @protected
		 * @param {String} filterValue Filter value
		 * @param {Terrasoft.Collection} list Collection
		 */
		prepareEntitiesExpandableList: function(filterValue, list) {
			this.getEntities(filterValue, function(entities) {
				var result = this.prepareEntities(entities);
				list.clear();
				list.loadAll(result);
			}, this);
		},

		/**
		 * Returns entities for list.
		 * @protected
		 * @param {Terrasoft.Collection} entities
		* @return {Object}
		 */
		prepareEntities: function(entities) {
			var result = {};
			entities.each(function(entity) {
				var primaryColumnValue = entity.get("Id");
				result[primaryColumnValue] = this.prepareEntity(entity);
			}, this);
			return result;
		},

		/**
		 * Returns entity for list.
		 * @protected
		 * @param {Terrasoft.BaseViewModel} entity
		 * @return {Object}
		 */
		prepareEntity: function(entity) {
			var body = entity.get("Body");
			var value = entity.get("Name");
			var id = entity.get("Id");
			return {
				value: value.replace(/"/g, "'"),
				displayValue: value,
				body: body,
				id : id
			};
		},

		/**
		 * Render list item event handler.
		 * @protected
		 * @param {Object} item List element
		 */
		onEntitiesListViewItemRender: function(item) {
			/*jshint quotmark: false */
			var displayValue = item.value;
			var primaryInfoHtml = [
				"<label class='listview-item-primaryInfo' data-value='" + displayValue + "'>",
				displayValue.toString(),
				"</label>"
			].join("");

			var tpl = [
				"<div class='listview-item' data-value='" + displayValue + "'>",
				primaryInfoHtml,
				"</div>"
			];
			item.customHtml = tpl.join("");
			/*jshint quotmark: true */
		},

		/**
		 * Returns entities by filter.
		 * @protected
		 * @throws {Terrasoft.ArgumentNullOrEmptyException}
		 * @param {String} filterValue Filter value
		 * @param {Function} callback
		 * @param {Object} scope Execution scope
		 */
		getEntities: function(filterValue, callback, scope) {
			if (this.Ext.isEmpty(filterValue)) {
				throw this.Ext.create("Terrasoft.ArgumentNullOrEmptyException");
			}
			var esq = this.getEsqForRetrivingEntities();
			esq.getEntityCollection(function(response) {
				if (response && response.success) {
					callback.call(scope, response.collection);
				}
			}, this);
		},

		/**
		 * Returns instance of Terrasoft.EntitySchemaQuery for search entities by filter.
		 * @protected
		 * @param {String} filterValue Filter value.
		 * @return {Terrasoft.EntitySchemaQuery} Query for retriving entities.
		 */
		getEsqForRetrivingEntities: function(filterValue) {
			var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
				rootSchemaName: "EmailTemplate"
			});
			esq.addColumn("Name");
			var paramDataType = this.Terrasoft.DataValueType.TEXT;
			var lookupFilter = this.Terrasoft.createColumnFilterWithParameter(this.Terrasoft.ComparisonType.START_WITH,
				"Name", filterValue, paramDataType);
			esq.filters.addItem(lookupFilter);
			esq.filters.addItem(this.getFilterForObject());
			return esq;
		},

		/**
		 * Returns filter to filter entities by current schema.
		 * @private
		 * @return {Terrasoft.CompareFilter} Filter by schema name.
		 */
		getFilterForObject: function() {
			var objectFilterGroup = this.Terrasoft.createFilterGroup();
			objectFilterGroup.logicalOperation = this.Terrasoft.LogicalOperatorType.OR;
			var sectionEntitySchema = this.get("SectionEntitySchemaName");
			objectFilterGroup.addItem(this.Terrasoft.createColumnFilterWithParameter(
				this.Terrasoft.ComparisonType.EQUAL, "[SysSchema:UId:Object].Name",
				sectionEntitySchema || this.entitySchemaName));
			objectFilterGroup.addItem(this.Terrasoft.createColumnIsNullFilter("Object"));
			return objectFilterGroup;
		},

		/**
		 * Open e-mail templates lookup button handler.
		 * @param {Object} control CKEditor
		 * @protected
		 */
		onOpenEmailTemplate: function(control) {
			var config = {
				entitySchemaName: "EmailTemplate",
				columns: ["Subject"],
				multiSelect: false
			};
			var callback = function(args) {
				this.onOpenEmailTemplateCallback(args, control);
			};
			const filterGroup = this.Terrasoft.createFilterGroup();
			filterGroup.addItem(this.getFilterForObject());
			filterGroup.addItem(this.Terrasoft.createColumnFilterWithParameter(this.Terrasoft.ComparisonType.EQUAL,
				"TemplateType", "74FF0CEE-6593-482F-A62F-6DDE6E17AB5E"));
			config.filters = filterGroup;
			this.openLookup(config, callback, this);
		},

		/**
		 * Open e-mail templates lookup button handler callback.
		 * @param {Object} args Context arguments
		 * @param {Object} control
		 * @protected
		 */
		onOpenEmailTemplateCallback: function(args, control) {
			this._getTemplateBody(args, function(result) {
				this.addCallBack(result, control);
			}, this);
		},

		/**
		 * On select item callback.
		 * @param {Object} args
		 * @param {Object} result
		 * @protected
		 */
		addCallBack: function(args, result) {
			var selectedItems = args.selectedRows.getItems();
			if (!selectedItems.length) {
				return;
			}
			var item = {
				body: selectedItems[0].Body,
				value: selectedItems[0].Name,
				isFromButton: true
			};
			const extendedHtmlEditModule = result.control;
			extendedHtmlEditModule.setTrackingValue(item, function(bodyValue) {
				bodyValue = bodyValue || extendedHtmlEditModule.getBodyValue() || Terrasoft.emptyString;
				this.set("Body", bodyValue.trim());
			}, this);
		}
	});
});


