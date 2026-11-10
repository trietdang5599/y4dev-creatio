namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: INotificationInfoExecutorSchema

	/// <exclude/>
	public class INotificationInfoExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationInfoExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationInfoExecutorSchema(INotificationInfoExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("70829de2-1828-4038-881b-1a16b2b88f30");
			Name = "INotificationInfoExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,145,177,78,195,48,16,134,231,88,242,59,156,186,180,93,28,193,0,3,85,151,138,33,12,141,4,108,136,193,73,207,149,37,199,87,249,108,160,42,188,59,78,66,33,82,133,100,201,190,243,125,119,255,111,39,182,126,15,79,71,142,216,221,73,33,133,215,29,242,65,183,8,207,24,130,102,50,81,109,200,27,187,79,65,71,75,94,138,147,20,69,89,150,176,226,212,117,58,28,215,63,113,229,35,6,211,163,134,2,120,138,214,216,118,96,0,63,176,77,253,73,157,217,114,2,191,212,13,147,195,136,139,217,173,186,186,81,215,240,57,105,246,110,157,131,6,33,96,71,111,184,3,109,242,13,236,176,7,192,160,142,41,32,204,183,147,113,92,251,218,227,198,105,230,7,106,230,106,182,124,205,83,14,169,113,182,5,251,219,184,154,50,149,55,116,63,168,164,144,139,79,253,91,20,23,54,135,196,246,95,103,151,214,198,76,192,44,210,243,250,113,220,255,32,224,168,35,170,85,121,174,232,145,134,200,193,168,5,23,203,252,43,197,151,20,121,125,3,55,157,35,56,172,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("70829de2-1828-4038-881b-1a16b2b88f30"));
		}

		#endregion

	}

	#endregion

}

