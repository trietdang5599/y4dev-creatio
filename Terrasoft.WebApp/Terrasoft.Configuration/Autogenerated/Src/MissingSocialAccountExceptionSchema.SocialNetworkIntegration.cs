namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: MissingSocialAccountExceptionSchema

	/// <exclude/>
	public class MissingSocialAccountExceptionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MissingSocialAccountExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MissingSocialAccountExceptionSchema(MissingSocialAccountExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4f684624-c132-4775-9271-2d2847917daa");
			Name = "MissingSocialAccountException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4e5fe717-963e-416c-b3c1-b2bb720a6449");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,141,49,10,195,48,12,0,103,27,252,7,65,247,60,32,157,74,232,216,41,253,128,171,42,65,224,216,198,178,33,165,228,239,181,235,165,83,7,13,18,119,58,111,55,146,104,145,224,78,41,89,9,75,30,166,224,23,94,75,178,153,131,31,230,128,108,157,209,111,163,85,17,246,43,204,47,201,180,157,141,174,151,83,162,181,82,48,57,43,50,194,141,165,33,221,185,32,134,226,243,117,71,138,237,213,87,136,229,225,24,1,27,255,31,135,17,126,84,213,250,170,206,209,187,228,159,61,221,214,227,3,72,110,115,14,199,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4f684624-c132-4775-9271-2d2847917daa"));
		}

		#endregion

	}

	#endregion

}

