namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: PropertyDefinitionJsonConverterSchema

	/// <exclude/>
	public class PropertyDefinitionJsonConverterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PropertyDefinitionJsonConverterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PropertyDefinitionJsonConverterSchema(PropertyDefinitionJsonConverterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d6a0401f-a958-433b-aa65-03c1287112a1");
			Name = "PropertyDefinitionJsonConverter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("efe6ccd0-4801-4cb7-acb1-e0c434c41931");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,83,219,110,219,48,12,125,78,129,254,3,209,13,133,13,120,14,246,218,52,125,241,138,97,67,215,5,75,176,61,43,54,29,43,147,37,79,151,100,94,144,127,47,37,59,183,54,5,182,1,134,44,82,228,57,135,20,37,89,141,166,97,57,194,12,181,102,70,149,54,205,148,44,249,194,105,102,185,146,233,189,212,60,175,106,148,246,242,98,115,121,49,112,134,203,5,76,91,99,177,30,237,237,71,92,91,37,67,250,103,163,228,171,7,233,3,151,191,14,167,7,210,3,77,250,73,90,212,37,105,50,105,86,49,155,169,186,17,232,181,248,60,250,134,195,33,220,26,87,215,76,183,119,189,157,57,99,85,13,158,130,228,175,80,19,4,148,74,195,68,171,134,172,246,3,150,92,114,143,2,86,65,197,100,33,16,222,106,44,223,41,41,90,80,243,37,230,214,164,59,248,225,17,126,227,230,130,231,144,11,102,204,25,188,83,206,155,83,13,183,47,227,61,36,53,146,214,193,27,141,11,175,168,15,226,104,110,96,18,216,186,243,32,133,203,10,53,183,133,202,97,232,115,119,122,20,49,104,94,32,204,149,18,144,49,249,131,162,16,198,119,80,50,97,112,212,83,160,44,58,150,83,202,47,104,43,85,252,23,223,153,150,126,67,86,248,186,35,191,120,131,58,161,195,47,129,89,219,96,223,95,191,77,60,228,96,112,6,4,127,115,99,105,42,190,51,225,48,233,202,170,152,185,63,117,123,134,41,9,100,130,255,33,22,179,223,198,176,9,208,188,132,168,227,78,103,234,39,202,192,63,30,135,196,224,72,31,157,16,187,232,129,70,235,180,4,73,190,81,240,108,195,186,98,26,150,10,40,237,107,144,158,62,40,86,244,184,241,104,79,180,84,233,76,183,31,209,6,117,209,149,159,168,171,4,148,179,224,17,200,10,148,49,92,95,19,28,61,45,39,173,23,243,254,5,63,174,207,53,118,67,173,45,73,197,14,136,74,154,90,77,221,136,98,216,62,215,171,209,56,65,240,175,128,69,189,238,67,203,210,137,106,156,96,22,125,29,25,21,103,177,187,188,40,78,122,180,62,167,87,217,249,130,107,251,47,35,179,82,188,128,48,159,251,41,9,150,134,117,248,37,231,106,95,253,229,133,31,213,179,143,139,118,184,1,36,62,86,252,236,69,144,151,190,39,73,91,116,88,8,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d6a0401f-a958-433b-aa65-03c1287112a1"));
		}

		#endregion

	}

	#endregion

}

