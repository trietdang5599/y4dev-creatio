namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: RecordProcessedEventArgsSchema

	/// <exclude/>
	public class RecordProcessedEventArgsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RecordProcessedEventArgsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RecordProcessedEventArgsSchema(RecordProcessedEventArgsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("55febf69-27f8-44d0-b988-9700d6626862");
			Name = "RecordProcessedEventArgs";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,80,77,107,195,48,12,61,47,144,255,32,232,61,185,183,99,48,74,25,187,149,125,252,0,207,86,50,65,98,103,146,93,86,202,254,251,108,167,109,194,218,245,98,164,103,233,189,167,103,85,143,50,40,141,240,134,204,74,92,227,171,181,179,13,181,129,149,39,103,225,80,22,119,65,200,182,240,186,23,143,253,170,44,34,178,96,108,211,239,186,83,34,75,120,65,237,216,108,217,105,20,65,179,217,161,245,143,220,74,158,173,235,26,238,37,244,189,226,253,195,177,143,163,59,50,40,160,140,161,164,163,58,32,219,56,238,71,213,88,129,255,196,191,196,128,137,185,58,145,214,51,214,33,124,116,164,65,39,67,255,250,129,37,76,117,186,236,124,72,156,29,144,61,97,188,102,155,169,178,247,11,243,25,216,124,107,28,178,79,215,0,103,45,24,70,177,24,84,117,222,155,251,59,25,156,118,167,234,0,45,250,21,72,122,126,110,232,190,91,250,10,8,49,56,235,169,33,100,153,12,220,86,125,10,100,142,169,60,155,107,122,11,180,102,140,34,118,35,54,135,202,34,98,191,138,144,1,183,45,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("55febf69-27f8-44d0-b988-9700d6626862"));
		}

		#endregion

	}

	#endregion

}

