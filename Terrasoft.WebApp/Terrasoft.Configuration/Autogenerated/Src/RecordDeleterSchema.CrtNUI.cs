namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: RecordDeleterSchema

	/// <exclude/>
	public class RecordDeleterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RecordDeleterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RecordDeleterSchema(RecordDeleterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a61c9bf9-deb2-46d9-9e0b-bc4b5a27b8cc");
			Name = "RecordDeleter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("edbaf284-b37c-4101-84cb-76a44645334f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,81,203,110,194,48,16,60,27,137,127,88,209,75,144,144,63,0,218,30,120,180,170,84,90,4,173,122,54,206,146,184,10,118,100,59,8,132,248,247,110,236,148,38,149,184,197,59,59,179,51,19,45,246,232,74,33,17,62,208,90,225,204,206,243,153,209,59,149,85,86,120,101,52,156,251,61,86,57,165,51,216,156,156,199,61,193,69,129,178,198,28,127,70,141,86,201,201,117,167,173,98,241,214,156,207,167,4,17,120,103,49,171,143,204,10,225,220,24,214,40,141,77,231,88,160,71,27,22,202,106,91,40,9,178,198,187,48,140,97,42,28,198,217,226,136,178,242,134,56,236,28,120,127,202,100,211,219,74,18,72,7,86,65,46,110,52,210,29,209,228,211,161,37,138,142,1,161,234,60,71,240,50,87,225,75,216,211,61,201,82,178,17,152,237,55,193,143,80,10,75,101,146,136,27,214,242,140,141,97,75,6,147,255,26,173,189,80,46,99,209,194,90,101,185,127,47,177,233,253,1,54,50,199,189,104,129,175,120,192,194,241,153,208,209,238,36,178,107,104,113,148,88,214,188,37,58,39,50,36,250,96,161,189,242,167,168,194,175,11,252,205,4,198,147,177,60,202,12,130,206,165,233,13,117,26,171,235,246,184,68,159,155,180,85,33,99,161,68,107,60,5,195,20,204,129,126,177,74,17,14,70,165,16,149,175,105,146,223,168,209,83,115,248,75,249,156,194,72,44,86,214,72,50,158,12,111,89,9,215,226,188,51,238,247,46,63,101,129,157,100,195,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a61c9bf9-deb2-46d9-9e0b-bc4b5a27b8cc"));
		}

		#endregion

	}

	#endregion

}

