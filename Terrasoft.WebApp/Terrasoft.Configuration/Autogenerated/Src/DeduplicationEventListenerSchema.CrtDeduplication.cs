namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DeduplicationEventListenerSchema

	/// <exclude/>
	public class DeduplicationEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DeduplicationEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DeduplicationEventListenerSchema(DeduplicationEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5977cffb-468d-4a86-a1e4-3fa810cbe99a");
			Name = "DeduplicationEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,84,203,110,219,48,16,60,59,64,254,129,112,46,14,16,72,247,56,49,80,219,13,106,160,70,31,54,208,51,67,174,101,214,20,41,144,75,161,106,208,127,47,245,138,205,88,86,212,158,36,238,46,103,102,7,187,84,52,5,155,81,6,100,11,198,80,171,119,24,45,180,218,137,196,25,138,66,171,104,9,220,101,82,176,234,116,125,245,114,125,53,114,86,168,36,184,96,32,122,162,12,181,17,96,167,29,21,63,224,217,87,165,169,86,62,235,243,55,6,18,15,71,22,146,90,123,79,2,142,143,57,40,252,44,44,130,2,83,85,199,113,76,30,172,75,83,106,138,89,115,14,174,16,154,29,255,161,188,79,100,3,16,181,247,227,19,128,204,61,251,114,194,74,246,30,114,114,79,62,100,89,16,154,83,11,30,224,165,210,117,108,67,43,139,84,161,111,229,107,5,93,167,27,26,159,66,255,49,64,185,86,178,240,103,83,186,179,108,88,193,126,119,18,22,123,96,7,48,91,154,144,71,50,238,204,141,167,67,96,231,78,30,130,150,62,33,102,11,41,124,19,13,120,79,197,127,82,108,169,61,188,79,115,86,213,178,221,128,226,181,147,161,173,79,2,36,47,61,53,34,247,94,52,210,234,3,97,165,231,175,94,158,242,4,243,187,97,70,100,56,119,66,242,163,187,195,170,223,147,183,6,220,235,90,159,70,96,8,188,85,216,28,73,46,12,58,42,73,174,5,39,43,37,80,80,41,126,67,192,191,132,204,227,131,98,197,74,253,244,215,124,104,173,57,200,201,45,41,119,109,52,170,118,164,222,174,34,154,11,197,31,86,11,103,81,167,151,149,223,13,53,100,54,169,40,70,195,253,187,157,94,18,21,96,172,169,162,201,153,144,38,58,155,244,160,116,77,254,221,155,101,121,197,185,180,67,3,85,110,128,26,182,255,230,192,20,221,206,157,23,244,105,239,156,248,13,82,131,37,240,89,246,141,27,127,134,78,219,201,11,83,189,108,66,237,193,8,228,218,191,104,6,118,143,227,174,71,43,250,162,124,184,18,51,142,103,39,59,174,115,255,74,11,14,245,144,30,171,38,45,138,31,7,132,95,88,46,92,249,109,199,242,159,199,185,167,201,58,26,6,125,236,47,253,66,235,56,157,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5977cffb-468d-4a86-a1e4-3fa810cbe99a"));
		}

		#endregion

	}

	#endregion

}

