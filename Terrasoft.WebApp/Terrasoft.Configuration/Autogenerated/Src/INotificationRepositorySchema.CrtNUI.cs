namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: INotificationRepositorySchema

	/// <exclude/>
	public class INotificationRepositorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationRepositorySchema(INotificationRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6c3d2ee1-fb37-4416-8019-d5f16be32ce0");
			Name = "INotificationRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,197,146,193,74,196,48,20,69,215,83,152,127,120,116,53,110,218,15,176,22,84,164,116,51,139,209,31,72,227,75,13,164,73,121,73,22,69,252,119,147,104,235,116,20,69,65,6,66,160,205,189,185,231,221,86,179,1,237,200,56,194,3,18,49,107,132,43,110,141,22,178,247,196,156,52,122,155,61,111,179,141,183,82,247,112,63,89,135,67,56,87,10,121,60,180,69,131,26,73,242,203,160,9,171,44,75,168,172,31,6,70,83,253,254,220,106,135,36,98,130,48,4,143,204,49,96,156,163,181,160,141,147,66,242,20,83,204,238,242,200,62,250,78,73,14,114,185,161,221,31,89,14,56,26,43,157,161,41,72,35,228,167,248,244,226,128,206,147,182,192,148,90,37,218,98,177,148,167,158,138,222,76,245,199,168,96,4,184,39,60,185,162,42,103,101,180,182,119,218,15,72,172,83,88,173,80,91,45,76,13,13,186,107,165,118,23,177,172,205,143,188,171,32,232,38,208,225,83,125,199,60,50,98,67,82,93,229,113,207,235,125,216,191,226,14,216,73,252,255,243,222,76,145,97,103,29,197,255,39,82,253,117,250,158,140,31,127,213,65,114,228,117,179,24,207,93,69,34,153,187,72,116,169,140,151,109,22,214,43,165,169,105,182,137,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6c3d2ee1-fb37-4416-8019-d5f16be32ce0"));
		}

		#endregion

	}

	#endregion

}

