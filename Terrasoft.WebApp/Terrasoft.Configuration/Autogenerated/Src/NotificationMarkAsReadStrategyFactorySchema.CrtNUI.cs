namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: NotificationMarkAsReadStrategyFactorySchema

	/// <exclude/>
	public class NotificationMarkAsReadStrategyFactorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public NotificationMarkAsReadStrategyFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public NotificationMarkAsReadStrategyFactorySchema(NotificationMarkAsReadStrategyFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9f29f5ef-547f-4e2a-abc0-31209fe97b73");
			Name = "NotificationMarkAsReadStrategyFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("cb307258-3a76-44c9-ba03-f25bdd404252");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,84,77,79,194,64,16,189,147,248,31,38,120,41,9,41,119,1,19,68,32,30,48,70,240,100,140,89,183,211,178,161,221,37,251,161,105,12,255,221,109,107,205,46,5,169,238,109,231,227,205,123,51,179,203,73,134,106,71,40,194,26,165,36,74,196,58,156,10,30,179,196,72,162,153,224,225,189,208,44,102,180,188,168,139,206,231,69,7,236,49,138,241,4,86,185,210,152,13,93,147,11,147,101,130,159,116,74,252,197,21,206,9,213,66,50,84,54,168,10,187,148,152,88,10,48,77,137,82,87,224,210,90,18,185,157,168,71,36,209,74,91,214,152,228,85,122,94,231,62,223,98,76,76,170,111,24,143,108,177,64,231,59,20,113,112,215,10,164,215,123,169,80,118,230,45,101,20,104,65,160,93,125,184,130,118,53,170,2,223,189,117,213,206,25,166,145,149,251,32,217,187,77,168,5,149,116,42,19,72,11,39,120,154,195,147,66,105,103,199,145,22,181,224,213,120,247,161,155,123,137,60,170,42,120,214,186,197,118,210,90,154,130,89,81,186,148,237,85,174,26,209,74,89,112,192,202,39,213,115,53,23,231,128,52,140,161,161,162,14,221,183,23,180,68,189,17,209,81,45,131,193,0,70,140,111,80,50,29,9,59,93,137,241,184,219,110,106,225,2,117,109,234,14,174,27,13,58,131,2,78,122,176,48,44,2,238,196,175,237,142,222,69,141,6,53,67,194,233,6,233,118,34,19,147,33,215,179,108,167,243,128,219,103,109,23,252,8,94,111,232,227,177,24,142,132,193,120,12,143,152,85,207,165,92,7,229,125,4,69,212,76,241,149,160,140,164,75,84,138,36,184,162,27,204,200,211,17,206,197,145,168,141,252,126,189,78,251,70,22,229,247,46,93,7,28,63,220,149,172,149,6,93,127,53,186,253,195,237,105,136,221,251,215,83,156,126,148,159,99,214,148,249,127,174,253,63,128,53,7,102,1,207,12,251,228,115,241,156,174,163,52,126,1,5,47,218,170,33,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9f29f5ef-547f-4e2a-abc0-31209fe97b73"));
		}

		#endregion

	}

	#endregion

}

