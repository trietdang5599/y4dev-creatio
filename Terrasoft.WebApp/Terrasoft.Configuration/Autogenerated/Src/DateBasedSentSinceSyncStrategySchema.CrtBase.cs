namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DateBasedSentSinceSyncStrategySchema

	/// <exclude/>
	public class DateBasedSentSinceSyncStrategySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DateBasedSentSinceSyncStrategySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DateBasedSentSinceSyncStrategySchema(DateBasedSentSinceSyncStrategySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("15be1ecd-0b88-4e9e-b6d5-d613f5e51e4e");
			Name = "DateBasedSentSinceSyncStrategy";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,83,219,110,219,48,12,125,118,129,254,3,225,189,116,64,22,239,57,109,3,108,137,7,20,88,131,110,78,62,64,177,25,79,152,45,25,20,61,212,8,242,239,163,47,73,229,44,205,94,108,145,34,15,15,15,41,163,74,116,149,74,17,214,72,164,156,221,241,244,89,233,226,246,102,127,123,19,212,78,155,220,187,89,88,179,211,121,77,138,181,53,247,23,3,8,223,243,79,99,195,154,53,58,9,144,144,15,132,185,160,192,162,80,206,205,96,169,24,191,42,135,89,130,134,19,109,82,76,26,147,38,44,181,48,111,186,140,40,138,224,193,213,101,169,168,153,159,108,68,72,9,119,143,225,147,159,16,70,115,208,101,85,96,41,112,74,179,53,19,200,176,208,127,144,48,131,29,217,210,79,125,43,62,134,152,30,171,68,231,101,9,197,252,237,142,246,117,246,80,203,13,176,5,135,5,166,12,170,40,192,88,254,148,145,218,241,164,63,202,13,75,144,76,195,169,28,221,100,0,118,45,150,228,25,134,76,176,222,8,121,4,170,122,91,232,20,210,86,200,255,49,241,133,30,233,27,236,59,141,79,99,121,33,91,33,113,51,107,79,44,172,49,235,3,206,167,208,57,18,84,148,254,2,124,173,72,26,104,243,25,69,253,129,241,191,26,6,213,17,20,172,140,132,116,38,77,50,181,75,179,49,78,136,61,187,188,199,252,81,35,53,208,46,99,16,228,200,195,41,32,228,154,12,132,155,213,242,231,151,111,107,144,127,252,61,94,199,75,72,226,213,58,121,90,45,98,216,127,62,132,247,93,248,161,253,30,134,6,209,100,125,143,227,134,101,183,133,65,157,178,37,89,199,151,78,211,43,29,47,8,165,59,119,121,139,46,73,223,109,164,148,80,226,127,71,148,206,83,41,82,37,24,121,151,143,161,236,13,9,47,35,74,9,197,112,190,17,27,210,147,99,250,16,117,209,151,147,91,25,19,100,22,81,93,56,247,120,182,239,123,107,95,19,255,222,39,231,163,14,187,117,189,181,187,205,136,39,140,105,79,160,123,248,13,248,132,62,118,115,153,193,86,64,239,206,227,71,129,253,196,47,15,175,247,250,206,195,95,240,119,88,31,209,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("15be1ecd-0b88-4e9e-b6d5-d613f5e51e4e"));
		}

		#endregion

	}

	#endregion

}

