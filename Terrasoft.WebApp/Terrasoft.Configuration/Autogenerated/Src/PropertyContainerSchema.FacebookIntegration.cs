namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: PropertyContainerSchema

	/// <exclude/>
	public class PropertyContainerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PropertyContainerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PropertyContainerSchema(PropertyContainerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("593ff365-923f-4ae6-ac7a-a20ebaa261c5");
			Name = "PropertyContainer";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("34c57733-6570-402b-8e25-5c50c5be2b38");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,143,77,10,131,48,16,133,215,10,222,33,224,222,3,212,165,32,116,81,144,218,11,140,113,148,208,152,132,73,92,136,120,247,154,248,3,133,210,118,55,51,239,123,143,55,10,6,180,6,56,178,7,18,129,213,157,203,10,173,58,209,143,4,78,104,149,213,154,11,144,73,60,39,113,52,90,161,122,86,79,214,225,144,221,177,147,200,61,147,39,241,42,166,132,253,186,176,66,130,181,23,86,145,54,72,110,90,211,28,8,133,20,32,51,54,82,112,198,61,243,9,137,230,128,157,97,59,34,208,39,6,239,166,239,57,214,145,111,84,174,15,52,90,63,75,129,178,101,190,105,20,245,232,242,48,216,125,88,190,57,43,32,84,238,63,235,81,251,170,58,125,6,220,192,24,108,15,233,71,80,138,170,221,30,12,251,118,125,63,46,47,19,105,152,235,154,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("593ff365-923f-4ae6-ac7a-a20ebaa261c5"));
		}

		#endregion

	}

	#endregion

}

