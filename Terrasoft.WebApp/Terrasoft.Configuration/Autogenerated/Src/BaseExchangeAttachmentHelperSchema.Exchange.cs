namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: BaseExchangeAttachmentHelperSchema

	/// <exclude/>
	public class BaseExchangeAttachmentHelperSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseExchangeAttachmentHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseExchangeAttachmentHelperSchema(BaseExchangeAttachmentHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9e525563-4bdb-4dfc-a6eb-a86a1fe5e500");
			Name = "BaseExchangeAttachmentHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("77ff850a-3558-415d-9b34-1a36190e74f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,221,149,81,107,219,48,16,199,159,87,232,119,56,218,151,12,130,253,222,118,129,38,11,157,97,129,66,86,246,48,246,112,150,46,142,64,150,141,78,46,51,163,223,125,146,221,218,78,83,130,7,238,75,159,20,157,116,127,253,127,119,71,12,6,115,226,18,5,193,15,178,22,185,216,185,104,85,152,157,202,42,139,78,21,230,252,236,239,249,217,167,138,149,201,96,91,179,163,220,159,107,77,34,28,114,116,71,134,172,18,215,221,157,141,18,182,104,100,214,127,196,30,77,70,209,79,74,183,100,31,149,32,142,190,162,195,254,242,240,77,75,62,238,79,46,45,101,94,26,86,26,153,175,96,137,76,47,74,183,206,161,216,231,100,220,55,210,37,217,230,126,28,199,112,195,85,158,163,173,23,221,158,8,132,165,221,151,139,228,56,249,193,41,173,156,34,190,136,23,160,242,82,83,136,54,180,209,139,64,60,80,44,171,84,43,1,152,178,179,40,28,136,224,236,164,49,184,130,83,239,122,205,80,212,14,117,67,110,95,72,15,123,223,190,212,112,29,129,253,15,89,180,178,132,174,243,247,92,126,207,219,233,12,1,143,8,95,229,193,155,106,179,7,38,235,103,197,180,179,0,213,193,118,14,94,43,244,56,132,215,57,42,125,43,165,37,230,207,215,19,224,109,113,71,75,101,100,226,231,113,60,85,112,177,241,22,48,35,24,42,204,94,243,114,187,206,33,156,38,18,84,179,204,225,222,22,190,187,174,222,146,131,178,253,237,221,124,60,162,57,140,235,45,147,145,207,221,157,164,8,119,228,250,48,143,46,67,178,54,85,78,22,83,77,55,125,254,2,14,229,102,7,213,202,219,245,29,108,47,235,68,78,108,61,72,190,105,191,235,4,118,151,19,57,9,211,247,2,199,83,60,22,74,66,200,152,245,82,3,75,83,21,217,79,160,243,177,209,182,210,218,209,175,223,208,103,158,182,119,233,167,185,253,71,246,187,167,246,99,52,8,61,253,3,203,15,207,87,45,7,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9e525563-4bdb-4dfc-a6eb-a86a1fe5e500"));
		}

		#endregion

	}

	#endregion

}

