namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IMergeReferencesFactorySchema

	/// <exclude/>
	public class IMergeReferencesFactorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMergeReferencesFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMergeReferencesFactorySchema(IMergeReferencesFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3658508f-d4ef-48d0-af35-afb96664f468");
			Name = "IMergeReferencesFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,145,193,74,196,48,16,134,207,45,244,29,6,188,232,165,185,235,178,151,21,101,15,138,44,190,64,76,38,221,64,147,148,153,68,40,178,239,110,154,90,173,148,189,12,204,207,204,207,247,207,120,233,144,7,169,16,222,145,72,114,48,177,61,4,111,108,151,72,70,27,124,251,136,58,13,189,85,165,107,234,175,166,110,234,234,134,176,203,45,28,125,68,50,121,253,30,142,47,72,29,158,208,32,161,87,200,79,82,197,64,99,25,23,66,192,142,147,115,146,198,253,79,255,70,225,211,106,100,112,24,207,65,51,152,64,128,62,218,56,2,253,186,128,78,100,125,151,135,178,57,12,20,178,198,237,98,41,86,158,67,250,200,148,96,23,162,235,64,85,206,80,109,152,138,112,194,152,200,51,168,208,247,168,166,196,16,204,26,103,130,220,176,108,97,102,133,102,183,253,225,138,91,187,19,203,200,180,243,159,119,181,244,140,241,47,198,45,199,114,17,86,103,116,242,53,255,239,238,161,28,249,2,185,76,191,65,175,231,247,76,242,229,27,84,75,200,79,226,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3658508f-d4ef-48d0-af35-afb96664f468"));
		}

		#endregion

	}

	#endregion

}

