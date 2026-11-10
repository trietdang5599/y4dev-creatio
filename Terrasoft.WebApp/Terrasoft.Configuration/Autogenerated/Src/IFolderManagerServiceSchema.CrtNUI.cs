namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IFolderManagerServiceSchema

	/// <exclude/>
	public class IFolderManagerServiceSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFolderManagerServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFolderManagerServiceSchema(IFolderManagerServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c540fd1a-0f99-4be3-b6a9-232ced714c13");
			Name = "IFolderManagerService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("be1f674b-cdb4-46e4-8c46-23cae20b9205");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,205,84,193,106,227,48,16,61,187,208,127,16,233,37,133,224,15,104,217,75,183,221,226,133,108,75,157,165,135,144,131,42,141,83,177,178,228,142,228,44,102,233,191,239,200,178,157,184,77,10,11,89,40,248,162,55,51,111,158,222,200,99,120,9,174,226,2,216,2,16,185,179,133,79,191,90,83,168,117,141,220,43,107,210,111,86,75,192,57,55,124,13,152,3,110,148,128,211,147,63,167,39,73,237,148,89,179,188,113,30,202,203,55,103,34,209,26,68,96,112,233,45,24,64,37,222,229,116,108,115,43,65,127,24,76,31,225,105,155,176,171,20,97,148,72,210,61,114,225,41,153,210,207,16,214,36,128,101,198,3,22,116,201,11,150,237,191,78,66,223,178,59,245,28,211,31,228,13,251,194,38,251,74,38,231,43,42,169,234,39,173,4,83,61,255,65,250,96,215,32,103,14,254,217,74,119,193,238,219,242,86,106,178,188,171,32,58,222,247,95,181,48,221,60,51,27,251,11,166,177,44,8,186,191,203,23,147,25,251,137,106,1,101,165,185,111,101,82,221,6,208,71,5,20,190,178,178,201,125,163,67,144,88,230,224,28,137,26,208,244,17,121,85,129,156,177,208,39,121,128,151,26,28,85,99,201,253,168,34,66,233,119,103,205,140,61,208,107,161,145,194,199,121,173,57,201,198,42,201,70,170,166,183,53,65,6,126,199,99,70,205,91,164,226,8,198,111,65,231,49,12,154,48,229,155,92,60,67,201,195,48,206,195,27,72,142,234,214,194,230,158,120,196,231,113,237,138,59,232,243,217,94,149,71,112,241,56,30,102,70,232,90,194,77,104,160,192,101,230,95,93,236,236,155,253,47,47,71,155,172,251,27,7,111,15,168,159,118,182,57,91,163,128,173,109,131,159,146,68,42,19,41,183,209,246,10,35,199,105,3,214,165,9,193,158,186,109,213,116,211,42,222,206,169,80,154,214,136,139,154,143,55,164,107,208,224,225,179,77,102,87,213,48,145,93,240,240,24,130,123,203,21,67,16,22,165,235,141,58,3,35,227,126,165,211,107,92,255,3,68,63,235,235,95,23,165,178,232,234,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c540fd1a-0f99-4be3-b6a9-232ced714c13"));
		}

		#endregion

	}

	#endregion

}

