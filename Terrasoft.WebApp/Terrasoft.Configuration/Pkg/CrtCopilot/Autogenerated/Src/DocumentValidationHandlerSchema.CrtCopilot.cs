namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DocumentValidationHandlerSchema

	/// <exclude/>
	public class DocumentValidationHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DocumentValidationHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DocumentValidationHandlerSchema(DocumentValidationHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bb104224-e0f6-44da-b73b-2f5fba2e41c2");
			Name = "DocumentValidationHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,147,77,111,219,48,12,134,207,46,208,255,192,97,23,23,104,227,123,187,182,104,189,6,203,97,31,64,183,93,7,69,102,98,97,18,101,72,114,59,175,216,127,31,109,203,70,98,39,57,138,34,249,190,15,41,145,48,232,43,33,17,114,135,34,40,187,200,109,165,180,13,231,103,111,231,103,73,237,21,109,225,185,241,1,205,205,120,254,142,206,9,111,55,129,147,141,177,116,248,198,33,199,249,230,189,195,173,178,4,185,22,222,95,195,71,43,107,131,20,126,10,173,138,86,145,62,9,42,52,186,46,57,203,50,248,224,107,99,132,107,238,226,121,41,180,94,11,249,27,94,198,18,40,251,26,216,88,7,100,233,74,25,177,69,40,98,111,15,138,32,148,12,213,195,192,70,105,220,45,151,165,80,180,24,244,178,29,193,170,94,107,37,65,182,102,143,123,133,107,88,197,222,75,110,125,128,37,121,235,120,70,250,165,66,93,48,254,55,167,94,68,192,254,178,234,15,192,163,47,44,233,6,86,19,69,166,251,85,76,67,55,177,51,82,209,55,223,87,202,45,249,224,106,201,153,173,94,199,19,229,122,182,163,84,233,1,249,153,250,5,180,15,35,73,230,190,224,118,158,13,247,247,188,8,103,95,129,240,21,30,220,182,187,254,82,107,253,213,61,153,42,52,79,127,36,86,173,135,148,248,41,218,77,58,23,188,104,223,87,242,239,52,245,103,12,165,45,38,192,221,118,21,149,232,84,224,190,144,221,237,140,97,109,173,134,92,68,248,116,21,63,192,195,56,132,145,102,64,118,24,106,71,99,24,222,221,2,49,201,174,189,147,138,138,107,34,22,166,63,60,58,94,21,161,236,94,100,189,119,188,132,19,118,46,59,51,9,119,227,217,218,32,244,144,241,172,254,226,138,30,155,128,30,122,107,19,231,243,157,45,6,63,67,143,116,106,100,84,61,170,117,116,63,49,182,191,50,142,253,7,40,180,90,21,117,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bb104224-e0f6-44da-b73b-2f5fba2e41c2"));
		}

		#endregion

	}

	#endregion

}

