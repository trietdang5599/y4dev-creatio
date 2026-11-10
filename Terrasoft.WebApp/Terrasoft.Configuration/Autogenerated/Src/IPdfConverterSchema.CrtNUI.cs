namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IPdfConverterSchema

	/// <exclude/>
	public class IPdfConverterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IPdfConverterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IPdfConverterSchema(IPdfConverterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("76370a5e-e3c8-4be4-b8c3-cb6e28b3bda1");
			Name = "IPdfConverter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,101,79,189,110,131,48,16,158,131,196,59,156,50,53,11,126,128,80,22,38,134,72,25,186,69,29,14,56,71,72,245,143,206,71,35,84,245,221,107,19,72,91,34,121,249,252,253,158,69,67,193,99,71,240,70,204,24,156,150,162,118,86,15,215,145,81,6,103,243,236,43,207,118,74,41,40,195,104,12,242,84,45,184,177,66,172,147,85,59,134,206,217,79,98,1,19,224,230,184,7,38,239,34,20,7,190,215,197,26,161,254,100,248,177,253,24,58,24,30,49,205,185,215,245,61,134,24,98,109,20,61,53,207,31,245,166,172,71,193,165,42,141,49,40,197,195,171,182,230,210,35,163,1,27,47,127,221,39,231,190,58,45,57,237,36,20,230,180,162,84,179,236,215,197,36,35,219,80,197,145,255,117,43,145,148,137,184,188,175,251,94,22,152,132,135,99,228,191,243,44,190,31,41,62,139,12,116,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("76370a5e-e3c8-4be4-b8c3-cb6e28b3bda1"));
		}

		#endregion

	}

	#endregion

}

