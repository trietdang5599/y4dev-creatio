namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ChatContactSchema

	/// <exclude/>
	public class ChatContactSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ChatContactSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ChatContactSchema(ChatContactSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9dfeee86-228f-4670-b6f8-b56e2b8c7992");
			Name = "ChatContact";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,145,77,75,195,64,16,134,207,6,242,31,150,158,244,146,252,128,168,32,81,164,96,84,172,120,17,15,211,205,36,29,220,143,176,31,66,149,254,119,39,137,193,182,52,167,221,153,121,159,121,103,119,12,104,244,29,72,20,175,232,28,120,219,132,172,180,166,161,54,58,8,100,77,246,164,13,201,13,24,131,42,171,208,123,104,201,180,105,242,147,38,103,209,243,85,172,182,62,160,46,142,226,236,37,154,64,26,179,21,58,2,69,223,67,183,127,213,190,157,27,84,95,36,177,178,53,42,246,15,14,100,96,49,203,243,60,23,151,62,106,13,110,123,253,23,151,10,188,23,146,117,64,6,157,104,172,19,60,99,24,83,50,136,26,2,100,19,156,239,209,239,183,92,153,12,62,56,209,197,181,34,41,228,208,177,228,30,229,216,130,75,253,19,71,160,66,189,70,119,254,200,159,37,174,196,130,234,197,69,207,78,240,125,164,90,44,235,98,78,111,248,60,36,124,112,253,39,244,130,89,170,219,216,96,151,167,172,158,199,202,44,137,26,72,157,52,188,235,43,179,28,72,105,121,107,135,228,131,181,159,177,123,3,21,81,220,140,130,226,120,32,94,121,25,85,136,14,199,169,118,105,178,251,5,175,73,64,246,90,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9dfeee86-228f-4670-b6f8-b56e2b8c7992"));
		}

		#endregion

	}

	#endregion

}

