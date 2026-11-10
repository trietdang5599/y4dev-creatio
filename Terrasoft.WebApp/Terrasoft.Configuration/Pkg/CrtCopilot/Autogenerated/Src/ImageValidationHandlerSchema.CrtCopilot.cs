namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ImageValidationHandlerSchema

	/// <exclude/>
	public class ImageValidationHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ImageValidationHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ImageValidationHandlerSchema(ImageValidationHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7446a324-0b99-49ac-934b-099e2e46fc2b");
			Name = "ImageValidationHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,83,75,111,219,48,12,62,187,64,255,3,129,93,92,160,176,119,94,215,6,157,215,98,62,172,27,144,109,215,65,149,152,68,128,76,25,148,220,206,43,246,223,71,191,130,216,72,114,11,41,250,123,240,99,72,85,24,106,165,17,10,70,21,173,207,10,95,91,231,227,229,197,219,229,69,210,4,75,91,88,183,33,98,117,179,175,127,32,179,10,126,19,101,184,170,60,29,127,97,148,190,188,188,99,220,90,79,80,56,21,194,7,40,43,181,197,95,202,89,211,209,209,23,69,198,33,247,147,121,158,195,199,208,84,149,226,246,110,172,199,73,12,16,154,186,246,28,209,128,237,32,96,99,157,116,45,65,220,137,250,65,117,223,132,151,61,58,232,157,178,148,77,216,249,1,120,221,60,59,171,65,119,170,78,136,2,81,59,2,63,10,238,17,209,201,91,47,124,239,241,209,162,51,98,242,59,219,23,17,61,60,214,67,1,178,96,227,201,181,80,30,210,121,134,223,118,86,223,140,152,72,102,128,157,115,20,158,66,228,70,203,100,199,212,219,24,137,6,75,199,205,164,75,214,57,233,21,116,121,39,201,66,11,220,46,230,96,181,146,133,179,127,5,194,87,184,231,109,83,33,197,167,198,185,111,252,80,213,177,125,248,163,177,238,120,83,146,219,242,155,116,193,115,213,93,75,242,239,188,199,175,24,119,222,44,236,245,17,90,218,33,219,104,188,134,252,238,192,244,179,247,14,10,53,186,77,203,241,156,239,203,207,94,247,18,193,140,63,38,167,140,177,97,90,46,63,43,195,122,58,180,126,97,233,244,221,42,235,142,224,73,76,205,44,156,85,101,133,119,186,224,244,103,64,150,240,8,117,127,154,205,172,188,134,51,146,175,123,193,137,160,201,242,125,84,110,154,88,219,191,88,210,167,182,251,127,220,2,73,10,39,114,204,38,21,131,167,37,247,158,232,36,252,224,121,90,218,251,83,33,142,189,121,174,210,251,15,222,251,198,48,104,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7446a324-0b99-49ac-934b-099e2e46fc2b"));
		}

		#endregion

	}

	#endregion

}

