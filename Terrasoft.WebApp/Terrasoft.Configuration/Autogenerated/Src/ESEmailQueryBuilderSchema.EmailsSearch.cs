namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ESEmailQueryBuilderSchema

	/// <exclude/>
	public class ESEmailQueryBuilderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ESEmailQueryBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ESEmailQueryBuilderSchema(ESEmailQueryBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0cc00175-fb23-4f7d-bfe2-e685b5c0080c");
			Name = "ESEmailQueryBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a23b23cb-9341-4081-891a-73b7d61e02fc");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,83,205,138,219,48,16,62,123,97,223,97,186,123,73,32,152,28,122,74,8,133,77,183,203,30,182,108,73,219,75,233,65,145,39,142,64,150,204,104,20,8,75,222,189,99,203,45,182,235,180,198,24,105,52,51,223,143,198,224,84,133,161,86,26,225,43,18,169,224,15,156,111,189,59,152,50,146,98,227,93,254,88,41,99,195,14,21,233,227,237,205,219,237,77,22,131,113,229,181,252,245,255,18,242,39,235,247,202,166,134,211,217,132,18,7,121,166,142,242,79,74,179,39,131,97,144,180,59,11,71,102,89,6,216,140,75,134,4,122,169,210,66,24,220,19,150,114,0,218,170,16,86,240,184,107,53,127,137,72,231,135,104,108,129,36,73,242,254,248,136,7,21,45,63,24,87,72,245,140,207,53,250,195,236,121,162,96,62,255,41,5,117,220,91,163,83,223,169,182,208,128,245,3,11,152,106,150,116,54,214,255,161,250,74,190,70,98,113,97,37,107,115,82,140,173,148,172,78,27,248,22,144,68,182,67,221,104,30,111,223,160,68,94,195,101,88,163,189,11,12,198,49,116,66,119,71,31,109,241,162,88,31,197,212,247,203,100,87,118,143,174,72,60,186,253,36,41,207,2,134,197,111,136,110,11,254,36,119,99,10,108,113,94,140,51,85,172,122,56,175,72,26,29,171,18,147,224,76,136,118,171,236,164,8,194,128,82,239,42,243,39,228,239,202,70,156,13,181,46,224,174,63,113,127,67,221,45,96,57,95,39,4,66,142,228,6,32,239,54,176,132,15,131,208,106,194,159,212,224,210,124,47,255,118,105,219,184,76,177,25,226,198,167,118,68,58,147,210,184,76,76,192,72,147,204,252,80,226,115,18,183,245,54,86,238,179,252,211,98,255,201,52,19,22,174,28,204,91,190,43,216,171,128,179,171,73,157,243,35,244,205,8,127,125,69,117,23,235,135,36,242,11,124,11,66,214,116,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0cc00175-fb23-4f7d-bfe2-e685b5c0080c"));
		}

		#endregion

	}

	#endregion

}

