namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IndexedDataConfigSchema

	/// <exclude/>
	public class IndexedDataConfigSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IndexedDataConfigSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IndexedDataConfigSchema(IndexedDataConfigSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5326868b-e6e3-4b52-8fc8-2345a24cdc02");
			Name = "IndexedDataConfig";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("30c103fe-34c6-441e-895c-acadc354f737");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,144,203,10,194,64,12,69,215,22,250,15,3,110,165,31,160,226,70,65,92,215,157,184,72,167,177,14,76,51,37,153,130,69,252,119,83,71,23,190,32,155,132,195,189,135,16,180,40,29,88,52,123,100,6,9,167,88,172,3,157,92,211,51,68,23,168,216,250,80,129,47,17,216,158,243,236,154,103,147,94,28,53,166,28,36,98,171,176,247,104,71,82,138,45,18,178,179,139,60,83,106,202,216,232,213,172,61,136,204,205,142,106,188,96,189,129,8,41,95,17,157,174,175,188,179,198,142,208,55,99,230,102,227,30,225,192,195,82,34,107,241,236,133,149,169,54,145,43,205,26,221,110,41,118,138,84,167,254,231,254,83,230,45,225,191,207,39,54,246,188,192,228,116,56,154,93,67,129,177,214,119,244,45,201,34,169,124,155,232,241,14,131,115,6,138,115,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5326868b-e6e3-4b52-8fc8-2345a24cdc02"));
		}

		#endregion

	}

	#endregion

}

