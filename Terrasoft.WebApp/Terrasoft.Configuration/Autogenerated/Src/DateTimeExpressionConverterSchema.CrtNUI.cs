namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DateTimeExpressionConverterSchema

	/// <exclude/>
	public class DateTimeExpressionConverterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DateTimeExpressionConverterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DateTimeExpressionConverterSchema(DateTimeExpressionConverterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3950f08c-8bf5-45b1-a16f-7b3f28203807");
			Name = "DateTimeExpressionConverter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e35bf724-6dee-44c8-b23b-34796602023a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,82,75,75,195,64,16,62,183,208,255,48,198,75,2,146,220,107,45,136,86,240,80,45,216,155,120,216,38,211,24,201,238,134,217,221,98,40,253,239,238,35,73,107,45,150,80,216,249,30,243,205,236,10,198,81,53,44,71,88,35,17,83,114,171,211,7,41,182,85,105,136,233,74,138,201,120,63,25,143,140,170,68,9,111,173,210,200,111,135,243,169,132,115,41,28,98,191,107,194,210,42,225,161,102,74,77,225,145,105,92,87,28,23,223,13,161,82,22,177,13,118,72,26,105,50,182,244,44,203,96,166,12,231,140,218,121,119,118,26,208,86,4,56,168,32,239,101,144,59,231,180,215,102,39,226,247,11,93,238,181,166,106,99,52,198,145,243,141,146,15,75,108,204,166,174,242,224,244,95,68,152,194,243,165,178,181,216,251,248,195,184,75,212,159,178,176,3,175,188,117,0,207,135,243,133,206,69,65,49,140,185,99,181,193,116,80,100,231,146,89,195,136,113,16,246,186,238,34,79,142,230,143,103,234,89,230,73,151,53,140,74,195,81,104,21,205,225,190,40,42,119,183,172,134,161,252,87,77,168,13,9,53,239,103,46,78,226,42,187,81,81,90,77,79,114,170,110,165,1,131,133,11,101,5,177,220,124,97,174,67,198,155,30,29,250,194,29,68,81,2,238,145,141,70,29,232,250,60,73,226,76,59,180,40,210,229,50,109,237,47,186,245,172,106,11,241,213,49,248,179,122,49,117,253,74,11,222,232,54,78,122,175,209,47,151,129,30,44,14,254,191,191,118,223,240,232,221,151,211,53,181,43,70,10,227,56,4,75,186,25,164,209,94,114,236,21,214,224,139,233,90,190,121,118,124,12,144,156,118,237,184,221,10,125,106,15,31,186,231,132,162,8,47,202,159,67,245,119,241,240,3,241,221,61,20,182,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3950f08c-8bf5-45b1-a16f-7b3f28203807"));
		}

		#endregion

	}

	#endregion

}

