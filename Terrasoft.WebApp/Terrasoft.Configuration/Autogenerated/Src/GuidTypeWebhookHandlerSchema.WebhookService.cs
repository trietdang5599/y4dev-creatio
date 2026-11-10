namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: GuidTypeWebhookHandlerSchema

	/// <exclude/>
	public class GuidTypeWebhookHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GuidTypeWebhookHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GuidTypeWebhookHandlerSchema(GuidTypeWebhookHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("78e0af57-7792-438f-8a76-624a4fc1bae5");
			Name = "GuidTypeWebhookHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c57d96f3-f6a9-41c3-a651-44ed58ea0c9a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,147,77,107,227,48,16,134,207,41,244,63,12,238,37,134,98,223,243,5,187,89,246,227,208,18,104,160,135,210,131,98,143,83,237,218,146,25,73,45,166,244,191,119,36,203,217,52,27,151,189,8,123,52,243,190,51,143,36,37,26,52,173,40,16,182,72,36,140,174,108,182,214,170,146,123,71,194,74,173,46,47,94,47,47,38,206,72,181,135,187,206,88,108,230,135,255,227,18,194,236,187,40,172,38,137,134,51,56,231,138,112,207,2,176,174,133,49,51,248,225,100,185,237,90,188,199,221,147,214,127,126,10,85,214,72,33,51,207,115,88,24,215,52,130,186,85,252,143,105,16,243,160,210,4,123,150,0,203,26,67,77,126,82,180,48,136,162,54,26,10,194,106,153,140,140,148,253,90,59,99,117,243,111,55,9,228,94,234,225,27,86,194,213,246,171,84,37,207,57,245,150,186,154,142,150,165,215,112,203,28,97,9,201,249,41,147,244,145,101,91,183,171,101,1,133,231,49,130,3,102,48,234,194,10,175,1,215,129,236,134,116,139,100,153,248,12,54,65,188,223,63,229,25,2,156,252,44,75,182,80,220,106,118,72,59,70,56,116,104,44,249,227,29,42,250,217,86,195,145,220,105,71,5,50,81,99,133,178,38,251,162,186,249,39,190,161,123,47,231,41,126,238,235,103,238,23,118,139,208,61,167,52,234,95,161,42,251,209,63,114,184,65,251,164,203,255,129,112,104,230,37,94,175,86,16,79,103,25,203,179,168,221,88,127,33,18,82,3,189,101,34,85,235,108,178,138,160,66,41,232,234,140,170,191,182,131,105,182,200,195,198,95,73,66,235,72,153,213,34,31,190,142,104,232,221,111,44,108,124,0,211,104,21,140,83,240,111,114,50,145,21,4,62,217,150,186,141,32,131,211,176,125,13,218,217,112,193,128,208,240,61,78,135,130,73,111,19,195,243,16,123,11,107,220,80,174,174,67,248,237,44,241,62,250,49,200,177,119,195,116,114,226,69,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("78e0af57-7792-438f-8a76-624a4fc1bae5"));
		}

		#endregion

	}

	#endregion

}

