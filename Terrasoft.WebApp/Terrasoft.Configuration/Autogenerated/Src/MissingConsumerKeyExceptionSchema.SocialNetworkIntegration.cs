namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: MissingConsumerKeyExceptionSchema

	/// <exclude/>
	public class MissingConsumerKeyExceptionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MissingConsumerKeyExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MissingConsumerKeyExceptionSchema(MissingConsumerKeyExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("430df10a-1542-481b-a502-d52c3facc4ee");
			Name = "MissingConsumerKeyException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4e5fe717-963e-416c-b3c1-b2bb720a6449");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,141,61,10,195,48,12,133,103,27,124,7,65,247,28,32,29,67,167,210,41,189,128,234,42,65,224,63,44,27,26,74,238,94,187,89,58,117,120,131,30,159,222,23,208,147,36,180,4,119,202,25,37,46,101,152,98,88,120,173,25,11,199,48,204,209,50,58,163,223,70,171,42,28,86,152,55,41,228,207,70,183,230,148,105,109,20,76,14,69,70,184,177,116,164,45,72,245,148,175,180,93,94,150,82,31,250,226,169,62,28,91,176,157,254,7,195,8,63,143,170,187,85,203,126,56,41,60,15,109,63,247,15,43,154,227,107,195,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("430df10a-1542-481b-a502-d52c3facc4ee"));
		}

		#endregion

	}

	#endregion

}

