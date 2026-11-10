namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IChatMessageMetadataSchema

	/// <exclude/>
	public class IChatMessageMetadataSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IChatMessageMetadataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IChatMessageMetadataSchema(IChatMessageMetadataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("137378c7-59c9-4c17-a6ee-807549c39cca");
			Name = "IChatMessageMetadata";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,203,106,195,48,16,69,215,49,248,31,134,116,211,110,236,125,235,102,227,69,200,34,20,138,127,96,98,143,101,129,53,50,146,92,8,37,255,94,61,106,247,145,20,186,18,26,143,207,157,51,136,81,145,157,176,37,104,200,24,180,186,119,69,173,185,151,98,54,232,164,230,226,69,177,108,7,100,166,177,56,146,181,40,36,139,60,123,207,179,60,219,220,25,18,190,9,234,17,173,125,132,67,61,160,75,77,116,36,135,29,58,140,125,101,89,66,101,103,165,208,156,119,159,247,3,59,50,125,136,238,181,1,65,76,33,145,5,248,52,7,42,81,252,153,48,197,66,41,127,97,42,119,158,104,66,131,10,216,203,60,111,155,237,174,25,8,66,25,116,15,225,103,152,45,117,255,139,169,202,149,23,18,166,249,52,202,22,228,58,235,45,197,170,9,173,126,35,155,43,209,88,216,167,80,178,107,76,156,5,127,142,112,194,48,164,95,166,243,211,79,70,191,201,206,223,23,247,107,249,84,249,110,30,122,147,252,151,180,211,139,51,69,240,95,214,171,113,194,26,114,179,97,187,123,77,103,252,117,225,116,183,33,128,214,43,89,103,252,114,61,112,33,4,100,42,174,123,184,111,226,128,15,79,254,219,37,189,35,226,46,61,165,60,187,124,0,56,137,98,88,148,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("137378c7-59c9-4c17-a6ee-807549c39cca"));
		}

		#endregion

	}

	#endregion

}

