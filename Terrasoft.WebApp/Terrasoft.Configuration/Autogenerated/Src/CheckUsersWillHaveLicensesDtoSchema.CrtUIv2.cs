namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: CheckUsersWillHaveLicensesDtoSchema

	/// <exclude/>
	public class CheckUsersWillHaveLicensesDtoSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CheckUsersWillHaveLicensesDtoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CheckUsersWillHaveLicensesDtoSchema(CheckUsersWillHaveLicensesDtoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c518ee2e-8d8f-4cf4-bbeb-e95fd33ac8fb");
			Name = "CheckUsersWillHaveLicensesDto";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,82,77,79,2,49,16,61,67,194,127,104,240,162,9,217,248,113,19,53,49,32,122,64,33,176,198,131,241,80,202,176,54,118,219,77,167,53,65,194,127,183,179,31,65,8,139,92,54,221,190,55,239,245,205,140,230,41,96,198,5,176,24,172,229,104,22,46,234,25,189,144,137,183,220,73,163,91,205,85,171,217,240,40,117,194,166,75,116,144,6,92,41,16,4,98,244,8,26,172,20,221,93,206,196,107,39,83,136,166,1,229,74,254,228,90,129,21,120,39,22,146,240,195,30,180,79,175,89,239,147,235,4,38,70,193,40,131,194,50,94,102,144,51,51,63,83,82,48,8,196,122,94,131,222,215,184,159,207,9,195,216,188,34,88,118,203,206,59,116,221,7,5,46,175,26,88,147,150,208,69,167,172,24,120,45,8,139,205,200,38,116,8,224,229,159,186,10,167,218,13,227,42,16,214,69,18,208,243,34,204,86,176,158,226,136,148,12,196,23,89,226,155,84,234,137,127,195,80,10,208,8,216,119,38,47,120,239,115,199,67,183,157,229,194,125,108,2,11,18,248,175,158,114,211,83,43,215,177,53,161,49,78,66,176,30,231,58,5,158,155,60,67,58,3,123,250,18,166,29,18,180,77,17,6,219,103,228,90,217,14,37,186,27,116,54,140,241,142,149,121,145,173,88,2,174,203,144,62,235,122,201,69,217,171,67,154,85,63,143,22,21,251,135,190,109,81,179,25,181,247,71,122,123,234,252,129,48,249,100,246,137,237,108,197,190,85,89,255,2,200,207,25,8,119,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c518ee2e-8d8f-4cf4-bbeb-e95fd33ac8fb"));
		}

		#endregion

	}

	#endregion

}

