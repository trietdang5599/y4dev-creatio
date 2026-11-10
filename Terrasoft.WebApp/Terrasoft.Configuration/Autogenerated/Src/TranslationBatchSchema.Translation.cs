namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: TranslationBatchSchema

	/// <exclude/>
	public class TranslationBatchSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TranslationBatchSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TranslationBatchSchema(TranslationBatchSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("10369cb8-3549-4f33-8ff6-7c40df21ba6d");
			Name = "TranslationBatch";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ab054f7f-9309-4520-a5a0-bfba22ceff76");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,143,205,74,3,49,20,133,215,25,152,119,184,224,70,161,204,236,219,218,133,21,68,220,20,236,11,196,120,59,13,102,50,195,189,137,48,20,223,221,252,169,211,214,85,38,103,14,231,251,98,101,143,60,74,133,176,71,34,201,195,193,53,219,193,30,116,231,73,58,61,216,102,79,210,178,73,223,117,117,170,43,225,89,219,14,94,39,118,216,135,174,49,168,226,79,110,158,208,34,105,181,170,171,208,186,33,236,66,10,91,35,153,151,48,91,121,144,78,29,83,103,244,111,70,43,80,177,114,213,128,37,60,234,180,44,105,90,179,163,64,93,64,62,55,11,120,190,94,20,167,180,250,135,14,82,142,188,114,3,5,131,93,130,229,70,1,95,78,220,230,117,248,192,233,14,226,83,133,120,193,9,238,99,176,138,215,175,2,64,251,158,25,231,192,29,13,35,146,211,120,129,107,219,22,214,236,251,62,188,100,243,19,204,224,113,191,249,45,182,243,102,49,45,98,209,38,123,117,232,146,145,24,73,127,74,135,192,37,248,95,49,167,231,97,200,190,1,35,55,58,13,254,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("10369cb8-3549-4f33-8ff6-7c40df21ba6d"));
		}

		#endregion

	}

	#endregion

}

