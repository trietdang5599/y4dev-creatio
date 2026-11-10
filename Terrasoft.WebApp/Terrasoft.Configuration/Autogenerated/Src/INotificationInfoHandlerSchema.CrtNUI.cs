namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: INotificationInfoHandlerSchema

	/// <exclude/>
	public class INotificationInfoHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationInfoHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationInfoHandlerSchema(INotificationInfoHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6fc817aa-1460-4964-9d28-c837ff664b7c");
			Name = "INotificationInfoHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,82,75,75,195,64,16,62,91,200,127,24,114,106,161,36,216,139,7,107,64,68,106,46,42,168,120,16,15,155,236,108,29,216,71,152,221,20,74,241,191,187,73,90,108,27,133,189,204,240,205,247,152,89,43,12,250,70,212,8,175,200,44,188,83,33,187,115,86,209,186,101,17,200,217,100,178,75,38,23,173,39,187,134,151,173,15,104,174,207,234,136,215,26,235,14,236,179,21,90,100,170,35,38,162,242,60,135,165,111,141,17,188,45,134,186,180,1,89,117,122,202,49,52,236,106,244,61,151,117,129,20,213,98,160,57,12,231,71,211,31,79,149,119,26,3,78,211,119,210,26,42,4,70,227,54,40,65,168,200,10,87,217,229,34,91,204,129,108,180,37,36,180,254,223,84,89,249,120,164,247,32,172,212,200,233,236,51,202,52,109,165,169,142,36,7,163,39,208,210,42,183,135,71,236,174,143,57,202,217,55,158,135,108,232,199,209,198,217,134,78,35,88,24,176,241,36,55,41,69,33,159,22,191,187,5,167,32,124,225,25,219,50,239,135,254,230,136,11,224,82,142,88,72,122,80,236,76,119,191,91,105,200,190,89,10,39,76,27,71,18,134,152,93,224,105,121,111,91,131,44,42,141,203,209,58,10,232,188,178,25,28,205,225,24,188,106,73,22,176,247,49,235,126,206,119,50,137,239,7,108,196,95,102,119,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6fc817aa-1460-4964-9d28-c837ff664b7c"));
		}

		#endregion

	}

	#endregion

}

