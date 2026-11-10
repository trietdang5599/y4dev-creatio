namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ExchangeEmailEventsProviderSchema

	/// <exclude/>
	public class ExchangeEmailEventsProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ExchangeEmailEventsProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ExchangeEmailEventsProviderSchema(ExchangeEmailEventsProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a2eb6a61-1c72-4cbf-9db4-831b77de2c84");
			Name = "ExchangeEmailEventsProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("77ff850a-3558-415d-9b34-1a36190e74f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,84,77,107,227,48,16,61,167,208,255,48,184,151,4,138,125,111,18,151,37,228,16,104,161,172,179,151,189,44,170,60,137,5,182,20,36,57,221,164,244,191,239,200,31,137,149,58,166,61,236,205,126,158,121,243,102,230,121,64,178,2,205,142,113,132,53,106,205,140,218,216,48,57,72,30,46,255,242,140,201,45,222,222,188,223,222,140,74,35,228,22,146,131,177,88,76,79,239,231,148,133,210,72,56,125,185,211,184,21,74,194,34,103,198,60,64,75,179,44,152,200,151,123,148,214,188,104,181,23,41,234,42,124,87,190,230,130,3,119,209,67,193,112,65,229,52,158,137,70,239,21,217,185,184,146,198,234,146,91,165,73,195,75,85,163,142,136,162,8,102,166,44,10,166,15,113,11,172,164,176,130,229,226,136,32,241,13,4,37,51,73,35,81,27,138,69,4,174,113,51,15,6,212,5,16,197,240,38,108,6,59,234,3,83,48,36,47,211,74,138,35,179,78,144,65,107,105,98,38,60,105,136,46,69,204,118,76,179,2,220,66,230,65,105,80,83,19,18,185,75,15,226,142,140,95,254,39,42,220,234,13,103,81,197,209,79,105,80,146,210,74,252,143,52,213,104,76,16,39,21,6,232,64,96,53,58,204,226,132,37,77,51,158,172,122,42,205,136,78,17,215,212,53,107,31,24,233,216,239,19,252,137,220,3,237,215,89,240,115,87,247,208,43,5,186,202,97,14,178,204,243,137,147,50,122,128,87,102,112,252,169,64,15,115,151,99,2,141,233,62,254,183,179,190,106,26,43,10,252,173,36,174,228,70,5,241,162,212,154,152,192,161,71,66,191,239,142,117,134,224,0,55,231,198,28,78,184,37,248,194,223,223,221,237,192,242,214,157,38,160,219,145,183,172,190,76,47,248,98,57,119,20,95,223,6,255,80,60,163,205,84,250,149,27,113,109,93,221,67,20,62,41,150,58,96,69,103,114,220,62,36,60,163,31,172,117,236,132,254,137,254,125,54,115,83,123,186,170,196,6,171,159,88,40,139,142,2,6,136,193,120,252,32,210,170,121,154,85,130,122,47,200,108,115,104,159,30,31,59,142,108,192,241,31,223,249,147,105,149,172,209,150,90,86,211,246,219,106,203,81,157,233,245,9,215,168,15,126,252,3,96,115,16,159,110,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a2eb6a61-1c72-4cbf-9db4-831b77de2c84"));
		}

		#endregion

	}

	#endregion

}

