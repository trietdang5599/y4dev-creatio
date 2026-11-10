namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SearchColumnSchema

	/// <exclude/>
	public class SearchColumnSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SearchColumnSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SearchColumnSchema(SearchColumnSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1e9e33bb-e2f8-4c17-b5b6-db4500bda4ab");
			Name = "SearchColumn";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,79,75,10,131,48,16,93,43,120,135,1,247,61,64,187,116,95,164,246,2,211,244,25,3,154,132,73,92,20,241,238,85,83,10,45,46,218,205,192,251,242,198,242,128,224,89,129,174,16,225,224,218,120,168,156,109,141,30,133,163,113,182,200,167,34,47,242,172,20,232,5,82,213,115,8,71,106,192,162,186,202,245,227,96,55,221,143,183,222,40,82,171,252,165,102,169,225,93,81,139,243,144,104,176,244,212,91,44,233,175,138,16,197,88,77,23,180,16,88,133,70,117,24,248,188,12,165,137,52,226,137,194,122,230,189,208,63,222,52,239,55,239,245,225,119,93,37,236,61,125,181,225,196,126,146,243,19,109,206,243,34,99,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1e9e33bb-e2f8-4c17-b5b6-db4500bda4ab"));
		}

		#endregion

	}

	#endregion

}

