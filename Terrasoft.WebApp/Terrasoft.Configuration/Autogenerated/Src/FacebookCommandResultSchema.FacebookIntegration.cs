namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: FacebookCommandResultSchema

	/// <exclude/>
	public class FacebookCommandResultSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FacebookCommandResultSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FacebookCommandResultSchema(FacebookCommandResultSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fbe4dcf3-dfa9-4277-a9bc-ff9fbac967cf");
			Name = "FacebookCommandResult";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a1c45040-f900-4d72-b99e-b97e9cbc42dd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,141,65,10,131,48,16,69,215,10,222,33,208,189,7,176,187,6,186,234,170,246,2,99,28,37,52,153,177,153,100,33,226,221,27,21,92,148,46,255,227,61,62,129,71,153,192,160,122,97,8,32,60,196,90,51,13,118,76,1,162,101,170,91,54,22,92,85,46,85,89,36,177,52,170,123,214,59,230,247,245,36,237,44,17,125,253,176,244,201,48,227,75,192,49,199,74,59,16,105,206,66,179,247,64,253,19,37,185,184,139,83,234,156,53,202,108,222,127,77,53,234,6,130,63,105,177,236,249,122,188,33,245,199,225,54,215,47,21,245,248,172,212,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fbe4dcf3-dfa9-4277-a9bc-ff9fbac967cf"));
		}

		#endregion

	}

	#endregion

}

