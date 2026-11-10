namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: BaseCommandParameterSchema

	/// <exclude/>
	public class BaseCommandParameterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseCommandParameterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseCommandParameterSchema(BaseCommandParameterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a330adc7-9feb-43e7-b328-86d676594b41");
			Name = "BaseCommandParameter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a1c45040-f900-4d72-b99e-b97e9cbc42dd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,81,207,75,195,48,20,62,175,208,255,33,116,151,21,70,209,171,99,23,43,158,156,20,59,188,136,135,183,246,173,6,154,164,190,188,14,180,244,127,55,77,59,97,99,211,83,94,190,151,239,23,209,160,208,54,80,160,216,34,17,88,179,231,36,53,122,47,171,150,128,165,209,73,110,10,9,117,24,116,97,16,6,179,214,74,93,137,252,203,50,170,228,73,234,207,213,57,248,210,106,150,10,147,28,201,241,228,183,87,89,121,242,156,176,114,23,145,214,96,237,157,184,7,139,169,81,10,116,153,1,185,32,140,228,223,189,61,0,131,75,193,4,5,191,59,160,105,119,181,44,68,49,240,174,208,102,99,190,95,143,140,76,131,196,18,157,81,230,233,227,222,107,111,80,237,144,22,207,142,44,214,34,210,238,140,226,193,232,232,100,153,134,74,254,65,55,224,179,10,121,229,7,59,13,253,117,189,3,212,237,101,193,215,97,243,143,226,28,117,57,150,56,109,180,65,254,48,229,89,157,73,222,28,220,239,201,18,143,62,91,147,251,97,17,79,102,132,220,146,158,214,201,163,33,5,188,136,186,155,126,221,221,246,209,210,55,93,142,241,226,63,194,140,232,41,216,255,0,210,247,113,202,68,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a330adc7-9feb-43e7-b328-86d676594b41"));
		}

		#endregion

	}

	#endregion

}

