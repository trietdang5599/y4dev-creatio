namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SectionExceptionResourcesSchema

	/// <exclude/>
	public class SectionExceptionResourcesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SectionExceptionResourcesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SectionExceptionResourcesSchema(SectionExceptionResourcesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1");
			Name = "SectionExceptionResources";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9735f166-4b01-4c20-b58c-0bd002ae38b1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,143,205,10,131,48,16,132,207,10,190,195,130,119,115,47,165,23,233,11,180,190,192,186,174,26,26,147,144,85,250,71,223,189,73,173,208,83,111,51,187,3,243,141,197,137,197,35,49,52,28,2,138,235,231,170,118,182,215,195,18,112,214,206,22,249,179,200,179,50,240,16,13,212,6,69,118,112,102,74,191,227,141,216,39,113,98,113,75,32,150,34,143,97,165,20,236,101,153,38,12,247,195,215,55,163,22,88,67,64,174,99,16,26,121,194,168,237,140,218,10,24,71,104,244,3,91,195,16,145,4,7,22,232,93,0,52,6,174,46,92,188,73,148,104,59,144,181,29,120,171,151,106,107,85,63,181,126,105,141,38,160,132,252,143,56,75,3,95,31,242,146,109,183,46,45,242,120,121,3,102,120,58,179,29,1,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateSectionNotFoundByIdTplLocalizableString());
			LocalizableStrings.Add(CreateWorkplaceNotFoundByIdTplLocalizableString());
			LocalizableStrings.Add(CreateEntityNotAllowedForSSPTplLocalizableString());
			LocalizableStrings.Add(CreateWorkplaceCreateFailedLocalizableString());
			LocalizableStrings.Add(CreateWorkplaceSectionTypeNotMatchLocalizableString());
			LocalizableStrings.Add(CreateSectionNotSspTypeTplLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateSectionNotFoundByIdTplLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("f01bcb74-e302-4b6e-9150-8ecf83c08c88"),
				Name = "SectionNotFoundByIdTpl",
				CreatedInPackageId = new Guid("9735f166-4b01-4c20-b58c-0bd002ae38b1"),
				CreatedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1"),
				ModifiedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateWorkplaceNotFoundByIdTplLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("5aa54c95-c48e-49ee-90c4-e020e313e093"),
				Name = "WorkplaceNotFoundByIdTpl",
				CreatedInPackageId = new Guid("9735f166-4b01-4c20-b58c-0bd002ae38b1"),
				CreatedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1"),
				ModifiedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateEntityNotAllowedForSSPTplLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("f341ba5c-75ac-4bd7-99b0-4a9e2a1729ea"),
				Name = "EntityNotAllowedForSSPTpl",
				CreatedInPackageId = new Guid("9735f166-4b01-4c20-b58c-0bd002ae38b1"),
				CreatedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1"),
				ModifiedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateWorkplaceCreateFailedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("ddbc7ab7-59d9-433c-88df-543bba74a3f1"),
				Name = "WorkplaceCreateFailed",
				CreatedInPackageId = new Guid("9735f166-4b01-4c20-b58c-0bd002ae38b1"),
				CreatedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1"),
				ModifiedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateWorkplaceSectionTypeNotMatchLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("09d7c38b-e8ab-4c98-85f0-1122edff1cb5"),
				Name = "WorkplaceSectionTypeNotMatch",
				CreatedInPackageId = new Guid("9735f166-4b01-4c20-b58c-0bd002ae38b1"),
				CreatedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1"),
				ModifiedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateSectionNotSspTypeTplLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("7b27fa27-0b26-45c9-b8bc-bcb375d08e95"),
				Name = "SectionNotSspTypeTpl",
				CreatedInPackageId = new Guid("9735f166-4b01-4c20-b58c-0bd002ae38b1"),
				CreatedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1"),
				ModifiedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1"));
		}

		#endregion

	}

	#endregion

}

