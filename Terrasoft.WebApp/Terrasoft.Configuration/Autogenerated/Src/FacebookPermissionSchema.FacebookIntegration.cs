namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: FacebookPermissionSchema

	/// <exclude/>
	public class FacebookPermissionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FacebookPermissionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FacebookPermissionSchema(FacebookPermissionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e9463608-7170-4f90-8842-6c14ece0a0d4");
			Name = "FacebookPermission";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a1c45040-f900-4d72-b99e-b97e9cbc42dd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,144,65,110,194,64,12,69,215,137,148,59,88,98,211,74,85,14,0,98,83,42,150,40,18,189,192,48,152,96,17,102,34,219,89,33,238,94,51,73,155,32,210,205,140,244,253,253,253,236,224,174,40,173,243,8,223,200,236,36,158,180,220,196,112,162,186,99,167,20,67,185,143,158,92,83,228,183,34,47,242,108,193,88,155,10,155,198,137,44,97,107,157,135,24,47,21,242,149,68,172,146,92,109,119,104,200,131,127,152,102,60,176,132,79,39,56,17,250,240,191,244,138,99,139,172,132,54,162,74,89,125,125,200,21,101,10,53,236,140,29,110,53,234,10,196,158,251,156,231,11,197,51,181,154,134,252,99,29,57,246,234,180,19,24,190,23,255,2,195,177,39,124,198,181,131,217,184,206,107,228,121,224,215,19,188,13,124,193,118,248,248,133,61,142,176,239,143,147,100,89,166,103,146,50,45,186,78,222,213,168,78,87,91,79,123,147,103,30,185,87,159,197,251,15,218,221,222,146,4,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e9463608-7170-4f90-8842-6c14ece0a0d4"));
		}

		#endregion

	}

	#endregion

}

