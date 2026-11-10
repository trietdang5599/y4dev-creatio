namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ActivityEmailSenderExtensionsSchema

	/// <exclude/>
	public class ActivityEmailSenderExtensionsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ActivityEmailSenderExtensionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ActivityEmailSenderExtensionsSchema(ActivityEmailSenderExtensionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fddb619a-7b2e-4221-a1e4-4319f11acd3e");
			Name = "ActivityEmailSenderExtensions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0ae7984f-6254-4486-964c-21c9c7df2d6d");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,144,207,10,194,48,12,135,207,19,124,135,128,151,13,100,15,160,40,200,24,226,193,211,124,129,218,197,25,216,186,209,164,162,136,239,110,235,252,135,40,30,147,126,223,175,73,140,106,144,59,165,17,54,104,173,226,118,39,233,90,81,157,22,104,74,180,195,193,121,56,136,28,147,169,160,56,177,96,51,125,214,47,33,107,205,142,42,103,149,80,107,190,3,22,127,245,211,220,8,9,33,123,192,35,35,139,149,79,129,172,86,204,19,88,104,161,3,201,41,111,252,80,253,76,249,81,208,176,103,248,38,116,110,91,147,6,22,255,187,6,29,180,127,86,20,150,250,16,31,10,4,60,150,61,125,77,1,110,157,213,56,134,165,163,18,212,29,88,149,73,8,140,102,115,136,31,82,210,147,183,59,198,111,96,56,195,165,223,212,191,244,203,134,242,114,5,110,79,251,197,138,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fddb619a-7b2e-4221-a1e4-4319f11acd3e"));
		}

		#endregion

	}

	#endregion

}

