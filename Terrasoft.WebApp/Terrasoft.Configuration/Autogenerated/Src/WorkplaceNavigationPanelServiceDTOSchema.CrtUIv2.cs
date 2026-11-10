namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: WorkplaceNavigationPanelServiceDTOSchema

	/// <exclude/>
	public class WorkplaceNavigationPanelServiceDTOSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WorkplaceNavigationPanelServiceDTOSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WorkplaceNavigationPanelServiceDTOSchema(WorkplaceNavigationPanelServiceDTOSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7e6ee3c5-590e-48d3-b5b9-30fd1fb88a29");
			Name = "WorkplaceNavigationPanelServiceDTO";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0b5fa047-b3f1-455e-b921-26461fc6607e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,213,84,203,110,194,48,16,60,131,196,63,88,112,105,47,249,0,104,57,144,86,8,9,56,16,170,30,170,30,140,179,164,22,142,29,249,65,69,81,255,189,235,4,90,72,221,54,28,123,201,195,59,59,51,30,111,34,105,14,166,160,12,200,18,180,166,70,173,109,20,43,185,230,153,211,212,114,37,163,57,221,242,172,124,156,129,116,157,246,190,211,110,57,195,101,70,146,157,177,144,35,92,8,96,30,96,162,49,72,208,156,13,234,152,133,147,150,231,16,37,88,165,130,191,149,124,136,66,92,79,67,134,47,36,22,212,152,62,25,131,61,87,28,107,229,10,179,64,151,40,0,101,203,211,29,181,20,93,90,77,153,125,198,133,194,173,4,103,132,121,138,191,24,72,159,196,74,151,86,182,156,193,76,165,32,142,92,209,136,26,248,146,106,249,189,86,106,51,200,87,160,175,230,24,23,185,37,221,87,165,55,133,192,216,76,247,218,27,56,58,152,220,75,151,131,166,43,1,55,1,19,67,242,248,217,72,246,36,3,59,32,198,95,222,203,125,5,165,132,162,41,38,137,174,156,176,231,106,198,106,159,241,244,20,81,167,109,85,212,61,144,105,21,116,40,244,128,213,6,65,7,187,126,206,140,167,65,247,147,180,105,18,140,22,94,44,200,18,87,181,166,84,230,48,176,181,211,155,114,99,107,231,54,193,241,29,146,228,128,15,240,95,158,175,167,188,56,222,170,233,127,164,203,153,146,35,202,54,25,142,132,76,241,255,160,116,216,220,119,220,37,18,15,90,252,72,139,181,166,84,18,239,65,158,18,208,144,196,238,138,48,201,18,11,205,167,146,106,246,18,255,114,16,201,41,162,193,167,142,43,31,110,172,42,200,226,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7e6ee3c5-590e-48d3-b5b9-30fd1fb88a29"));
		}

		#endregion

	}

	#endregion

}

