namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: OmnichannelChatCloserSchema

	/// <exclude/>
	public class OmnichannelChatCloserSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OmnichannelChatCloserSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OmnichannelChatCloserSchema(OmnichannelChatCloserSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("495695b8-7d6f-4949-94fd-1777698ef8a2");
			Name = "OmnichannelChatCloser";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,83,203,110,194,64,12,60,7,169,255,96,193,5,36,148,220,91,30,135,148,34,42,161,162,62,206,213,18,12,44,74,118,35,123,195,67,21,255,222,205,6,82,146,34,196,205,118,60,227,177,103,163,68,130,156,138,8,225,19,137,4,235,165,241,67,173,150,114,149,145,48,82,43,255,45,81,50,90,11,165,48,246,167,200,44,86,82,173,30,26,63,15,13,47,99,27,66,168,9,159,202,236,227,192,6,19,203,17,199,24,229,4,236,143,81,33,201,200,246,216,174,22,225,202,86,33,140,5,51,60,194,5,125,184,22,38,140,53,35,185,206,32,8,160,199,89,146,8,58,12,78,249,59,166,132,140,202,48,136,58,20,10,44,108,244,220,63,195,131,11,124,154,205,99,25,65,228,6,95,29,107,229,76,94,245,124,180,199,40,51,218,170,240,242,45,75,201,47,18,227,69,174,121,70,114,43,12,58,149,94,90,36,144,211,88,121,154,165,133,30,224,155,202,184,88,220,107,161,90,20,76,167,252,68,59,69,179,214,119,243,142,209,84,43,237,47,171,220,90,166,138,115,67,86,73,59,224,86,240,8,77,70,234,82,21,12,135,208,190,204,251,160,112,87,27,215,174,177,117,114,163,189,227,221,11,185,147,23,95,235,118,186,130,187,251,63,35,119,107,84,32,13,72,6,35,19,244,75,120,80,199,247,82,65,34,1,101,95,113,191,89,213,218,28,228,135,129,168,44,248,189,192,117,95,7,187,24,13,18,55,7,179,50,174,96,78,15,104,43,201,100,34,134,173,150,11,40,222,10,222,54,161,11,147,103,233,34,171,189,199,134,236,143,210,5,61,223,216,207,3,248,155,124,54,107,43,172,238,170,237,253,43,198,215,188,113,214,120,85,156,239,14,60,218,167,146,112,145,195,185,125,203,194,162,90,45,30,127,1,89,156,84,101,35,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("495695b8-7d6f-4949-94fd-1777698ef8a2"));
		}

		#endregion

	}

	#endregion

}

