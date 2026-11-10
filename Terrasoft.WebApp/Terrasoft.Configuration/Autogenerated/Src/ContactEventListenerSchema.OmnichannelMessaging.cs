namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ContactEventListenerSchema

	/// <exclude/>
	public class ContactEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactEventListenerSchema(ContactEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7bbed3c8-78ef-49dc-a0ac-f1c79bd9a80b");
			Name = "ContactEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3e2142cb-b5f1-4ce8-8571-f789e137e2ae");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,83,193,110,219,48,12,61,167,64,255,129,240,14,117,128,194,190,167,113,128,46,235,186,2,235,58,180,105,47,195,14,140,69,219,26,108,41,144,228,0,70,177,127,31,45,217,217,18,56,216,145,212,123,122,124,79,148,194,134,236,14,115,130,13,25,131,86,23,46,89,107,85,200,178,53,232,164,86,151,23,239,151,23,179,214,74,85,194,75,103,29,53,55,135,250,12,37,121,106,148,204,43,84,138,234,228,145,172,197,146,209,211,52,67,201,157,114,210,73,178,255,5,36,119,123,82,174,199,49,242,131,161,146,181,96,93,163,181,11,224,1,28,230,206,35,190,74,30,83,145,241,184,52,77,97,105,219,166,65,211,173,134,122,4,64,161,13,92,13,212,43,160,94,167,3,242,42,201,200,77,79,200,75,75,132,181,213,144,27,42,178,232,35,90,242,3,118,71,218,17,164,61,225,199,196,81,252,146,87,212,224,55,78,30,50,136,6,249,104,254,147,241,187,118,91,203,28,242,222,212,164,39,88,192,25,69,102,191,123,199,135,104,30,201,85,90,112,56,223,253,173,225,240,52,15,223,248,130,74,212,100,199,4,62,81,77,142,68,72,34,57,176,210,83,218,114,135,6,27,80,236,36,139,44,41,193,190,87,126,40,8,85,178,76,61,100,154,65,209,106,83,145,15,116,8,115,179,56,251,244,126,178,219,194,145,241,2,183,166,180,125,198,32,149,117,168,120,127,243,62,45,169,250,253,113,21,141,130,222,2,8,116,120,52,203,144,179,222,179,156,20,4,123,45,5,60,169,193,120,172,183,191,40,31,77,92,195,148,56,208,28,250,159,49,155,109,249,61,146,191,220,145,68,243,27,127,28,200,97,60,190,51,131,56,116,230,1,24,64,123,52,192,19,100,35,44,185,39,183,233,118,36,214,186,110,27,245,134,117,75,203,251,86,138,85,28,61,136,104,184,250,159,127,54,236,202,131,232,159,176,144,28,253,51,53,108,47,52,92,247,217,232,102,141,188,120,177,20,215,7,149,87,75,134,153,138,205,242,194,132,91,127,15,75,196,211,133,61,242,117,232,30,55,185,247,7,252,76,44,119,63,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7bbed3c8-78ef-49dc-a0ac-f1c79bd9a80b"));
		}

		#endregion

	}

	#endregion

}

