namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: PrimeContactInAccountLanguageRuleSchema

	/// <exclude/>
	public class PrimeContactInAccountLanguageRuleSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PrimeContactInAccountLanguageRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PrimeContactInAccountLanguageRuleSchema(PrimeContactInAccountLanguageRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("41844107-7e4d-4d9f-9450-654c0ae6bb86");
			Name = "PrimeContactInAccountLanguageRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d5fe5418-b108-401a-ba83-ff1213a966db");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,77,111,219,48,12,134,207,41,208,255,64,120,151,4,8,236,123,154,24,232,130,161,8,176,14,217,250,113,87,101,58,17,96,75,25,37,101,48,130,254,247,209,178,98,216,222,134,245,72,138,124,248,242,165,180,168,209,158,132,68,120,70,34,97,77,233,210,173,209,165,58,120,18,78,25,125,123,115,185,189,153,121,171,244,1,158,26,235,176,190,235,227,97,11,225,191,242,233,23,237,148,83,104,185,128,75,178,44,131,181,245,117,45,168,201,99,188,173,132,181,75,56,145,57,171,2,45,84,66,31,188,56,224,18,74,50,53,8,41,141,215,46,189,118,103,131,246,147,127,171,148,4,217,18,96,79,170,70,150,239,132,116,59,125,223,181,125,141,176,31,190,66,88,193,103,97,113,152,98,198,37,8,155,125,34,60,240,198,192,0,235,200,75,103,200,174,96,31,6,116,21,83,237,157,120,66,225,88,180,226,46,161,217,73,83,114,17,34,72,194,114,147,92,103,237,116,20,54,28,158,100,121,218,131,179,41,121,125,18,36,106,208,124,163,77,226,45,18,19,52,202,246,44,73,254,194,49,200,62,145,174,179,80,29,154,163,41,255,181,99,254,50,130,194,120,198,162,69,205,86,240,198,142,205,39,79,112,129,247,232,26,234,162,51,110,236,226,35,186,163,41,62,98,224,126,122,118,224,136,255,76,169,120,195,233,7,248,136,85,177,124,87,36,121,92,26,90,158,107,6,224,145,95,129,160,244,17,73,185,194,72,200,134,46,154,51,127,103,110,132,7,175,10,120,192,222,193,93,49,15,169,126,28,187,18,44,59,11,2,180,63,97,3,26,127,65,248,254,205,147,60,98,45,190,123,164,102,226,122,58,44,120,20,154,201,180,132,36,42,79,22,119,61,243,234,207,214,84,190,214,223,120,87,30,193,131,210,251,162,232,114,243,164,189,57,27,19,175,158,94,181,166,108,198,34,109,91,58,92,55,243,42,221,197,176,163,241,138,93,60,17,186,28,108,218,81,194,250,85,111,7,247,143,129,45,234,185,57,97,84,247,42,42,143,235,182,41,159,255,185,75,100,18,58,79,122,64,13,233,191,127,54,206,190,255,6,14,60,58,101,194,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("41844107-7e4d-4d9f-9450-654c0ae6bb86"));
		}

		#endregion

	}

	#endregion

}

