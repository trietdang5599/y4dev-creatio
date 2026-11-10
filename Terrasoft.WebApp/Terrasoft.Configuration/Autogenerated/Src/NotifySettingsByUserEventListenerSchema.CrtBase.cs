namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: NotifySettingsByUserEventListenerSchema

	/// <exclude/>
	public class NotifySettingsByUserEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public NotifySettingsByUserEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public NotifySettingsByUserEventListenerSchema(NotifySettingsByUserEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3b735c7f-e2d0-455f-b385-4bc2d14bce5b");
			Name = "NotifySettingsByUserEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,82,193,110,194,48,12,61,131,180,127,176,216,5,36,212,222,129,33,141,10,237,178,177,73,133,93,166,29,66,107,32,83,73,170,36,173,84,161,253,251,156,132,50,202,186,161,221,18,251,249,249,217,207,130,237,81,231,44,65,88,162,82,76,203,141,9,34,41,54,124,91,40,102,184,20,55,221,195,77,183,83,104,46,182,13,136,194,96,46,12,55,28,245,248,26,32,152,151,40,204,25,46,174,180,193,125,140,198,208,79,195,221,101,97,67,65,64,232,26,74,20,68,114,171,112,75,9,136,50,166,245,8,22,210,240,77,85,67,102,213,74,163,114,29,31,57,181,17,168,92,209,155,83,83,53,18,253,56,217,225,158,45,104,9,36,162,215,70,212,27,188,83,113,94,172,51,158,64,98,27,94,239,7,35,152,49,141,45,13,137,234,224,212,156,102,120,66,179,147,41,77,241,162,120,201,12,250,108,238,63,160,13,173,32,129,82,242,20,86,121,74,161,239,101,244,61,63,136,115,57,62,54,0,107,90,167,83,50,5,218,39,34,153,218,25,91,192,193,3,154,101,149,99,26,201,172,216,139,87,150,21,56,209,70,17,96,218,239,217,186,222,96,124,73,231,80,255,224,91,75,153,17,91,76,243,156,232,154,87,16,208,195,97,251,109,156,118,199,116,21,2,19,123,18,195,243,169,134,13,77,158,251,243,184,100,20,169,223,243,111,75,119,190,218,164,77,135,97,8,19,46,118,168,184,73,101,2,225,212,121,225,189,151,37,221,40,167,37,58,51,158,69,204,74,107,130,92,127,144,38,146,32,82,84,67,240,114,103,184,161,51,118,206,223,43,58,112,172,13,89,211,89,4,167,218,186,232,40,186,243,195,225,163,197,3,15,252,107,52,31,109,6,41,246,5,5,65,241,244,223,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3b735c7f-e2d0-455f-b385-4bc2d14bce5b"));
		}

		#endregion

	}

	#endregion

}

