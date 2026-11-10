namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: BasePermissionSchema

	/// <exclude/>
	public class BasePermissionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BasePermissionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BasePermissionSchema(BasePermissionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("61e6f54e-7847-49e3-aff5-86a7ed440807");
			Name = "BasePermission";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a1c45040-f900-4d72-b99e-b97e9cbc42dd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,144,193,78,195,48,12,134,207,173,212,119,176,196,21,85,236,186,138,11,27,218,5,77,21,229,5,66,230,85,150,82,183,216,201,1,166,190,59,73,139,128,117,189,36,178,253,217,191,253,179,233,80,7,99,17,222,80,196,104,127,246,229,174,231,51,181,65,140,167,158,203,166,183,100,92,145,95,138,188,200,179,160,196,45,52,159,234,177,139,160,115,104,19,165,229,1,25,133,108,181,100,94,136,63,110,146,175,129,61,117,88,54,177,197,56,250,154,148,170,73,224,78,176,141,1,60,115,232,182,80,163,116,164,26,19,141,55,62,232,132,12,225,221,145,5,140,196,10,144,197,69,179,108,143,214,17,227,9,30,225,225,62,37,14,98,216,79,241,38,134,227,172,133,124,154,229,174,164,119,206,168,110,225,201,40,254,141,255,175,108,19,112,83,207,102,135,126,199,212,210,15,40,158,48,206,170,167,198,185,174,94,146,21,199,232,60,92,160,69,95,129,166,103,188,42,239,81,173,208,144,140,89,163,150,119,195,207,183,130,46,174,92,59,125,252,6,108,219,28,20,7,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("61e6f54e-7847-49e3-aff5-86a7ed440807"));
		}

		#endregion

	}

	#endregion

}

