namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: TimelineUtilitiesSchema

	/// <exclude/>
	public class TimelineUtilitiesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TimelineUtilitiesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TimelineUtilitiesSchema(TimelineUtilitiesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("315c3b7a-309c-4cee-a111-cc022ffb97a1");
			Name = "TimelineUtilities";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7a90b74c-4b62-4974-bba4-023527b96ef3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,82,75,107,2,49,16,62,175,224,127,24,236,165,150,178,107,75,123,169,86,40,246,129,80,65,80,123,45,233,238,104,3,155,68,242,144,90,241,191,119,146,184,234,138,61,102,102,190,71,190,25,201,4,154,37,203,17,166,168,53,51,106,110,211,129,146,115,190,112,154,89,174,100,58,229,2,75,46,177,217,216,52,27,137,51,92,46,106,179,26,187,205,6,117,46,52,46,104,30,6,37,51,230,1,42,216,204,242,146,91,142,38,12,101,89,6,61,227,132,96,122,221,223,189,199,90,173,120,129,102,15,1,23,48,107,16,104,191,85,97,210,10,152,29,33,151,238,171,228,57,24,75,46,115,200,189,232,57,205,100,19,116,15,238,148,36,136,180,228,112,172,249,138,89,140,253,101,124,84,124,92,90,248,20,236,103,194,127,241,25,231,3,85,58,33,63,88,233,16,30,225,166,115,123,7,87,112,223,233,238,184,81,22,145,190,174,53,138,246,73,41,120,141,205,211,4,66,225,13,173,1,20,140,151,240,165,138,53,228,65,15,200,0,24,114,144,238,129,217,41,178,183,100,154,9,144,180,198,199,150,51,168,233,131,18,115,191,185,86,127,250,77,89,82,141,248,170,98,218,203,2,226,64,160,209,58,45,77,255,105,47,119,236,100,229,255,76,160,106,42,100,85,139,222,71,69,254,95,60,102,20,19,59,138,235,114,86,243,4,117,139,109,240,55,149,36,145,29,252,49,157,92,223,100,109,38,104,45,29,157,73,73,37,114,214,73,174,161,245,206,244,2,189,114,112,17,134,134,242,85,35,22,74,204,134,173,235,127,118,217,238,122,245,237,217,45,198,106,189,184,253,3,5,216,239,86,46,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("315c3b7a-309c-4cee-a111-cc022ffb97a1"));
		}

		#endregion

	}

	#endregion

}

