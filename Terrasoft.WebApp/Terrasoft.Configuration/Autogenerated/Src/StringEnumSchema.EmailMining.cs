namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: StringEnumSchema

	/// <exclude/>
	public class StringEnumSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public StringEnumSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public StringEnumSchema(StringEnumSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3d732c7c-0f8d-47a1-85af-96c11b6df501");
			Name = "StringEnum";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b6327e89-1dee-4b6f-a695-226c016beae1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,147,77,111,219,48,12,134,207,14,144,255,64,100,151,244,80,251,190,37,1,218,162,5,122,40,80,108,185,23,154,77,39,2,44,201,160,232,20,105,177,255,62,70,242,103,209,164,151,158,12,139,175,200,151,15,41,171,12,250,90,229,8,91,36,82,222,149,156,222,57,91,234,93,67,138,181,179,233,189,81,186,122,210,86,219,221,124,246,62,159,205,103,201,15,194,157,132,224,174,82,222,255,132,63,76,18,188,183,141,9,209,44,203,96,229,27,99,20,29,55,237,255,173,242,8,249,73,14,165,35,240,225,6,240,177,198,107,175,74,188,70,185,12,181,98,70,178,81,135,62,237,114,101,163,100,117,243,183,210,121,155,106,92,56,137,214,122,111,15,26,171,66,204,61,147,62,40,198,24,252,104,45,28,108,247,8,7,85,53,152,246,146,113,197,164,142,25,128,80,21,206,86,199,206,253,75,184,244,171,45,139,182,136,149,167,54,132,165,200,155,156,29,5,51,142,49,103,44,46,216,121,180,154,181,170,244,27,122,80,96,241,21,180,164,80,86,70,228,74,96,49,187,242,40,48,9,203,245,98,32,176,200,54,145,202,153,46,194,73,173,72,25,176,50,243,245,34,184,95,108,134,238,87,89,8,183,61,183,70,71,140,151,109,223,65,125,5,239,39,93,18,33,192,26,58,24,73,242,239,50,145,39,228,189,11,147,9,163,188,64,226,25,73,150,197,8,6,11,218,212,34,214,12,185,179,7,36,127,202,84,146,51,231,97,176,155,196,142,158,209,164,81,34,225,111,161,20,212,132,220,144,245,147,117,34,244,77,197,221,188,6,203,163,170,227,107,237,82,203,148,89,62,125,171,174,70,121,131,253,115,89,14,253,77,103,16,83,181,254,182,46,202,150,87,227,97,124,202,247,119,180,32,91,118,22,20,156,64,238,21,75,71,181,52,133,150,189,252,107,223,239,228,37,142,31,201,220,124,79,157,79,200,57,225,75,186,192,238,105,14,16,166,136,94,190,218,210,120,58,61,148,179,255,185,104,1,177,38,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3d732c7c-0f8d-47a1-85af-96c11b6df501"));
		}

		#endregion

	}

	#endregion

}

