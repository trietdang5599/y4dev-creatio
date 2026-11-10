namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IWorkplaceInfoNavigationPanelProviderSchema

	/// <exclude/>
	public class IWorkplaceInfoNavigationPanelProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IWorkplaceInfoNavigationPanelProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IWorkplaceInfoNavigationPanelProviderSchema(IWorkplaceInfoNavigationPanelProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("161e712a-6f4f-41c5-b81a-63cb2bfef4ba");
			Name = "IWorkplaceInfoNavigationPanelProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,145,81,75,195,48,16,199,159,87,216,119,56,216,139,190,180,239,110,12,196,135,49,176,82,80,216,115,214,94,107,48,77,194,93,50,25,226,119,55,73,215,14,11,130,232,219,93,242,207,47,191,92,60,75,221,193,243,153,29,246,249,131,81,10,107,39,141,230,124,135,26,73,214,235,101,230,83,228,5,137,4,155,214,133,148,110,101,231,73,196,96,254,36,78,178,75,101,137,218,79,241,131,161,55,171,68,141,247,86,134,197,101,86,20,5,108,216,247,189,160,243,118,104,167,12,72,221,26,104,132,19,96,201,156,100,131,4,173,33,208,19,27,172,208,168,242,11,166,184,114,172,63,42,89,7,128,67,106,35,106,63,81,247,1,122,181,171,34,160,186,208,151,217,71,116,90,172,8,187,72,47,209,189,154,134,239,160,74,184,180,55,19,78,253,163,17,13,195,123,184,129,109,184,129,7,241,31,84,23,115,215,97,129,208,121,210,188,61,140,20,232,200,120,203,80,79,211,223,20,99,40,28,250,62,224,93,202,198,167,37,153,88,220,220,174,255,32,220,155,163,84,8,194,218,127,169,206,88,191,55,47,211,153,233,179,120,124,197,10,117,51,252,74,108,63,191,0,42,109,27,94,160,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("161e712a-6f4f-41c5-b81a-63cb2bfef4ba"));
		}

		#endregion

	}

	#endregion

}

