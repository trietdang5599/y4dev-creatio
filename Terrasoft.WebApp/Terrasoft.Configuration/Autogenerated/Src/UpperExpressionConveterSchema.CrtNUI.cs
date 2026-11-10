namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: UpperExpressionConveterSchema

	/// <exclude/>
	public class UpperExpressionConveterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UpperExpressionConveterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UpperExpressionConveterSchema(UpperExpressionConveterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("27fcf242-4fd9-4cab-8a03-9f96704724a7");
			Name = "UpperExpressionConveter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,143,49,11,194,64,12,133,103,11,253,15,161,147,130,28,56,137,58,170,179,131,58,137,195,181,166,122,208,222,29,73,78,20,237,127,55,213,181,66,150,151,247,242,61,226,109,139,28,109,133,112,64,34,203,161,22,179,14,190,118,215,68,86,92,240,121,246,202,179,81,98,231,175,176,127,178,96,187,82,173,115,218,149,28,26,20,28,23,115,179,48,51,120,195,38,128,15,2,137,17,228,230,24,170,198,50,79,193,121,61,179,151,239,254,79,139,57,198,136,180,125,68,66,102,213,106,222,145,4,169,152,156,181,43,166,178,113,213,143,7,67,81,77,194,114,208,233,33,160,136,254,139,46,207,186,15,29,119,214,196,241,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("27fcf242-4fd9-4cab-8a03-9f96704724a7"));
		}

		#endregion

	}

	#endregion

}

