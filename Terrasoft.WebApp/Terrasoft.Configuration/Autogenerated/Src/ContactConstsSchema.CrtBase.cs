namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ContactConstsSchema

	/// <exclude/>
	public class ContactConstsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactConstsSchema(ContactConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("42db62ea-f92c-4df6-b6a2-c994e9708c0b");
			Name = "ContactConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,144,203,106,195,48,16,69,215,54,248,31,132,87,237,66,177,20,165,170,66,218,130,227,200,33,139,66,161,249,1,213,158,4,131,95,72,242,194,148,252,123,37,135,134,102,209,134,110,52,98,56,151,57,220,193,84,237,17,189,143,198,66,179,138,194,40,108,85,3,166,87,5,160,61,104,173,76,119,176,179,172,107,15,213,113,208,202,86,93,27,133,159,81,24,244,195,71,93,21,200,88,183,43,80,81,43,99,144,195,172,42,172,27,198,26,199,120,46,72,146,4,61,153,161,105,148,30,95,190,23,251,177,7,132,145,108,250,186,27,1,46,92,242,19,188,62,177,29,170,242,18,240,249,93,233,161,233,70,112,4,139,206,191,64,131,29,116,59,225,179,55,165,13,220,197,156,60,50,38,243,12,231,140,175,49,93,80,130,83,33,24,166,124,35,88,150,174,201,82,144,248,126,53,229,79,254,61,249,34,126,81,223,66,91,130,118,242,175,170,134,217,159,230,133,47,194,249,107,95,177,199,119,37,122,70,177,148,105,182,152,75,137,249,195,154,227,77,78,41,22,140,166,152,16,186,225,68,46,153,200,120,60,217,220,150,200,161,249,159,198,57,112,22,201,179,249,66,176,92,220,20,113,125,156,190,0,79,36,106,12,41,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("42db62ea-f92c-4df6-b6a2-c994e9708c0b"));
		}

		#endregion

	}

	#endregion

}

