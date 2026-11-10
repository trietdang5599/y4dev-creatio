namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IMarkNotificationAsReadExecutorSchema

	/// <exclude/>
	public class IMarkNotificationAsReadExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMarkNotificationAsReadExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMarkNotificationAsReadExecutorSchema(IMarkNotificationAsReadExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5756ae2a-e1ed-46c5-b16e-e91d802e9c2d");
			Name = "IMarkNotificationAsReadExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,143,205,10,194,48,16,132,207,45,228,29,22,188,40,72,31,160,61,137,138,244,80,17,237,11,196,102,83,23,109,82,242,35,150,226,187,27,91,149,222,188,237,204,240,205,176,138,55,104,91,94,33,148,104,12,183,90,186,100,173,149,164,218,27,238,72,171,100,175,29,73,170,6,97,89,220,179,56,242,150,84,13,167,206,58,108,50,22,7,103,102,176,14,57,228,202,161,145,161,46,133,188,224,230,58,133,87,246,136,92,108,31,88,121,167,205,128,181,254,124,163,10,232,75,253,135,162,126,0,127,131,5,186,139,22,54,133,195,80,53,134,119,77,2,70,6,231,59,31,132,154,84,150,93,139,185,88,194,134,59,44,169,65,48,216,144,18,239,115,145,125,218,81,137,113,32,168,231,248,225,196,98,113,240,94,87,17,43,114,58,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5756ae2a-e1ed-46c5-b16e-e91d802e9c2d"));
		}

		#endregion

	}

	#endregion

}

