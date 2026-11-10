namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: INotificationStoreSchema

	/// <exclude/>
	public class INotificationStoreSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationStoreSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationStoreSchema(INotificationStoreSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5ee4e1be-170c-44d3-92be-47cd9f1c5368");
			Name = "INotificationStore";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,101,80,205,106,195,48,12,62,47,144,119,208,113,187,196,15,208,144,203,24,37,151,82,214,190,128,235,202,157,33,150,131,36,15,74,233,187,207,201,150,46,108,96,131,229,239,23,145,141,40,163,117,8,71,100,182,146,188,54,175,137,124,184,100,182,26,18,213,213,173,174,158,178,4,186,192,225,42,138,177,224,195,128,110,2,165,217,34,33,7,183,169,171,194,50,198,64,43,57,70,203,215,238,103,238,73,145,253,20,224,19,131,117,14,69,224,108,213,66,242,160,31,8,148,52,248,224,230,48,24,57,125,134,51,178,52,139,157,89,249,141,249,52,4,7,225,97,217,239,86,226,131,38,198,194,186,205,93,254,149,153,63,222,81,51,147,252,230,0,149,5,52,15,190,249,43,104,249,91,209,181,102,121,77,80,255,70,57,34,219,211,128,173,40,151,229,116,176,69,93,215,217,47,17,187,146,240,252,178,153,100,229,222,235,170,156,47,135,134,173,246,119,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5ee4e1be-170c-44d3-92be-47cd9f1c5368"));
		}

		#endregion

	}

	#endregion

}

