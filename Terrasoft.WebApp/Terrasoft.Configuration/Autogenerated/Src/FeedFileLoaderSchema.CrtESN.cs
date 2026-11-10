namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: FeedFileLoaderSchema

	/// <exclude/>
	public class FeedFileLoaderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FeedFileLoaderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FeedFileLoaderSchema(FeedFileLoaderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bcaef2e2-05be-4e8f-8a25-8d27e34d45f1");
			Name = "FeedFileLoader";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f0db0304-dc6c-40c0-a3bb-97ab97632500");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,147,81,107,219,48,16,199,159,93,232,119,56,210,23,23,138,253,190,38,129,18,146,82,216,198,104,182,231,161,72,231,88,204,150,204,73,202,48,99,223,125,178,20,167,177,154,116,143,58,221,253,238,175,251,159,20,107,209,116,140,35,124,71,34,102,116,101,139,149,86,149,220,59,98,86,106,85,172,183,95,111,111,254,220,222,100,206,72,181,135,109,111,44,182,143,167,243,181,178,141,108,240,179,102,226,114,38,225,181,120,177,86,86,90,137,230,106,194,134,113,171,41,102,248,156,59,194,189,111,8,171,134,25,243,9,54,136,98,236,141,20,50,58,183,107,36,7,62,36,36,247,224,11,206,146,179,225,157,111,68,173,140,101,202,122,234,55,146,7,102,49,224,178,46,30,128,144,9,173,154,30,94,214,70,13,152,87,236,180,145,94,92,15,63,171,201,57,74,205,238,80,137,8,31,206,144,180,34,55,60,108,232,22,4,199,146,178,44,97,110,92,219,50,234,151,99,96,229,91,91,52,192,64,225,111,144,65,166,183,80,87,96,107,244,233,136,192,9,171,197,108,250,218,89,185,4,219,119,88,156,192,101,74,158,119,140,88,11,202,175,197,98,230,12,146,87,166,144,15,150,206,150,103,224,31,211,43,15,30,85,20,243,50,48,2,242,56,250,169,140,124,90,12,211,54,247,222,147,29,51,152,167,225,224,77,118,96,148,20,60,209,222,181,168,44,44,194,52,206,70,57,222,228,233,75,30,210,158,143,129,157,152,230,129,97,169,226,194,245,197,51,218,249,123,171,151,249,101,57,145,249,247,146,241,111,190,127,65,91,107,17,22,76,91,95,143,226,204,117,169,106,36,105,133,230,163,155,167,17,22,171,26,249,175,87,191,128,67,236,137,115,52,38,15,63,167,223,242,26,91,246,0,207,78,138,123,111,76,220,216,35,29,244,193,127,38,41,16,118,90,55,240,63,10,224,59,36,12,51,122,17,163,29,132,214,145,74,215,253,162,188,41,235,136,249,96,72,49,58,13,250,216,63,255,140,148,172,178,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bcaef2e2-05be-4e8f-8a25-8d27e34d45f1"));
		}

		#endregion

	}

	#endregion

}

