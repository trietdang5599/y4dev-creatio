namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ILogoutEventHandlerSchema

	/// <exclude/>
	public class ILogoutEventHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ILogoutEventHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ILogoutEventHandlerSchema(ILogoutEventHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("06f8ea2d-d42f-9e96-1ad8-2155021d7863");
			Name = "ILogoutEventHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ee75749b-5184-4f75-a3ec-dd2e096c705e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,145,205,110,194,48,12,128,207,67,226,29,172,238,178,93,154,59,20,46,104,210,144,54,137,3,123,128,144,186,37,82,126,42,59,97,154,16,239,62,147,2,26,104,183,36,182,63,127,177,131,246,200,131,54,8,91,36,210,28,187,84,175,98,232,108,159,73,39,27,195,116,114,156,78,158,50,219,208,223,165,16,206,167,19,137,60,19,246,146,6,235,144,144,58,1,205,96,253,17,251,152,211,219,1,67,122,215,161,117,72,37,85,41,5,13,103,239,53,253,44,47,247,13,197,131,109,145,65,15,22,186,72,80,9,43,51,18,184,2,169,64,155,179,6,131,245,131,67,47,200,162,85,95,121,234,15,112,200,59,103,13,216,171,202,127,38,112,44,46,55,239,79,76,251,216,242,12,54,165,120,12,62,154,150,135,237,222,50,248,146,14,223,214,57,216,33,24,237,28,182,114,18,117,28,189,25,153,207,96,12,173,152,128,36,60,168,115,125,107,161,30,123,52,131,38,237,33,200,86,22,85,54,213,178,97,148,46,132,221,162,250,18,186,172,38,96,25,72,165,150,130,231,164,131,193,186,81,165,174,96,14,209,182,48,126,182,252,251,229,190,14,178,121,157,95,70,32,138,227,20,202,253,52,238,243,238,241,244,11,220,32,59,206,32,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("06f8ea2d-d42f-9e96-1ad8-2155021d7863"));
		}

		#endregion

	}

	#endregion

}

