namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ImapErrorMessagesSchema

	/// <exclude/>
	public class ImapErrorMessagesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ImapErrorMessagesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ImapErrorMessagesSchema(ImapErrorMessagesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a97a27d8-986d-4adc-b58a-66f3167f55a1");
			Name = "ImapErrorMessages";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,144,193,10,194,48,12,134,207,27,236,29,10,222,125,128,237,56,20,132,77,7,21,60,215,46,150,194,150,148,180,83,68,246,238,142,110,40,194,60,38,249,254,63,127,130,170,7,239,148,6,113,6,102,229,233,22,182,181,178,93,150,190,178,52,75,147,13,131,177,132,66,6,30,116,200,197,161,87,110,199,76,92,131,247,202,128,143,148,27,174,157,213,194,71,104,141,73,102,183,143,221,222,66,215,250,92,52,81,56,207,190,38,22,141,168,72,151,10,143,20,74,66,4,29,138,85,68,2,223,129,39,74,14,206,17,7,233,187,133,159,182,172,75,42,50,22,79,220,60,218,11,19,154,63,190,79,212,241,132,98,201,13,216,206,209,99,61,206,191,249,105,142,111,80,72,229,168,75,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a97a27d8-986d-4adc-b58a-66f3167f55a1"));
		}

		#endregion

	}

	#endregion

}

