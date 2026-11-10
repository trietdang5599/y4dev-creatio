namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EmailTemplateUserTaskContactLanguageRuleSchema

	/// <exclude/>
	public class EmailTemplateUserTaskContactLanguageRuleSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailTemplateUserTaskContactLanguageRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailTemplateUserTaskContactLanguageRuleSchema(EmailTemplateUserTaskContactLanguageRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("93d56a0b-3d90-4502-a157-7f5bc05c865d");
			Name = "EmailTemplateUserTaskContactLanguageRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6b752d82-945c-4729-b067-d3f384b1bc2d");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,84,75,107,219,64,16,62,43,144,255,48,85,47,54,24,233,238,23,20,97,130,161,105,211,196,237,125,35,141,228,165,210,174,58,187,155,34,130,255,123,103,245,112,45,181,13,238,197,48,163,111,230,123,104,100,37,42,52,181,72,17,14,72,36,140,206,109,148,104,149,203,194,145,176,82,171,219,155,215,219,155,192,25,169,10,120,106,140,197,106,117,174,19,77,56,174,162,157,178,210,74,52,220,230,7,239,9,11,222,1,73,41,140,89,50,66,89,145,218,143,66,21,78,20,248,232,74,108,97,113,28,195,218,184,170,18,212,108,251,186,29,89,128,61,10,11,53,233,23,153,161,129,178,159,132,156,116,5,105,183,174,7,25,180,32,21,96,37,100,9,44,179,46,133,69,112,6,9,172,48,223,1,189,178,38,26,232,226,11,190,218,61,151,50,133,212,83,194,206,47,56,244,243,95,121,252,192,211,127,81,14,75,216,143,157,4,175,173,155,179,235,7,210,53,146,79,99,9,15,45,69,247,124,106,183,109,120,38,239,72,97,234,99,143,206,192,75,161,131,82,15,78,206,216,105,233,95,88,16,20,104,87,62,20,255,130,130,83,175,12,85,214,137,27,43,229,97,99,201,165,86,211,53,90,19,66,206,198,112,220,198,10,197,183,163,115,6,33,66,74,152,111,194,107,19,12,227,237,63,108,182,157,90,144,168,64,241,129,110,66,55,114,24,110,167,105,173,227,22,125,153,209,181,42,102,147,244,198,84,243,62,205,9,104,51,129,93,19,242,61,218,163,206,174,201,247,243,179,21,156,237,239,115,231,227,231,235,205,37,155,254,255,203,127,43,99,169,142,72,210,102,58,133,248,50,188,59,39,51,184,195,115,80,251,108,214,182,186,143,232,17,83,77,217,62,27,194,121,17,4,104,126,112,42,10,127,66,251,23,208,60,165,71,22,244,197,33,53,147,132,163,75,192,189,80,188,158,22,16,246,175,38,156,175,206,59,7,255,137,46,93,165,62,241,37,48,5,19,69,31,178,172,235,205,194,65,97,180,207,194,121,228,49,221,124,71,50,36,213,87,221,52,251,234,234,137,176,197,212,94,183,73,230,48,27,175,121,199,70,93,89,14,246,3,66,235,72,141,185,60,203,161,169,177,23,250,77,148,14,215,62,195,237,236,79,91,61,211,169,253,237,183,121,108,180,171,106,219,188,113,92,93,119,220,60,253,2,140,57,173,110,212,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("93d56a0b-3d90-4502-a157-7f5bc05c865d"));
		}

		#endregion

	}

	#endregion

}

