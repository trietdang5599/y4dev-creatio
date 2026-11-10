namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: LanguageInContactLanguageRuleSchema

	/// <exclude/>
	public class LanguageInContactLanguageRuleSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LanguageInContactLanguageRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LanguageInContactLanguageRuleSchema(LanguageInContactLanguageRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e2c80707-56d1-485c-9153-61f3c4d5fd6c");
			Name = "LanguageInContactLanguageRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d5fe5418-b108-401a-ba83-ff1213a966db");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,83,203,110,219,48,16,60,59,64,254,97,161,94,36,192,144,238,142,173,67,92,55,16,208,2,70,220,52,103,134,92,57,4,36,210,229,195,173,97,228,223,187,34,101,71,22,220,32,55,237,236,206,112,56,75,41,214,162,221,49,142,240,19,141,97,86,215,46,95,106,85,203,173,55,204,73,173,110,111,142,183,55,19,111,165,218,194,230,96,29,182,119,231,122,72,105,91,173,174,119,12,254,15,207,191,222,83,139,154,69,81,192,220,250,182,101,230,80,246,245,178,97,214,78,97,103,244,94,10,180,208,48,181,245,108,139,83,168,141,110,129,107,229,24,119,249,137,93,12,232,59,255,210,72,14,188,83,128,239,61,175,82,203,72,57,1,143,190,65,152,193,61,179,56,132,136,127,12,166,38,95,12,110,41,1,32,158,117,198,115,167,141,157,193,58,136,199,137,177,239,104,220,32,115,100,88,18,139,41,74,86,215,52,132,8,220,96,189,72,62,244,147,20,101,126,22,46,198,202,243,29,51,172,5,69,59,91,36,222,162,33,5,133,188,91,83,82,62,81,221,165,210,3,249,188,8,211,129,220,7,242,225,209,233,211,133,32,92,234,103,157,204,100,6,47,148,86,58,106,193,17,222,250,196,80,137,24,218,101,130,63,208,189,106,241,153,240,214,227,117,3,85,202,201,90,210,237,198,139,255,76,76,156,12,175,72,192,29,30,145,107,35,42,145,148,253,237,1,3,62,56,225,34,180,32,37,213,43,26,233,132,230,80,12,163,212,123,122,201,68,132,7,47,5,60,224,57,202,74,164,1,234,109,86,130,226,9,217,237,153,57,129,167,217,13,54,20,33,44,64,225,31,136,197,104,11,25,253,39,141,111,85,154,240,100,10,239,111,71,36,89,254,141,210,72,147,254,46,93,151,39,113,75,147,252,153,76,99,207,9,179,149,93,253,246,172,73,163,90,190,238,46,137,14,77,250,110,51,3,102,123,19,119,65,230,170,217,124,245,23,185,119,184,161,191,185,193,24,105,74,15,94,208,122,22,37,196,175,156,242,136,39,253,98,141,199,121,23,72,153,94,184,159,130,246,46,134,215,156,225,44,30,108,208,121,163,6,120,128,175,63,49,66,223,254,1,49,96,84,172,196,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e2c80707-56d1-485c-9153-61f3c4d5fd6c"));
		}

		#endregion

	}

	#endregion

}

