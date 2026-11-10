namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ITranslationBatchSchema

	/// <exclude/>
	public class ITranslationBatchSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITranslationBatchSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITranslationBatchSchema(ITranslationBatchSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6a16d126-b908-4b9c-8616-b21a5c69f407");
			Name = "ITranslationBatch";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ab054f7f-9309-4520-a5a0-bfba22ceff76");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,101,144,65,10,194,48,16,69,215,45,244,14,3,110,165,221,171,184,80,65,138,27,193,94,32,198,105,13,182,105,153,73,23,165,120,119,167,137,74,197,85,38,63,47,255,133,88,213,32,119,74,35,20,72,164,184,45,93,186,111,109,105,170,158,148,51,173,77,11,82,150,107,63,39,241,152,196,81,207,198,86,112,25,216,97,35,108,93,163,158,14,57,61,162,69,50,122,157,196,66,45,8,43,73,33,183,14,169,20,193,10,242,89,213,78,57,125,247,96,215,95,107,163,193,124,184,127,12,228,234,193,120,137,162,97,195,142,228,1,75,8,235,86,42,70,95,244,85,158,169,237,144,156,65,94,193,217,183,135,243,44,203,96,195,125,211,72,203,246,19,204,100,240,192,33,253,130,217,156,12,46,56,225,0,211,23,68,81,133,110,61,13,207,183,26,237,45,216,253,62,164,191,161,100,47,48,124,134,191,109,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6a16d126-b908-4b9c-8616-b21a5c69f407"));
		}

		#endregion

	}

	#endregion

}

