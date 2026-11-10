namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ITimelineDataLoaderSchema

	/// <exclude/>
	public class ITimelineDataLoaderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITimelineDataLoaderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITimelineDataLoaderSchema(ITimelineDataLoaderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("64fda8d7-1a00-44a6-879f-e69e891738f1");
			Name = "ITimelineDataLoader";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ef55f699-c757-427c-a5d6-6f8a0d355b0a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,81,203,78,195,48,16,60,55,82,254,97,21,46,32,161,228,3,8,57,20,16,66,234,9,250,3,198,217,68,43,217,235,224,199,33,66,253,119,236,56,169,64,237,133,163,119,102,60,59,59,44,52,186,73,72,132,35,90,43,156,25,124,253,100,120,160,49,88,225,201,112,125,36,141,138,24,203,226,187,44,118,193,17,143,240,49,59,143,58,18,149,66,153,88,174,126,69,70,75,242,161,44,34,235,198,226,24,167,240,182,137,159,133,23,7,35,122,180,11,222,52,13,180,46,104,45,236,220,173,239,4,59,216,4,208,71,5,12,198,130,155,80,210,64,18,144,61,249,185,222,228,205,47,253,20,62,85,100,16,123,180,67,10,115,213,120,151,2,92,120,255,215,252,210,61,79,38,97,133,6,142,247,124,172,50,187,234,94,178,170,109,22,240,58,87,46,215,174,186,179,185,138,187,64,158,254,81,30,200,249,118,111,2,247,27,53,127,223,45,219,167,160,183,27,176,176,50,186,110,126,127,14,247,142,95,1,157,207,37,175,62,119,185,182,83,46,15,185,207,253,165,231,233,7,69,16,162,172,34,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("64fda8d7-1a00-44a6-879f-e69e891738f1"));
		}

		#endregion

	}

	#endregion

}

