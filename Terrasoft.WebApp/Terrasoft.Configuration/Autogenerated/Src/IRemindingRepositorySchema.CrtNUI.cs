namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IRemindingRepositorySchema

	/// <exclude/>
	public class IRemindingRepositorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IRemindingRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IRemindingRepositorySchema(IRemindingRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4233de2b-b2d2-4f8a-93e4-3ee4626b552e");
			Name = "IRemindingRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,82,205,106,2,49,16,62,43,248,14,131,94,236,197,189,87,187,151,82,150,92,74,209,190,64,220,76,116,96,147,44,147,68,144,210,119,111,18,255,22,109,11,123,201,240,253,206,142,149,6,125,47,91,132,79,100,150,222,233,176,120,117,86,211,46,178,12,228,236,100,252,53,25,143,162,39,187,131,205,209,7,52,203,187,119,194,119,29,182,25,236,23,13,90,100,106,51,38,125,51,198,93,26,131,176,1,89,39,151,103,16,107,52,100,85,162,175,177,119,158,130,227,227,100,156,176,85,85,193,202,71,99,36,31,235,243,251,131,221,129,20,122,144,96,48,236,157,2,237,24,24,91,164,67,14,192,69,11,217,47,46,2,213,64,161,143,219,142,90,160,139,249,31,222,163,92,240,193,190,12,214,24,34,91,127,246,73,188,98,244,232,116,154,240,9,93,223,246,1,164,33,236,113,200,95,85,23,88,230,137,55,27,13,178,220,118,184,18,239,46,144,166,182,172,93,88,237,106,104,48,92,35,251,249,211,178,44,234,247,168,27,12,195,156,64,30,60,218,240,95,222,94,178,52,96,211,5,188,76,175,76,161,166,195,2,238,174,0,164,223,97,115,76,228,84,165,40,20,193,131,35,149,51,220,226,10,191,73,200,249,176,97,19,73,213,48,176,202,141,70,223,165,213,12,173,58,93,75,57,157,52,252,1,252,54,224,50,155,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4233de2b-b2d2-4f8a-93e4-3ee4626b552e"));
		}

		#endregion

	}

	#endregion

}

