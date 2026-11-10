Terrasoft.configuration.Structures["SectionCasesWizard"] = {innerHierarchyStack: ["SectionCasesWizard"]};
define("SectionCasesWizard", ["ext-base", "terrasoft", "SectionCasesWizardResources", "PackageUtilities",
		"SectionWizard", "css!SectionWizard"],
	function(Ext, Terrasoft) {
		/**
		 * Class of visual module of representation for the section cases wizard variant.
		 */
		Ext.define("Terrasoft.configuration.SectionCasesWizard", {
			extend: "Terrasoft.configuration.SectionWizard",
			alternateClassName: "Terrasoft.SectionCasesWizard",

			mixins: {
				PackageUtilities: "Terrasoft.PackageUtilities"
			},

			/**
			 * @inheritdoc Terrasoft.ApplicationStructureItemWizard#getSteps
			 * @override
			 */
			getSteps: function() {
				const parentSteps = this.callParent(arguments);
				return parentSteps.filter(function(step) {
					return step.name === "Cases";
				});
			},

			/**
			 * @inheritdoc Terrasoft.ApplicationStructureItemWizard#init
			 * @override
			 */
			init: function() {
				const hashArray = window.location.hash.split("/");
				if (hashArray.length > 2) {
					this._packageUId = hashArray[2];
					this.isCheckEntitySchemas = false;
					this.isClientUnitSchemas = false;
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.ApplicationStructureItemWizard#initPackageUtilities
			 * @override
			 */
			initPackageUtilities: function(callback) {
				this.setPackageUId(this._packageUId);
				callback.call(this);
			}
		});
		return Terrasoft.SectionCasesWizard;
	});


