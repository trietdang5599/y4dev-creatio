namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: INotificationSenderSchema

	/// <exclude/>
	public class INotificationSenderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationSenderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationSenderSchema(INotificationSenderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d0434505-a3a8-488e-a33b-2a071c2954f0");
			Name = "INotificationSender";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,101,144,65,106,195,48,16,69,215,49,248,14,34,171,118,99,29,160,174,55,165,4,111,74,33,185,128,34,143,147,1,107,100,102,164,64,40,185,123,37,145,150,168,93,74,243,223,155,207,144,113,32,171,177,160,14,192,108,196,207,161,123,243,52,227,41,178,9,232,169,109,190,218,102,19,5,233,164,246,87,9,224,210,124,89,192,230,161,116,59,32,96,180,47,109,147,82,90,107,213,75,116,206,240,117,184,191,63,217,95,112,2,81,2,52,101,9,249,128,51,218,34,23,229,32,156,253,36,221,15,173,31,240,53,30,23,180,10,41,0,207,185,226,248,241,192,238,147,15,56,197,114,191,127,171,203,71,142,72,189,176,251,13,235,191,233,126,53,108,156,162,116,145,215,109,5,109,135,195,25,42,79,42,53,123,118,119,103,175,11,90,76,23,143,83,89,252,52,190,83,116,192,230,184,64,95,53,31,19,59,212,181,158,211,1,55,183,182,185,125,3,231,226,60,180,144,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d0434505-a3a8-488e-a33b-2a071c2954f0"));
		}

		#endregion

	}

	#endregion

}

