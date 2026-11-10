namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: FacebookMappingSchema

	/// <exclude/>
	public class FacebookMappingSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FacebookMappingSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FacebookMappingSchema(FacebookMappingSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7d848782-ec7f-4a67-83bd-2846ad8a81d8");
			Name = "FacebookMapping";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("34c57733-6570-402b-8e25-5c50c5be2b38");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,144,81,107,194,48,20,133,159,43,248,31,2,123,81,24,253,1,202,30,68,230,155,67,208,61,141,49,98,119,45,97,49,9,55,55,142,34,253,239,187,77,179,90,75,125,41,233,201,201,57,223,189,70,158,193,59,89,128,56,0,162,244,246,68,249,218,154,147,42,3,74,82,214,228,123,91,40,169,167,147,235,116,146,5,175,76,41,246,149,39,56,47,167,19,86,158,16,74,118,137,181,150,222,47,196,134,147,142,214,254,108,165,115,108,141,150,143,21,17,170,99,32,120,247,178,132,89,247,123,144,88,2,249,124,135,214,1,82,245,44,86,90,219,223,109,208,164,156,6,241,34,8,3,204,63,57,195,133,163,86,133,40,154,150,97,137,88,136,46,146,173,215,88,122,3,179,198,115,76,65,22,153,111,23,115,90,71,202,28,164,205,216,221,132,26,94,204,92,52,67,103,217,27,159,153,166,145,150,81,216,73,4,67,44,181,230,252,245,236,168,138,87,117,106,7,243,221,2,220,211,164,81,21,12,89,80,93,36,65,202,19,95,93,85,130,76,122,4,105,153,120,115,233,148,33,80,64,211,123,212,80,240,215,223,44,241,142,121,47,82,135,190,167,30,175,119,113,190,17,128,52,248,67,132,222,195,17,8,247,191,182,7,24,253,173,37,237,126,145,245,31,85,55,175,138,175,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7d848782-ec7f-4a67-83bd-2846ad8a81d8"));
		}

		#endregion

	}

	#endregion

}

