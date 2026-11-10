namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ISectionStructureBuilderSchema

	/// <exclude/>
	public class ISectionStructureBuilderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISectionStructureBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISectionStructureBuilderSchema(ISectionStructureBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3f3b188d-ae35-4cb4-bff8-fb00b0b7fadd");
			Name = "ISectionStructureBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,143,65,10,194,48,16,69,215,41,244,14,1,55,10,210,3,216,149,213,77,55,110,234,5,98,58,173,129,38,41,51,19,161,72,239,110,210,162,184,209,213,240,135,63,255,191,113,202,2,141,74,131,188,2,162,34,223,113,113,242,174,51,125,64,197,198,187,60,123,230,89,158,137,64,198,245,178,153,136,193,150,31,253,125,132,240,107,95,156,171,114,9,217,32,244,49,83,214,142,1,187,216,122,144,117,3,58,245,52,140,65,115,64,168,130,25,90,192,197,63,134,219,96,180,52,111,251,31,183,136,152,66,60,188,105,229,113,28,135,233,20,136,189,141,175,180,38,29,208,150,24,19,25,233,59,88,117,137,111,239,101,3,67,140,147,180,140,93,162,159,87,76,112,237,74,154,228,252,2,223,20,32,138,36,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3f3b188d-ae35-4cb4-bff8-fb00b0b7fadd"));
		}

		#endregion

	}

	#endregion

}

