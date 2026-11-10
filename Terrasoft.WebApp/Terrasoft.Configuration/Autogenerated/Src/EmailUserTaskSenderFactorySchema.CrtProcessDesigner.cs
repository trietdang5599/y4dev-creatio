namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EmailUserTaskSenderFactorySchema

	/// <exclude/>
	public class EmailUserTaskSenderFactorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailUserTaskSenderFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailUserTaskSenderFactorySchema(EmailUserTaskSenderFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("638e470d-51ca-4d2c-ac7f-a8a2d6682831");
			Name = "EmailUserTaskSenderFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("da7de29a-d2b3-4248-bf8e-b7a592dc81f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,81,203,106,195,48,16,60,43,144,127,88,232,197,185,248,3,18,122,40,233,131,28,82,2,73,63,64,149,55,142,168,45,25,237,138,52,132,252,123,245,176,67,12,105,111,189,8,237,204,206,236,176,107,100,139,212,73,133,176,67,231,36,217,61,151,75,235,176,220,56,171,144,40,20,102,175,107,239,36,107,107,166,147,243,116,34,60,105,83,195,246,68,140,237,226,90,223,234,111,36,131,209,51,146,174,13,186,32,8,146,7,135,117,32,97,217,72,162,57,188,180,82,55,31,132,110,39,233,107,139,166,66,247,42,21,91,119,74,221,157,255,108,180,2,226,224,168,64,69,205,159,18,113,78,178,235,148,53,242,193,86,97,206,38,25,101,114,108,186,186,227,7,111,200,9,206,101,145,254,59,108,187,70,50,14,173,224,251,207,12,226,110,132,160,163,102,117,128,162,136,170,44,57,117,56,27,218,202,49,220,139,132,146,132,48,162,202,39,207,118,158,89,225,144,189,51,96,240,8,17,190,23,182,55,18,34,226,225,4,6,85,220,63,60,94,19,150,99,166,239,191,44,126,77,176,150,198,203,230,78,134,76,252,71,138,10,247,210,55,60,204,228,131,179,199,52,242,221,242,42,108,30,91,52,140,213,203,183,194,46,202,139,89,22,94,226,123,233,207,30,162,228,203,167,58,163,99,48,96,63,174,208,12,66,250,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("638e470d-51ca-4d2c-ac7f-a8a2d6682831"));
		}

		#endregion

	}

	#endregion

}

