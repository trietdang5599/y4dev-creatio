namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: LowerExpressionConverterSchema

	/// <exclude/>
	public class LowerExpressionConverterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LowerExpressionConverterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LowerExpressionConverterSchema(LowerExpressionConverterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b69b03e9-3983-48ee-b50b-7df2ea273c76");
			Name = "LowerExpressionConverter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("75f7d434-56de-4d62-8a8c-9fe090e3ebb1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,82,201,106,195,48,16,61,59,144,127,24,156,75,12,197,190,103,49,132,144,67,160,27,36,183,210,131,98,79,92,23,91,50,35,41,109,40,249,247,74,178,229,102,235,193,50,243,230,189,167,89,196,89,141,178,97,25,194,22,137,152,20,123,21,47,5,223,151,133,38,166,74,193,135,131,159,225,32,208,178,228,5,108,142,82,97,61,29,14,12,50,34,44,76,26,150,21,147,114,2,143,226,11,105,245,221,16,74,105,96,99,113,64,82,72,150,107,216,73,146,192,76,234,186,102,116,76,187,216,73,32,99,18,65,42,178,254,216,235,33,243,6,144,217,11,98,239,145,156,153,188,221,185,111,161,140,213,78,43,28,135,206,63,140,222,13,179,209,187,170,204,90,171,127,75,133,9,172,239,193,70,111,71,16,216,207,119,253,132,234,67,228,166,239,87,231,236,211,215,109,58,160,115,146,190,203,3,171,52,198,61,61,185,230,207,26,70,172,6,110,54,51,15,29,57,76,55,231,210,89,226,24,247,5,140,10,93,35,87,50,76,97,145,231,165,221,33,171,160,135,111,213,132,74,19,151,169,239,56,191,40,20,148,128,170,223,148,81,123,186,213,119,115,237,248,43,43,96,102,244,98,247,137,153,106,245,15,62,219,87,0,115,8,195,8,220,76,131,46,105,126,6,30,183,81,228,132,83,151,47,247,30,141,215,242,89,87,213,11,173,234,70,29,45,24,121,147,160,173,201,186,180,170,147,59,255,208,120,43,220,214,215,252,192,168,100,92,141,35,71,60,185,199,25,140,144,231,237,98,93,220,162,151,224,233,23,143,16,117,214,41,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b69b03e9-3983-48ee-b50b-7df2ea273c76"));
		}

		#endregion

	}

	#endregion

}

