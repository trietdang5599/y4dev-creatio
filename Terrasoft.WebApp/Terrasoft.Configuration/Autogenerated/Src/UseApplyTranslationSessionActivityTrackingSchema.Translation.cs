namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: UseApplyTranslationSessionActivityTrackingSchema

	/// <exclude/>
	public class UseApplyTranslationSessionActivityTrackingSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UseApplyTranslationSessionActivityTrackingSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UseApplyTranslationSessionActivityTrackingSchema(UseApplyTranslationSessionActivityTrackingSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4b55a2f8-94a9-4067-ba4e-ae0aa59ceb7b");
			Name = "UseApplyTranslationSessionActivityTracking";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,80,65,78,3,49,12,60,239,74,253,131,85,46,112,217,7,180,226,80,45,69,226,128,132,196,242,0,55,235,141,162,6,39,178,179,32,84,241,119,146,108,43,224,216,147,157,241,120,102,28,0,198,119,210,136,134,96,32,17,212,48,165,174,15,60,57,59,11,38,23,184,27,4,89,125,237,87,237,105,213,54,179,58,182,208,11,21,172,123,204,101,22,26,130,181,62,227,219,85,155,41,55,66,54,243,161,247,168,186,129,55,165,93,140,254,235,143,212,43,169,230,178,51,201,125,184,84,38,230,152,215,235,182,227,68,194,232,193,148,245,43,182,97,3,231,56,207,148,112,196,132,89,237,84,53,127,35,5,214,36,179,73,65,114,178,151,249,224,157,89,24,177,246,87,216,221,222,65,249,143,166,121,210,61,227,193,211,8,247,48,161,87,218,86,248,129,212,136,139,69,33,15,214,11,71,33,93,210,186,9,176,56,21,228,98,5,81,130,201,118,224,20,62,131,28,157,97,219,173,171,222,247,249,16,226,113,185,165,190,23,244,63,152,177,31,210,119,33,219,218,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4b55a2f8-94a9-4067-ba4e-ae0aa59ceb7b"));
		}

		#endregion

	}

	#endregion

}

