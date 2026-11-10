namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ImapExceptionSchema

	/// <exclude/>
	public class ImapExceptionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ImapExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ImapExceptionSchema(ImapExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("136f52d1-b451-48cb-a9cb-2a36268a593c");
			Name = "ImapException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("80eb4b00-d20b-4335-a2cc-1f02c0e63f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,143,65,10,194,48,16,69,215,41,244,14,3,221,84,40,30,160,46,197,133,11,65,208,11,164,113,44,129,54,9,153,20,148,210,187,155,164,106,141,184,112,57,127,30,111,254,40,222,35,25,46,16,206,104,45,39,125,117,235,3,151,93,158,141,121,198,6,146,170,133,211,157,28,246,155,60,243,73,97,177,149,90,193,182,227,68,53,236,123,110,118,55,129,198,249,48,2,102,104,58,41,64,132,125,186,134,26,62,80,54,70,124,17,106,69,206,14,194,105,235,189,199,104,153,137,167,49,113,149,158,13,213,124,121,226,45,174,2,199,106,104,56,97,249,202,32,124,192,166,191,37,213,82,15,164,82,104,223,227,47,125,245,205,36,231,10,84,151,249,177,56,207,105,26,78,15,178,173,235,221,123,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("136f52d1-b451-48cb-a9cb-2a36268a593c"));
		}

		#endregion

	}

	#endregion

}

