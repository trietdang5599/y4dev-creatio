namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IAfterDeduplicationActionSchema

	/// <exclude/>
	public class IAfterDeduplicationActionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IAfterDeduplicationActionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IAfterDeduplicationActionSchema(IAfterDeduplicationActionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("aec23552-782f-4407-a3bb-de7bbc336923");
			Name = "IAfterDeduplicationAction";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4b7fcaef-4d0d-4f1c-b466-136a63eb8599");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,145,207,106,2,49,16,198,207,46,236,59,12,246,210,94,146,187,110,5,169,30,60,8,165,244,5,210,205,236,26,216,252,97,146,136,34,125,247,166,137,43,171,148,222,242,77,230,251,241,205,140,17,26,189,19,45,194,39,18,9,111,187,192,222,172,233,84,31,73,4,101,13,219,160,140,110,80,109,86,117,117,169,171,89,244,202,244,119,6,66,182,53,65,5,133,126,89,87,169,229,137,176,79,253,176,51,1,169,75,252,5,236,214,93,122,223,225,214,109,129,38,3,231,28,26,31,181,22,116,94,93,245,7,58,66,143,38,120,16,112,16,70,14,72,128,39,108,99,64,9,226,23,7,114,202,131,214,106,55,96,64,54,18,249,4,233,226,87,106,4,53,70,250,47,209,236,146,83,221,230,216,99,56,88,233,23,240,158,33,229,243,49,115,46,108,254,12,52,198,103,55,31,127,52,54,78,144,208,96,210,69,94,231,26,169,71,153,119,122,158,175,246,89,65,90,70,28,2,96,174,178,134,103,67,246,31,173,146,176,45,155,121,46,46,152,34,94,150,215,113,208,200,50,81,214,223,229,86,147,98,170,252,0,105,217,49,148,19,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("aec23552-782f-4407-a3bb-de7bbc336923"));
		}

		#endregion

	}

	#endregion

}

