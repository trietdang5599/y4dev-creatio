namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ObjectFilesCopySettingsSchema

	/// <exclude/>
	public class ObjectFilesCopySettingsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ObjectFilesCopySettingsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ObjectFilesCopySettingsSchema(ObjectFilesCopySettingsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8c876db7-b521-4b78-af16-6a8f941e5884");
			Name = "ObjectFilesCopySettings";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("8b1c57bf-1ff6-4af0-890b-4cc1ace5ccaa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,146,193,110,194,48,12,134,207,32,237,29,44,113,111,239,48,237,82,49,180,211,96,101,15,16,82,183,245,212,38,93,156,104,170,208,222,125,73,10,168,76,48,49,110,245,95,255,254,191,218,85,162,69,238,132,68,216,162,49,130,117,105,147,76,171,146,42,103,132,37,173,30,166,251,135,233,196,49,169,10,242,158,45,182,139,83,61,182,24,76,150,202,146,37,100,223,224,91,102,6,43,239,135,172,17,204,115,120,221,125,160,180,207,212,32,103,186,235,115,180,214,143,224,216,154,166,41,60,178,107,91,97,250,167,67,253,134,157,65,70,101,25,116,180,66,25,188,32,189,25,248,224,78,142,230,116,228,238,220,174,33,9,50,228,94,143,157,236,99,244,9,115,109,116,135,38,224,207,97,29,39,12,239,127,179,69,97,133,1,203,4,14,134,101,190,1,171,253,115,19,40,191,106,146,117,100,13,98,160,77,78,99,198,148,71,204,184,180,62,151,53,182,98,227,208,244,23,148,61,84,104,23,33,109,1,223,183,98,57,69,159,14,129,10,191,67,42,9,13,232,18,10,100,255,253,241,176,128,49,7,56,6,253,13,185,114,84,192,86,24,143,49,166,123,127,41,238,99,59,135,178,53,250,69,41,229,215,135,197,225,218,55,240,100,71,203,112,227,123,89,46,238,233,18,146,23,26,215,170,255,147,101,209,119,101,89,51,84,197,240,11,198,122,80,207,69,175,253,0,231,134,208,249,167,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8c876db7-b521-4b78-af16-6a8f941e5884"));
		}

		#endregion

	}

	#endregion

}

