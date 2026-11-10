namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: FeatureUtilsWrapSchema

	/// <exclude/>
	public class FeatureUtilsWrapSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FeatureUtilsWrapSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FeatureUtilsWrapSchema(FeatureUtilsWrapSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("857989eb-d198-4858-9f7a-b2ad3d351897");
			Name = "FeatureUtilsWrap";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5e01e2a5-733f-47cc-a4c2-452cdff090f0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,147,79,107,2,49,16,197,207,43,248,29,6,189,184,32,238,221,254,1,107,171,120,40,20,90,233,161,244,16,147,89,13,196,100,153,36,135,69,252,238,77,118,173,216,110,165,69,237,49,147,247,126,153,55,67,52,91,163,45,24,71,120,65,34,102,77,238,6,99,163,115,185,244,196,156,52,186,221,218,180,91,137,183,82,47,225,185,180,14,215,87,251,243,161,133,240,88,125,48,97,220,25,146,104,131,34,104,186,132,203,0,134,177,98,214,14,97,130,204,121,194,185,147,202,190,18,43,42,205,219,61,230,204,43,119,39,181,8,196,158,43,11,52,121,111,118,32,150,46,16,211,244,61,168,11,191,80,146,3,143,192,6,15,134,208,176,5,207,166,122,103,223,204,35,186,149,17,161,157,167,138,85,95,102,89,6,215,82,175,144,164,19,38,60,64,152,223,116,26,180,193,20,221,204,238,170,15,154,45,20,138,222,220,34,133,65,106,228,113,138,125,176,142,66,144,180,147,221,70,242,174,227,133,49,10,126,119,131,231,159,0,224,70,96,10,113,39,73,66,24,60,241,246,199,14,42,101,92,74,178,253,175,56,125,152,122,41,46,19,170,102,129,45,237,72,172,165,158,107,233,102,226,239,73,251,223,157,23,74,62,49,52,210,101,108,253,188,149,30,229,156,180,220,3,218,37,215,28,177,74,157,31,180,193,56,57,164,82,17,100,155,41,187,168,69,253,119,171,115,93,253,90,220,126,0,77,103,160,222,221,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("857989eb-d198-4858-9f7a-b2ad3d351897"));
		}

		#endregion

	}

	#endregion

}

