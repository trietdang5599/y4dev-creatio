namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EmailTemplateUserTaskMLangBinderSchema

	/// <exclude/>
	public class EmailTemplateUserTaskMLangBinderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailTemplateUserTaskMLangBinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailTemplateUserTaskMLangBinderSchema(EmailTemplateUserTaskMLangBinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0b12cd08-0384-44fd-b87b-86ac638b898a");
			Name = "EmailTemplateUserTaskMLangBinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6b752d82-945c-4729-b067-d3f384b1bc2d");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,145,209,107,194,48,16,198,159,21,252,31,14,247,226,96,180,239,42,194,20,7,130,178,193,28,123,190,182,103,23,214,36,37,185,200,68,252,223,119,166,237,208,209,167,144,220,119,191,187,239,139,65,77,190,198,156,96,79,206,161,183,7,78,86,214,28,84,25,28,178,178,102,52,60,143,134,131,224,149,41,239,36,142,146,23,204,217,58,69,126,214,163,248,164,76,84,90,91,35,85,169,63,56,42,5,7,171,10,189,159,194,90,163,170,62,60,185,61,250,239,221,22,77,185,84,166,32,23,181,105,154,194,220,7,173,209,157,22,237,61,54,0,147,174,43,100,130,32,173,192,210,11,58,84,172,42,1,4,44,9,242,43,30,178,200,74,58,84,122,195,170,67,86,169,188,213,69,232,190,101,246,108,51,133,231,186,94,31,201,240,86,121,38,67,110,137,158,132,114,142,123,254,153,218,17,127,217,66,108,189,69,122,83,108,39,217,163,100,162,10,130,163,85,5,188,26,33,190,51,58,158,116,104,137,155,233,135,33,111,206,71,184,6,62,24,100,50,41,185,145,119,229,89,172,198,24,155,15,56,37,215,101,231,155,109,155,193,134,73,190,206,186,167,126,123,255,101,139,201,184,87,55,110,38,93,90,167,100,138,198,108,188,55,175,247,143,151,95,51,32,109,228,76,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0b12cd08-0384-44fd-b87b-86ac638b898a"));
		}

		#endregion

	}

	#endregion

}

