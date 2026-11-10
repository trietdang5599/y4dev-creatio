namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: MobileFeaturesSchema

	/// <exclude/>
	public class MobileFeaturesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MobileFeaturesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MobileFeaturesSchema(MobileFeaturesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c869f8b0-e4e6-4ab2-b81c-7222bb422e81");
			Name = "MobileFeatures";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d53ccc06-4052-4cec-9f64-2db65912f531");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,144,65,106,195,48,16,69,215,49,228,14,159,172,90,40,62,64,67,23,37,77,32,11,175,146,11,140,229,145,51,32,75,70,35,83,76,201,221,43,197,78,87,93,104,4,243,223,255,195,140,167,129,117,36,195,184,114,140,164,193,166,250,16,188,149,126,138,148,36,248,186,9,173,56,222,86,63,219,106,51,169,248,30,135,200,69,170,79,249,155,34,95,67,223,187,220,223,111,171,140,140,83,235,196,64,83,70,12,140,35,85,44,17,43,174,25,42,89,79,114,65,46,179,55,159,206,29,125,146,52,95,204,141,7,82,188,99,245,52,156,168,163,68,197,246,240,62,205,255,217,94,94,177,48,155,179,30,61,181,142,59,124,32,197,137,247,75,251,139,213,68,25,203,118,89,216,149,12,12,235,4,216,16,65,206,129,75,164,176,214,56,91,116,162,143,156,55,4,239,230,63,13,54,134,1,233,198,235,134,104,200,139,101,77,248,150,28,209,50,100,24,67,76,220,237,150,209,247,82,75,201,239,94,206,245,11,29,99,61,218,127,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c869f8b0-e4e6-4ab2-b81c-7222bb422e81"));
		}

		#endregion

	}

	#endregion

}

