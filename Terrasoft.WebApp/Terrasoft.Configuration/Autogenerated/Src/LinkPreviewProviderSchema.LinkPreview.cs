namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: LinkPreviewProviderSchema

	/// <exclude/>
	public class LinkPreviewProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LinkPreviewProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LinkPreviewProviderSchema(LinkPreviewProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e4a3f83d-3ebf-4233-b30c-47b99325a13a");
			Name = "LinkPreviewProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5bdc21ce-6c09-4da3-b22d-c3e4fd10c6a0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,146,193,78,194,64,16,134,207,109,194,59,76,240,130,137,105,239,130,189,32,49,36,104,136,232,3,44,237,128,27,219,221,102,118,23,211,16,222,221,237,182,72,91,138,193,196,227,108,231,255,231,159,111,106,20,23,91,88,21,74,99,54,30,248,198,149,111,72,196,148,220,232,96,42,9,237,243,192,23,44,67,149,179,24,91,31,197,134,111,13,49,205,165,24,248,251,129,239,221,16,110,109,1,211,148,41,117,15,11,46,62,151,132,59,142,95,75,146,59,158,32,149,102,94,24,134,48,81,38,203,24,21,81,93,59,9,108,36,65,94,181,66,106,213,182,112,114,72,152,102,193,81,26,54,180,185,89,167,60,134,216,201,123,7,122,123,55,244,20,78,10,165,201,196,90,146,205,184,116,250,170,163,155,171,10,70,200,52,42,16,54,69,143,63,112,235,198,68,140,193,143,67,216,181,152,228,140,88,6,37,196,135,161,81,72,54,130,192,184,228,54,140,222,91,245,201,110,18,58,213,201,132,80,27,18,42,250,53,196,36,60,182,149,186,26,78,143,98,212,25,219,78,117,11,229,53,189,67,13,14,69,82,177,107,131,124,70,253,33,147,107,24,174,216,174,115,79,46,54,18,214,5,160,208,92,23,64,24,75,74,128,39,215,82,76,79,43,205,173,213,208,81,105,185,159,3,108,234,171,185,175,110,236,60,25,70,179,110,142,139,248,95,172,255,249,42,77,97,207,5,158,12,79,28,133,69,59,247,168,83,67,103,175,187,74,217,78,91,95,199,171,230,184,142,96,150,229,186,24,55,142,214,123,135,71,76,81,255,243,37,254,68,178,198,177,147,118,169,42,76,23,200,229,125,123,254,198,250,173,249,116,248,6,92,127,175,165,211,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e4a3f83d-3ebf-4233-b30c-47b99325a13a"));
		}

		#endregion

	}

	#endregion

}

