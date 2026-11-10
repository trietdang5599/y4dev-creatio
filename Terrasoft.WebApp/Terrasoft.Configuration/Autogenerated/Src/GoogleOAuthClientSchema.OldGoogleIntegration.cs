namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: GoogleOAuthClientSchema

	/// <exclude/>
	public class GoogleOAuthClientSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GoogleOAuthClientSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GoogleOAuthClientSchema(GoogleOAuthClientSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d3c16520-2979-4ffd-92ac-fac71311fb0b");
			Name = "GoogleOAuthClient";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("50cc600a-f6aa-433b-8a0a-6a453519907c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,82,77,75,195,64,16,61,183,208,255,48,228,148,66,201,222,219,52,80,43,22,65,20,170,158,196,195,118,59,137,11,201,110,216,15,165,136,255,221,201,246,195,164,77,17,178,36,51,251,222,155,153,55,81,188,66,91,115,129,240,130,198,112,171,115,151,44,181,202,101,225,13,119,82,171,209,240,123,52,28,120,43,85,209,129,24,156,93,201,39,119,92,56,109,36,218,62,196,179,22,146,151,201,211,194,187,15,186,39,4,99,12,82,235,171,138,155,93,118,136,215,88,27,180,168,156,5,174,96,165,117,81,34,4,14,136,82,82,62,57,18,89,139,249,118,139,57,247,165,187,145,106,75,85,99,183,171,81,231,113,224,45,3,109,60,129,71,154,24,230,16,237,69,91,119,209,248,157,52,106,191,41,165,160,42,220,90,184,192,192,20,90,17,193,27,115,46,38,8,9,114,209,58,227,27,43,146,19,136,157,163,210,154,27,94,129,162,166,230,145,183,104,30,116,33,85,148,165,44,92,4,220,161,165,139,102,98,210,111,204,61,209,38,240,74,159,84,88,161,104,118,23,110,254,194,49,52,106,131,41,108,184,197,184,197,58,135,133,161,126,194,114,250,103,91,163,243,70,209,110,168,23,106,68,10,78,83,66,78,135,226,107,235,186,230,128,217,139,101,169,69,4,97,48,159,71,253,191,75,114,31,94,139,118,209,136,101,32,201,104,174,4,38,41,59,106,5,219,140,118,52,17,110,65,127,146,158,220,34,244,8,192,10,93,39,17,255,227,97,48,103,176,47,4,10,191,218,123,233,10,157,49,103,7,87,155,67,207,47,1,82,167,218,122,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d3c16520-2979-4ffd-92ac-fac71311fb0b"));
		}

		#endregion

	}

	#endregion

}

