namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ISocialMentionExecutorSchema

	/// <exclude/>
	public class ISocialMentionExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISocialMentionExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISocialMentionExecutorSchema(ISocialMentionExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("731044fc-827f-47a1-af08-e646f558fb9f");
			Name = "ISocialMentionExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b66b5ae8-46e0-4931-ad78-c2c1ba5fd6ea");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,145,77,110,194,64,12,133,215,69,226,14,22,221,180,82,149,236,129,178,169,80,197,130,10,41,189,128,73,156,100,84,50,131,108,15,63,66,220,189,195,36,164,20,169,221,205,60,251,61,127,178,45,54,36,91,204,9,62,137,25,197,149,154,188,57,91,154,202,51,170,113,54,153,103,31,195,193,105,56,120,240,98,108,5,217,81,148,154,201,112,16,148,71,166,42,180,0,44,172,18,151,33,101,12,139,204,229,6,55,75,178,23,247,252,64,185,87,199,177,61,77,83,152,138,111,26,228,227,172,251,175,216,237,76,65,2,13,105,237,10,129,210,49,236,29,127,193,222,104,13,94,136,67,41,102,73,114,205,72,111,66,182,126,189,49,57,152,43,193,31,0,112,138,8,61,242,178,29,55,134,85,244,183,197,123,192,40,100,184,163,43,2,224,218,121,141,84,2,90,163,246,108,1,32,8,4,185,103,14,82,208,69,176,162,164,143,77,239,115,167,91,100,108,192,134,3,188,142,186,246,69,49,154,45,219,39,152,34,153,166,177,231,95,203,143,65,233,160,191,44,59,103,10,232,246,16,110,170,152,171,60,189,251,32,246,227,94,64,148,47,103,237,148,231,73,183,38,178,69,187,169,248,63,183,231,190,17,207,223,8,156,11,86,57,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("731044fc-827f-47a1-af08-e646f558fb9f"));
		}

		#endregion

	}

	#endregion

}

