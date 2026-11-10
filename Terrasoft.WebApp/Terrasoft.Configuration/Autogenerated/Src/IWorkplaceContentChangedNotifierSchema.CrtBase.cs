namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IWorkplaceContentChangedNotifierSchema

	/// <exclude/>
	public class IWorkplaceContentChangedNotifierSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IWorkplaceContentChangedNotifierSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IWorkplaceContentChangedNotifierSchema(IWorkplaceContentChangedNotifierSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d9069699-d4c5-46f2-903e-71f11dc83ff9");
			Name = "IWorkplaceContentChangedNotifier";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9229ed18-5614-47df-8744-72b0c7198840");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,144,49,79,195,48,16,133,231,68,202,127,56,149,5,150,100,167,165,75,134,42,3,8,169,72,12,136,193,141,207,169,69,227,139,124,54,40,170,250,223,177,157,164,2,70,6,91,186,59,125,239,221,59,48,162,71,30,68,139,240,130,214,10,38,229,202,154,140,210,157,183,194,105,50,69,126,46,242,204,179,54,29,236,71,118,216,175,139,60,116,170,170,130,13,251,190,23,118,220,206,117,99,28,90,21,197,20,89,96,52,50,82,134,156,86,186,77,106,16,220,88,116,8,226,64,222,193,23,217,143,225,20,129,150,2,107,28,180,71,97,186,64,149,139,69,245,195,99,240,135,147,110,65,95,109,154,215,69,160,158,248,58,226,40,159,146,37,218,192,156,211,182,217,141,197,46,250,63,162,59,146,228,123,120,78,90,113,20,223,223,52,169,177,15,1,248,255,235,79,162,131,176,162,135,120,230,135,149,103,180,141,228,213,54,124,64,10,98,205,224,40,157,106,209,46,55,85,98,174,107,252,58,65,246,73,90,66,202,55,222,238,188,150,111,239,48,203,222,173,231,168,65,108,74,27,170,75,145,95,190,1,220,35,188,86,229,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d9069699-d4c5-46f2-903e-71f11dc83ff9"));
		}

		#endregion

	}

	#endregion

}

