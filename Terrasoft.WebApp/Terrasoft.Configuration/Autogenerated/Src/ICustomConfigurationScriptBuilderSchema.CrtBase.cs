namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ICustomConfigurationScriptBuilderSchema

	/// <exclude/>
	public class ICustomConfigurationScriptBuilderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICustomConfigurationScriptBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICustomConfigurationScriptBuilderSchema(ICustomConfigurationScriptBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e9b66793-dace-4458-a258-e4f09a3b7b8b");
			Name = "ICustomConfigurationScriptBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,142,61,14,194,48,12,133,231,68,202,29,34,117,129,133,3,192,70,167,206,192,1,66,234,86,150,90,39,114,146,9,245,238,228,71,12,217,144,188,60,251,189,231,143,204,14,193,27,11,250,9,204,38,184,37,94,70,71,11,174,137,77,68,71,90,201,143,146,34,5,164,181,243,48,220,148,204,151,129,97,45,190,137,34,240,146,155,174,122,26,83,136,110,239,122,30,150,209,199,123,194,109,6,206,177,60,62,189,55,180,26,127,193,191,114,5,70,132,200,5,167,110,155,225,244,10,192,57,72,96,43,117,234,228,57,163,138,163,125,29,128,230,134,92,245,241,5,87,15,90,94,2,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e9b66793-dace-4458-a258-e4f09a3b7b8b"));
		}

		#endregion

	}

	#endregion

}

