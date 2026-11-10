namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ICopilotFileValidationHandlerSchema

	/// <exclude/>
	public class ICopilotFileValidationHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICopilotFileValidationHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICopilotFileValidationHandlerSchema(ICopilotFileValidationHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("99159faa-442e-4791-86d1-1ce688c5d002");
			Name = "ICopilotFileValidationHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,148,77,111,219,48,12,134,207,13,144,255,64,164,151,14,8,226,123,227,186,216,82,12,243,97,88,177,117,187,43,50,93,11,144,41,67,31,43,218,98,255,125,148,108,121,77,138,102,3,118,20,69,62,124,249,82,54,137,30,221,32,36,194,206,162,240,202,108,118,102,80,218,248,229,226,121,185,56,11,78,209,61,220,161,181,194,153,214,243,165,197,237,114,193,55,231,22,239,149,33,168,201,163,109,25,112,9,245,84,250,81,105,252,33,180,106,34,143,62,9,106,52,218,84,84,20,5,148,46,244,189,176,143,213,116,254,138,131,69,135,228,29,8,232,198,100,80,4,190,99,77,35,16,90,38,194,207,25,9,178,19,138,54,25,88,188,32,14,97,175,149,228,250,73,213,223,68,157,61,39,97,243,56,159,209,119,166,113,151,112,155,64,227,229,177,236,20,184,65,110,209,43,66,7,15,29,87,177,234,40,89,6,107,121,152,121,18,41,40,43,199,148,224,6,148,170,85,216,64,99,100,232,57,119,51,247,40,142,155,148,131,176,162,7,226,45,93,173,114,254,170,186,99,78,62,129,55,60,110,164,250,77,89,164,252,63,229,22,125,176,228,170,82,86,222,6,44,11,89,129,106,147,142,151,2,7,107,36,58,151,226,153,187,5,19,135,122,80,14,215,192,245,173,208,46,1,184,75,198,198,62,123,99,52,236,196,100,233,69,61,189,163,247,245,77,22,152,137,239,182,39,236,156,118,131,238,63,77,10,14,237,206,16,177,29,188,207,209,170,24,3,57,7,163,93,94,144,196,215,126,253,155,221,121,159,167,235,189,241,66,103,19,190,169,39,172,233,195,35,15,184,170,190,12,81,134,208,144,82,198,215,237,56,33,62,251,125,76,121,123,145,81,74,110,223,140,149,60,152,143,194,34,225,104,55,252,25,204,198,94,124,63,112,6,14,141,90,195,137,197,173,35,43,194,174,225,173,161,224,10,40,104,157,87,124,142,212,140,95,84,58,255,26,127,25,7,65,142,253,6,19,122,48,252,125,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("99159faa-442e-4791-86d1-1ce688c5d002"));
		}

		#endregion

	}

	#endregion

}

