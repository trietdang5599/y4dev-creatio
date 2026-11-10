namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ISearchColumnNameProviderSchema

	/// <exclude/>
	public class ISearchColumnNameProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISearchColumnNameProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISearchColumnNameProviderSchema(ISearchColumnNameProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("90958362-e618-422a-ad51-19a35fdf8930");
			Name = "ISearchColumnNameProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,145,177,142,194,48,12,134,103,42,245,29,44,88,142,165,217,185,94,23,6,196,0,66,192,11,228,90,183,68,34,73,229,36,72,8,241,238,148,164,133,0,167,27,243,219,159,255,223,49,40,46,209,180,188,68,216,35,17,55,186,182,217,92,171,90,52,142,184,21,90,165,9,92,210,36,77,70,19,194,166,123,195,82,89,164,186,35,102,176,220,33,167,242,48,215,71,39,213,186,155,180,33,125,18,21,146,7,128,49,6,185,113,82,114,58,23,131,16,16,40,61,3,198,106,18,170,129,123,12,104,123,58,123,192,44,166,91,247,123,20,37,136,193,255,63,251,81,31,250,145,122,133,246,160,43,3,51,216,248,49,161,250,17,49,40,91,180,142,148,249,43,100,246,196,216,7,151,183,156,184,244,125,63,99,19,133,27,23,47,107,103,57,243,157,17,73,193,178,216,197,94,57,27,100,223,104,172,47,45,208,190,47,254,21,11,16,59,79,191,251,77,39,168,170,240,23,225,56,215,112,212,23,245,122,3,244,102,181,136,15,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("90958362-e618-422a-ad51-19a35fdf8930"));
		}

		#endregion

	}

	#endregion

}

