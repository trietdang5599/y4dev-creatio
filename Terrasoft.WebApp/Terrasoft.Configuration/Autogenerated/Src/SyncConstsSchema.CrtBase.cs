namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SyncConstsSchema

	/// <exclude/>
	public class SyncConstsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SyncConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SyncConstsSchema(SyncConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("46b057b7-14b5-4c05-b912-248362985d2b");
			Name = "SyncConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("912fb492-38c7-4dbe-88b2-46a261777d72");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,147,221,106,220,48,16,133,175,215,224,119,16,217,155,246,98,26,175,254,44,19,122,33,107,164,18,8,180,52,237,3,184,94,37,24,118,237,69,178,91,66,201,187,87,206,38,108,13,91,216,14,186,155,209,124,135,115,164,41,118,253,35,185,127,138,163,223,223,228,89,158,245,205,222,199,67,211,122,242,205,135,208,196,225,97,252,96,134,254,161,123,156,66,51,118,67,159,103,191,243,108,117,152,126,236,186,150,180,187,38,198,116,189,111,211,76,28,35,73,173,185,189,186,190,94,191,22,89,255,93,100,77,238,80,127,153,71,94,87,196,49,173,109,73,240,205,118,232,119,79,228,211,212,109,201,221,182,57,204,91,63,31,252,145,122,187,37,31,73,239,127,189,180,223,93,25,206,52,19,181,1,198,156,6,142,178,128,106,99,44,152,26,169,168,40,210,146,171,171,247,55,171,153,115,148,115,9,241,123,244,225,222,135,159,93,235,111,247,135,33,140,255,194,99,89,35,170,90,130,112,44,225,165,51,160,41,55,192,29,117,101,197,120,97,108,153,240,39,250,194,129,151,186,68,207,81,4,118,193,183,179,136,133,4,205,156,160,74,151,160,52,101,192,57,19,160,44,115,80,211,90,113,116,220,106,102,151,14,156,20,192,91,38,23,197,48,181,173,143,241,171,143,211,110,92,72,112,182,18,194,72,9,182,42,44,112,141,6,106,76,113,48,89,48,231,202,82,91,110,206,187,240,127,10,108,8,67,56,195,71,73,29,173,44,5,205,133,4,174,112,3,149,101,18,234,98,131,154,25,170,13,226,57,126,162,95,254,6,231,143,177,160,170,66,166,131,2,140,177,10,184,48,41,2,164,27,64,41,120,50,94,85,210,184,19,245,57,207,158,255,0,27,47,248,54,100,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("46b057b7-14b5-4c05-b912-248362985d2b"));
		}

		#endregion

	}

	#endregion

}

