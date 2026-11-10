namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: OAuthExceptionsSchema

	/// <exclude/>
	public class OAuthExceptionsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OAuthExceptionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OAuthExceptionsSchema(OAuthExceptionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fc203001-613e-494f-8857-3cb5ad94462e");
			Name = "OAuthExceptions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,213,83,203,106,194,64,20,93,71,240,31,6,220,40,72,82,186,180,165,32,210,133,171,22,237,174,116,49,142,55,201,64,50,19,230,129,90,241,223,59,153,60,154,26,31,37,77,104,187,10,55,57,57,143,185,115,24,142,65,38,152,0,122,1,33,176,228,190,114,103,156,249,52,208,2,43,202,153,251,52,213,42,188,189,233,247,246,253,158,163,37,101,1,90,238,164,130,248,238,104,118,23,154,41,26,131,187,4,65,113,68,223,237,255,6,101,112,3,1,129,25,208,44,194,82,78,144,229,92,128,228,90,16,120,220,18,72,82,168,69,122,158,135,238,165,142,99,44,118,15,249,92,34,144,10,5,223,48,180,9,105,4,72,228,4,40,37,55,14,132,241,226,22,20,94,133,227,181,116,180,138,224,205,188,72,244,42,162,4,145,212,205,25,51,104,130,42,198,156,189,53,247,153,131,51,169,132,38,138,11,19,231,217,210,101,8,43,78,89,104,20,213,154,19,47,213,47,244,78,43,13,71,40,61,90,231,208,152,192,88,73,215,96,54,41,113,0,35,99,125,133,37,12,203,185,85,250,113,101,29,148,49,16,229,120,44,60,174,125,175,26,25,0,91,103,167,121,241,104,5,87,64,20,172,47,185,47,48,231,2,124,185,144,115,230,115,99,204,231,99,180,84,2,112,108,178,25,77,5,91,133,72,246,28,165,172,142,147,167,201,176,197,167,179,25,242,119,71,177,46,93,252,57,155,69,20,152,106,92,0,98,127,71,56,73,204,246,108,184,54,171,80,179,215,121,37,106,138,67,187,137,70,215,183,206,117,165,37,157,41,253,160,48,199,158,58,239,76,61,75,155,221,185,18,231,219,5,202,60,78,147,228,143,53,167,238,171,179,202,212,165,26,116,229,4,73,219,37,185,42,241,31,218,113,34,196,47,215,226,240,1,96,185,28,103,184,9,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fc203001-613e-494f-8857-3cb5ad94462e"));
		}

		#endregion

	}

	#endregion

}

