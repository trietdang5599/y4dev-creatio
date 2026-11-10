namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: OmnichatEsqColumnsAppenderSchema

	/// <exclude/>
	public class OmnichatEsqColumnsAppenderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OmnichatEsqColumnsAppenderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OmnichatEsqColumnsAppenderSchema(OmnichatEsqColumnsAppenderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5322e155-583b-42c4-86ac-8bbc2f6dad98");
			Name = "OmnichatEsqColumnsAppender";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6f05d58c-8c35-4460-8cdc-92bf987e5f26");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,147,219,78,195,48,12,134,239,145,246,14,6,36,84,110,210,123,216,38,141,49,164,73,156,225,5,66,234,117,17,77,210,197,41,162,154,246,238,36,61,104,217,40,228,170,181,253,127,254,157,186,154,43,164,146,11,132,119,180,150,147,89,57,54,55,122,37,243,202,114,39,141,102,79,74,75,177,230,90,99,193,30,144,136,231,82,231,163,147,237,232,4,252,169,200,191,193,91,77,14,21,187,151,122,115,29,199,99,166,82,70,255,153,180,248,79,138,45,180,147,78,34,249,154,182,234,220,98,238,189,193,188,224,68,87,208,89,116,11,218,204,77,81,41,77,179,178,68,157,161,237,5,105,154,194,152,42,165,184,173,167,251,80,163,7,103,128,103,89,232,91,152,60,199,12,68,11,9,137,30,205,34,78,122,8,42,171,143,66,10,32,231,239,75,128,104,144,255,57,10,154,109,111,44,158,230,1,221,218,100,126,158,231,134,24,151,12,248,239,195,179,44,163,1,227,72,27,118,164,79,135,1,227,146,91,174,64,251,77,152,156,121,217,217,180,119,223,64,198,105,147,143,68,135,3,127,25,153,5,19,247,141,133,110,218,164,249,100,245,155,88,163,226,47,21,218,58,176,46,97,187,167,132,35,87,144,132,30,175,198,184,182,150,45,233,221,114,241,57,247,27,151,35,45,245,237,205,47,85,56,71,170,174,45,187,51,118,193,197,58,17,48,153,14,201,250,166,98,160,15,92,92,192,105,224,246,176,153,174,147,239,0,250,102,143,254,114,96,50,1,209,60,93,14,90,138,173,249,251,104,41,73,167,184,30,174,223,253,14,239,142,107,163,154,221,193,218,248,125,106,55,167,141,117,117,221,31,18,37,119,240,3,239,31,146,150,230,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5322e155-583b-42c4-86ac-8bbc2f6dad98"));
		}

		#endregion

	}

	#endregion

}

