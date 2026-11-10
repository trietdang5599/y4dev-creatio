namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DateNotStrictEmailHashComposerSchema

	/// <exclude/>
	public class DateNotStrictEmailHashComposerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DateNotStrictEmailHashComposerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DateNotStrictEmailHashComposerSchema(DateNotStrictEmailHashComposerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("24733d4d-8f04-4aad-aee5-3ff56062b864");
			Name = "DateNotStrictEmailHashComposer";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5e01e2a5-733f-47cc-a4c2-452cdff090f0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,205,83,201,110,219,48,16,61,43,64,254,97,160,94,36,192,149,209,107,18,27,136,151,52,6,154,180,168,221,75,139,30,104,105,100,179,160,72,131,75,10,35,200,191,119,72,45,150,157,198,167,30,122,33,48,203,123,51,243,102,40,89,133,102,199,114,132,21,106,205,140,42,109,54,85,178,228,27,167,153,229,74,94,94,60,95,94,68,206,112,185,129,229,222,88,172,174,79,108,202,23,2,115,159,108,178,143,40,81,243,252,144,211,167,213,248,150,63,187,99,185,85,154,163,161,12,202,121,167,113,67,124,48,21,204,152,43,152,49,139,143,202,46,45,81,219,121,197,184,184,103,102,59,85,213,78,25,212,1,49,28,14,225,198,184,170,98,122,63,110,236,128,134,92,35,193,13,160,199,193,150,128,100,112,153,11,87,248,70,136,194,240,181,64,176,188,66,40,80,176,189,201,90,194,97,143,241,199,12,75,230,132,157,112,233,129,137,221,239,80,149,201,226,85,63,233,0,30,73,86,24,65,124,190,241,56,253,73,188,59,183,22,60,135,60,52,123,30,0,87,48,97,6,255,162,64,244,28,84,232,132,123,64,187,85,5,73,247,37,176,215,193,83,141,26,7,34,19,70,121,157,202,81,252,122,28,218,169,189,15,170,37,223,200,164,235,144,245,182,7,208,229,206,86,159,211,120,56,6,94,237,4,86,40,109,184,157,172,171,209,215,177,29,88,61,209,9,240,2,97,49,151,174,66,205,104,9,55,134,6,151,155,49,188,85,19,220,153,22,234,21,167,224,47,54,138,62,113,99,59,190,102,237,35,144,248,27,250,145,36,189,14,217,188,132,228,152,219,207,189,48,119,116,60,78,227,92,250,246,138,36,166,118,186,253,44,81,22,126,97,38,78,219,162,209,19,211,80,113,233,44,78,176,164,203,166,146,161,171,172,77,206,110,139,226,33,36,152,228,253,135,166,122,15,118,91,90,90,244,57,84,7,170,135,242,161,175,76,110,48,233,68,91,72,226,144,76,36,167,106,249,233,143,20,107,186,142,150,110,253,139,146,14,117,107,123,208,134,155,54,40,222,31,174,13,79,84,177,239,160,222,104,3,43,250,83,223,149,60,168,208,58,234,248,75,250,31,140,18,4,255,103,147,188,132,87,35,29,141,108,174,46,4,94,154,255,73,213,235,47,26,236,218,123,236,36,223,31,231,32,103,167,150,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("24733d4d-8f04-4aad-aee5-3ff56062b864"));
		}

		#endregion

	}

	#endregion

}

