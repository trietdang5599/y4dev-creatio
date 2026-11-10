namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: MergeSocialMessageReferencesFactorySchema

	/// <exclude/>
	public class MergeSocialMessageReferencesFactorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MergeSocialMessageReferencesFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MergeSocialMessageReferencesFactorySchema(MergeSocialMessageReferencesFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e48291b4-a733-42d9-a644-93ba7e513590");
			Name = "MergeSocialMessageReferencesFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b66b5ae8-46e0-4931-ad78-c2c1ba5fd6ea");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,82,193,74,3,49,16,61,183,208,127,24,214,131,45,148,221,187,214,30,180,85,10,86,196,122,19,145,152,157,221,6,118,147,37,147,173,44,210,127,119,154,212,214,197,46,244,146,144,228,205,203,123,111,70,139,18,169,18,18,225,21,173,21,100,50,23,223,25,157,169,188,182,194,41,163,227,249,234,105,208,255,30,244,123,53,41,157,195,170,33,135,37,99,138,2,229,14,64,241,3,106,180,74,94,31,48,93,84,51,76,235,170,80,210,159,78,195,45,198,247,66,58,99,21,18,35,24,115,97,49,103,56,44,209,230,184,50,82,137,98,137,68,34,199,23,204,208,162,150,72,161,164,241,248,36,73,96,66,117,89,10,219,76,247,231,103,107,54,42,69,2,242,245,80,6,130,75,2,145,231,204,47,28,130,61,176,197,240,75,147,252,225,121,155,97,38,234,194,221,42,157,178,234,161,107,42,52,217,112,225,117,253,147,50,26,195,19,71,11,55,16,157,33,60,26,189,243,15,85,253,201,225,128,44,4,209,57,118,225,10,58,126,103,178,111,31,198,33,189,123,133,69,74,87,156,132,218,176,219,240,88,133,3,144,227,142,72,78,64,164,70,23,13,180,73,143,173,134,143,99,72,236,76,227,87,55,116,55,49,189,94,88,123,81,203,72,52,246,165,143,138,220,132,156,229,48,167,123,56,35,231,218,41,215,44,210,40,92,108,253,230,215,237,245,222,18,234,52,184,106,91,92,162,91,27,239,209,231,24,30,125,27,149,94,243,128,186,212,200,100,234,125,135,160,59,181,63,160,59,70,58,12,18,129,228,26,75,177,107,234,8,110,166,127,163,56,173,107,27,166,183,117,185,253,1,151,55,60,113,111,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e48291b4-a733-42d9-a644-93ba7e513590"));
		}

		#endregion

	}

	#endregion

}

