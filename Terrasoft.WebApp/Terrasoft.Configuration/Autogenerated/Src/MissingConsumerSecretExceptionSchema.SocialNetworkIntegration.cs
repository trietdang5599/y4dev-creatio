namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: MissingConsumerSecretExceptionSchema

	/// <exclude/>
	public class MissingConsumerSecretExceptionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MissingConsumerSecretExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MissingConsumerSecretExceptionSchema(MissingConsumerSecretExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0f8b9071-26fc-4a2e-b670-8e728d131210");
			Name = "MissingConsumerSecretException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4e5fe717-963e-416c-b3c1-b2bb720a6449");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,142,61,14,194,48,12,70,231,70,202,29,44,177,247,0,101,172,24,153,194,5,66,112,35,75,249,147,157,72,32,212,187,147,208,133,141,193,131,173,247,190,207,201,70,148,98,29,194,13,153,173,228,173,206,107,78,27,249,198,182,82,78,179,201,142,108,208,234,173,213,212,132,146,7,243,146,138,241,172,85,191,156,24,125,167,96,13,86,100,129,43,201,64,122,130,180,136,108,208,49,214,203,211,97,25,89,95,163,180,123,32,7,110,8,127,120,88,224,199,157,198,7,83,159,253,104,198,244,56,202,199,186,127,0,101,249,175,199,201,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0f8b9071-26fc-4a2e-b670-8e728d131210"));
		}

		#endregion

	}

	#endregion

}

