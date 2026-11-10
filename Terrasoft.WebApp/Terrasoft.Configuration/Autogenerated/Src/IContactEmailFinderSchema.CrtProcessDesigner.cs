namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IContactEmailFinderSchema

	/// <exclude/>
	public class IContactEmailFinderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IContactEmailFinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IContactEmailFinderSchema(IContactEmailFinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("852212d0-47e7-4f6a-a531-c7d9190493f5");
			Name = "IContactEmailFinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("832b05cc-1d40-42ab-9415-c96f927e05e6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,85,142,189,14,194,48,12,132,231,70,202,59,100,4,9,245,5,24,203,143,216,24,128,221,77,157,202,168,117,42,59,153,80,223,157,68,44,116,243,157,125,223,153,97,70,93,192,163,123,160,8,104,12,169,237,34,7,26,179,64,162,200,109,39,233,46,209,163,234,9,149,70,70,177,230,99,77,147,149,120,220,164,4,143,214,148,205,146,251,137,188,35,78,40,161,162,111,133,152,192,167,243,12,52,93,136,7,20,87,17,141,38,169,144,106,253,159,188,96,202,184,123,42,74,113,25,125,253,195,229,141,60,184,216,191,203,232,252,47,119,205,52,236,75,125,179,90,179,126,1,39,72,85,32,213,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("852212d0-47e7-4f6a-a531-c7d9190493f5"));
		}

		#endregion

	}

	#endregion

}

