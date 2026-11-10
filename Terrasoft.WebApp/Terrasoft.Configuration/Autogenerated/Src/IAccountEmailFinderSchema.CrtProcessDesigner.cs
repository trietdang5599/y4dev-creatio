namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IAccountEmailFinderSchema

	/// <exclude/>
	public class IAccountEmailFinderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IAccountEmailFinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IAccountEmailFinderSchema(IAccountEmailFinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f9242ddc-61c5-433c-95a8-3bed1f530e1a");
			Name = "IAccountEmailFinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("832b05cc-1d40-42ab-9415-c96f927e05e6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,85,142,189,14,194,48,12,132,231,70,234,59,100,4,9,245,5,152,80,249,17,27,3,176,167,174,91,25,181,78,101,59,19,234,187,147,108,116,243,249,206,159,143,195,140,186,4,64,255,68,145,160,113,176,166,141,60,208,152,36,24,69,110,90,177,135,68,64,213,51,42,141,140,82,187,111,237,170,164,196,227,230,74,240,88,187,236,44,169,155,8,60,177,161,12,5,125,63,1,196,196,118,153,3,77,87,226,30,197,23,68,165,38,5,82,86,255,145,119,152,18,238,94,138,146,171,48,66,233,225,211,70,30,124,236,62,121,244,16,217,2,216,45,81,191,207,239,171,181,118,235,15,197,41,163,108,213,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f9242ddc-61c5-433c-95a8-3bed1f530e1a"));
		}

		#endregion

	}

	#endregion

}

