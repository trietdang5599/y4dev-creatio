namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IOpenLinkUrlGeneratorSchema

	/// <exclude/>
	public class IOpenLinkUrlGeneratorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IOpenLinkUrlGeneratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IOpenLinkUrlGeneratorSchema(IOpenLinkUrlGeneratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2fafdc8e-06dd-4537-8697-db38d63c648d");
			Name = "IOpenLinkUrlGenerator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("1f10590a-fc29-47c3-b5ab-e5c9890ca43c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,83,193,110,219,48,12,61,183,64,255,129,240,46,219,197,190,55,169,129,98,232,130,0,93,58,116,233,7,40,54,109,11,179,37,131,148,219,5,65,254,125,148,108,167,206,150,100,232,73,48,77,190,247,248,72,26,213,32,183,42,67,88,35,145,98,91,184,248,171,53,133,46,59,82,78,91,19,191,80,13,187,155,235,171,142,181,41,225,231,150,29,54,179,155,107,137,36,73,2,115,238,154,70,209,54,29,190,165,214,41,109,24,178,41,8,20,150,160,68,131,254,83,80,148,1,219,162,129,151,231,199,120,4,74,38,72,109,183,169,117,6,89,173,152,225,73,50,69,68,175,74,126,238,60,185,188,255,240,135,192,2,29,131,176,177,127,93,133,192,89,133,141,2,35,141,198,135,170,41,217,200,198,142,66,135,33,127,37,233,176,19,205,110,230,161,102,176,255,8,39,97,102,41,7,157,163,113,186,208,72,151,153,23,157,206,225,57,212,44,243,19,172,251,179,118,47,141,67,42,252,248,254,114,88,156,229,16,203,117,81,32,137,14,113,224,85,151,253,56,108,235,31,62,233,253,39,194,210,231,28,160,111,97,233,71,240,168,205,47,25,195,162,231,176,20,52,13,13,232,131,140,51,169,253,208,174,14,224,223,209,85,54,231,91,248,17,0,254,51,209,0,131,12,202,183,5,27,197,152,131,128,120,167,91,178,175,98,115,126,188,111,103,236,14,145,86,145,106,194,58,220,69,125,81,148,174,5,233,226,194,122,42,191,172,115,70,201,36,44,238,162,163,181,140,146,116,158,4,228,119,34,252,157,97,240,121,40,152,30,88,211,136,200,123,42,187,70,38,179,234,234,250,137,30,154,214,109,31,198,154,40,133,117,69,246,205,192,91,133,125,171,189,64,48,146,61,114,248,157,123,95,111,208,12,232,81,124,220,167,197,243,228,32,226,3,186,150,114,225,43,235,190,217,206,228,151,4,13,212,194,106,172,19,199,36,29,54,219,254,210,78,50,19,186,142,12,167,247,227,173,17,182,132,236,143,100,240,120,176,92,230,25,220,78,198,10,15,49,212,200,177,137,237,159,143,236,31,188,249,50,27,182,12,77,222,47,218,228,124,142,131,251,63,70,220,21,250,249,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2fafdc8e-06dd-4537-8697-db38d63c648d"));
		}

		#endregion

	}

	#endregion

}

