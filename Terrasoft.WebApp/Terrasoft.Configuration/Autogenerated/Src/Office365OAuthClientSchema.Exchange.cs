namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: Office365OAuthClientSchema

	/// <exclude/>
	public class Office365OAuthClientSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public Office365OAuthClientSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public Office365OAuthClientSchema(Office365OAuthClientSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("455c7107-3388-47b8-bf89-0df39b6d2de3");
			Name = "Office365OAuthClient";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("77ff850a-3558-415d-9b34-1a36190e74f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,82,77,79,194,64,16,61,67,226,127,152,148,75,73,72,123,48,122,128,66,130,24,141,137,138,65,61,25,15,203,118,10,155,192,110,179,31,26,98,248,239,78,183,5,11,22,14,77,59,51,239,189,153,121,83,144,108,141,38,103,28,225,13,181,102,70,101,54,154,40,153,137,133,211,204,10,37,47,218,63,23,237,150,51,66,46,14,32,26,7,39,242,209,29,227,86,105,129,166,9,241,170,184,96,171,104,58,118,118,73,117,66,196,113,12,137,113,235,53,211,155,81,21,207,48,215,104,80,90,3,76,194,52,203,4,199,203,235,43,240,52,224,43,65,165,104,199,141,107,228,143,91,204,152,91,217,27,33,83,106,28,218,77,142,42,11,61,111,226,105,221,30,60,211,210,48,132,96,175,91,43,7,221,79,146,201,221,124,37,56,53,98,198,64,19,12,250,80,139,136,81,184,212,234,104,92,144,103,64,14,26,171,93,97,131,233,195,139,23,243,187,254,91,214,39,106,240,104,15,138,143,81,73,206,52,91,67,113,177,97,224,12,234,71,181,16,50,24,37,177,47,120,92,53,119,211,196,33,181,40,78,177,103,246,224,157,62,169,183,68,94,92,218,87,254,194,110,161,215,234,195,156,25,12,107,164,35,20,248,197,183,229,118,29,148,105,105,65,21,87,126,60,161,93,170,180,176,66,43,75,68,76,207,184,49,67,235,180,164,195,211,232,52,183,224,140,124,129,140,30,138,207,252,11,167,108,211,165,222,40,49,136,192,53,102,195,160,249,119,140,30,252,107,92,239,27,196,35,16,116,29,38,57,70,73,188,211,242,94,239,118,1,245,69,122,34,69,104,16,128,123,180,7,137,240,188,235,165,159,173,178,17,72,252,62,58,230,161,214,17,121,112,226,22,69,110,251,11,26,184,157,157,236,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("455c7107-3388-47b8-bf89-0df39b6d2de3"));
		}

		#endregion

	}

	#endregion

}

