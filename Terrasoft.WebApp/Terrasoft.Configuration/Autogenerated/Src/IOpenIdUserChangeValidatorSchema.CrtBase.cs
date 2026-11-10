namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IOpenIdUserChangeValidatorSchema

	/// <exclude/>
	public class IOpenIdUserChangeValidatorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IOpenIdUserChangeValidatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IOpenIdUserChangeValidatorSchema(IOpenIdUserChangeValidatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cb3ab0c1-6714-4491-9345-efbe56bcf524");
			Name = "IOpenIdUserChangeValidator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,82,77,75,195,64,16,61,183,224,127,24,234,69,161,52,119,173,129,18,122,232,65,4,177,222,39,217,217,100,48,153,13,251,161,22,233,127,119,183,49,106,181,122,88,118,118,153,247,230,189,199,8,118,228,122,172,8,30,200,90,116,70,251,69,97,68,115,29,44,122,54,178,184,235,73,54,106,21,124,115,54,125,59,155,78,130,99,169,143,186,45,93,255,241,191,88,139,103,207,228,98,67,108,57,183,84,71,74,216,136,39,171,227,208,43,216,12,244,91,71,182,104,80,106,122,196,150,21,122,99,15,136,62,148,45,87,192,35,224,223,254,73,146,55,201,178,12,150,46,116,29,218,93,62,126,20,13,85,79,14,88,3,189,178,243,73,105,136,20,80,161,64,73,208,25,197,154,73,125,226,179,159,4,203,30,45,118,32,49,174,155,89,130,198,144,132,170,148,208,44,255,170,193,27,136,106,176,68,71,203,236,128,57,77,225,118,110,165,58,150,173,176,191,253,152,62,203,199,10,40,229,182,3,163,33,57,253,197,100,201,7,43,46,191,31,110,240,54,80,50,119,202,19,160,40,112,248,28,171,111,226,230,96,124,67,246,133,29,193,192,6,26,219,36,122,228,78,195,74,99,90,40,80,134,168,147,148,139,237,145,119,56,142,98,14,235,65,248,41,123,151,105,75,246,241,164,77,32,81,195,50,28,222,251,119,132,168,138,87,135,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cb3ab0c1-6714-4491-9345-efbe56bcf524"));
		}

		#endregion

	}

	#endregion

}

