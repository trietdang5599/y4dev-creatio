namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: INotificationMarkAsReadStrategyFactorySchema

	/// <exclude/>
	public class INotificationMarkAsReadStrategyFactorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationMarkAsReadStrategyFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationMarkAsReadStrategyFactorySchema(INotificationMarkAsReadStrategyFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f3b5563c-e3e1-4096-aa54-ee41d3b117e2");
			Name = "INotificationMarkAsReadStrategyFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("cb307258-3a76-44c9-ba03-f25bdd404252");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,191,110,194,48,16,198,231,68,202,59,156,210,165,29,136,247,54,68,66,149,138,24,218,161,240,2,110,114,73,45,240,159,158,237,33,170,120,247,218,129,208,0,3,100,138,237,251,126,223,249,243,41,46,209,26,94,35,108,144,136,91,221,186,226,85,171,86,116,158,184,19,90,21,31,218,137,86,212,195,194,102,233,111,150,38,222,10,213,193,186,183,14,229,75,150,102,41,132,239,129,176,11,37,176,82,14,169,13,196,103,88,77,181,239,156,182,11,251,137,188,89,187,128,198,174,127,227,181,211,212,71,64,194,24,131,210,122,41,57,245,213,113,125,60,135,86,19,212,132,129,18,92,213,4,9,161,122,59,227,118,22,14,27,176,71,44,8,105,118,40,81,185,67,207,197,136,103,19,190,241,95,59,81,131,24,155,189,187,215,36,6,112,213,238,176,177,68,103,193,125,35,112,99,72,27,18,65,121,79,191,241,126,81,102,13,214,161,22,155,115,145,235,13,22,39,83,118,233,90,26,78,92,130,10,15,57,207,167,194,77,208,173,154,188,218,4,180,87,226,199,35,136,38,164,18,45,8,116,59,120,94,59,149,108,0,254,243,9,157,39,101,171,133,186,72,54,50,74,139,24,31,167,157,231,55,18,204,89,117,215,77,75,54,26,198,14,110,64,99,230,227,255,227,210,139,115,224,33,129,167,48,162,201,254,52,166,168,154,195,164,102,233,254,15,216,148,255,141,254,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f3b5563c-e3e1-4096-aa54-ee41d3b117e2"));
		}

		#endregion

	}

	#endregion

}

