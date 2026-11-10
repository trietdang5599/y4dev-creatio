namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: GoogleSynchronizationDataAccessExceptionSchema

	/// <exclude/>
	public class GoogleSynchronizationDataAccessExceptionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GoogleSynchronizationDataAccessExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GoogleSynchronizationDataAccessExceptionSchema(GoogleSynchronizationDataAccessExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fa6fe31b-4855-4a7a-adcc-c5b7fb65f30f");
			Name = "GoogleSynchronizationDataAccessException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,146,65,75,195,64,16,133,207,9,228,63,12,237,37,129,146,220,163,22,164,138,87,161,254,129,233,118,18,23,146,221,101,54,65,99,241,191,187,201,54,77,90,60,84,212,227,62,230,189,249,30,179,10,107,178,6,5,193,11,49,163,213,69,147,110,180,42,100,217,50,54,82,171,40,60,68,97,20,6,173,149,170,132,109,103,27,170,111,6,101,201,84,186,1,216,84,104,109,14,79,90,151,21,109,59,37,94,89,43,249,49,184,31,176,193,123,33,200,218,199,119,65,198,7,58,111,150,101,112,107,219,186,70,238,214,199,183,15,0,52,18,246,206,6,56,248,128,70,35,188,49,26,67,156,142,254,108,22,96,218,93,37,5,136,158,229,106,20,200,97,134,21,248,162,83,47,173,108,195,173,104,52,187,122,207,195,2,63,113,73,127,20,136,64,48,21,119,139,83,104,156,44,178,117,122,154,152,3,143,196,215,178,198,9,28,122,219,231,79,17,92,7,119,185,63,4,241,129,224,254,141,197,146,146,62,34,200,97,135,150,226,81,251,21,234,106,58,202,191,81,207,118,128,84,138,120,90,249,77,159,213,229,204,89,191,37,169,189,255,50,195,219,171,231,162,211,190,0,0,35,219,129,105,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fa6fe31b-4855-4a7a-adcc-c5b7fb65f30f"));
		}

		#endregion

	}

	#endregion

}

