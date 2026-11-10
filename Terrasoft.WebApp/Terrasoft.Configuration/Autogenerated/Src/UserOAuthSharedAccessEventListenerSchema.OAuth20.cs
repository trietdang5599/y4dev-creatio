namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: UserOAuthSharedAccessEventListenerSchema

	/// <exclude/>
	public class UserOAuthSharedAccessEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UserOAuthSharedAccessEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UserOAuthSharedAccessEventListenerSchema(UserOAuthSharedAccessEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("529ea73f-b7fe-436b-b66e-d3b192d59383");
			Name = "UserOAuthSharedAccessEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,205,82,193,78,2,49,16,61,67,226,63,140,120,129,196,44,119,80,19,64,14,36,42,6,228,100,60,148,118,216,173,97,219,77,167,187,72,8,255,110,183,5,226,26,136,122,48,225,216,153,215,55,111,222,27,197,82,164,140,113,132,23,52,134,145,94,216,104,160,213,66,198,185,97,86,106,117,81,223,92,212,107,57,73,21,87,32,105,170,85,247,104,199,96,52,84,86,90,137,244,35,32,26,22,168,108,137,115,200,43,131,177,155,8,131,37,35,234,192,140,208,140,123,185,77,166,9,51,40,122,156,35,145,199,63,72,178,168,208,248,95,175,158,107,93,105,52,167,60,193,148,61,185,229,224,22,26,71,153,26,173,55,247,59,203,231,75,201,129,151,35,127,49,17,58,208,103,132,71,70,58,174,141,215,115,88,227,17,109,162,133,91,228,217,200,130,89,12,221,44,60,128,172,179,151,67,161,165,128,151,196,232,213,4,153,208,106,185,30,126,112,204,74,231,155,122,254,142,220,2,161,18,104,90,80,230,80,171,21,204,0,250,241,110,179,102,16,210,10,144,174,7,200,5,52,47,3,34,114,11,245,68,42,213,68,198,137,165,61,69,205,160,205,141,10,240,237,129,149,188,103,3,230,135,59,242,29,71,176,50,218,213,195,39,91,10,6,133,43,24,123,141,35,42,213,143,143,168,47,35,232,84,169,91,158,99,187,51,203,41,15,126,157,50,207,7,20,154,237,118,27,110,164,74,208,72,43,52,135,246,157,119,52,68,168,11,119,98,82,96,176,116,172,238,113,137,214,157,94,213,198,107,8,150,245,113,225,238,208,39,216,51,49,1,238,205,57,145,197,46,132,175,210,255,164,102,164,220,109,157,143,156,89,38,216,249,168,153,178,226,63,181,124,187,177,80,173,22,93,237,19,7,153,190,14,10,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("529ea73f-b7fe-436b-b66e-d3b192d59383"));
		}

		#endregion

	}

	#endregion

}

