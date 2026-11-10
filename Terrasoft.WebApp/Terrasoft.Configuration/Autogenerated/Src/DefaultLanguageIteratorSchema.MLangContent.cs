namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DefaultLanguageIteratorSchema

	/// <exclude/>
	public class DefaultLanguageIteratorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DefaultLanguageIteratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DefaultLanguageIteratorSchema(DefaultLanguageIteratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("aeeb29af-e2e5-4dd2-b9f3-3255567cf2c9");
			Name = "DefaultLanguageIterator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("2659875a-4670-491c-9c1f-f4641a7bae64");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,146,77,79,195,48,12,134,207,157,180,255,96,117,23,38,85,235,125,95,7,198,101,18,66,8,216,9,113,240,50,183,139,212,38,85,62,64,128,246,223,73,210,140,181,27,227,212,198,126,109,63,126,19,129,53,233,6,25,193,11,41,133,90,22,102,178,146,162,224,165,85,104,184,20,195,193,247,112,144,88,205,69,217,147,40,154,13,7,46,51,82,84,58,25,172,42,212,122,10,119,84,160,173,204,61,138,210,98,73,107,67,174,141,84,65,154,231,57,204,181,173,107,84,159,203,120,142,122,168,98,1,240,88,145,129,217,163,129,70,201,119,190,163,83,190,80,178,6,38,133,65,102,90,137,38,3,92,128,102,123,170,113,114,156,147,119,6,53,118,91,113,6,204,35,94,35,132,41,220,162,166,75,240,196,239,127,90,83,10,109,148,101,46,229,182,125,12,141,195,114,23,219,133,192,90,112,195,177,226,95,164,65,208,135,227,212,6,133,115,91,22,78,76,4,76,81,177,72,175,48,165,249,114,242,219,58,63,239,61,111,80,97,13,194,221,224,34,181,154,148,99,19,196,252,165,165,203,141,59,123,155,98,96,50,207,131,250,239,226,214,186,7,247,159,46,159,195,127,214,90,236,112,253,198,222,235,94,135,104,232,21,236,155,77,15,6,250,108,25,56,3,253,107,58,77,29,251,158,201,20,182,238,2,110,250,234,49,4,251,147,227,140,39,91,57,43,23,193,204,117,55,248,250,22,149,137,79,69,178,200,222,213,157,193,101,93,140,236,162,193,63,149,45,244,97,230,63,135,246,9,140,72,236,218,119,18,206,109,180,31,60,252,0,238,118,137,120,113,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("aeeb29af-e2e5-4dd2-b9f3-3255567cf2c9"));
		}

		#endregion

	}

	#endregion

}

