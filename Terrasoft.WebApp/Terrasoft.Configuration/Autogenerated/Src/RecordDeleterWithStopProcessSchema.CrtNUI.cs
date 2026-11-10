namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: RecordDeleterWithStopProcessSchema

	/// <exclude/>
	public class RecordDeleterWithStopProcessSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RecordDeleterWithStopProcessSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RecordDeleterWithStopProcessSchema(RecordDeleterWithStopProcessSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c0257476-0351-4841-902a-f92f292b905b");
			Name = "RecordDeleterWithStopProcess";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("edbaf284-b37c-4101-84cb-76a44645334f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,83,203,78,195,48,16,60,7,137,127,176,196,165,72,40,31,64,17,135,62,132,144,90,181,2,42,142,200,117,150,214,40,181,195,122,83,17,161,252,59,107,59,161,164,144,114,139,215,227,217,157,217,137,145,59,112,133,84,32,158,0,81,58,251,74,233,216,154,87,189,41,81,146,182,70,124,158,159,37,165,211,102,35,30,43,71,176,27,30,157,25,158,231,160,60,214,165,119,96,0,181,58,137,89,172,223,248,115,110,51,200,15,184,159,221,17,250,234,233,212,144,38,13,174,23,48,25,245,94,45,209,42,112,61,79,119,59,107,126,77,61,211,230,189,151,174,227,18,163,24,119,129,176,241,150,141,115,233,220,181,120,0,101,49,155,64,14,4,248,172,105,251,72,182,104,166,8,248,162,92,231,90,9,229,225,39,209,226,136,204,47,133,223,31,26,178,175,132,165,34,139,220,119,25,104,35,162,105,113,138,124,176,114,128,204,96,226,130,68,217,57,94,121,150,36,185,159,232,112,148,88,221,112,43,246,227,74,216,176,200,91,81,72,228,20,49,177,187,228,65,215,210,193,224,136,163,3,241,129,74,234,70,0,152,44,106,232,10,154,3,109,109,230,181,160,222,75,2,127,23,228,196,163,216,91,157,137,40,199,171,25,75,163,32,159,126,128,42,125,191,86,216,33,117,55,77,105,166,121,177,28,81,30,186,91,104,231,74,26,224,212,108,180,129,21,233,60,228,45,141,29,150,18,193,80,75,255,242,75,229,49,231,48,80,122,71,210,56,236,162,128,24,152,65,188,171,91,97,255,27,209,44,181,245,193,18,119,133,76,216,61,199,82,103,29,75,126,116,105,84,17,86,205,215,169,105,146,90,40,73,106,43,6,225,63,171,56,24,217,168,106,29,249,80,80,132,128,64,251,213,178,39,255,110,226,251,73,186,252,219,163,186,39,20,65,110,172,119,202,231,103,245,23,106,64,223,238,187,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c0257476-0351-4841-902a-f92f292b905b"));
		}

		#endregion

	}

	#endregion

}

