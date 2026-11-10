namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DefaultFieldMapperSchema

	/// <exclude/>
	public class DefaultFieldMapperSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DefaultFieldMapperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DefaultFieldMapperSchema(DefaultFieldMapperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dd14c32f-0ced-492a-9501-56c2b7f9064c");
			Name = "DefaultFieldMapper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe674b36-6b4e-4761-be68-f76112863a49");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,145,77,107,195,48,12,134,207,9,244,63,136,238,210,66,73,238,253,130,209,117,35,176,110,131,13,118,118,98,165,241,230,216,193,118,90,74,233,127,159,18,183,37,41,133,93,108,252,234,209,43,89,82,172,68,91,177,12,225,11,141,97,86,231,46,90,105,149,139,109,109,152,19,90,13,194,227,32,12,106,43,212,22,62,15,214,97,73,113,41,49,107,130,54,122,65,133,70,100,179,65,72,212,131,193,45,169,176,146,204,218,41,60,97,206,106,233,158,5,74,190,97,85,133,166,165,226,56,134,185,80,5,229,57,174,51,200,12,230,139,97,210,193,134,241,146,184,170,78,165,160,112,99,118,199,11,166,144,244,172,131,99,107,127,237,98,131,174,208,156,250,248,104,141,124,240,255,226,17,93,237,211,250,54,46,125,236,180,224,112,141,141,146,181,170,75,52,44,149,56,183,206,208,120,150,176,199,180,208,250,215,19,19,120,21,214,205,191,189,70,51,171,75,69,233,75,40,155,50,220,67,99,104,166,27,4,185,54,200,178,2,70,222,170,231,4,66,245,157,47,73,193,142,153,198,237,61,253,161,117,192,2,20,238,225,182,222,133,13,214,202,9,119,240,250,27,109,157,248,174,235,228,140,245,242,239,112,30,59,205,252,221,253,75,244,200,249,232,218,206,216,19,167,230,60,157,23,131,138,251,221,180,111,175,246,69,210,254,0,72,99,10,66,146,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dd14c32f-0ced-492a-9501-56c2b7f9064c"));
		}

		#endregion

	}

	#endregion

}

