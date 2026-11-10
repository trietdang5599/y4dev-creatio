namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IESMentionQueryBuilderSchema

	/// <exclude/>
	public class IESMentionQueryBuilderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IESMentionQueryBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IESMentionQueryBuilderSchema(IESMentionQueryBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8a92e121-7675-4439-bb61-e6af58efe391");
			Name = "IESMentionQueryBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f0db0304-dc6c-40c0-a3bb-97ab97632500");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,146,203,110,131,48,16,69,215,141,148,127,24,209,77,187,177,247,121,176,104,133,170,44,34,181,77,127,96,128,129,88,2,147,142,237,69,20,229,223,107,108,146,66,148,118,233,203,61,115,231,129,198,150,204,1,11,130,47,98,70,211,85,86,188,118,186,82,181,99,180,170,211,226,173,233,114,108,118,132,92,236,231,179,211,124,246,224,140,210,245,196,207,36,50,109,149,85,100,150,119,12,227,18,98,163,45,113,229,19,123,171,55,63,50,213,62,7,174,250,2,54,217,110,75,186,79,255,112,196,199,23,167,154,146,56,184,165,148,176,50,174,109,145,143,233,240,206,26,52,86,21,96,66,0,180,17,133,239,158,133,60,194,226,194,202,17,124,112,121,227,57,117,73,254,35,24,78,33,250,218,233,150,236,190,43,205,2,222,3,31,63,222,54,22,132,80,192,203,68,80,48,85,235,100,92,61,145,41,84,29,15,109,247,27,43,209,162,241,237,0,77,38,18,215,250,242,54,96,117,64,198,22,180,191,226,58,9,3,39,233,63,113,74,27,139,186,32,177,146,1,252,173,195,100,29,107,51,134,135,181,222,131,47,238,30,143,103,253,36,159,110,108,156,56,32,79,227,240,120,140,231,229,176,72,210,101,220,101,255,246,202,57,254,9,19,249,252,3,90,228,185,65,155,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8a92e121-7675-4439-bb61-e6af58efe391"));
		}

		#endregion

	}

	#endregion

}

