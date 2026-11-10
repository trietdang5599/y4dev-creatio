namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IGoogleServiceSchema

	/// <exclude/>
	public class IGoogleServiceSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IGoogleServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IGoogleServiceSchema(IGoogleServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("956a9445-e36a-4d6f-9741-e5836ee6b58c");
			Name = "IGoogleService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,146,209,107,194,48,16,198,159,21,252,31,14,247,162,32,237,187,58,97,19,38,29,56,101,21,124,16,31,98,122,173,97,109,210,37,169,80,196,255,125,103,98,69,183,225,99,190,251,242,203,125,119,145,172,64,83,50,142,176,66,173,153,81,169,13,166,74,166,34,171,52,179,66,201,32,86,92,176,188,211,62,118,218,173,202,8,153,65,92,27,139,69,16,163,62,8,142,115,149,96,62,122,84,12,94,184,21,7,71,123,236,91,227,142,12,100,121,210,152,145,27,34,105,81,167,212,221,16,162,153,82,89,142,23,191,115,109,46,7,234,215,106,198,109,239,131,194,192,51,116,239,172,221,254,150,188,101,181,203,5,7,209,0,255,240,90,71,199,188,62,61,71,187,87,137,25,194,210,221,244,197,48,12,97,108,170,162,96,186,158,52,194,39,218,74,75,3,92,73,42,161,166,71,82,165,11,151,23,216,78,85,22,50,247,22,152,61,211,152,0,43,75,34,250,233,94,169,225,111,236,88,123,238,100,250,15,55,24,135,77,249,236,223,44,74,244,235,106,102,177,117,50,13,52,146,7,245,133,61,31,231,60,156,229,34,94,117,7,212,245,119,133,198,190,57,34,233,100,157,163,49,44,67,47,5,239,70,201,1,188,170,164,142,109,157,227,157,229,170,6,107,77,105,48,57,243,76,73,141,226,99,160,219,69,203,143,190,201,21,81,172,230,54,204,208,222,234,189,254,232,178,22,148,137,223,140,59,159,252,55,185,19,79,63,9,13,135,131,204,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("956a9445-e36a-4d6f-9741-e5836ee6b58c"));
		}

		#endregion

	}

	#endregion

}

