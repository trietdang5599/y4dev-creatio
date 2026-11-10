namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: CommunicationConstantsSchema

	/// <exclude/>
	public class CommunicationConstantsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CommunicationConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CommunicationConstantsSchema(CommunicationConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e9a5adfa-2804-4de4-87ad-c536b6ee39e7");
			Name = "CommunicationConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("45b7d114-643d-4217-a8b2-b9950d3eddb7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,143,207,74,196,48,16,135,207,45,244,29,194,158,244,16,55,217,54,109,23,241,208,191,139,7,97,161,235,3,196,36,173,129,54,41,77,138,20,241,221,77,171,151,21,17,97,78,51,223,252,190,153,217,72,213,129,102,49,86,12,247,129,31,248,138,14,194,140,148,9,112,17,211,68,141,110,237,93,161,85,43,187,121,162,86,106,21,248,239,129,239,141,243,75,47,25,48,214,245,24,96,61,53,6,20,122,24,102,37,217,134,185,29,99,141,35,87,218,219,239,175,134,192,46,163,0,16,156,180,238,122,177,2,215,121,147,160,92,171,126,1,167,89,242,111,234,226,86,158,31,57,120,0,74,188,109,131,155,157,104,5,225,9,61,64,210,134,41,20,24,99,152,18,44,32,66,152,16,142,34,134,48,223,221,110,127,253,173,56,191,106,181,25,126,8,42,20,38,245,129,100,176,76,242,2,150,181,19,228,8,213,171,160,140,81,117,12,211,34,254,151,160,121,106,126,137,207,208,145,96,156,71,16,135,53,130,21,114,241,89,26,231,95,247,151,40,42,156,102,139,247,62,2,223,213,39,137,193,222,160,174,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e9a5adfa-2804-4de4-87ad-c536b6ee39e7"));
		}

		#endregion

	}

	#endregion

}

