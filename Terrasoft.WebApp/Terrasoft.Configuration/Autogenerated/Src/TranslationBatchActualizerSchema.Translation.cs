namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: TranslationBatchActualizerSchema

	/// <exclude/>
	public class TranslationBatchActualizerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TranslationBatchActualizerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TranslationBatchActualizerSchema(TranslationBatchActualizerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8fccbdb7-dc23-4a94-a151-19c141114606");
			Name = "TranslationBatchActualizer";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ab054f7f-9309-4520-a5a0-bfba22ceff76");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,205,84,193,74,195,64,16,61,111,161,255,176,208,75,10,37,31,208,34,69,43,66,64,161,104,193,163,108,147,105,186,144,236,150,217,73,64,139,255,238,38,27,99,98,178,213,131,7,111,217,153,55,239,237,123,59,68,137,28,204,73,196,192,119,128,40,140,62,80,184,209,234,32,211,2,5,73,173,194,29,10,101,178,250,123,58,57,79,39,172,48,82,165,252,233,213,16,228,171,246,220,29,71,232,78,89,140,69,205,16,82,123,224,155,76,24,179,228,157,254,141,160,248,120,29,83,33,50,249,6,88,163,79,197,62,147,49,143,43,240,5,44,239,17,117,57,216,185,230,249,146,213,202,16,22,49,105,180,234,219,154,222,33,26,41,191,72,16,117,122,91,212,165,76,172,50,13,107,139,138,142,177,200,70,179,41,50,42,16,34,117,208,237,132,25,45,47,120,151,254,94,167,105,159,220,85,230,142,122,201,247,194,64,48,166,237,165,31,114,241,234,21,217,251,175,237,63,130,209,5,198,208,58,193,111,133,190,135,127,17,209,240,138,127,25,218,12,84,226,22,171,191,101,150,224,4,72,18,170,29,67,77,16,19,36,77,206,40,75,65,48,8,186,245,254,66,158,206,202,141,55,108,126,2,111,163,190,57,75,129,154,47,134,96,29,43,191,34,95,175,29,144,5,126,204,21,15,124,138,243,145,109,152,215,54,170,0,127,76,241,1,232,168,147,177,8,63,51,208,165,253,219,88,86,94,106,153,240,72,17,160,18,89,187,179,29,249,224,214,134,190,147,57,216,165,21,201,29,234,188,121,73,86,173,73,120,113,180,157,112,87,247,185,13,159,81,18,124,239,130,9,220,220,184,89,87,237,23,109,237,3,210,224,248,226,143,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8fccbdb7-dc23-4a94-a151-19c141114606"));
		}

		#endregion

	}

	#endregion

}

