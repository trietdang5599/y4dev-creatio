namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: MissingConsumerInfoServiceUriExceptionSchema

	/// <exclude/>
	public class MissingConsumerInfoServiceUriExceptionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MissingConsumerInfoServiceUriExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MissingConsumerInfoServiceUriExceptionSchema(MissingConsumerInfoServiceUriExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5e6523ca-dcf1-4c7d-a366-78c39999c290");
			Name = "MissingConsumerInfoServiceUriException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4e5fe717-963e-416c-b3c1-b2bb720a6449");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,142,61,14,194,48,12,133,231,86,202,29,44,177,247,0,101,172,24,24,152,2,7,8,193,141,44,229,79,118,83,129,80,239,78,66,23,70,6,15,207,122,223,167,23,77,64,201,198,34,92,145,217,72,154,151,97,74,113,38,87,216,44,148,226,160,147,37,227,85,255,86,125,87,132,162,3,253,146,5,195,81,245,245,115,96,116,181,5,147,55,34,35,92,72,90,165,26,164,4,228,115,156,147,70,94,201,226,141,233,244,180,152,155,243,75,230,114,247,100,193,54,240,79,14,70,248,113,116,109,81,87,111,219,151,96,124,236,99,90,220,62,150,148,178,253,217,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5e6523ca-dcf1-4c7d-a366-78c39999c290"));
		}

		#endregion

	}

	#endregion

}

