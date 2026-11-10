namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IEsnCenterFactorySchema

	/// <exclude/>
	public class IEsnCenterFactorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IEsnCenterFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IEsnCenterFactorySchema(IEsnCenterFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5db535e2-9bbb-4b57-8890-3bdffc4020de");
			Name = "IEsnCenterFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b66b5ae8-46e0-4931-ad78-c2c1ba5fd6ea");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,146,207,106,132,48,16,135,207,10,190,195,96,47,237,197,220,91,215,139,108,193,75,41,253,243,0,169,59,218,192,38,145,73,82,88,74,223,189,19,117,171,178,189,180,39,153,113,248,126,95,134,49,82,163,27,100,139,240,130,68,210,217,206,23,181,53,157,234,3,73,175,172,41,246,207,15,89,250,153,165,73,112,202,244,80,91,194,187,44,229,250,138,176,231,1,128,198,120,164,142,25,183,208,236,157,169,49,214,247,178,245,150,78,227,164,16,2,74,23,180,150,116,170,230,250,145,236,135,58,160,3,141,254,221,30,28,116,150,160,37,228,80,78,81,198,121,105,216,202,118,160,244,112,68,205,80,102,32,198,153,110,151,47,65,57,136,170,56,135,136,85,202,16,222,142,170,101,212,108,247,155,92,18,31,118,225,55,54,234,232,130,255,49,185,84,153,58,131,36,169,193,240,198,119,121,112,72,188,103,131,109,92,114,94,53,171,152,21,252,117,59,22,3,74,49,114,22,44,161,15,100,92,245,52,126,255,44,92,138,51,32,18,151,159,243,2,126,234,235,173,11,108,95,112,195,55,145,124,77,119,129,230,48,157,70,150,114,231,27,138,134,112,100,98,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5db535e2-9bbb-4b57-8890-3bdffc4020de"));
		}

		#endregion

	}

	#endregion

}

