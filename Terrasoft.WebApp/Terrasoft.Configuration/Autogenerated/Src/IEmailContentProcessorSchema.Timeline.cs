namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IEmailContentProcessorSchema

	/// <exclude/>
	public class IEmailContentProcessorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IEmailContentProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IEmailContentProcessorSchema(IEmailContentProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("819ce2ce-5952-41b4-b5b6-a1b94edb0446");
			Name = "IEmailContentProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0f0b57ce-3155-4876-a7bb-8a901e434b75");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,189,83,205,78,219,64,16,62,19,41,239,48,130,11,72,200,190,67,26,9,161,138,34,129,148,150,60,64,183,155,113,60,146,189,187,157,25,131,16,226,221,59,222,53,161,41,105,143,61,238,248,251,155,207,187,193,245,40,201,121,132,53,50,59,137,141,86,215,49,52,180,29,216,41,197,80,173,169,199,142,2,206,103,47,243,217,209,32,20,182,240,240,44,138,189,1,187,14,253,136,146,234,6,3,50,249,203,249,204,80,39,140,91,155,194,109,80,228,198,212,47,224,246,115,239,168,51,105,197,160,43,142,30,69,34,103,116,93,215,176,144,161,239,29,63,47,167,243,142,9,77,100,72,5,63,90,227,40,3,190,232,84,111,236,250,55,122,26,126,116,228,129,118,10,127,179,62,122,201,246,187,180,247,168,109,220,200,5,172,178,66,249,248,103,184,60,248,134,202,132,143,40,224,44,27,62,18,62,65,108,64,91,252,152,239,99,192,50,73,142,93,15,193,250,255,116,156,73,199,203,181,241,39,230,190,156,19,248,178,190,191,171,22,117,102,189,139,48,234,192,65,150,87,32,109,100,5,9,148,18,234,193,48,83,147,37,109,26,56,69,65,49,201,55,141,81,84,108,47,43,249,6,173,167,12,60,157,38,89,233,236,242,31,157,60,164,142,84,14,216,218,143,136,240,115,136,138,114,14,46,108,96,50,4,210,239,2,150,130,198,27,100,176,204,141,76,91,10,174,43,34,255,177,192,142,36,147,10,193,96,250,30,206,130,63,181,200,166,230,124,155,191,217,18,86,165,152,209,120,7,54,198,165,224,181,172,105,59,128,39,45,207,103,191,223,59,3,46,78,173,17,16,53,149,243,177,28,192,176,57,91,142,157,127,53,118,102,201,106,50,62,88,255,137,17,202,149,205,231,215,242,228,246,134,175,191,0,249,121,172,46,216,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("819ce2ce-5952-41b4-b5b6-a1b94edb0446"));
		}

		#endregion

	}

	#endregion

}

