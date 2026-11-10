namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SSPSysAdminUnitEntityEventListenerSchema

	/// <exclude/>
	public class SSPSysAdminUnitEntityEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SSPSysAdminUnitEntityEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SSPSysAdminUnitEntityEventListenerSchema(SSPSysAdminUnitEntityEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("97f62c83-391e-4913-874c-0be2b5b5de4c");
			Name = "SSPSysAdminUnitEntityEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,197,85,77,79,227,48,16,61,23,137,255,48,155,189,164,82,229,222,129,34,65,161,43,36,88,208,22,216,3,66,43,55,153,54,94,28,187,178,157,66,129,254,119,252,21,54,253,224,99,181,135,189,180,114,102,230,189,55,51,47,142,160,37,234,41,205,16,46,81,41,170,229,216,144,190,20,99,54,169,20,53,76,10,50,28,94,108,111,61,109,111,181,42,205,196,4,134,115,109,176,220,125,61,55,203,202,82,138,205,17,133,228,88,24,102,24,234,15,19,200,241,12,133,113,121,54,179,219,237,194,158,174,202,146,170,249,126,60,251,196,57,160,75,3,206,172,30,129,10,140,132,169,10,207,114,228,104,28,131,84,80,202,156,141,231,238,160,189,114,192,7,131,74,80,14,149,70,69,106,138,110,131,227,38,16,120,25,167,17,62,29,102,5,150,244,187,29,23,244,32,177,83,56,200,75,38,174,4,51,73,251,246,115,69,215,247,235,101,211,106,196,89,6,25,167,90,131,29,117,51,99,3,34,236,192,33,213,184,33,98,177,158,252,196,90,95,21,78,236,226,96,192,144,231,122,199,78,133,205,168,193,16,140,7,208,70,185,153,252,178,67,185,144,202,80,110,151,46,48,115,27,191,178,115,105,244,185,26,78,118,35,13,138,60,48,45,211,158,161,41,228,155,188,35,41,57,156,232,13,184,142,54,173,87,235,255,218,224,108,215,106,177,49,164,95,194,35,114,162,251,146,87,165,184,166,188,194,83,73,115,204,211,196,169,77,218,117,122,107,70,21,112,27,242,57,58,66,246,34,40,9,59,33,125,133,86,79,8,166,49,228,36,252,17,212,222,13,112,171,80,100,128,38,43,6,74,150,71,135,105,114,146,39,157,26,250,66,49,231,161,134,194,14,8,188,191,185,133,39,8,137,65,42,44,106,236,90,19,154,70,81,108,168,179,214,4,249,182,41,175,29,193,22,254,87,161,169,148,168,21,217,130,203,249,20,243,70,213,94,88,253,126,93,13,189,222,251,54,120,126,134,37,177,53,230,57,255,23,88,175,121,177,108,142,153,100,57,244,11,204,238,62,240,135,123,117,155,238,120,219,80,62,115,217,25,217,227,25,106,77,39,120,137,229,148,59,222,158,219,18,156,202,140,114,246,72,71,28,135,190,23,95,188,98,10,242,83,170,59,127,97,146,31,168,101,165,50,155,44,149,69,235,4,138,86,242,241,91,236,140,176,198,166,201,27,61,244,11,42,38,120,252,144,225,212,43,240,227,78,106,7,45,183,100,91,9,123,32,3,169,74,106,210,245,110,59,239,174,165,134,53,133,146,247,126,44,175,196,13,172,166,227,22,159,189,14,252,77,23,130,254,202,101,162,64,197,76,46,179,238,190,119,65,184,10,229,204,126,22,88,30,221,112,46,142,226,101,158,202,209,111,171,21,180,37,66,213,137,95,129,67,28,219,111,135,159,238,129,154,104,192,122,215,110,46,110,127,118,34,209,53,237,80,25,164,191,235,50,111,154,144,55,178,183,45,105,136,168,217,227,8,22,127,223,207,144,206,254,119,55,81,194,230,94,86,22,105,159,46,94,0,41,149,209,144,37,8,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateSysPortalConnectionUserChangeExceptionLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateSysPortalConnectionUserChangeExceptionLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("aa7b54fa-d468-e38c-65d2-008c79d90400"),
				Name = "SysPortalConnectionUserChangeException",
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c"),
				CreatedInSchemaUId = new Guid("97f62c83-391e-4913-874c-0be2b5b5de4c"),
				ModifiedInSchemaUId = new Guid("97f62c83-391e-4913-874c-0be2b5b5de4c")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("97f62c83-391e-4913-874c-0be2b5b5de4c"));
		}

		#endregion

	}

	#endregion

}

