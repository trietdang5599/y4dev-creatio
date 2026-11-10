namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ContactInOmniChatLanguageRuleSchema

	/// <exclude/>
	public class ContactInOmniChatLanguageRuleSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactInOmniChatLanguageRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactInOmniChatLanguageRuleSchema(ContactInOmniChatLanguageRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ba21deee-aa7e-5f17-8481-2cba8316ae86");
			Name = "ContactInOmniChatLanguageRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,147,75,111,155,64,16,128,207,142,148,255,48,162,23,44,161,229,238,216,150,82,43,138,44,197,109,218,36,189,111,96,192,43,193,46,217,135,43,100,229,191,119,96,129,2,121,40,55,239,120,230,155,217,111,22,201,75,52,21,79,16,30,81,107,110,84,102,217,78,201,76,228,78,115,43,148,188,188,56,95,94,44,156,17,50,135,135,218,88,44,175,134,243,7,37,236,103,41,69,114,228,82,98,193,14,104,12,207,41,251,253,50,141,31,197,217,141,180,194,10,52,148,64,41,113,28,195,218,184,178,228,186,222,118,231,93,193,141,137,160,210,234,36,82,52,80,112,153,59,158,99,4,153,86,37,52,99,236,142,220,130,199,211,140,150,39,150,245,176,120,68,171,220,115,33,18,72,26,96,159,184,151,61,224,174,227,254,118,5,194,10,190,115,131,227,16,213,159,219,25,23,223,52,230,36,160,33,24,171,93,98,149,54,43,184,111,225,62,99,126,13,127,15,141,220,210,252,130,170,184,164,93,168,140,146,16,33,209,152,109,130,79,231,9,226,45,27,192,241,156,188,174,184,230,37,72,218,242,38,112,6,53,177,36,38,205,150,130,237,19,157,33,25,2,108,29,183,217,109,113,39,228,211,214,225,211,4,8,83,254,178,193,44,86,240,76,182,194,217,95,112,134,215,206,24,202,212,75,155,26,60,160,61,170,244,43,242,238,231,219,159,46,63,122,187,253,175,184,82,93,249,62,13,182,195,59,194,230,69,214,64,221,232,71,38,80,79,148,181,12,33,143,168,133,77,85,2,241,88,164,58,209,227,166,66,184,117,34,133,91,28,68,238,211,176,13,253,111,72,118,90,117,39,174,1,205,11,108,64,226,95,104,191,134,250,33,57,98,201,127,57,212,245,204,62,27,39,28,184,36,180,142,32,232,103,15,150,87,3,180,23,181,83,133,43,229,15,186,47,245,160,78,236,58,77,125,44,236,223,28,235,199,100,36,98,201,154,92,207,233,62,113,123,99,94,124,137,185,174,42,218,37,57,33,202,157,202,115,236,88,38,36,116,215,221,207,56,220,181,59,250,230,228,196,159,103,23,139,198,106,60,166,21,86,12,2,9,48,37,54,172,199,186,234,39,248,195,11,135,235,166,104,27,190,189,123,199,212,104,157,150,35,106,27,126,255,149,182,209,215,127,248,219,148,196,59,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ba21deee-aa7e-5f17-8481-2cba8316ae86"));
		}

		#endregion

	}

	#endregion

}

