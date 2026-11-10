namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: LlmModelReferenceSchema

	/// <exclude/>
	public class LlmModelReferenceSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LlmModelReferenceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LlmModelReferenceSchema(LlmModelReferenceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("df49f534-b8ea-4202-ac3e-781f0650f206");
			Name = "LlmModelReference";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("11a936bf-8ee0-4505-a8db-e67a2dd080a5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,144,65,107,195,48,12,133,239,129,252,7,193,238,201,125,29,131,145,67,41,164,151,118,183,177,131,106,43,153,192,150,139,101,51,178,210,255,190,120,89,183,142,213,7,97,30,159,244,30,79,208,147,30,209,16,60,83,140,168,97,72,77,23,100,224,49,71,76,28,164,89,147,60,109,234,234,84,87,48,191,172,44,35,236,39,77,228,87,117,181,136,119,145,198,25,133,206,161,234,61,244,206,111,131,37,183,163,129,34,137,161,11,215,182,45,60,104,246,30,227,244,248,43,245,60,190,165,119,42,19,226,101,7,82,0,20,232,251,45,248,114,12,76,144,132,44,197,62,136,155,128,84,73,18,163,3,182,229,51,176,249,10,12,22,19,54,87,134,237,95,199,151,61,197,121,139,63,240,224,232,117,209,142,249,224,216,128,41,249,111,197,47,204,119,1,87,248,58,179,133,141,133,19,140,148,86,160,101,156,255,81,154,98,201,220,205,39,111,145,231,159,18,73,236,210,99,93,205,226,39,150,193,16,164,153,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("df49f534-b8ea-4202-ac3e-781f0650f206"));
		}

		#endregion

	}

	#endregion

}

