namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: PopupNotificationsConstsSchema

	/// <exclude/>
	public class PopupNotificationsConstsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PopupNotificationsConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PopupNotificationsConstsSchema(PopupNotificationsConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ac17ee24-4307-4b11-a6ae-537793d26efc");
			Name = "PopupNotificationsConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,53,142,177,10,194,48,20,69,103,3,249,135,224,164,67,138,173,182,40,226,36,40,46,34,232,15,60,147,151,18,104,147,146,151,12,69,250,239,166,130,243,57,151,123,18,89,215,138,231,72,17,251,35,103,156,57,232,145,6,80,40,94,24,2,144,55,177,56,123,103,108,155,2,68,235,29,103,31,206,22,67,122,119,86,9,213,1,145,120,248,33,13,119,31,173,177,234,231,80,94,80,36,145,197,89,254,219,20,51,85,34,32,104,239,186,81,92,147,213,243,247,19,99,204,25,116,241,157,198,112,211,226,244,67,197,3,2,225,106,9,101,93,214,59,115,144,8,251,70,238,154,170,150,239,109,125,144,102,163,116,165,155,61,150,70,45,215,185,126,49,113,54,125,1,106,204,4,172,210,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ac17ee24-4307-4b11-a6ae-537793d26efc"));
		}

		#endregion

	}

	#endregion

}

