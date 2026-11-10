namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IDeduplicationManagerSchema

	/// <exclude/>
	public class IDeduplicationManagerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDeduplicationManagerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDeduplicationManagerSchema(IDeduplicationManagerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f3e391f5-bea4-4635-974c-b28b77b1e29d");
			Name = "IDeduplicationManager";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,83,205,110,194,48,12,62,23,137,119,176,216,133,73,83,123,135,174,151,49,38,14,72,19,236,5,66,235,118,145,154,180,115,146,73,8,241,238,51,233,223,64,108,227,176,83,107,231,251,177,191,166,90,40,52,181,72,17,222,144,72,152,42,183,225,83,165,115,89,56,18,86,86,58,92,96,230,234,82,166,190,26,143,14,227,81,224,140,212,5,108,247,198,162,154,95,212,204,46,75,76,79,96,19,190,160,70,146,41,99,24,117,71,88,112,23,86,218,34,229,108,57,131,213,153,248,90,104,81,32,121,112,20,69,16,27,167,148,160,125,210,214,103,96,80,13,58,236,192,209,55,116,237,118,140,3,217,57,253,100,20,28,188,89,63,218,26,237,123,149,153,25,188,122,129,230,240,114,20,223,88,74,157,25,232,52,209,0,179,141,248,196,176,103,68,151,148,184,22,36,20,104,78,252,113,146,51,127,209,179,55,248,225,208,216,73,210,190,132,113,228,193,3,151,208,58,210,38,25,56,144,246,65,51,188,59,63,17,86,207,218,41,36,177,43,49,94,72,143,224,57,98,99,137,63,211,3,52,207,36,241,59,12,122,211,229,181,145,224,234,160,247,243,63,163,49,82,201,82,16,16,166,21,113,157,83,165,216,186,34,204,0,181,149,118,127,107,84,116,115,56,219,214,211,235,203,255,138,168,85,221,52,139,44,121,143,173,95,99,250,219,97,23,31,13,129,5,129,191,106,168,179,230,182,249,8,143,205,175,113,214,60,126,1,23,195,156,8,149,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f3e391f5-bea4-4635-974c-b28b77b1e29d"));
		}

		#endregion

	}

	#endregion

}

