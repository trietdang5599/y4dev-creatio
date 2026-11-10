namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: AnniversaryRemindingsHelperSchema

	/// <exclude/>
	public class AnniversaryRemindingsHelperSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AnniversaryRemindingsHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AnniversaryRemindingsHelperSchema(AnniversaryRemindingsHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f3683174-bd15-44f4-9f35-a742936c5d37");
			Name = "AnniversaryRemindingsHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7094e60e-83c9-4747-8d9c-40b7b1b1c58b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,145,97,107,194,48,16,134,63,87,240,63,28,253,84,153,164,63,64,87,216,220,96,238,195,6,234,31,136,245,212,140,246,218,93,146,13,25,251,239,187,166,78,43,84,33,73,203,123,247,188,220,155,144,46,209,214,58,71,88,33,179,182,213,214,169,89,69,91,179,243,172,157,169,104,56,248,25,14,34,111,13,237,46,90,24,213,211,227,100,56,144,98,237,215,133,201,193,58,1,114,200,11,109,45,60,16,153,47,100,171,249,176,192,210,208,70,120,251,130,69,141,44,68,99,25,53,59,77,83,152,90,95,150,210,151,253,11,11,116,158,201,130,197,2,115,7,223,198,237,225,163,50,4,181,102,25,215,137,173,58,193,65,3,18,253,62,110,129,56,91,134,175,154,166,161,152,245,247,230,123,44,245,155,252,199,217,204,51,35,57,104,181,208,112,27,214,231,116,203,142,79,39,244,109,175,180,27,249,242,250,218,217,225,85,242,174,244,186,192,228,40,180,217,198,210,198,205,83,156,199,63,73,189,67,141,32,220,117,212,226,170,177,77,130,247,161,70,53,39,66,30,95,1,3,22,169,119,74,122,235,99,136,231,155,120,164,230,246,249,211,235,34,233,14,212,11,192,93,75,76,130,49,135,55,62,166,10,210,175,28,178,101,253,1,186,237,108,212,148,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f3683174-bd15-44f4-9f35-a742936c5d37"));
		}

		#endregion

	}

	#endregion

}

