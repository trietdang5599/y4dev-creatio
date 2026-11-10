namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: LinkPreviewClassSchema

	/// <exclude/>
	public class LinkPreviewClassSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LinkPreviewClassSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LinkPreviewClassSchema(LinkPreviewClassSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b31973ba-92a5-4182-983d-c8439780d8a1");
			Name = "LinkPreviewClass";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("8a6b5719-da97-4634-8f04-4375bc29ffcf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,83,77,79,194,64,16,61,67,194,127,152,200,5,46,237,93,62,46,152,40,137,26,162,24,15,198,195,182,76,203,198,118,183,153,221,106,208,240,223,157,221,130,52,165,106,47,77,230,227,189,121,157,121,91,26,169,82,120,220,25,139,249,100,208,47,107,97,240,80,42,43,115,12,30,145,164,200,228,167,176,82,43,110,26,244,149,200,209,20,34,70,88,35,145,48,58,177,193,66,171,68,166,37,249,174,65,255,203,245,245,134,132,41,135,176,200,132,49,151,112,43,213,219,138,240,93,226,199,82,37,218,183,132,97,8,83,83,230,185,160,221,252,16,251,118,208,9,100,12,128,162,66,128,100,72,112,68,132,53,200,203,149,176,130,231,91,18,177,125,229,68,81,70,153,140,33,246,52,103,67,123,172,173,247,35,109,69,186,64,178,18,89,223,202,227,188,172,138,244,14,243,8,105,116,207,255,11,51,184,176,210,102,120,49,118,35,142,51,140,37,183,178,181,171,192,23,164,104,39,96,220,103,255,59,205,6,77,76,178,112,139,106,37,187,58,213,187,82,202,92,164,237,202,150,174,210,149,102,171,141,109,101,185,225,66,87,146,146,178,86,142,39,202,218,40,134,168,54,213,45,56,170,114,245,212,159,46,250,199,65,137,38,158,167,144,77,137,29,189,244,155,117,42,219,212,141,115,135,118,171,55,13,215,52,181,248,196,245,65,130,57,215,0,209,14,120,95,193,15,54,108,130,167,133,32,145,131,123,114,51,191,218,57,239,49,152,134,62,125,234,34,180,37,41,51,191,61,251,203,105,120,172,213,78,210,120,20,44,209,62,99,180,98,171,212,42,163,195,225,120,234,24,252,163,233,85,84,160,152,188,65,49,26,79,92,71,183,163,238,191,1,219,29,109,188,120,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b31973ba-92a5-4182-983d-c8439780d8a1"));
		}

		#endregion

	}

	#endregion

}

