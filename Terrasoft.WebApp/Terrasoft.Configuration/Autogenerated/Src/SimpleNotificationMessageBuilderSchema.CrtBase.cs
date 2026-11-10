namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SimpleNotificationMessageBuilderSchema

	/// <exclude/>
	public class SimpleNotificationMessageBuilderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SimpleNotificationMessageBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SimpleNotificationMessageBuilderSchema(SimpleNotificationMessageBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("314059c6-f688-44bf-b84c-c7c747f99b73");
			Name = "SimpleNotificationMessageBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,84,77,111,219,48,12,61,167,64,255,3,145,93,18,160,72,182,107,188,20,88,11,180,243,33,91,129,172,183,0,131,106,49,142,0,91,50,36,121,67,96,228,191,143,178,228,175,14,75,92,116,39,75,36,31,249,248,72,89,178,28,77,193,18,132,31,168,53,51,106,111,23,247,74,238,69,90,106,102,133,146,215,87,213,245,213,164,52,66,166,176,61,26,139,121,212,222,59,200,6,141,97,41,217,8,156,231,74,82,12,69,125,208,152,82,10,184,207,152,49,43,216,138,188,200,240,155,178,98,47,146,58,185,135,225,93,41,50,142,186,198,20,229,75,38,18,72,28,228,34,2,86,16,159,203,55,169,234,156,45,145,7,129,25,39,38,79,90,252,98,22,189,179,240,23,208,200,184,146,217,49,84,13,185,224,103,30,14,107,144,248,123,232,156,205,163,80,0,37,247,53,134,5,159,180,42,80,91,129,174,104,221,153,247,47,151,75,248,108,202,60,103,250,120,219,24,30,209,26,80,26,140,251,10,142,146,26,163,30,213,30,236,1,193,93,237,113,209,162,151,125,120,80,237,177,20,28,98,14,110,100,147,73,138,54,170,15,38,28,78,111,44,46,186,234,140,231,66,66,41,133,29,193,128,246,228,139,139,127,166,240,255,192,70,210,142,54,60,156,156,245,168,193,42,144,110,244,23,36,49,86,187,85,253,222,226,222,203,198,208,168,59,93,194,114,140,226,176,245,200,243,4,254,181,73,27,180,7,197,199,172,81,189,253,6,88,195,173,55,205,17,179,171,209,49,159,205,3,79,141,182,212,242,213,72,47,42,246,23,135,3,61,174,75,245,227,141,73,191,214,113,30,239,207,45,147,158,219,103,163,23,217,60,206,133,119,120,69,67,173,32,247,58,232,30,245,219,57,116,225,111,106,227,69,241,113,251,86,35,239,40,250,181,144,222,191,120,80,58,103,118,54,173,42,216,77,53,38,74,147,232,187,233,138,110,213,199,211,110,122,67,135,118,215,201,78,230,79,100,62,157,200,19,243,155,110,159,231,227,155,144,189,63,229,184,197,117,146,123,124,219,70,171,56,61,236,117,183,45,209,208,233,58,111,220,94,5,31,48,152,235,96,34,13,244,204,91,240,214,161,145,108,127,0,191,59,227,112,195,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("314059c6-f688-44bf-b84c-c7c747f99b73"));
		}

		#endregion

	}

	#endregion

}

