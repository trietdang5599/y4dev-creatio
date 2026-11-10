/**
 * Process element schema item to diagram element type resolver.
 */
Ext.define("Terrasoft.diagram.ProcessDiagramTypeResolver", {
	alternateClassName: "Terrasoft.mixins.ProcessDiagramTypeResolver",

	_elementConstSize: Terrasoft.diagram.enums.ProcessDiagramUnsupportedElemenetConst.size,

	// #region Methods: Private

	/**
	 * @private
	 */
	_getElementSize: function(type) {
		let width, height;
		if (Terrasoft.diagram.enums.ProcessDiagramUnsupportedSquareTypes.indexOf(type) > -1) {
			width = height = this._elementConstSize.round.diameter;
		} else {
			width = this._elementConstSize.rectangle.width;
			height = this._elementConstSize.rectangle.height;
		}
		return {width: width, height: height};
	},

	/**
	 * @private
	 */
	_getElementLargeImage: function(type) {
		return {largeImage: Terrasoft.toCamelCase(type) + "Large.svg"};
	},

	// #endregion

	// #region Methods: Public

	/**
	 * Finds diagram type by element item.
	 * @public
	 * @param {String} item process element schema item.
	 * @return {String} diagram type name.
	 */
	toDiagramType: function(item) {
		let type;
		if (["Terrasoft.manager.ProcessUnsupportedElementSchema",
			"Terrasoft.manager.ProcessUnsupportedTerminateEventSchema",
			"Terrasoft.manager.ProcessBoundaryEventSchema"]
			.includes(item.$className)) {
			type = item.unsupportedType;
		} else {
			type = Terrasoft.ProcessDiagramTypesEnum[item.$className];
		}
		return type;
	},

	/**
	 * Returns diagram type name.
	 * @param item Process element schema item.
	 * @return {String}
	 */
	toDiagramTypeName: function(item) {
		switch (item.$className) {
			case "Terrasoft.manager.ProcessFormulaTaskSchema":
			case "Terrasoft.manager.ProcessUserTaskSchema":
			case "Terrasoft.manager.ProcessSchemaUserTask":
			case "Terrasoft.manager.ProcessWebServiceSchema":
				return Terrasoft.toLowerCamelCase(item.name);
			case "Terrasoft.manager.ProcessEndEventSchema":
				return "endEvent2";
			default:
				return this.toDiagramType(item);
		}
	},

	/**
	 * Returns diagram unsupported element config.
	 * @param type Unsupported element type name.
	 * @return {Object | null}
	 */
	getUnsupportedElementConfig: function(type) {
		if (Terrasoft.ProcessDiagramUnsupportedTypes.indexOf(type) < 0) {
			return null;
		}
		const unsupportedElementConfig = Object.assign(
			{type: type},
			this._getElementSize(type),
			this._getElementLargeImage(type));
		const transformToType = Terrasoft.UnsupportedTypeToUserTaskType[type];
		if (transformToType) {
			unsupportedElementConfig.transformToType = transformToType;
		}
		return unsupportedElementConfig;
	}

	// # endregion

});
