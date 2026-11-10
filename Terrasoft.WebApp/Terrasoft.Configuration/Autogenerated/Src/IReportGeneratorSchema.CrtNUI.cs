namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IReportGeneratorSchema

	/// <exclude/>
	public class IReportGeneratorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IReportGeneratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IReportGeneratorSchema(IReportGeneratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1f7efd48-adaa-42e5-b285-f3efa252f7e7");
			Name = "IReportGenerator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,82,65,106,195,48,16,60,39,144,63,44,238,165,133,98,221,19,215,151,22,74,14,133,144,54,15,80,229,181,35,136,37,179,146,2,33,244,239,149,37,91,196,110,122,18,59,154,217,157,29,73,241,22,77,199,5,194,23,18,113,163,107,155,191,106,85,203,198,17,183,82,171,213,242,186,90,46,156,145,170,249,143,146,239,177,211,100,63,145,206,82,224,230,46,157,122,220,223,60,16,54,94,2,91,101,145,106,63,119,13,219,40,127,71,133,190,159,166,192,99,140,65,97,92,219,114,186,148,67,189,35,125,150,21,26,160,32,128,38,42,250,81,181,83,162,183,194,79,210,94,242,81,207,110,26,116,238,251,36,5,200,113,238,157,177,139,107,24,157,60,126,160,61,234,202,172,97,23,180,241,114,110,44,0,67,147,100,45,79,76,54,167,22,29,39,222,130,242,185,191,100,206,32,249,40,21,6,243,89,121,240,53,136,4,228,5,11,236,251,98,113,251,6,89,153,210,153,224,80,107,154,229,165,233,111,95,66,235,72,153,114,31,79,232,188,132,19,86,227,62,5,27,25,189,36,38,247,198,45,79,155,63,30,38,171,192,116,179,103,152,133,61,249,63,83,199,79,155,225,21,80,85,241,33,66,253,19,191,207,4,244,216,47,236,248,221,151,192,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1f7efd48-adaa-42e5-b285-f3efa252f7e7"));
		}

		#endregion

	}

	#endregion

}

