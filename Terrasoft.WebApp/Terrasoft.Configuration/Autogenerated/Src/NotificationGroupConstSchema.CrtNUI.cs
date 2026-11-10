namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: NotificationGroupConstSchema

	/// <exclude/>
	public class NotificationGroupConstSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public NotificationGroupConstSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public NotificationGroupConstSchema(NotificationGroupConstSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5b4de5f4-8161-4ca8-921e-9f19f6876f8d");
			Name = "NotificationGroupConst";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,144,79,75,196,64,12,197,207,91,232,119,8,235,125,123,95,255,128,44,226,109,17,21,239,177,157,150,192,52,83,146,169,176,136,223,221,204,232,234,80,16,123,154,121,153,247,123,201,132,113,116,58,97,235,224,217,137,160,134,62,238,14,129,123,26,102,193,72,129,235,234,189,174,54,23,226,6,19,112,240,168,186,135,99,136,212,83,155,13,247,18,230,201,16,141,117,101,206,166,105,224,74,231,113,68,57,221,124,235,252,138,28,21,66,15,67,242,43,112,17,177,59,115,77,1,78,243,171,167,22,12,140,118,180,169,241,159,125,55,105,198,223,33,207,237,246,240,144,67,242,96,139,64,113,216,5,246,39,211,66,60,192,11,41,194,53,108,211,185,189,252,223,255,232,70,226,46,221,12,250,17,107,200,242,19,9,46,245,26,254,238,233,184,140,88,148,214,164,220,50,211,155,19,181,109,167,132,66,174,162,189,207,148,247,201,157,151,239,184,251,218,191,169,143,92,43,75,86,249,4,91,144,31,62,107,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5b4de5f4-8161-4ca8-921e-9f19f6876f8d"));
		}

		#endregion

	}

	#endregion

}

