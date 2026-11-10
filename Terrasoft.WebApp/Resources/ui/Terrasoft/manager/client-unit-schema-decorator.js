/**
 * A utility class for working with schemas and packages.
 */
Ext.define("Terrasoft.manager.ClientUnitSchemaDecorator", {
	extend: "Terrasoft.BaseObject",
	alternateClassName: "Terrasoft.ClientUnitSchemaDecorator",

	getDependOnSchemes: function(schema, callback, scope) {
		Terrasoft.chain(
			function(next) {
				Terrasoft.EntitySchemaManager.initialize(next, this);
			},
			function(next) {
				Terrasoft.ClientUnitSchemaManager.initialize(next, this);
			},
			function() {
				const schemaManagerItems = [];
				schema.dependencies.each(function(dependOnSchemaUId) {
					let schemaManagerItem = Terrasoft.ClientUnitSchemaManager.items.find(dependOnSchemaUId);
					if (!schemaManagerItem) {
						schemaManagerItem = Terrasoft.EntitySchemaManager.items.find(dependOnSchemaUId);
					}
					schemaManagerItems.push(schemaManagerItem);
				}, this);
				Terrasoft.ClientUnitSchemaManager.getInstances(schemaManagerItems, callback, scope);
			},
			this
		);
	},

	getCommonSchemaHash: function(schema) {
		const result = schema.uId;
		return result;
	},

	getSchemaPath: function(schema) {
		const basePath = "../../configuration/";
		const result = basePath + (Terrasoft.instanceOfClass(schema, "Terrasoft.EntitySchema") ? "entityschema/" : "") +
			this.getCommonSchemaHash(schema);
		return result;
	},

	getModuleCss: function(schema, identifiersQuote) {
		let result = "";
		if (Terrasoft.instanceOfClass(schema, "Terrasoft.ClientUnitSchema")) {
			result = (schema.SchemaType === Terrasoft.SchemaType.MODULE && !Ext.isEmpty(schema.css))
				? ", " + identifiersQuote + "css" + identifiersQuote + ": [\"" + schema.name + "\"]"
				: "";
		}
		return result;
	},

	getSchemaMessagesContract: function(schema) {
		const result = [];
		if (Terrasoft.instanceOfClass(schema, "Terrasoft.ClientUnitSchema")) {
			const messages = [];
			if (schema.messages.getCount() > 0) {
				result.push(",\"messages\": {");
				schema.messages.each(function(message) {
					const messageTpl = "\t\t\"{0}\": { \"direction\": \"{1}\", \"mode\": \"{2}\" }";
					messages.push(Ext.String.format(messageTpl, message.name, message.directionType, message.mode));
				}, this);
				result.push(messages.join(","));
				result.push("\t}");
			} else {
				result.push(",\"messages\": {}");
			}
		}
		return result.join("\n");
	},

	getSchemaDescriptor: function(schema) {
		const result = [],
			identifiersQuote = "";
		result.push("{" + identifiersQuote + "path" + identifiersQuote + ": \"");
		result.push(this.getSchemaPath(schema) + "\"");
		result.push(this.getModuleCss(schema, identifiersQuote));
		result.push(this.getSchemaMessagesContract(schema) + "}");
		return result.join("");
	},

	generateSchemaRequirementsBlock: function(dependOnSchemes) {
		const result = [];
		Terrasoft.each(dependOnSchemes, function(schema) {
			result.push("core.setModuleDescriptor('" + schema.name + "', " + this.getSchemaDescriptor(schema) + ");");
		}, this);
		return result.join("\n");
	},

	generateDescriptorSetters: function(schema, callback, scope) {
		let dependOnSchemes,
			result = [];
		Terrasoft.chain(
			function(next) {
				this.getDependOnSchemes(schema, function(getDependOnSchemesResult) {
					dependOnSchemes = getDependOnSchemesResult;
					next();
				}, this);
			},
			function() {
				result.push("var core = require(\"core\");");
				result.push(this.generateSchemaRequirementsBlock(dependOnSchemes));
				callback.call(scope, result.join("\n"));
			},
			this
		);
	},

	getSchemaHierarchicalName: function(requestedSchema, schema) {
		let schemaHierarchicalName = schema.name;
		if (schema.realUId !== requestedSchema.realUId) {
			schemaHierarchicalName += schema.packageUId;
		}
		return schemaHierarchicalName;
	},

	appendLocalizableStrings: function(localizableStrings, variableName) {
		const result = [];
		if (localizableStrings.getCount() === 0) {
			result.push("var " + variableName + "={};");
		} else {
			result.push("var " + variableName + "={");
			const tmp = [];
			localizableStrings.eachKey(function(schemaLocalizableStringName, schemaLocalizableString) {
				let resultLocalizableString = "\t" + schemaLocalizableStringName + ": '";
				const localizableStringValue = schemaLocalizableString.getValue();
				if (localizableStringValue) {
					resultLocalizableString += localizableStringValue.replace("\"", "\\").replace("\"", "\\\"")
						.replace("\r\n", "\n").replace("\n", "\\n").replace("'", "\'");
				}
				resultLocalizableString += "'";
				tmp.push(resultLocalizableString);
			}, this);
			result.push(tmp.join(","));
			result.push("};");
		}
		return result.join("\n");
	},

	generateSchemaResourcesBlock: function(schema, schemaPackageName) {
		const result = [];
		result.push("define(\"" + Ext.String.format("{0}Resources", schemaPackageName) +
			"\", ['terrasoft'], function(Terrasoft) {");
		result.push(this.appendLocalizableStrings(schema.localizableStrings, "localizableStrings"));
		result.push("return {localizableStrings:localizableStrings};");
		result.push("});");
		return result.join("\n");
	},

	addResources: function(schema, schemas) {
		const result = [];
		Terrasoft.each(schemas, function(clientUnitSchema) {
			const schemaPackageName = this.getSchemaHierarchicalName(schema, clientUnitSchema);
			result.push(this.generateSchemaResourcesBlock(clientUnitSchema, schemaPackageName));
		}, this);
		return result.join("\n");
	},

	addStructures: function(schema, schemas) {
		const result = [];
		Terrasoft.each(schemas, function(clientUnitSchema) {
			if (clientUnitSchema.SchemaType !== Terrasoft.SchemaType.MODULE) {
				const schemaHierarchicalName = this.getSchemaHierarchicalName(schema, clientUnitSchema);
				const parentSchemaUIdString = clientUnitSchema.parentSchemaUId;
				let defineStructureCode = Ext.String.format((clientUnitSchema.autogeneratedCode || ""),
					schemaHierarchicalName, "", clientUnitSchema.uId, schemaHierarchicalName, parentSchemaUIdString,
					clientUnitSchema.extendParent
				);
				let parentSchemaName = "";
				const parentSchemaUId = clientUnitSchema.parentSchemaUId;
				if (parentSchemaUId) {
					parentSchemaName = clientUnitSchema.extendParent
						? ""
						: Terrasoft.ClientUnitSchemaManager.getItem(clientUnitSchema.parentSchemaUId).name;
				}
				defineStructureCode = defineStructureCode.replace("schemaName:",
					Ext.String.format("schemaCaption: '{0}', parentSchemaName: '{1}', schemaName:",
						clientUnitSchema.caption.getValue(), parentSchemaName || ""));
				result.push(defineStructureCode);
			}
		}, this);
		return result.join("\n");
	},

	addBodies: function(requestedSchema, schemas) {
		const result = [];
		Terrasoft.each(schemas, function(schema) {
			const schemaHierarchyName = this.getSchemaHierarchicalName(requestedSchema, schema);
			result.push(schema.body.replace(requestedSchema.name, schemaHierarchyName));
		}, this);
		return result.join("\n");
	},

	decorate: function(schema, callback, scope) {
		const result = [];
		let schemaHierarchy = [];
		if (this.schemaType !== Terrasoft.SchemaType.UNIT_TEST_MODULE) {
			Terrasoft.chain(
				function(next) {
					this.generateDescriptorSetters(schema, function(generateDescriptorSettersResult) {
						result.push(generateDescriptorSettersResult);
						next();
					}, this);
				},
				function(next) {
					Terrasoft.SchemaDesignerUtilities.getSchemaHierarchy(schema, function(getResult) {
						schemaHierarchy = getResult;
						next();
					}, this);
				},
				function(next) {
					result.push(this.addResources(schema, schemaHierarchy));
					result.push(this.addStructures(schema, schemaHierarchy));
					result.push(this.addBodies(schema, schemaHierarchy));
					next();
				},
				function() {
					callback.call(scope, result.join("\n"));
				},
				this
			);
		} else {
			callback.call(scope);
		}
	}

});
