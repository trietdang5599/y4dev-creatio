namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: BaseCommandResultSchema

	/// <exclude/>
	public class BaseCommandResultSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseCommandResultSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseCommandResultSchema(BaseCommandResultSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d2b8d1ca-42bf-4559-aeb0-b421b90c0d74");
			Name = "BaseCommandResult";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a1c45040-f900-4d72-b99e-b97e9cbc42dd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,101,80,205,110,194,48,12,62,183,18,239,16,193,5,46,125,0,42,46,235,174,155,16,237,109,154,38,83,76,21,169,73,42,199,41,99,136,119,159,155,210,1,218,205,241,247,235,88,48,232,59,168,81,85,72,4,222,29,57,43,156,61,234,38,16,176,118,54,43,93,173,161,157,165,151,89,154,4,175,109,163,202,179,103,52,217,46,88,214,6,179,18,73,8,250,39,210,243,89,42,188,5,97,35,15,85,180,224,253,90,189,128,199,194,25,3,246,176,67,31,90,142,164,143,87,96,144,44,38,168,249,83,22,93,216,183,186,86,245,32,250,175,81,107,245,84,76,98,123,93,163,128,157,179,30,69,127,137,182,127,225,91,114,29,18,107,148,6,219,104,61,226,49,247,13,205,30,105,249,46,231,171,141,154,51,126,243,124,53,148,152,90,120,166,225,214,74,0,53,156,158,36,13,114,30,7,127,27,174,163,95,71,186,7,70,117,56,91,48,162,252,34,56,229,15,78,211,126,7,167,187,211,109,74,8,57,144,189,107,6,211,49,98,98,12,144,84,236,161,13,56,82,146,88,106,19,69,89,229,202,216,116,185,122,208,223,154,45,208,30,198,207,136,239,113,251,188,188,254,2,97,172,35,147,1,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d2b8d1ca-42bf-4559-aeb0-b421b90c0d74"));
		}

		#endregion

	}

	#endregion

}

