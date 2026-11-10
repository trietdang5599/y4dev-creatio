namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: GetXmlSchemaFilesContentResponseSchema

	/// <exclude/>
	public class GetXmlSchemaFilesContentResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GetXmlSchemaFilesContentResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GetXmlSchemaFilesContentResponseSchema(GetXmlSchemaFilesContentResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("90c4c327-4a7f-a0dd-f8fb-e87a2ae11e91");
			Name = "GetXmlSchemaFilesContentResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0cd720a-279e-436c-a704-8c755267ad15");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,144,205,78,195,48,16,132,207,169,212,119,176,202,5,36,148,7,40,63,7,26,209,83,81,213,114,64,170,122,112,221,73,88,201,113,162,181,131,84,42,222,157,181,211,80,224,210,219,122,61,158,249,60,78,215,240,173,54,80,175,96,214,190,41,67,62,107,92,73,85,199,58,80,227,242,53,248,131,12,10,120,170,28,120,60,58,142,71,89,231,201,85,106,125,240,1,181,232,173,133,137,98,159,207,33,26,50,119,255,53,171,206,5,170,17,221,72,91,250,76,222,103,213,239,112,198,144,185,104,246,176,66,19,88,155,32,98,145,95,49,42,121,169,102,86,123,63,85,115,132,183,218,174,205,59,106,253,76,22,62,170,225,194,74,62,37,56,72,111,54,133,14,122,176,217,202,162,237,118,150,140,50,209,227,162,133,154,170,39,237,113,118,204,142,201,245,7,101,201,77,11,14,4,225,89,38,231,254,62,197,46,80,239,192,215,47,82,179,122,80,147,50,6,76,110,34,196,64,81,80,170,78,243,225,222,7,150,50,110,21,185,176,217,62,170,68,163,98,221,89,86,33,22,32,131,63,13,95,39,8,184,125,207,145,206,253,246,239,82,118,223,35,5,148,171,230,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("90c4c327-4a7f-a0dd-f8fb-e87a2ae11e91"));
		}

		#endregion

	}

	#endregion

}

