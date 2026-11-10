namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: RegistrationTimeoutJobSchema

	/// <exclude/>
	public class RegistrationTimeoutJobSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RegistrationTimeoutJobSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RegistrationTimeoutJobSchema(RegistrationTimeoutJobSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("51199334-03d1-4755-a35a-4e27cf9831ed");
			Name = "RegistrationTimeoutJob";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d7352345-17a4-46e8-b32e-306ac0453d7a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,82,193,110,219,48,12,61,167,64,255,129,240,46,54,80,216,247,182,201,97,73,87,164,232,128,162,235,208,179,98,51,169,54,91,50,40,41,109,16,228,223,75,73,78,102,123,203,78,54,69,234,233,241,189,167,68,131,166,21,37,194,11,18,9,163,215,54,159,107,181,150,27,71,194,74,173,46,47,246,151,23,19,103,164,218,192,143,157,177,216,220,140,106,158,175,107,44,253,176,201,239,81,33,201,242,207,76,31,150,240,220,121,190,248,202,45,110,126,33,220,48,16,204,107,97,204,53,60,115,101,108,100,242,34,27,212,206,62,232,21,132,209,162,40,224,214,184,166,17,180,155,117,245,2,107,180,104,0,63,90,73,88,1,245,238,131,38,104,25,245,93,147,111,148,122,139,180,131,90,170,223,38,63,194,21,61,188,214,173,106,89,66,233,153,156,35,114,13,75,254,220,125,96,233,172,38,190,180,15,212,78,107,124,71,251,166,43,94,228,137,228,86,88,140,221,54,22,176,213,178,234,40,223,69,194,143,158,77,250,211,32,177,9,42,138,10,110,80,102,224,13,153,76,22,140,224,153,64,233,136,80,217,83,61,29,93,200,231,113,192,163,178,63,118,62,156,79,179,155,128,183,21,4,85,224,2,211,112,48,81,248,222,177,75,71,20,98,63,255,70,186,73,19,78,65,95,29,198,21,201,113,226,245,13,9,211,196,175,21,55,244,175,38,89,190,52,143,104,76,202,201,113,141,202,159,4,113,12,45,82,58,218,37,235,184,69,94,121,212,249,200,248,208,73,141,170,138,106,159,147,62,248,24,155,193,100,169,152,149,180,149,102,115,9,215,211,164,239,225,233,145,161,9,87,176,92,200,240,199,233,216,243,174,156,225,43,208,171,95,220,62,100,73,49,11,190,198,196,4,91,255,13,51,178,102,128,122,59,68,157,113,88,59,89,204,201,243,191,179,50,114,230,63,202,196,211,225,225,225,19,111,137,72,215,0,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("51199334-03d1-4755-a35a-4e27cf9831ed"));
		}

		#endregion

	}

	#endregion

}

