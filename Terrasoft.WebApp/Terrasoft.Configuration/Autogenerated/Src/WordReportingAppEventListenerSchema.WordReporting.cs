namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: WordReportingAppEventListenerSchema

	/// <exclude/>
	public class WordReportingAppEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WordReportingAppEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WordReportingAppEventListenerSchema(WordReportingAppEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c074c284-2329-406d-b902-b8e6677ad447");
			Name = "WordReportingAppEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7609649d-94a6-447b-b054-9d91465ffa7b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,82,219,106,195,48,12,125,78,161,255,96,216,75,242,146,15,104,187,192,218,93,24,108,172,236,66,159,157,68,205,204,90,217,200,106,182,81,246,239,115,226,222,28,210,190,196,145,116,164,115,142,108,148,107,176,70,22,32,222,129,72,90,189,228,116,166,113,169,170,13,73,86,26,211,87,48,154,88,97,149,46,52,149,135,104,56,216,14,7,209,198,186,223,160,117,189,214,56,238,173,156,31,218,124,190,128,250,219,8,206,229,211,123,89,176,38,5,182,15,177,128,252,40,199,213,175,8,42,71,45,102,43,105,237,72,4,102,110,140,185,171,1,249,73,89,6,4,106,27,204,38,95,169,66,20,13,254,50,92,140,68,55,53,149,22,220,140,109,59,233,192,61,39,109,192,141,0,39,96,78,170,150,12,30,96,124,32,62,44,144,219,20,66,209,172,169,27,94,103,94,189,247,253,155,62,0,79,66,72,22,39,227,29,37,96,233,89,59,18,90,87,35,241,12,252,169,75,187,163,247,86,117,237,182,167,74,16,181,86,165,120,65,103,234,141,37,113,188,119,231,136,24,126,88,20,254,76,68,243,6,162,40,119,102,211,19,248,190,60,110,171,129,228,169,194,114,242,120,220,230,45,88,85,161,191,255,44,142,147,198,35,194,119,184,239,83,80,28,26,78,60,201,95,175,105,159,13,147,46,247,15,69,124,60,113,244,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c074c284-2329-406d-b902-b8e6677ad447"));
		}

		#endregion

	}

	#endregion

}

