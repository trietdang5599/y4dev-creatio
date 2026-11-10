namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: INotificationMarkAsReadStrategySchema

	/// <exclude/>
	public class INotificationMarkAsReadStrategySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationMarkAsReadStrategySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationMarkAsReadStrategySchema(INotificationMarkAsReadStrategySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f5f2edc2-c33a-48e3-b58f-ae8cbc7a01c1");
			Name = "INotificationMarkAsReadStrategy";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("cb307258-3a76-44c9-ba03-f25bdd404252");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,83,203,110,219,48,16,60,219,128,255,97,145,94,82,160,144,238,173,107,32,168,11,67,135,246,16,251,7,40,114,101,45,44,146,198,146,12,234,22,249,247,46,229,151,98,213,72,117,18,201,221,153,225,204,210,41,139,97,175,52,194,6,153,85,240,77,44,190,121,215,208,54,177,138,228,93,241,211,71,106,72,247,139,48,155,254,153,77,39,41,144,219,194,250,16,34,218,47,55,107,233,238,58,212,125,117,177,66,135,76,90,106,102,83,144,239,3,227,86,14,160,114,17,185,17,214,207,80,13,241,127,40,222,61,133,103,84,102,29,133,30,183,135,220,57,41,203,18,230,33,89,171,248,176,56,173,151,216,144,195,0,10,194,169,20,26,207,32,37,187,44,198,13,85,131,10,192,2,90,156,177,202,1,216,62,213,29,105,160,179,164,247,20,65,118,96,36,169,223,120,198,200,132,47,189,42,125,177,1,124,115,35,167,90,6,136,173,138,16,90,159,58,3,53,246,186,209,12,133,142,149,30,119,246,138,149,5,39,185,125,125,96,180,228,204,134,44,62,44,54,45,130,17,133,160,156,129,40,91,66,193,40,12,66,144,157,121,43,33,250,204,170,229,151,12,50,154,98,94,246,192,255,230,209,109,114,187,53,253,62,209,88,245,139,108,146,195,100,107,228,241,253,4,156,79,86,136,175,57,34,137,164,67,168,85,212,237,152,73,106,19,187,176,120,122,223,52,223,27,117,177,105,94,158,123,51,88,245,93,4,33,171,186,195,249,42,145,89,192,10,227,155,241,221,248,156,231,227,82,108,202,166,193,213,191,79,121,0,224,114,207,143,253,200,222,137,57,99,228,0,17,194,30,181,160,75,112,119,231,237,127,98,28,54,87,38,28,77,190,239,197,29,43,174,174,190,120,50,112,157,220,199,177,49,55,140,249,186,147,215,203,43,69,103,142,15,117,54,125,253,11,67,99,242,155,33,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f5f2edc2-c33a-48e3-b58f-ae8cbc7a01c1"));
		}

		#endregion

	}

	#endregion

}

