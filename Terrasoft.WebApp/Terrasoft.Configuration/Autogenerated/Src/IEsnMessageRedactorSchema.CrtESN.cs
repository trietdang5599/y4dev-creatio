namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IEsnMessageRedactorSchema

	/// <exclude/>
	public class IEsnMessageRedactorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IEsnMessageRedactorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IEsnMessageRedactorSchema(IEsnMessageRedactorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("95f9fa02-7c86-4d9f-a8c2-7614daa3758a");
			Name = "IEsnMessageRedactor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b66b5ae8-46e0-4931-ad78-c2c1ba5fd6ea");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,213,86,193,110,226,48,16,61,131,196,63,140,232,161,93,169,74,238,45,229,2,168,226,208,237,170,84,234,217,196,19,98,109,108,35,143,179,8,85,253,247,53,142,19,66,161,173,82,64,218,61,58,30,191,121,239,101,158,101,197,36,210,146,37,8,207,104,12,35,157,218,104,164,85,42,22,133,97,86,104,21,77,102,63,123,221,215,94,183,83,144,80,11,152,173,201,162,188,173,215,35,109,48,154,40,43,172,64,114,159,221,198,133,193,133,59,9,48,85,22,77,234,192,111,96,58,33,245,128,68,108,129,79,200,89,98,181,241,181,113,28,195,128,10,41,153,89,15,195,250,151,209,127,4,71,2,137,54,211,156,32,213,6,72,39,130,229,160,208,174,180,249,13,198,131,108,8,200,18,149,162,10,45,110,192,45,139,121,46,18,16,21,145,195,60,58,27,121,123,84,74,46,154,44,224,70,222,250,146,170,94,81,93,30,191,175,31,44,153,97,18,148,179,245,174,31,202,199,204,178,254,48,116,5,238,86,209,32,246,117,245,177,149,176,25,216,12,33,195,124,9,58,117,68,16,33,49,152,222,245,29,227,23,35,44,6,128,241,243,99,63,30,122,10,247,133,224,158,97,216,186,218,47,133,6,135,31,229,239,249,68,104,40,118,74,19,45,165,147,221,82,233,148,111,117,78,249,158,202,157,35,161,67,105,206,168,92,156,197,156,128,125,229,63,212,68,175,225,128,89,13,78,159,154,53,225,226,232,169,216,58,181,202,52,193,28,1,29,42,126,225,218,206,72,205,172,105,36,160,157,111,158,124,229,213,92,235,220,139,170,7,201,111,87,200,215,64,59,157,254,23,127,154,145,251,122,104,206,104,223,17,185,244,86,126,59,151,161,124,27,176,54,94,238,36,52,204,90,213,255,253,193,239,184,85,5,51,184,21,160,235,97,107,21,198,127,192,161,230,29,214,126,218,78,105,224,17,55,219,24,115,180,120,250,236,114,143,187,111,103,91,217,37,191,195,57,59,167,176,15,199,228,180,194,14,255,209,141,176,206,91,249,182,66,197,203,231,85,175,251,246,23,143,8,229,160,189,9,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("95f9fa02-7c86-4d9f-a8c2-7614daa3758a"));
		}

		#endregion

	}

	#endregion

}

