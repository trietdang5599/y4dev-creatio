namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IDeleteHandlerSchema

	/// <exclude/>
	public class IDeleteHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDeleteHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDeleteHandlerSchema(IDeleteHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("20195bd2-50b1-4e93-a074-7128a08c449a");
			Name = "IDeleteHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,207,78,132,48,16,198,207,107,226,59,76,118,47,122,129,187,139,92,148,40,7,47,171,47,80,232,64,154,244,15,153,182,137,100,227,187,219,82,96,137,198,184,183,206,244,251,250,235,55,25,205,20,218,129,181,8,31,72,196,172,233,92,246,100,116,39,122,79,204,9,163,225,124,123,179,243,86,232,30,222,71,235,80,29,215,122,235,32,204,42,237,132,19,104,131,32,72,14,132,125,180,215,218,33,117,1,240,0,245,51,74,116,248,202,52,151,72,147,42,207,115,40,172,87,138,209,88,206,117,173,6,137,10,181,3,62,233,129,176,53,196,193,116,128,17,49,102,139,49,223,56,7,223,72,209,130,88,112,63,104,49,70,80,253,2,78,141,19,58,79,218,2,126,182,56,76,161,3,43,193,179,213,180,133,237,170,85,121,57,157,161,71,119,132,175,107,64,68,134,32,76,222,178,30,255,133,89,71,113,220,85,52,189,205,158,43,96,41,191,157,135,6,205,184,12,82,240,216,234,4,210,31,192,169,51,48,98,10,116,216,143,199,125,50,214,124,95,86,233,177,205,19,69,62,41,47,70,74,33,203,19,90,47,221,38,93,145,47,87,81,219,24,35,231,63,222,189,120,193,97,129,220,167,5,74,209,14,168,121,218,164,88,134,222,55,247,52,133,157,177,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("20195bd2-50b1-4e93-a074-7128a08c449a"));
		}

		#endregion

	}

	#endregion

}

