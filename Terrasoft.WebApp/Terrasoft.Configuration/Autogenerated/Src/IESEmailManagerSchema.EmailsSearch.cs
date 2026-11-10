namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IESEmailManagerSchema

	/// <exclude/>
	public class IESEmailManagerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IESEmailManagerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IESEmailManagerSchema(IESEmailManagerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0f0a3bfc-dd1a-49ca-91a0-daff393823fe");
			Name = "IESEmailManager";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("92df5372-6a61-42f2-95f4-67c9e246a93f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,82,205,78,2,49,16,62,67,194,59,76,240,162,9,217,245,12,203,94,144,24,18,137,68,124,129,178,204,46,77,182,45,118,90,12,33,188,187,253,91,84,212,120,106,58,253,126,230,155,169,100,2,105,207,42,132,87,212,154,145,170,77,54,83,178,230,141,213,204,112,37,179,185,96,188,165,53,50,93,237,6,253,211,160,223,179,196,101,3,235,35,25,20,14,220,182,88,121,36,101,143,40,81,243,106,50,232,59,212,141,198,198,85,97,33,13,234,218,57,140,97,49,95,7,181,37,147,172,65,29,96,121,158,67,65,86,8,166,143,101,186,175,180,58,240,45,18,8,52,59,181,37,168,149,6,244,76,160,208,135,243,207,58,110,254,133,188,183,155,150,87,192,59,203,159,142,189,83,112,189,116,183,140,14,99,88,5,106,124,188,238,41,20,226,4,98,27,148,93,96,249,53,174,216,51,205,4,72,55,216,233,80,227,155,69,50,195,242,137,147,1,85,167,254,129,140,118,25,40,43,242,128,254,131,172,222,103,202,74,199,14,135,167,187,18,185,120,160,209,88,45,225,192,90,139,255,138,208,115,93,19,58,153,23,207,86,225,226,69,26,191,46,214,58,49,218,187,245,253,34,20,109,168,124,224,97,195,46,166,111,34,141,160,200,187,103,143,95,204,165,21,78,110,211,98,241,9,47,98,208,81,10,92,150,105,140,241,83,221,250,169,36,72,9,105,86,35,191,62,232,178,195,20,238,47,149,20,196,215,238,38,105,143,40,183,113,149,225,126,142,95,239,91,241,252,1,122,39,166,70,228,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0f0a3bfc-dd1a-49ca-91a0-daff393823fe"));
		}

		#endregion

	}

	#endregion

}

