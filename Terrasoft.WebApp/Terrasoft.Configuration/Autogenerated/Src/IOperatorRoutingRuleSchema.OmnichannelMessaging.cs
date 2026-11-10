namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IOperatorRoutingRuleSchema

	/// <exclude/>
	public class IOperatorRoutingRuleSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IOperatorRoutingRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IOperatorRoutingRuleSchema(IOperatorRoutingRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e93c971a-debf-4f24-ad8f-d4b461191ae0");
			Name = "IOperatorRoutingRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,205,82,77,107,220,48,20,60,39,144,255,240,216,94,26,40,246,61,235,26,66,2,139,161,97,211,52,253,1,178,244,228,21,200,146,171,143,150,176,228,191,231,73,90,59,155,52,129,94,10,185,217,79,243,70,51,163,49,108,68,63,49,142,112,143,206,49,111,101,168,174,172,145,106,136,142,5,101,77,181,29,141,226,59,102,12,234,234,6,189,103,131,50,195,217,233,254,236,244,36,122,250,132,31,15,62,224,184,126,245,79,44,90,35,79,20,190,218,160,65,167,56,97,8,245,201,225,64,83,232,76,64,39,233,234,11,232,182,19,210,117,214,221,217,24,136,227,46,106,204,216,41,246,90,113,80,51,244,29,228,201,62,163,23,234,91,103,9,22,20,250,11,184,205,20,229,188,174,107,104,124,28,71,230,30,218,121,208,121,32,127,1,132,242,193,169,62,6,20,16,44,48,173,129,253,102,90,177,94,35,216,195,181,30,164,102,67,181,236,74,32,72,68,104,120,43,153,246,216,212,188,45,116,14,23,194,36,73,219,129,140,252,81,196,218,35,176,105,210,10,197,194,211,212,199,170,122,107,53,201,186,34,154,235,103,81,247,246,82,235,237,162,99,15,3,134,53,60,30,156,163,17,197,252,203,36,110,48,236,172,248,151,24,54,24,142,93,90,87,108,148,55,245,19,114,37,201,64,177,145,79,163,115,104,2,188,241,32,239,216,202,147,137,57,54,130,161,218,125,93,141,185,78,184,106,75,175,144,226,9,59,144,148,17,61,65,114,223,9,96,38,127,166,250,125,143,24,177,19,85,83,103,146,103,78,135,33,58,227,219,78,144,32,146,137,100,192,202,84,68,38,70,101,126,26,117,100,141,214,103,124,34,248,70,1,55,155,168,68,155,18,152,205,116,194,127,94,202,62,171,59,200,61,95,127,172,20,121,14,106,213,166,192,64,45,17,252,29,211,241,210,175,146,101,222,74,217,66,30,188,189,14,255,53,230,212,111,202,166,184,248,2,9,3,7,117,115,210,175,202,93,42,255,114,72,179,39,185,12,93,132,203,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e93c971a-debf-4f24-ad8f-d4b461191ae0"));
		}

		#endregion

	}

	#endregion

}

