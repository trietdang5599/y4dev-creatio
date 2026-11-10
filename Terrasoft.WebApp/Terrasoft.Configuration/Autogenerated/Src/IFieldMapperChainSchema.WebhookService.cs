namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IFieldMapperChainSchema

	/// <exclude/>
	public class IFieldMapperChainSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFieldMapperChainSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFieldMapperChainSchema(IFieldMapperChainSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a18d0b8b-0554-48fe-80f3-0d61e8456086");
			Name = "IFieldMapperChain";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe674b36-6b4e-4761-be68-f76112863a49");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,82,81,107,131,48,16,126,86,240,63,28,237,203,6,195,188,111,206,151,178,149,62,116,12,90,216,115,170,167,134,153,68,46,201,70,41,251,239,75,212,110,90,54,168,136,152,203,221,119,223,247,221,41,46,209,116,188,64,216,35,17,55,186,178,233,74,171,74,212,142,184,21,90,37,241,41,137,35,103,132,170,97,119,52,22,165,191,111,91,44,194,165,73,215,168,144,68,241,144,196,62,139,49,6,153,113,82,114,58,230,227,121,223,32,116,164,63,68,137,4,186,130,79,60,52,90,191,3,42,43,236,49,61,87,177,73,89,231,14,173,40,64,40,139,84,5,106,155,103,129,109,185,229,93,135,180,106,184,240,164,162,83,232,8,227,179,36,172,61,29,216,162,109,116,105,238,225,181,135,152,166,92,112,155,134,215,104,13,88,207,83,134,14,37,84,161,155,73,47,106,217,223,197,89,199,137,75,80,222,199,199,197,40,174,167,107,22,121,208,126,214,59,130,102,172,207,191,2,100,167,29,21,56,7,49,125,236,26,144,193,222,23,255,191,200,195,55,88,31,36,142,182,255,131,64,104,29,41,211,247,156,155,145,177,243,157,247,62,218,60,41,39,145,248,161,197,236,109,224,230,151,194,73,229,103,148,7,63,251,89,149,131,15,55,211,108,99,201,111,82,14,51,167,238,96,8,195,76,250,79,244,87,203,237,176,103,209,18,85,57,140,188,63,127,37,177,127,191,1,99,129,203,135,203,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a18d0b8b-0554-48fe-80f3-0d61e8456086"));
		}

		#endregion

	}

	#endregion

}

