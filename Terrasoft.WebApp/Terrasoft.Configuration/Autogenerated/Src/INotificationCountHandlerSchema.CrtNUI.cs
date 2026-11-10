namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: INotificationCountHandlerSchema

	/// <exclude/>
	public class INotificationCountHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationCountHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationCountHandlerSchema(INotificationCountHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e44863be-4aaa-47e8-b8fa-552d50bcc3f3");
			Name = "INotificationCountHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,82,77,79,195,48,12,61,111,210,254,131,53,46,32,77,237,29,74,47,67,26,189,76,136,143,31,16,82,183,139,104,147,202,113,134,38,180,255,142,147,178,1,27,28,122,176,243,222,243,243,171,173,234,209,15,74,35,60,35,145,242,174,225,108,233,108,99,218,64,138,141,179,179,233,199,108,58,9,222,216,22,158,118,158,177,191,57,169,5,223,117,168,35,216,103,43,180,72,70,11,70,80,23,132,173,116,161,178,140,212,200,144,107,168,214,142,77,99,116,210,94,186,96,249,94,217,186,67,130,196,200,243,28,10,31,250,94,209,174,252,170,31,200,109,77,141,30,122,228,141,171,129,29,16,50,25,220,34,240,6,65,71,21,36,159,29,248,249,15,129,33,188,118,70,131,57,56,248,223,128,128,227,166,147,248,157,218,72,141,71,228,64,214,255,154,9,141,35,80,16,60,82,6,71,102,126,74,45,6,69,170,7,43,97,223,206,181,179,172,52,87,245,188,124,17,30,200,110,54,90,18,137,34,79,192,191,121,45,185,48,204,203,181,20,224,154,100,35,181,206,89,52,58,45,239,76,250,43,226,100,1,239,27,36,132,55,220,129,241,35,47,138,164,61,64,2,128,173,234,2,198,183,212,18,205,131,72,84,173,190,149,10,47,209,219,118,17,35,45,97,133,124,150,167,196,114,185,10,166,134,227,162,11,24,73,227,220,171,120,64,251,241,64,208,214,227,141,204,166,251,79,78,140,149,60,139,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e44863be-4aaa-47e8-b8fa-552d50bcc3f3"));
		}

		#endregion

	}

	#endregion

}

