namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: RecordUnlinkerSchema

	/// <exclude/>
	public class RecordUnlinkerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RecordUnlinkerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RecordUnlinkerSchema(RecordUnlinkerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("66bb5f4d-9a35-4ffa-80c6-0587b0525470");
			Name = "RecordUnlinker";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("edbaf284-b37c-4101-84cb-76a44645334f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,81,209,110,26,49,16,124,62,36,254,97,149,190,16,41,186,15,32,109,31,2,164,170,212,180,21,148,15,48,246,112,184,49,246,117,237,59,5,85,249,247,174,207,52,1,36,164,123,56,239,204,206,238,204,122,181,71,108,149,6,253,2,179,138,97,155,234,89,240,91,219,116,172,146,13,158,254,142,71,85,23,173,111,104,117,136,9,251,251,139,183,208,157,131,206,220,88,127,129,7,91,253,206,57,85,101,92,171,215,11,159,108,178,136,87,9,243,135,12,201,247,129,209,228,181,102,78,197,56,165,37,116,96,179,246,206,250,103,240,120,36,140,182,219,56,171,73,103,194,5,78,83,122,80,17,165,184,120,129,238,82,224,236,80,218,222,149,197,72,226,78,11,36,3,126,14,106,133,113,84,62,215,156,172,35,88,122,124,201,128,186,179,231,29,125,157,219,225,79,241,225,163,232,138,183,59,10,155,223,2,127,166,86,177,228,159,192,241,54,235,87,213,148,54,178,223,228,82,227,132,55,220,163,170,202,14,75,219,236,210,143,22,199,83,125,162,149,222,97,175,78,192,111,232,225,98,61,83,126,97,108,186,47,189,25,88,188,104,180,185,235,9,49,170,6,210,124,51,92,225,80,52,234,55,66,253,61,12,29,143,129,235,117,107,84,194,205,160,243,122,140,13,222,148,228,206,99,124,66,218,5,115,146,96,85,13,25,114,72,98,11,134,66,47,39,182,6,212,7,107,104,14,39,6,223,188,76,254,27,45,59,213,43,213,99,210,43,103,243,252,37,254,116,150,97,166,180,85,46,226,246,218,58,195,196,82,63,43,143,71,175,255,0,118,83,20,7,248,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("66bb5f4d-9a35-4ffa-80c6-0587b0525470"));
		}

		#endregion

	}

	#endregion

}

