namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: FeatureEventListenerSchema

	/// <exclude/>
	public class FeatureEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FeatureEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FeatureEventListenerSchema(FeatureEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1f50e50d-51d9-4c9e-9c39-6822020189dc");
			Name = "FeatureEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0c6d5769-8079-4d44-b72c-713dda089a12");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,83,193,110,19,49,16,61,167,82,255,97,20,46,27,9,109,238,73,91,169,44,165,32,81,138,148,182,23,196,193,89,207,110,140,54,246,106,108,7,149,42,255,206,172,189,91,234,146,64,137,196,37,218,120,222,123,243,230,121,12,90,172,209,182,162,68,184,65,34,97,77,229,242,194,232,74,213,158,132,83,70,31,31,61,28,31,141,188,85,186,78,32,132,243,61,231,249,133,118,202,41,180,127,5,228,23,27,212,174,195,49,242,21,97,205,253,160,104,132,181,51,120,135,194,121,194,128,248,168,172,67,141,20,112,95,2,251,62,41,100,139,114,133,107,241,137,135,129,83,24,247,220,241,228,43,227,91,191,108,84,9,101,39,187,83,21,102,240,70,88,220,33,203,236,135,208,243,151,57,163,173,19,236,121,6,159,73,109,132,195,88,111,227,31,40,187,58,88,71,221,212,119,10,191,95,25,233,27,92,148,164,90,119,221,58,181,86,63,66,172,189,145,193,241,173,197,203,174,35,107,252,137,53,158,247,118,80,203,232,40,181,119,133,110,101,228,62,115,27,163,36,92,15,173,139,149,208,53,202,204,44,191,97,201,158,141,167,18,39,208,221,246,104,180,17,4,85,159,85,200,133,77,102,241,107,18,145,243,231,184,126,148,132,149,95,162,187,185,111,81,22,166,241,107,125,39,26,143,39,49,157,179,108,92,24,201,119,20,133,84,5,89,34,116,250,210,248,6,203,163,162,65,65,61,9,155,200,41,4,47,70,150,122,226,172,137,239,81,243,212,172,212,247,223,118,191,219,29,121,237,87,77,117,192,167,178,189,171,228,45,45,98,237,61,54,45,82,30,148,163,148,223,97,105,251,210,171,14,251,29,139,211,233,20,78,148,94,33,41,39,77,9,211,179,48,79,124,1,102,195,175,80,201,199,61,248,160,185,171,123,178,1,220,9,233,53,196,152,206,43,135,20,94,195,57,213,22,30,99,94,242,83,201,159,144,7,22,246,65,254,182,95,17,144,204,244,79,54,111,91,41,14,117,57,112,255,187,201,183,216,224,161,38,7,238,33,38,159,109,71,60,77,15,249,236,39,246,85,129,8,230,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1f50e50d-51d9-4c9e-9c39-6822020189dc"));
		}

		#endregion

	}

	#endregion

}

