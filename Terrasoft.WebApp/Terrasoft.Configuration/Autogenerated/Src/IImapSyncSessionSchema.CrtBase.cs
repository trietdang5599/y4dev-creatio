namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IImapSyncSessionSchema

	/// <exclude/>
	public class IImapSyncSessionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImapSyncSessionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImapSyncSessionSchema(IImapSyncSessionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b5e207e3-b931-420a-8ad6-b7eb4a279b1a");
			Name = "IImapSyncSession";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("80eb4b00-d20b-4335-a2cc-1f02c0e63f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,145,193,106,132,48,16,134,207,10,190,195,192,94,218,139,222,215,82,40,187,23,15,130,212,190,64,54,142,110,192,36,146,137,11,118,217,119,239,68,237,178,197,22,154,83,38,153,255,207,151,127,140,208,72,131,144,8,31,232,156,32,219,250,180,20,170,79,226,107,18,3,175,145,148,233,160,158,200,163,206,147,56,137,163,157,195,78,89,3,133,241,232,90,150,238,161,40,180,24,234,201,200,26,137,248,110,238,203,178,12,94,104,212,90,184,233,117,173,43,103,47,170,65,2,141,254,108,27,130,214,58,40,202,183,10,136,213,103,103,141,250,20,62,184,171,224,46,100,216,167,223,102,217,131,219,48,158,122,37,151,182,0,177,97,96,170,163,162,193,146,56,245,200,2,254,79,116,103,103,142,1,157,87,72,123,168,102,167,25,121,195,60,31,188,163,182,30,65,158,133,233,16,20,7,65,32,237,104,124,122,151,60,146,69,204,180,106,14,179,132,14,161,25,174,208,161,207,225,182,188,180,67,211,44,48,107,189,146,149,75,48,255,192,170,189,112,158,64,241,183,65,243,200,54,17,210,18,196,31,148,23,171,26,8,121,133,220,194,200,159,158,243,95,209,22,224,159,135,183,47,141,198,184,252,56,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b5e207e3-b931-420a-8ad6-b7eb4a279b1a"));
		}

		#endregion

	}

	#endregion

}

