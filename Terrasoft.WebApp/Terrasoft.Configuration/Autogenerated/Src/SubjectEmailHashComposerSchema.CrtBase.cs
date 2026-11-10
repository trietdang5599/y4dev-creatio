namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SubjectEmailHashComposerSchema

	/// <exclude/>
	public class SubjectEmailHashComposerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SubjectEmailHashComposerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SubjectEmailHashComposerSchema(SubjectEmailHashComposerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0ab466a0-81cf-410f-864e-38ae3b3a01c4");
			Name = "SubjectEmailHashComposer";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5e01e2a5-733f-47cc-a4c2-452cdff090f0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,82,219,106,227,48,16,125,118,161,255,48,116,95,108,8,206,123,111,208,36,189,4,246,198,38,165,176,165,15,138,60,113,180,200,82,208,72,217,53,165,255,222,177,172,184,233,150,130,94,230,156,209,153,163,51,50,162,65,218,10,137,176,68,231,4,217,181,47,167,214,172,85,29,156,240,202,154,227,163,231,227,163,44,144,50,53,44,90,242,216,48,175,53,202,142,164,242,22,13,58,37,207,134,158,67,25,135,159,225,229,141,144,222,58,133,196,29,220,51,30,143,225,156,66,211,8,215,94,166,122,170,5,17,72,135,194,35,1,54,66,105,216,8,218,112,161,140,212,161,234,100,183,150,72,173,52,130,180,102,135,206,119,24,235,214,202,8,13,20,86,127,216,104,185,31,48,62,152,240,56,195,181,8,218,79,148,233,132,114,223,110,209,174,243,249,117,55,231,142,199,76,109,195,226,232,138,17,124,231,144,224,2,78,22,189,222,135,150,147,226,137,21,183,97,165,149,4,25,109,127,214,10,167,48,17,132,31,112,190,255,28,147,200,190,56,172,57,90,248,134,126,99,43,58,133,159,81,183,39,211,12,203,79,117,170,66,152,95,155,208,160,19,156,192,57,121,199,15,185,132,91,244,119,49,166,252,158,133,121,153,166,95,22,132,119,229,8,6,19,179,229,143,62,223,2,186,101,103,217,87,69,126,208,75,153,95,128,193,191,112,200,228,197,89,236,222,9,183,143,154,187,174,88,125,167,124,123,239,149,166,242,70,253,123,216,40,223,255,49,202,227,148,50,133,147,174,247,250,229,85,85,253,18,166,198,124,240,63,55,30,29,239,49,255,223,120,103,228,157,249,222,117,182,24,76,36,59,163,132,163,169,102,252,139,152,72,6,18,144,248,137,173,218,129,235,138,132,47,85,131,191,173,121,187,183,7,34,253,82,164,7,56,244,193,153,148,83,132,94,210,42,121,76,191,205,88,51,202,231,21,208,32,73,209,114,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0ab466a0-81cf-410f-864e-38ae3b3a01c4"));
		}

		#endregion

	}

	#endregion

}

