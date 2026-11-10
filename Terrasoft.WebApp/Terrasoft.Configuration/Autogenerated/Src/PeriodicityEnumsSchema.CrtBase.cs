namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: PeriodicityEnumsSchema

	/// <exclude/>
	public class PeriodicityEnumsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PeriodicityEnumsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PeriodicityEnumsSchema(PeriodicityEnumsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01");
			Name = "PeriodicityEnums";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e5f52fab-ebea-4990-be49-0763f7c9fbd6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,237,87,93,111,219,54,20,125,118,129,254,7,193,126,113,0,211,21,37,82,162,154,109,0,37,145,217,128,21,13,154,108,121,44,84,153,113,133,218,82,64,74,27,188,194,255,125,36,165,216,137,172,116,217,92,212,125,152,225,47,209,247,158,123,238,7,174,142,203,108,45,212,93,150,11,231,90,72,153,169,234,182,158,39,85,121,91,44,27,153,213,69,85,190,124,241,249,229,139,81,163,138,114,233,92,109,84,45,214,231,189,107,109,191,90,137,220,24,171,249,133,40,133,44,242,189,205,67,88,41,134,207,215,235,170,52,191,232,231,68,138,165,6,114,146,85,166,212,107,231,231,170,145,234,173,124,83,148,77,45,148,61,108,237,238,154,15,171,34,119,114,115,242,132,149,225,189,195,227,133,88,45,52,224,165,44,254,200,106,97,126,50,175,187,246,210,249,77,9,169,211,46,219,52,156,247,205,163,235,243,123,243,137,40,23,45,224,238,164,195,191,148,213,157,144,117,33,76,12,203,109,23,162,101,250,107,149,103,171,226,175,236,195,74,92,213,210,84,192,178,118,44,203,209,82,212,221,183,145,20,117,35,75,167,20,127,30,250,76,47,68,253,78,40,237,152,235,147,74,102,75,49,61,155,57,227,75,93,243,106,81,228,69,189,97,101,179,86,227,89,139,53,26,31,64,168,185,141,59,255,61,91,53,98,124,54,191,174,58,232,51,155,229,104,107,222,183,255,72,190,171,245,9,232,119,145,159,153,192,211,29,211,237,85,181,108,114,205,227,169,158,13,204,213,180,55,41,143,7,229,172,171,66,111,126,156,31,123,118,231,109,152,103,176,124,35,234,143,213,23,6,247,151,94,61,157,161,18,27,135,150,216,171,87,147,201,100,230,76,218,199,253,231,163,43,103,226,220,84,242,83,187,20,146,119,48,244,125,28,89,231,174,181,189,228,230,189,112,231,255,58,179,161,210,167,133,5,207,228,230,135,139,166,88,204,14,135,233,39,147,234,227,14,77,239,235,255,96,8,159,1,180,115,211,143,207,198,199,24,78,199,60,138,3,143,184,4,112,22,184,0,121,144,131,8,19,4,40,229,44,129,204,131,9,74,199,122,124,45,135,237,108,0,1,122,156,65,68,8,64,65,12,1,74,121,2,98,232,67,0,73,72,112,200,125,130,41,51,8,29,253,237,246,11,181,219,118,251,241,225,217,225,190,76,179,141,122,123,123,35,196,167,167,118,229,161,197,247,190,39,175,154,114,145,109,78,176,105,218,192,71,111,202,234,68,244,219,192,199,210,191,110,132,58,13,255,46,242,177,9,220,136,69,121,170,20,118,177,143,238,194,71,189,99,78,212,134,46,244,177,41,112,89,156,38,129,54,240,177,244,175,50,77,243,68,123,168,11,253,45,36,79,239,246,240,191,220,249,174,228,206,190,59,95,87,234,104,45,146,66,134,92,224,165,4,3,68,145,15,40,79,48,136,80,72,253,4,133,33,74,161,17,42,237,29,113,80,235,112,196,34,146,114,31,36,136,106,173,195,32,3,132,135,12,160,208,71,62,11,9,35,212,170,165,246,174,52,8,17,198,52,12,121,226,1,230,6,92,59,226,0,68,36,78,0,129,81,72,32,194,36,141,173,92,234,110,12,195,146,139,249,16,51,170,227,6,76,103,226,134,24,16,159,38,32,138,35,156,166,30,230,40,244,12,198,110,51,15,39,67,80,226,251,212,7,30,98,90,189,81,173,217,226,4,19,144,114,148,224,208,15,82,26,6,150,73,183,27,135,65,168,135,93,130,19,144,106,185,7,16,118,57,32,148,19,64,34,47,133,41,165,190,235,34,3,210,238,167,65,8,63,208,195,72,2,6,2,152,80,157,18,66,32,10,125,93,145,24,167,174,38,225,146,196,181,125,233,54,196,127,81,144,221,4,10,189,134,122,127,120,204,102,106,199,197,158,171,157,80,85,123,180,135,222,251,233,220,123,234,137,177,61,183,93,179,101,183,85,179,89,91,222,45,212,246,111,148,178,29,95,136,16,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateHoursLocalizableString());
			LocalizableStrings.Add(CreateMinutesLocalizableString());
			LocalizableStrings.Add(CreateSundayLocalizableString());
			LocalizableStrings.Add(CreateSaturdayLocalizableString());
			LocalizableStrings.Add(CreateFridayLocalizableString());
			LocalizableStrings.Add(CreateThursdayLocalizableString());
			LocalizableStrings.Add(CreateWednesdayLocalizableString());
			LocalizableStrings.Add(CreateTuesdayLocalizableString());
			LocalizableStrings.Add(CreateMondayLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateHoursLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("12f23832-fa87-4303-aacd-c714edf36063"),
				Name = "Hours",
				CreatedInPackageId = new Guid("e5f52fab-ebea-4990-be49-0763f7c9fbd6"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateMinutesLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("65f8dfe4-7ce0-435b-abc2-6bc7c5d56ace"),
				Name = "Minutes",
				CreatedInPackageId = new Guid("e5f52fab-ebea-4990-be49-0763f7c9fbd6"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateSundayLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("a8d5eda9-2165-4a96-9e78-d74c46256197"),
				Name = "Sunday",
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateSaturdayLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("1020d386-033c-46b6-a17f-8e39fb443bc2"),
				Name = "Saturday",
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateFridayLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("bfeef8db-c2a7-438b-a423-cb94b9790dd6"),
				Name = "Friday",
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateThursdayLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("0b2c9a60-8c38-49fa-a995-ace5363fa8d1"),
				Name = "Thursday",
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateWednesdayLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("fade33fe-e073-4386-af12-715568054744"),
				Name = "Wednesday",
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateTuesdayLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("165ca4ef-8cfc-4d1c-874e-ed4de8b3461e"),
				Name = "Tuesday",
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateMondayLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("5664557f-389b-421d-a281-b77b0f6df8fb"),
				Name = "Monday",
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"));
		}

		#endregion

	}

	#endregion

}

