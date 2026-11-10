namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SearchScoreSettingSchema

	/// <exclude/>
	public class SearchScoreSettingSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SearchScoreSettingSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SearchScoreSettingSchema(SearchScoreSettingSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4f808b42-28b6-4954-82ef-e995b5076254");
			Name = "SearchScoreSetting";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6f142301-7a5f-41f6-815b-40f61aa5d442");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,81,189,106,195,48,16,158,109,240,59,28,153,90,40,246,3,36,205,210,63,232,16,74,93,232,80,58,168,202,217,17,200,146,209,157,9,166,228,221,123,146,157,144,80,58,116,16,210,221,125,127,146,156,234,144,122,165,17,222,48,4,69,190,225,242,206,187,198,180,67,80,108,188,131,239,34,47,242,108,32,227,90,168,71,98,236,4,96,45,234,56,165,242,9,29,6,163,151,39,204,6,247,44,131,40,244,76,222,45,19,189,170,42,88,209,208,117,42,140,235,185,126,197,62,32,161,99,2,180,138,216,104,32,84,65,239,128,180,15,40,5,179,8,82,121,228,87,103,2,253,240,101,133,160,133,72,80,39,90,29,89,245,68,18,132,228,206,126,249,166,198,131,99,195,35,236,209,180,59,46,79,176,115,249,236,35,102,127,9,190,199,192,227,213,241,176,145,215,130,91,88,76,212,197,245,103,132,206,81,140,99,120,79,253,248,22,217,159,238,143,6,237,150,46,110,247,111,255,38,105,92,250,223,155,244,35,34,176,34,14,34,125,3,211,190,158,45,99,172,131,172,34,63,252,0,198,3,250,128,246,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4f808b42-28b6-4954-82ef-e995b5076254"));
		}

		#endregion

	}

	#endregion

}

