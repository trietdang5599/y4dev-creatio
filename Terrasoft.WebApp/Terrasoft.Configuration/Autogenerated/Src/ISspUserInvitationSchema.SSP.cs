namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ISspUserInvitationSchema

	/// <exclude/>
	public class ISspUserInvitationSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISspUserInvitationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISspUserInvitationSchema(ISspUserInvitationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c32a2df7-dfa5-4008-a507-49930a3bf59e");
			Name = "ISspUserInvitation";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,148,81,107,194,48,16,199,159,21,252,14,7,190,219,247,57,6,50,68,10,67,196,206,167,177,135,24,175,93,160,77,202,93,226,16,241,187,47,105,117,206,225,108,237,94,66,27,126,185,255,253,239,146,211,162,64,46,133,68,120,69,34,193,38,181,163,103,163,83,149,57,18,86,25,61,74,146,197,160,191,31,244,123,142,149,206,32,217,177,197,98,60,232,251,157,33,97,230,17,136,181,69,74,125,144,7,136,19,46,87,140,20,235,173,178,85,128,138,44,221,58,87,18,212,9,188,202,245,130,74,47,138,34,120,100,87,20,130,118,79,167,141,105,33,84,14,38,133,210,144,21,57,56,127,116,244,77,71,63,113,182,20,242,172,79,236,33,67,59,6,14,203,161,202,228,122,252,197,57,44,120,251,86,72,27,111,254,16,152,57,181,57,67,255,145,0,237,171,127,219,198,220,19,157,36,124,159,38,155,66,233,149,86,13,86,46,201,214,98,161,123,64,38,71,190,17,252,237,189,226,150,1,235,100,163,254,158,72,105,156,110,240,241,11,189,207,136,191,157,168,25,91,116,228,165,38,59,55,230,152,224,140,140,43,111,27,186,36,59,137,205,27,237,4,247,119,121,89,34,187,220,134,183,104,74,60,206,136,235,10,107,99,114,72,156,148,200,237,155,63,37,50,4,159,31,42,71,63,46,252,112,240,73,54,188,244,234,68,219,248,137,159,54,142,67,250,188,99,17,238,189,243,247,30,8,165,161,191,186,81,25,137,57,148,106,34,173,218,94,43,86,189,14,81,111,234,161,24,126,15,95,34,254,189,157,94,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c32a2df7-dfa5-4008-a507-49930a3bf59e"));
		}

		#endregion

	}

	#endregion

}

