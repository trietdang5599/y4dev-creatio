namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: CreatioAIDocumentSchema

	/// <exclude/>
	public class CreatioAIDocumentSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CreatioAIDocumentSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CreatioAIDocumentSchema(CreatioAIDocumentSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("acf18860-6422-4915-b6e0-8cee95e572c3");
			Name = "CreatioAIDocument";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,146,75,107,195,48,16,132,207,9,228,63,44,201,165,189,216,247,164,15,138,67,138,15,41,161,62,150,30,100,121,235,8,244,48,210,250,208,134,252,247,74,118,156,146,86,4,138,47,198,59,179,154,111,176,165,153,66,215,48,142,144,89,100,36,76,146,153,70,72,67,179,233,97,54,157,180,78,232,26,138,79,71,168,86,191,230,228,181,213,36,20,38,5,90,193,164,248,10,199,181,223,242,123,11,139,181,31,32,147,204,185,229,144,253,148,175,13,111,21,106,234,150,210,52,133,59,161,247,254,56,85,134,167,15,94,123,91,51,98,153,209,100,25,167,247,32,156,211,75,137,65,104,218,82,10,14,60,36,255,13,134,37,228,17,218,228,208,17,207,189,118,214,52,104,73,160,47,183,235,2,123,63,86,169,239,180,69,85,162,189,121,241,223,11,238,97,46,52,249,224,188,154,223,134,78,67,169,231,86,84,143,144,159,60,56,64,141,180,2,23,30,199,127,2,28,58,231,155,198,9,197,96,142,66,248,63,239,88,141,113,196,118,48,71,33,62,132,140,230,195,166,51,70,103,135,247,203,116,71,54,92,209,205,201,28,77,40,248,30,21,187,202,249,89,137,209,22,168,171,254,214,117,115,175,94,138,199,111,189,13,249,147,134,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("acf18860-6422-4915-b6e0-8cee95e572c3"));
		}

		#endregion

	}

	#endregion

}

