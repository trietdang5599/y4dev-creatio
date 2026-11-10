namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: FieldMapperChainSchema

	/// <exclude/>
	public class FieldMapperChainSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FieldMapperChainSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FieldMapperChainSchema(FieldMapperChainSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("78eea549-96b0-4d4a-9003-79a704dc0682");
			Name = "FieldMapperChain";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe674b36-6b4e-4761-be68-f76112863a49");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,83,193,78,227,48,16,61,7,137,127,24,177,151,84,66,205,157,210,92,42,64,72,128,144,88,105,143,43,55,153,52,22,137,29,198,118,81,133,248,119,38,113,18,185,77,128,147,147,55,111,230,141,103,158,149,168,209,52,34,67,248,139,68,194,232,194,46,55,90,21,114,231,72,88,169,213,249,217,199,249,89,228,140,84,59,120,57,24,139,53,199,171,10,179,54,104,150,119,168,144,100,182,58,229,60,72,245,198,32,195,127,8,119,76,133,77,37,140,185,130,91,137,85,254,40,154,6,105,83,10,169,58,78,146,36,112,45,85,201,165,108,174,51,200,8,139,245,197,253,41,247,34,73,153,220,184,109,37,153,211,214,155,148,131,43,152,164,113,206,71,39,51,246,210,49,184,153,103,146,123,97,209,7,27,255,115,148,127,43,50,171,233,0,255,139,9,182,234,75,162,202,125,213,99,137,103,210,204,181,18,91,153,174,99,31,239,174,106,92,93,11,58,164,3,112,135,214,128,38,48,237,105,75,132,78,14,234,78,15,10,47,184,28,211,147,48,191,31,199,92,215,51,80,187,204,40,218,161,237,191,34,89,64,60,115,59,88,175,65,185,170,90,12,188,136,208,58,82,115,147,0,166,226,251,140,90,188,88,249,228,79,127,124,95,194,243,60,141,135,0,235,244,27,161,189,168,28,118,236,207,159,231,255,136,182,212,249,220,240,127,247,25,187,218,118,191,185,55,138,247,221,56,233,27,229,106,36,177,173,240,250,31,110,75,173,95,249,69,184,90,113,74,10,39,169,113,200,54,150,248,137,164,240,238,179,60,227,18,60,60,160,47,218,81,134,151,126,20,62,130,202,74,123,120,226,167,58,172,99,47,200,187,163,151,233,87,240,32,141,157,246,52,172,33,108,37,188,115,218,27,173,173,50,93,226,56,12,50,241,113,139,97,95,94,161,208,132,34,43,33,14,203,67,176,72,224,23,218,139,141,206,10,194,75,62,250,185,157,204,40,188,236,34,116,75,239,169,48,254,131,61,60,122,12,50,246,5,114,201,32,23,6,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("78eea549-96b0-4d4a-9003-79a704dc0682"));
		}

		#endregion

	}

	#endregion

}

