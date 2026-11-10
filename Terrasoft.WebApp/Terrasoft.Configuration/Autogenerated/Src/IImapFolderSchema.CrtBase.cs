namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IImapFolderSchema

	/// <exclude/>
	public class IImapFolderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImapFolderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImapFolderSchema(IImapFolderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6310e556-8a63-4c49-b0b8-076bc13c50bb");
			Name = "IImapFolder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,142,193,10,194,48,16,68,207,13,244,31,22,188,251,1,245,42,133,130,22,169,254,64,108,183,113,33,77,202,38,234,161,244,223,13,9,74,139,122,220,121,51,179,99,228,128,110,148,45,194,5,153,165,179,189,223,30,37,233,92,76,185,200,69,182,97,84,100,13,84,198,35,247,193,87,64,85,13,114,44,173,238,144,163,101,188,95,53,181,64,111,199,218,144,165,158,79,81,73,168,59,87,192,41,166,18,115,158,201,40,168,195,22,152,64,161,223,193,188,208,207,55,203,254,31,220,163,166,129,194,235,95,176,145,207,175,92,216,9,53,58,31,248,1,31,168,23,48,238,68,211,165,169,241,78,234,90,156,95,153,7,237,186,53,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6310e556-8a63-4c49-b0b8-076bc13c50bb"));
		}

		#endregion

	}

	#endregion

}

