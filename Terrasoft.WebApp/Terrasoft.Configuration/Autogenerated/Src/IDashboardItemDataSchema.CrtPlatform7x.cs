namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IDashboardItemDataSchema

	/// <exclude/>
	public class IDashboardItemDataSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDashboardItemDataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDashboardItemDataSchema(IDashboardItemDataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6b9c62e2-4fb8-44c6-bf30-c17c6dcdc426");
			Name = "IDashboardItemData";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,82,193,78,195,48,12,61,111,210,254,193,71,184,180,31,48,196,165,149,80,39,196,56,20,33,113,75,91,103,4,168,93,146,84,104,84,251,119,220,116,171,70,41,210,142,246,123,47,207,126,49,169,26,93,163,74,132,28,173,85,142,181,143,18,38,109,118,173,85,222,48,173,150,221,106,185,104,157,161,29,36,108,113,61,86,15,248,229,153,130,98,227,152,162,123,67,159,130,10,30,199,49,220,184,182,174,149,221,223,30,235,140,60,90,221,27,105,182,80,41,247,90,176,178,21,24,143,181,148,94,69,39,97,124,166,108,218,226,195,148,96,70,113,150,158,148,153,8,83,209,9,171,11,174,127,108,67,227,201,161,133,146,137,176,236,215,137,96,100,158,251,44,122,90,50,178,96,82,118,176,67,191,134,195,224,179,217,22,111,2,192,144,19,76,209,156,223,145,224,81,89,137,86,198,118,83,130,243,54,196,39,240,60,242,108,42,233,230,251,102,138,207,46,152,254,142,178,84,77,216,115,126,205,163,67,50,144,46,121,62,55,50,230,55,19,2,107,237,208,255,243,176,252,80,160,190,8,115,27,136,243,153,221,161,239,143,229,234,122,184,148,128,30,126,0,227,191,149,169,133,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6b9c62e2-4fb8-44c6-bf30-c17c6dcdc426"));
		}

		#endregion

	}

	#endregion

}

