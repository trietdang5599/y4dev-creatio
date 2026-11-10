namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EqualComparatorProviderSchema

	/// <exclude/>
	public class EqualComparatorProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EqualComparatorProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EqualComparatorProviderSchema(EqualComparatorProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ebef606a-f1e5-4bdb-b9fe-2515dda709fc");
			Name = "EqualComparatorProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,189,84,203,74,195,64,20,93,183,208,127,184,82,144,20,36,217,219,86,23,109,17,23,106,177,226,126,154,220,180,35,201,76,156,135,16,31,255,238,100,102,18,211,52,186,16,116,21,230,220,123,206,185,47,194,72,142,178,32,49,194,3,10,65,36,79,85,184,224,44,165,59,45,136,162,156,133,43,166,168,42,55,37,139,247,130,51,250,106,209,209,240,109,52,28,13,7,90,82,182,131,77,41,21,230,83,139,140,5,238,76,2,44,50,34,229,57,172,158,53,201,22,60,47,136,145,227,98,45,248,11,77,80,216,212,40,138,96,38,117,158,19,81,94,248,183,79,144,16,55,28,9,41,23,144,208,52,69,129,76,129,42,11,148,97,205,143,90,2,133,222,102,52,134,184,178,254,206,25,206,225,250,219,162,6,174,171,166,137,27,84,123,158,152,54,214,86,217,5,187,101,91,224,30,149,22,76,2,86,210,173,226,109,237,82,9,51,166,176,33,71,93,246,76,56,250,197,87,81,225,44,170,193,42,203,183,214,89,195,130,103,58,103,95,36,184,66,181,177,102,157,22,131,9,188,85,50,3,167,9,9,102,184,35,10,3,190,125,194,88,129,228,90,196,248,72,50,141,103,224,49,179,5,69,153,245,177,129,90,162,214,8,90,36,56,153,3,211,89,6,167,167,71,188,118,172,69,9,109,137,50,56,178,153,56,151,193,251,187,177,112,147,187,150,183,70,224,78,172,242,66,149,129,71,39,45,177,137,21,255,41,249,216,102,106,125,62,236,231,227,183,171,77,204,16,31,104,142,255,180,220,165,177,251,203,213,46,125,59,151,158,86,191,97,14,65,19,107,15,126,218,229,181,164,251,201,93,239,105,223,81,53,212,254,187,234,134,253,197,52,7,86,199,67,119,105,213,179,231,220,122,178,14,143,175,51,130,159,75,241,225,190,179,26,35,75,220,31,197,190,29,122,8,26,236,19,174,91,181,145,139,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ebef606a-f1e5-4bdb-b9fe-2515dda709fc"));
		}

		#endregion

	}

	#endregion

}

