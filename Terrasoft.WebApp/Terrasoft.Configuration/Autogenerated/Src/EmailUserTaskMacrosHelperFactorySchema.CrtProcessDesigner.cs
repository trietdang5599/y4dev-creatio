namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EmailUserTaskMacrosHelperFactorySchema

	/// <exclude/>
	public class EmailUserTaskMacrosHelperFactorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailUserTaskMacrosHelperFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailUserTaskMacrosHelperFactorySchema(EmailUserTaskMacrosHelperFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d18446c3-8f82-456b-8ac3-209c16faa243");
			Name = "EmailUserTaskMacrosHelperFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a1a6f4c5-4ce0-49cf-afb2-f720b4b96f90");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,189,82,203,110,194,48,16,60,7,137,127,216,170,151,32,161,124,0,136,3,165,180,229,64,133,10,253,0,227,44,137,213,196,142,236,77,41,66,252,123,29,231,209,4,40,234,169,23,203,251,152,153,221,209,74,150,162,201,24,71,216,160,214,204,168,29,5,51,165,49,88,105,197,209,24,27,200,157,136,114,205,72,40,217,239,29,251,61,47,55,66,70,176,62,24,194,116,220,196,109,124,11,82,19,61,162,17,145,68,109,1,22,114,175,49,178,69,152,37,204,152,17,204,83,38,146,119,131,122,195,204,199,146,113,173,204,11,38,25,234,39,198,73,233,131,195,100,249,54,17,28,12,89,94,14,188,64,254,1,232,29,29,184,81,92,34,197,42,180,154,43,71,87,22,187,212,139,43,172,118,139,79,17,162,134,103,164,182,142,95,192,61,207,33,54,152,102,9,35,172,145,144,87,159,33,20,41,107,139,68,94,120,226,10,63,225,0,142,142,101,171,84,82,148,166,97,42,228,155,136,98,50,48,105,72,130,53,202,176,212,57,100,8,119,19,240,133,164,65,39,27,76,115,82,99,71,102,246,130,120,12,190,255,160,194,67,61,89,209,51,104,8,47,42,213,28,30,103,6,225,188,26,116,118,28,149,157,158,70,202,181,4,137,123,184,234,65,199,171,90,185,17,242,188,51,99,38,103,214,12,91,125,23,182,180,18,85,219,105,124,107,129,234,18,111,172,80,117,252,122,85,255,183,65,136,59,150,39,84,207,72,177,86,123,55,226,171,162,133,157,31,83,148,132,225,252,139,99,86,200,248,131,18,120,42,222,83,117,242,246,52,202,171,119,113,153,237,38,79,223,49,122,11,178,0,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d18446c3-8f82-456b-8ac3-209c16faa243"));
		}

		#endregion

	}

	#endregion

}

