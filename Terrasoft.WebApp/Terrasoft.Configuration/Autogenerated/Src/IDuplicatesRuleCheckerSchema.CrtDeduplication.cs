namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IDuplicatesRuleCheckerSchema

	/// <exclude/>
	public class IDuplicatesRuleCheckerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDuplicatesRuleCheckerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDuplicatesRuleCheckerSchema(IDuplicatesRuleCheckerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("53ff3e32-a9b5-4c01-b749-bb3b0594295a");
			Name = "IDuplicatesRuleChecker";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,83,205,106,194,64,16,62,87,240,29,6,189,180,80,146,187,90,161,104,17,15,45,210,250,2,107,50,49,67,147,108,152,217,213,138,244,221,187,187,241,15,171,80,10,222,50,179,51,223,223,102,43,85,162,212,42,65,152,35,179,18,157,153,104,164,171,140,150,150,149,33,93,69,99,76,109,93,80,18,170,118,107,219,110,221,89,161,106,9,31,27,49,88,246,219,45,215,233,50,46,221,49,76,43,131,156,57,184,30,76,199,187,53,148,119,91,224,40,199,228,19,57,76,199,113,12,3,177,101,169,120,51,220,213,51,214,43,74,81,64,129,160,1,157,65,137,38,215,169,128,209,144,248,101,48,57,130,90,41,42,212,130,10,50,27,63,148,158,170,3,118,68,18,237,25,226,19,138,218,46,220,20,208,94,223,85,121,119,219,32,241,224,232,181,81,209,131,89,64,104,14,207,13,132,70,128,144,139,42,213,5,157,176,216,120,175,53,38,148,17,166,64,105,116,128,142,207,177,7,181,98,85,66,229,110,235,169,67,105,103,56,207,189,133,67,54,209,32,14,19,199,5,70,99,185,146,225,156,45,2,93,145,176,38,147,239,176,25,179,35,124,60,4,252,34,49,242,8,218,249,225,53,9,66,166,10,65,71,180,71,246,84,11,173,11,152,160,153,202,248,136,237,243,124,241,235,247,19,75,222,216,67,255,118,177,9,42,78,114,16,23,67,169,130,131,191,198,216,172,188,185,239,38,206,223,72,55,137,247,132,246,31,49,63,39,134,86,120,49,108,49,236,159,229,17,127,31,123,23,171,180,249,155,67,253,221,188,216,147,166,235,252,0,37,174,89,233,8,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("53ff3e32-a9b5-4c01-b749-bb3b0594295a"));
		}

		#endregion

	}

	#endregion

}

