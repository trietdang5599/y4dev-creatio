namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IRepositorySchema

	/// <exclude/>
	public class IRepositorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IRepositorySchema(IRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fb47eba1-93f4-4a26-a75c-b68259fb6949");
			Name = "IRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,84,77,75,195,64,16,61,183,224,127,24,226,165,130,36,119,141,1,45,90,122,147,54,224,121,147,76,235,194,126,132,253,80,130,248,223,157,205,54,177,86,173,10,30,119,242,230,205,123,111,103,163,152,68,219,178,26,161,68,99,152,213,27,151,206,181,218,240,173,55,204,113,173,78,166,47,39,211,137,183,92,109,97,221,89,135,242,242,224,76,120,33,176,14,96,155,46,80,161,225,53,97,8,117,106,112,75,85,88,42,135,102,67,67,46,96,185,194,86,91,238,180,233,122,72,150,101,144,91,47,37,51,93,177,59,151,40,91,193,28,54,96,70,48,56,13,172,178,206,176,218,129,165,10,219,98,58,244,103,7,4,185,235,90,108,153,97,18,20,249,187,74,202,164,88,83,15,49,162,114,220,17,27,1,210,60,27,113,161,179,245,149,224,53,240,65,236,190,214,188,44,224,249,17,13,197,4,23,112,195,44,6,62,86,9,188,237,9,169,61,196,244,201,78,95,88,161,243,70,217,97,118,213,1,111,210,17,157,29,194,243,125,229,188,73,138,56,34,52,229,217,168,54,66,77,164,222,65,232,251,80,8,136,18,238,184,106,102,11,207,27,106,62,139,119,242,181,196,185,65,10,124,148,200,213,144,49,48,21,174,33,26,224,206,254,65,122,228,74,138,158,59,172,11,14,34,143,154,136,62,247,125,244,6,162,194,89,185,99,57,234,102,133,82,63,225,127,7,254,164,73,70,164,254,77,166,147,53,50,83,63,98,136,13,165,13,42,90,218,64,94,147,141,20,126,169,102,232,232,187,146,226,126,36,248,54,196,56,149,174,204,122,225,14,130,92,222,42,47,177,95,219,176,208,15,97,161,103,119,94,213,121,121,14,149,214,162,128,15,3,127,8,249,125,171,233,93,236,189,201,239,140,141,18,119,171,213,231,114,92,226,2,221,181,16,179,32,100,242,26,255,41,168,154,248,91,9,199,215,55,183,89,138,218,192,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fb47eba1-93f4-4a26-a75c-b68259fb6949"));
		}

		#endregion

	}

	#endregion

}

