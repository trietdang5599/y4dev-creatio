namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: INotificationHandlerSchema

	/// <exclude/>
	public class INotificationHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationHandlerSchema(INotificationHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f9c66d6e-bd4a-4fc2-8d6b-edbb5e21ba56");
			Name = "INotificationHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,101,144,77,78,195,48,16,133,215,141,148,59,88,93,193,166,62,0,33,27,132,74,54,8,169,189,192,212,29,23,75,246,76,52,182,145,170,170,119,199,73,10,52,100,57,63,239,123,111,134,32,96,236,193,160,218,163,8,68,182,105,243,194,100,221,41,11,36,199,84,87,151,186,90,229,232,232,164,118,231,152,48,148,185,247,104,134,97,220,108,145,80,156,121,170,171,178,165,181,86,77,204,33,128,156,219,91,221,81,66,177,131,129,101,81,189,176,193,56,194,136,147,179,206,192,196,249,81,235,59,121,159,15,222,25,229,126,9,221,251,157,230,13,232,232,81,202,222,16,112,225,61,54,62,38,59,140,75,183,165,221,212,233,65,32,40,42,111,121,94,207,68,235,246,239,110,197,86,165,79,252,71,109,244,40,30,89,95,236,142,106,138,248,208,189,82,14,40,112,240,216,204,78,232,200,114,59,135,60,150,79,174,174,117,117,253,6,212,221,233,35,153,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f9c66d6e-bd4a-4fc2-8d6b-edbb5e21ba56"));
		}

		#endregion

	}

	#endregion

}

