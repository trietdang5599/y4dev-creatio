namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IIncomingMessageNotifierSchema

	/// <exclude/>
	public class IIncomingMessageNotifierSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IIncomingMessageNotifierSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IIncomingMessageNotifierSchema(IIncomingMessageNotifierSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ce1c4ef7-b936-4dd7-987d-b5980c9beea9");
			Name = "IIncomingMessageNotifier";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("92ff52b6-dfba-4556-90d8-6f4c37f69c5d");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,147,193,78,195,48,12,134,207,173,212,119,176,186,203,184,180,247,81,42,33,78,149,24,160,137,23,200,90,183,139,212,56,85,156,14,77,104,239,78,73,155,110,108,2,113,128,99,236,223,191,63,39,14,9,133,220,137,18,225,21,141,17,172,107,155,60,104,170,101,211,27,97,165,166,228,89,145,44,119,130,8,219,100,141,204,162,145,212,68,225,123,20,70,97,176,48,216,12,34,40,200,162,169,7,155,21,20,5,149,90,13,154,81,140,79,218,202,90,162,113,250,52,77,33,227,94,41,97,14,249,116,222,96,103,144,145,44,131,244,54,80,107,3,228,42,169,129,86,178,69,66,195,32,182,186,183,64,248,6,106,116,79,188,105,122,230,218,245,219,86,150,103,110,223,51,5,195,28,193,60,198,26,237,78,87,188,130,23,231,224,144,175,152,93,224,190,170,216,113,120,182,100,150,166,151,218,172,19,70,40,160,225,170,239,98,175,143,243,137,229,228,144,165,78,232,234,246,90,86,159,77,30,167,228,242,114,4,159,152,203,111,110,127,192,221,160,210,123,228,127,165,29,123,252,17,240,244,66,39,98,254,45,242,180,24,113,238,251,207,171,114,69,236,154,28,60,24,47,231,245,246,195,78,149,158,116,129,84,141,155,226,206,199,241,11,124,9,30,63,0,149,156,60,35,81,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ce1c4ef7-b936-4dd7-987d-b5980c9beea9"));
		}

		#endregion

	}

	#endregion

}

