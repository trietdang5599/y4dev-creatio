namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DuplicatesScheduledSearchParameterCronFactorySchema

	/// <exclude/>
	public class DuplicatesScheduledSearchParameterCronFactorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DuplicatesScheduledSearchParameterCronFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DuplicatesScheduledSearchParameterCronFactorySchema(DuplicatesScheduledSearchParameterCronFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bafd10b7-77ee-4318-8348-d2d3788c8c67");
			Name = "DuplicatesScheduledSearchParameterCronFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,146,219,78,219,64,16,134,175,141,196,59,76,77,133,188,40,90,33,245,174,52,244,34,225,160,10,40,146,67,185,94,236,137,189,170,179,235,206,238,162,70,40,239,206,248,144,56,9,170,40,151,115,250,102,254,127,215,168,5,186,90,101,8,51,36,82,206,206,189,156,88,51,215,69,32,229,181,53,114,138,121,168,43,157,181,209,225,193,203,225,65,20,156,54,5,164,75,231,113,113,182,23,203,27,109,254,112,146,211,71,132,5,207,192,164,82,206,125,133,105,143,65,151,102,37,67,43,204,83,84,148,149,247,138,248,10,143,52,33,107,46,85,230,45,45,91,64,29,158,120,2,156,231,221,25,100,13,230,163,148,168,185,119,184,196,26,134,25,207,215,220,147,126,102,74,187,39,170,187,0,178,166,14,218,120,152,170,229,207,249,35,226,239,180,180,228,239,152,124,131,166,240,37,140,225,75,167,46,58,66,147,119,220,62,238,151,220,162,47,109,222,172,104,207,239,55,236,72,113,158,26,199,174,208,55,199,94,252,173,9,157,227,217,164,105,141,34,95,234,255,17,10,249,187,45,2,90,253,209,179,34,112,109,137,133,57,22,241,254,168,76,55,253,103,123,140,153,94,224,71,24,77,255,192,200,153,216,121,203,140,11,19,22,146,125,248,165,170,128,46,241,203,26,237,60,217,172,238,250,132,232,124,145,19,229,252,183,189,226,121,178,174,62,150,72,152,228,235,2,140,207,183,52,203,107,229,46,43,85,12,117,1,199,199,48,116,127,26,195,30,89,222,89,131,107,120,138,21,102,126,151,190,9,228,204,166,237,147,38,241,85,44,100,26,158,186,23,78,78,71,255,252,73,130,135,30,234,26,41,17,162,51,135,208,7,50,240,57,62,133,151,193,104,121,171,77,96,143,87,59,201,107,27,136,83,223,225,132,211,237,46,249,195,106,147,196,163,120,180,229,176,88,193,73,220,210,87,111,63,109,159,219,78,173,94,1,34,70,159,127,16,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bafd10b7-77ee-4318-8348-d2d3788c8c67"));
		}

		#endregion

	}

	#endregion

}

