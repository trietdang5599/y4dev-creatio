namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: AppSectionCreationPackageDependencyExceptionSchema

	/// <exclude/>
	public class AppSectionCreationPackageDependencyExceptionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AppSectionCreationPackageDependencyExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AppSectionCreationPackageDependencyExceptionSchema(AppSectionCreationPackageDependencyExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("11a7b02d-3f17-45e0-a8d6-807497e95249");
			Name = "AppSectionCreationPackageDependencyException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,144,177,10,131,64,12,134,103,5,223,225,160,139,93,250,0,118,42,182,123,193,210,165,116,136,103,148,163,122,119,92,78,168,45,190,123,115,74,197,213,37,240,39,249,191,144,95,67,135,100,65,162,184,161,115,64,166,246,135,220,232,90,53,189,3,175,140,78,226,111,18,71,61,41,221,136,98,32,143,221,113,209,107,75,215,25,205,19,158,237,28,54,108,20,121,11,68,153,56,89,91,160,12,168,220,225,132,188,130,124,65,131,103,180,168,43,212,114,184,188,37,218,249,24,251,31,5,58,5,173,250,64,217,98,186,127,114,203,246,101,171,164,144,129,184,9,40,50,113,103,84,5,30,87,71,162,240,210,31,186,5,151,146,119,225,113,206,140,120,99,207,248,18,8,211,69,79,224,145,203,56,71,193,128,57,141,32,199,31,136,42,84,9,109,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("11a7b02d-3f17-45e0-a8d6-807497e95249"));
		}

		#endregion

	}

	#endregion

}

