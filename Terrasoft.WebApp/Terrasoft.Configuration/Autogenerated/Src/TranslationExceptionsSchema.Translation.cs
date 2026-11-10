namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: TranslationExceptionsSchema

	/// <exclude/>
	public class TranslationExceptionsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TranslationExceptionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TranslationExceptionsSchema(TranslationExceptionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dd34e1f4-8c12-45a5-b98a-235cdfe34c22");
			Name = "TranslationExceptions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,80,61,79,195,64,12,157,19,41,255,193,18,75,89,146,189,32,150,138,141,1,137,168,204,206,225,36,39,93,124,145,125,71,91,42,254,59,151,143,66,89,96,186,243,179,253,222,243,99,28,72,71,52,4,53,137,160,250,54,148,59,207,173,237,162,96,176,158,203,90,144,213,205,255,34,63,23,121,22,213,114,7,47,39,13,52,220,21,121,66,110,132,186,212,134,157,67,213,45,188,138,13,244,228,13,58,251,129,141,163,61,186,72,143,71,67,227,66,146,54,170,170,130,123,141,195,128,114,122,88,235,186,39,160,203,20,132,30,3,88,77,175,248,3,195,161,39,6,197,119,2,63,210,226,108,234,178,15,160,209,24,82,109,163,43,47,204,213,21,245,24,27,103,13,152,201,219,63,214,96,11,87,54,179,243,108,245,231,58,207,26,36,154,224,37,29,249,60,211,46,19,171,196,223,228,155,180,60,5,151,242,86,236,232,54,137,53,168,180,249,174,167,108,179,207,85,147,248,109,145,157,235,5,253,13,38,236,11,123,17,51,162,189,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dd34e1f4-8c12-45a5-b98a-235cdfe34c22"));
		}

		#endregion

	}

	#endregion

}

