namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IFacebookServiceSchema

	/// <exclude/>
	public class IFacebookServiceSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFacebookServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFacebookServiceSchema(IFacebookServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("653008e5-9c4b-409b-9e2f-8dcc34086cdd");
			Name = "IFacebookService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("42c3ed99-d529-4b29-9a2a-6514376125eb");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,229,88,77,111,226,48,16,61,83,169,255,193,162,23,42,85,249,1,173,246,80,160,84,84,130,86,27,164,30,170,30,140,51,4,139,196,206,218,99,118,81,213,255,190,131,77,16,105,187,89,237,113,227,147,229,241,155,201,188,103,79,252,161,120,9,182,226,2,216,2,140,225,86,175,48,25,105,181,146,185,51,28,165,86,73,170,133,228,197,249,217,219,249,89,207,89,169,114,150,238,44,66,153,164,96,182,82,192,76,103,80,220,180,13,38,183,2,229,214,71,107,199,61,195,146,0,4,185,48,144,19,154,77,21,130,89,81,118,215,108,58,161,102,169,245,230,224,225,113,47,135,14,101,140,134,11,28,204,137,14,251,198,250,31,192,253,203,87,66,87,110,89,72,193,100,29,244,139,152,189,55,31,247,152,192,12,112,173,51,123,205,158,188,111,24,124,121,172,32,136,83,127,247,213,155,41,253,169,218,234,13,12,130,219,62,145,167,199,116,209,191,98,223,225,135,3,139,19,109,74,142,100,39,232,12,172,229,57,4,83,242,96,181,186,98,67,157,237,82,220,21,208,128,28,173,201,179,225,85,5,217,62,158,173,180,178,208,30,208,179,238,53,166,243,192,180,246,103,41,224,173,16,228,185,160,188,213,32,76,246,28,240,167,54,155,35,214,231,206,76,104,47,111,254,75,21,78,88,30,201,223,199,76,126,34,85,22,7,251,214,2,24,25,224,8,129,60,201,161,157,194,14,75,209,224,57,85,43,125,90,11,159,6,163,20,98,95,23,49,41,209,90,29,99,40,32,158,234,104,255,81,172,65,108,98,81,98,200,45,29,170,202,146,171,140,220,92,129,228,189,207,114,228,140,1,21,201,174,249,89,132,187,95,32,28,214,198,14,83,79,129,27,177,110,178,14,182,14,147,174,111,3,119,10,37,74,176,167,123,227,156,46,40,118,204,145,119,152,255,31,215,251,144,163,88,119,127,209,143,97,233,242,175,142,202,126,32,170,95,95,187,20,113,104,240,247,211,192,136,171,64,9,186,45,131,117,37,152,143,183,133,83,251,191,208,191,0,149,133,215,21,223,127,15,15,62,13,227,251,111,238,140,124,224,150,18,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("653008e5-9c4b-409b-9e2f-8dcc34086cdd"));
		}

		#endregion

	}

	#endregion

}

