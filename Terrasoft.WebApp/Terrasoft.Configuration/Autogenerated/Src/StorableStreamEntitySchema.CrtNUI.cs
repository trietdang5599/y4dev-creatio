namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: StorableStreamEntitySchema

	/// <exclude/>
	public class StorableStreamEntitySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public StorableStreamEntitySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public StorableStreamEntitySchema(StorableStreamEntitySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a0a87ec1-0968-41f6-a659-4da5f3e39a17");
			Name = "StorableStreamEntity";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,101,80,193,106,2,49,16,61,43,248,15,83,189,180,151,172,45,148,130,150,130,85,15,189,40,116,45,30,68,202,172,206,46,129,236,102,153,204,22,182,226,191,55,49,46,148,246,50,201,123,153,55,239,77,42,44,201,213,120,32,216,16,51,58,155,139,154,219,42,215,69,195,40,218,86,131,254,105,208,239,53,78,87,5,164,173,19,42,167,127,176,122,91,123,202,147,35,166,194,43,96,110,208,185,9,164,98,25,51,67,169,48,97,121,233,72,146,4,158,93,83,150,200,237,203,21,111,25,235,154,24,114,203,224,46,173,32,22,50,242,192,50,29,85,39,75,126,233,118,41,177,70,163,191,195,252,189,39,234,38,51,250,0,135,224,252,199,120,89,137,150,22,38,240,138,142,186,167,72,122,97,88,174,55,210,57,220,172,150,155,116,51,91,45,102,239,139,135,207,241,37,110,111,183,206,156,53,36,116,59,220,106,99,66,42,166,210,126,209,17,48,23,31,250,73,221,63,170,177,130,15,71,176,64,65,168,217,250,101,164,85,195,187,144,171,11,22,163,116,199,9,10,146,41,184,80,206,209,105,68,213,81,231,241,126,213,100,173,208,110,31,199,254,87,196,26,100,241,215,3,60,255,0,211,19,125,133,206,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a0a87ec1-0968-41f6-a659-4da5f3e39a17"));
		}

		#endregion

	}

	#endregion

}

