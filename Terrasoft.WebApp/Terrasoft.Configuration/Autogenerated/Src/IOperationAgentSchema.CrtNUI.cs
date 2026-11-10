namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IOperationAgentSchema

	/// <exclude/>
	public class IOperationAgentSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IOperationAgentSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IOperationAgentSchema(IOperationAgentSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("125ee0b8-83aa-4709-82ef-794af080f041");
			Name = "IOperationAgent";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,148,207,78,195,48,12,198,207,76,226,29,172,113,25,18,90,239,108,84,66,104,154,122,24,32,254,60,64,214,186,37,82,155,20,39,153,64,19,239,142,147,210,104,43,108,236,212,214,249,62,251,231,216,170,18,13,154,86,228,8,47,72,36,140,46,237,244,78,171,82,86,142,132,149,90,193,249,104,123,62,58,115,70,170,10,158,63,141,197,102,54,248,102,67,93,99,238,213,102,186,68,133,36,115,214,176,234,130,176,242,57,50,101,145,74,174,114,13,217,67,139,93,230,219,10,149,13,178,36,73,96,110,92,211,8,250,76,127,190,163,5,116,9,246,141,31,189,15,132,55,78,123,95,178,99,108,221,186,150,57,200,232,29,84,131,109,168,23,185,30,201,103,181,18,205,53,60,118,222,78,48,36,10,129,39,180,142,148,1,75,14,65,150,208,104,66,16,27,33,107,177,174,113,26,125,187,68,103,107,173,107,88,177,242,118,35,106,233,133,176,133,10,237,12,190,252,113,160,65,85,116,64,251,116,43,180,111,186,136,104,39,144,41,252,176,144,199,105,244,87,231,148,124,247,200,5,95,129,44,37,146,57,0,27,34,212,37,75,239,78,201,51,79,122,185,247,103,11,229,26,190,112,238,114,190,116,178,72,97,137,246,158,161,50,94,19,51,185,156,29,233,225,181,45,132,69,195,195,43,53,53,98,183,46,97,174,169,56,198,220,10,18,13,40,94,230,155,113,167,206,138,113,250,58,228,101,220,160,252,219,136,31,57,182,190,238,56,93,244,175,123,142,141,150,197,15,231,83,87,132,89,39,190,81,232,139,94,65,180,66,204,119,180,239,103,180,230,255,153,229,194,106,226,213,211,225,144,79,220,161,133,59,120,31,102,124,234,72,7,29,47,84,168,55,249,61,221,152,218,119,248,231,50,127,117,255,129,189,96,136,125,3,31,102,114,116,121,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("125ee0b8-83aa-4709-82ef-794af080f041"));
		}

		#endregion

	}

	#endregion

}

