namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SysUserProfileQueryExecutorSchema

	/// <exclude/>
	public class SysUserProfileQueryExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysUserProfileQueryExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysUserProfileQueryExecutorSchema(SysUserProfileQueryExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2874e500-f502-47f6-9bab-e93d028d1b70");
			Name = "SysUserProfileQueryExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("400566f7-77a1-4986-aa86-a353b8b6c452");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,83,75,111,155,64,16,62,19,41,255,97,74,47,88,178,224,158,24,75,169,27,87,61,180,74,147,246,84,85,213,22,6,103,165,101,161,179,187,110,81,148,255,222,125,64,12,184,225,98,193,240,237,247,154,53,72,86,163,106,89,129,240,21,137,152,106,42,157,238,26,89,241,131,33,166,121,35,47,47,158,46,47,34,163,184,60,76,32,132,215,175,204,211,91,169,185,230,168,94,5,236,89,161,27,10,8,139,121,75,120,176,74,176,19,76,169,43,120,232,212,55,133,116,71,77,197,5,126,49,72,221,237,95,44,140,61,226,225,223,223,99,197,140,208,239,184,44,45,121,162,187,22,155,42,249,232,101,187,9,126,181,134,207,54,32,228,16,47,176,198,171,31,150,182,53,191,4,47,160,112,38,150,60,192,21,252,79,202,50,60,121,123,47,113,246,28,69,105,243,220,17,63,50,141,225,99,27,94,128,144,149,141,20,29,56,25,91,184,196,194,181,13,63,205,228,253,186,167,68,89,6,214,169,132,5,42,77,198,181,233,132,124,130,94,39,164,89,200,145,204,148,167,194,43,112,107,143,162,153,31,219,228,153,193,40,122,94,118,249,9,245,99,83,206,12,102,89,6,27,101,234,154,81,183,29,6,247,168,13,73,229,53,160,13,166,211,23,116,54,135,111,90,70,172,6,119,135,243,216,98,53,146,138,183,251,240,144,110,50,255,249,132,166,192,190,157,150,2,42,36,113,7,6,196,168,193,176,234,93,35,68,223,192,7,212,243,89,18,6,15,197,35,214,204,151,12,168,126,15,21,30,25,1,122,192,61,170,70,28,109,180,60,220,245,240,63,232,82,75,185,217,25,34,139,154,122,27,14,108,19,137,127,198,219,190,161,131,169,45,60,241,10,81,60,93,74,188,158,223,163,213,202,47,42,10,70,125,191,189,68,63,201,103,22,157,167,222,210,200,79,210,211,184,72,197,169,146,28,156,189,179,86,102,30,214,115,137,113,107,61,49,175,32,57,55,247,198,10,24,33,134,66,163,147,116,122,83,150,231,7,122,178,103,255,27,118,58,178,187,112,101,195,116,58,180,179,127,122,53,159,204,38,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2874e500-f502-47f6-9bab-e93d028d1b70"));
		}

		#endregion

	}

	#endregion

}

