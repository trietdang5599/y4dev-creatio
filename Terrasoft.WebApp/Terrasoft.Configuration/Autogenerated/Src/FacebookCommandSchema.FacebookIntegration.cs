namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: FacebookCommandSchema

	/// <exclude/>
	public class FacebookCommandSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FacebookCommandSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FacebookCommandSchema(FacebookCommandSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("eaf15c5a-de82-46d3-9492-d1bed2d4d5e1");
			Name = "FacebookCommand";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a1c45040-f900-4d72-b99e-b97e9cbc42dd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,145,203,106,195,48,16,69,215,10,228,31,134,116,19,67,240,7,164,143,69,13,237,38,139,64,186,15,178,50,113,69,244,112,53,18,165,4,255,123,37,217,137,169,11,109,118,186,51,247,220,25,49,134,107,164,150,11,132,55,116,142,147,61,250,178,178,230,40,155,224,184,151,214,148,59,43,36,87,243,217,121,62,99,129,164,105,96,247,69,30,245,253,68,71,76,41,20,137,161,242,21,13,58,41,126,121,54,210,124,196,98,44,223,57,108,162,21,42,197,137,214,240,18,87,168,173,61,85,86,107,110,14,217,210,134,90,73,1,34,57,166,6,88,195,51,39,188,218,217,57,35,99,108,220,194,187,32,188,117,49,125,155,147,122,199,144,58,201,91,22,144,62,200,216,22,157,150,68,233,23,240,8,6,63,97,35,201,63,164,97,99,235,105,48,179,212,191,36,141,237,229,34,16,186,61,175,109,240,123,141,139,21,76,10,197,234,111,28,53,151,42,97,253,227,63,123,14,63,58,137,230,64,215,97,23,125,19,172,228,9,71,180,87,55,129,237,187,245,118,36,7,89,100,178,75,231,103,221,112,152,184,76,127,155,172,251,234,207,98,247,13,23,172,63,91,141,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eaf15c5a-de82-46d3-9492-d1bed2d4d5e1"));
		}

		#endregion

	}

	#endregion

}

