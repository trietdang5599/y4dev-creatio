namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: FacebookCommandParameterSchema

	/// <exclude/>
	public class FacebookCommandParameterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FacebookCommandParameterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FacebookCommandParameterSchema(FacebookCommandParameterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("55eedac6-1832-49bb-ada6-3ce9df23cd0c");
			Name = "FacebookCommandParameter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a1c45040-f900-4d72-b99e-b97e9cbc42dd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,142,65,10,131,48,16,69,215,10,222,33,208,125,14,96,119,21,186,234,162,212,94,96,140,163,12,53,19,155,73,22,173,120,247,70,5,55,210,229,255,60,222,255,12,22,101,4,131,234,137,222,131,184,46,232,202,113,71,125,244,16,200,177,174,157,33,24,138,124,42,242,44,10,113,175,174,9,111,156,123,157,247,166,254,72,64,171,111,196,239,67,249,136,28,200,162,174,209,39,15,125,87,107,162,18,119,242,216,167,160,170,1,68,202,221,91,57,107,129,219,59,248,116,46,160,95,217,49,54,3,25,101,22,244,47,169,74,117,1,193,163,32,155,86,201,188,205,34,183,219,242,18,231,31,179,225,244,151,3,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("55eedac6-1832-49bb-ada6-3ce9df23cd0c"));
		}

		#endregion

	}

	#endregion

}

