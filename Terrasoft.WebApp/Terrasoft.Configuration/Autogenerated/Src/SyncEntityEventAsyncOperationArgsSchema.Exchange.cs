namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SyncEntityEventAsyncOperationArgsSchema

	/// <exclude/>
	public class SyncEntityEventAsyncOperationArgsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SyncEntityEventAsyncOperationArgsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SyncEntityEventAsyncOperationArgsSchema(SyncEntityEventAsyncOperationArgsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7e247f3a-b8b6-4b8f-a8ea-e969f8ba34fb");
			Name = "SyncEntityEventAsyncOperationArgs";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("77ff850a-3558-415d-9b34-1a36190e74f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,147,81,107,194,48,16,199,159,21,252,14,135,123,113,48,218,119,117,130,136,136,48,152,224,246,1,98,122,237,2,109,234,46,201,160,19,191,251,46,77,93,171,56,101,47,77,123,247,207,255,126,185,75,181,40,208,236,133,68,120,67,34,97,202,212,70,139,82,167,42,115,36,172,42,245,160,127,24,244,123,206,40,157,193,182,50,22,139,201,197,55,235,243,28,165,23,155,104,133,26,73,201,86,211,181,37,140,150,218,42,171,208,220,21,68,115,83,105,249,186,199,128,113,117,195,150,21,28,231,204,3,97,198,42,88,228,194,152,49,248,68,109,84,45,191,80,219,115,171,57,101,166,222,180,119,187,92,73,144,126,207,253,45,48,134,59,150,189,67,109,219,194,48,182,37,39,109,73,204,180,169,171,5,69,83,249,110,205,81,200,2,214,203,19,4,153,135,193,211,219,35,115,237,132,193,209,73,211,201,248,201,245,142,13,20,234,36,112,157,67,110,168,228,138,190,227,231,136,113,28,195,212,184,162,16,84,205,218,0,34,72,194,244,121,184,246,240,31,84,106,245,93,227,242,97,45,249,139,64,195,120,6,170,216,231,88,48,72,24,30,104,127,205,162,95,155,184,107,220,52,227,69,25,59,229,126,241,136,103,208,186,153,112,138,94,134,118,2,134,31,157,51,93,101,12,151,18,156,65,2,194,92,88,76,186,220,222,89,72,91,67,242,120,132,230,171,239,180,250,116,8,42,241,61,76,21,210,109,210,149,83,9,188,179,127,227,181,78,254,203,216,225,241,109,156,215,63,15,35,221,174,219,74,161,89,254,46,123,49,238,16,61,15,30,127,0,138,64,25,233,252,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7e247f3a-b8b6-4b8f-a8ea-e969f8ba34fb"));
		}

		#endregion

	}

	#endregion

}

