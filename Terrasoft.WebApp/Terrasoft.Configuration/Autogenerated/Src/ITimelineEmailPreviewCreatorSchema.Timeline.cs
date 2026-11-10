namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ITimelineEmailPreviewCreatorSchema

	/// <exclude/>
	public class ITimelineEmailPreviewCreatorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITimelineEmailPreviewCreatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITimelineEmailPreviewCreatorSchema(ITimelineEmailPreviewCreatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("437742ef-1987-4d72-ba0d-753a57b1a47f");
			Name = "ITimelineEmailPreviewCreator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7a90b74c-4b62-4974-bba4-023527b96ef3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,146,221,106,195,48,12,133,175,91,232,59,136,238,102,133,146,220,111,93,161,148,49,122,55,104,95,192,181,149,70,16,219,153,236,164,132,209,119,159,227,56,97,127,244,82,194,250,116,206,177,140,208,232,106,33,17,78,200,44,156,45,124,182,183,166,160,75,195,194,147,53,217,137,52,86,100,112,49,255,92,204,23,243,217,3,227,37,244,225,96,60,114,17,38,159,224,240,170,5,85,227,195,119,198,150,240,186,103,20,222,114,156,201,243,28,54,174,209,90,112,183,77,245,52,15,133,101,144,253,107,50,23,136,40,168,7,6,200,74,56,151,141,132,252,27,162,110,206,21,73,160,137,114,95,196,44,136,159,253,209,17,27,199,186,34,239,192,151,8,24,151,75,27,160,198,247,108,11,31,141,245,232,214,32,140,2,39,90,4,242,32,92,103,100,201,214,216,198,85,93,54,145,243,223,232,77,45,88,104,48,33,228,151,101,132,31,212,114,187,147,158,90,242,29,144,10,107,168,32,100,176,197,176,60,219,228,113,230,127,4,163,180,172,122,198,41,168,213,194,5,243,48,52,99,138,215,146,100,25,157,140,1,146,155,162,189,143,78,166,151,219,125,114,63,42,130,179,85,221,143,217,214,146,130,55,244,59,163,142,33,145,20,245,163,243,220,127,96,178,185,134,84,143,154,167,70,218,180,122,14,172,219,112,82,104,212,112,85,125,121,251,2,146,155,67,124,148,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("437742ef-1987-4d72-ba0d-753a57b1a47f"));
		}

		#endregion

	}

	#endregion

}

