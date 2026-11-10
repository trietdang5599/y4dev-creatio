namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IWorkplaceNavigationPanelProviderSchema

	/// <exclude/>
	public class IWorkplaceNavigationPanelProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IWorkplaceNavigationPanelProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IWorkplaceNavigationPanelProviderSchema(IWorkplaceNavigationPanelProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8254b1c8-62eb-4388-85ee-c89cb0aa6a53");
			Name = "IWorkplaceNavigationPanelProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0b5fa047-b3f1-455e-b921-26461fc6607e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,144,65,107,195,48,12,133,207,13,228,63,24,118,217,46,241,189,13,185,140,81,10,107,9,108,208,179,107,43,169,153,35,27,217,238,40,99,255,125,177,211,165,44,176,155,159,245,244,233,73,209,107,236,217,219,213,7,24,170,103,107,12,200,160,45,250,106,11,8,164,229,166,44,98,182,188,3,145,240,182,11,163,11,59,221,71,18,201,88,29,196,69,247,249,185,7,140,163,189,44,56,231,172,246,113,24,4,93,155,73,30,45,125,56,35,36,48,37,130,96,142,236,69,43,32,214,89,98,56,19,152,19,8,166,186,17,248,29,225,226,201,104,201,52,6,160,46,81,118,51,240,62,191,77,205,237,141,92,22,95,41,202,234,129,160,79,228,61,132,179,85,126,205,218,140,202,181,69,206,172,95,173,80,158,125,142,116,239,210,160,158,108,116,254,191,156,171,101,208,233,131,32,68,66,223,28,151,24,57,31,184,230,191,166,177,105,247,130,113,0,18,39,3,245,223,123,110,83,95,147,83,61,62,109,166,141,0,213,180,84,146,223,63,194,253,169,252,193,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8254b1c8-62eb-4388-85ee-c89cb0aa6a53"));
		}

		#endregion

	}

	#endregion

}

