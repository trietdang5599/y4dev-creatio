namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: NotificationCounterFactorySchema

	/// <exclude/>
	public class NotificationCounterFactorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public NotificationCounterFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public NotificationCounterFactorySchema(NotificationCounterFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b249d9e1-6ca1-4cdb-b5cf-9f2e4cc638b6");
			Name = "NotificationCounterFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,84,77,139,219,48,16,61,59,144,255,48,120,47,94,88,236,251,230,3,150,208,13,57,116,89,250,113,46,138,51,118,68,101,201,140,164,148,176,236,127,175,36,219,137,227,58,217,182,224,139,70,51,111,230,189,121,178,100,21,234,154,229,8,223,144,136,105,85,152,116,165,100,193,75,75,204,112,37,167,147,183,233,36,178,154,203,18,190,30,181,193,202,221,11,129,185,191,212,233,26,37,18,207,103,167,156,62,76,85,41,57,126,67,120,45,158,62,179,220,40,226,168,125,134,251,238,8,75,215,10,86,130,105,253,8,47,202,240,130,231,97,182,149,178,210,32,53,21,199,233,196,101,103,89,6,115,109,171,138,209,113,217,158,95,73,29,248,14,53,48,168,208,236,213,14,140,2,150,231,168,53,152,61,66,238,145,221,117,161,8,74,52,198,15,21,226,13,188,78,59,220,172,7,92,219,173,224,121,83,123,99,40,120,132,205,173,145,163,183,200,147,60,177,124,230,40,118,142,230,43,241,3,51,24,56,69,117,115,0,66,182,83,82,28,225,187,70,114,91,146,205,22,224,135,189,56,207,154,170,59,148,187,6,181,61,119,66,186,189,25,178,126,0,223,40,240,104,251,52,156,174,207,155,12,26,95,246,189,7,111,149,40,186,140,166,171,61,230,63,159,168,180,21,74,243,98,133,72,164,51,157,42,146,65,245,253,44,84,15,200,192,2,254,96,23,69,239,183,41,126,14,107,190,38,227,230,147,116,179,16,219,10,156,143,45,103,9,107,52,35,113,189,113,194,49,233,124,147,56,1,189,75,74,82,182,238,104,31,24,1,239,50,220,216,193,176,173,112,238,157,152,39,33,198,219,37,1,230,33,128,68,18,127,245,55,212,233,150,196,151,42,196,15,195,173,119,250,17,26,75,242,60,201,191,233,213,115,195,240,41,133,192,151,128,174,123,68,85,225,178,208,189,22,194,98,17,143,17,140,179,37,108,143,253,172,126,210,218,147,119,41,167,150,217,176,231,188,102,196,42,240,174,89,196,65,171,120,249,1,216,60,11,53,103,136,70,21,189,60,255,187,254,110,240,121,214,85,246,30,200,127,27,104,212,55,237,194,62,244,92,83,116,109,157,109,172,31,122,255,13,85,46,185,52,221,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b249d9e1-6ca1-4cdb-b5cf-9f2e4cc638b6"));
		}

		#endregion

	}

	#endregion

}

