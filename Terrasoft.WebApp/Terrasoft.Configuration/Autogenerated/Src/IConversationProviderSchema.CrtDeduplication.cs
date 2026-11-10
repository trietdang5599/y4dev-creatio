namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IConversationProviderSchema

	/// <exclude/>
	public class IConversationProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IConversationProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IConversationProviderSchema(IConversationProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ae9b308e-924f-4ea5-bac1-90760e48d38f");
			Name = "IConversationProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b5c46c08-cc76-4157-b24b-44267444e258");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,147,193,106,2,49,16,134,207,10,190,195,176,189,180,32,238,189,90,15,21,41,11,109,17,90,232,57,110,102,215,128,73,150,73,34,149,210,119,111,146,117,117,197,149,86,123,156,201,63,51,223,63,73,156,17,170,132,183,173,177,40,199,131,254,160,175,152,68,83,177,28,225,29,137,152,209,133,29,205,180,42,68,233,136,89,161,21,124,5,89,239,134,176,12,81,166,44,82,225,245,247,144,121,221,6,201,68,217,130,244,70,112,164,40,78,211,20,38,198,73,201,104,59,221,197,153,172,214,40,81,89,3,107,93,150,1,67,23,128,159,152,187,56,198,7,21,233,28,185,35,28,53,61,210,86,147,202,45,215,34,7,209,0,116,207,223,225,158,32,196,196,179,31,140,220,183,40,52,201,218,29,91,106,103,97,233,205,41,21,152,206,3,157,18,213,153,138,17,147,16,246,248,144,236,11,94,125,152,76,23,77,24,143,71,147,52,106,15,165,132,214,145,50,211,182,17,16,220,11,155,147,32,125,114,130,195,99,32,108,235,110,141,165,0,124,52,242,110,124,141,251,92,135,187,105,76,219,21,94,110,60,111,145,101,60,233,112,116,176,190,209,222,207,92,241,35,55,209,228,113,151,235,204,248,87,172,9,60,251,255,111,243,18,83,39,197,145,99,166,185,127,6,243,136,244,167,130,23,52,134,149,251,26,89,135,191,174,239,67,216,85,93,209,181,200,97,248,52,176,7,26,194,238,233,180,39,134,101,247,190,235,175,142,138,215,191,125,208,247,153,31,28,107,210,217,51,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ae9b308e-924f-4ea5-bac1-90760e48d38f"));
		}

		#endregion

	}

	#endregion

}

