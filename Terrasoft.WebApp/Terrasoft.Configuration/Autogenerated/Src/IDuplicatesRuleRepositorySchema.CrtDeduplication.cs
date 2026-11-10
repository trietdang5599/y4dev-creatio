namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IDuplicatesRuleRepositorySchema

	/// <exclude/>
	public class IDuplicatesRuleRepositorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDuplicatesRuleRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDuplicatesRuleRepositorySchema(IDuplicatesRuleRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("724d927b-4ab0-492e-878f-0d68376bae8a");
			Name = "IDuplicatesRuleRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,84,203,110,194,48,16,60,131,196,63,172,224,66,165,42,185,67,154,11,84,8,169,85,43,30,31,96,146,13,88,74,236,212,143,74,17,226,223,187,113,32,144,80,40,151,30,189,222,153,157,153,117,34,88,134,58,103,17,194,10,149,98,90,38,198,155,72,145,240,173,85,204,112,41,188,41,198,54,79,121,228,78,189,238,190,215,237,88,205,197,22,150,133,54,152,141,91,103,66,167,41,70,101,179,246,102,40,80,241,232,220,115,57,68,225,173,186,183,52,213,45,221,15,20,110,137,11,230,194,160,74,72,232,8,230,211,163,32,212,11,204,165,230,212,93,184,102,223,247,33,208,54,203,152,42,194,227,249,220,12,202,166,8,40,12,55,5,168,26,9,252,68,237,157,40,252,11,142,220,110,8,127,110,106,140,39,194,75,9,157,189,147,81,139,126,71,179,147,177,30,193,167,35,169,46,219,34,93,97,129,198,42,161,33,229,218,128,76,32,110,170,214,94,141,244,219,208,32,103,138,101,32,104,147,47,125,171,81,209,254,68,181,129,126,184,166,51,68,117,1,18,169,200,250,151,69,109,188,192,119,200,223,137,34,22,237,208,237,161,31,46,42,0,184,26,232,178,120,13,86,149,131,240,173,229,160,156,234,44,64,108,36,193,78,125,37,112,254,42,108,134,138,109,82,12,154,169,78,87,31,33,204,208,52,171,122,184,110,248,131,166,221,231,146,147,88,39,181,118,56,219,120,26,63,16,127,249,24,233,141,180,210,135,77,1,150,199,255,176,131,187,43,224,49,69,95,142,167,209,55,227,110,61,239,86,192,87,161,150,153,254,17,34,204,200,43,205,188,27,216,146,125,211,196,7,3,161,197,247,195,155,14,154,138,55,82,166,176,206,99,210,60,188,86,79,76,39,89,3,20,113,245,153,185,243,161,250,91,52,138,135,31,193,163,249,52,222,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("724d927b-4ab0-492e-878f-0d68376bae8a"));
		}

		#endregion

	}

	#endregion

}

