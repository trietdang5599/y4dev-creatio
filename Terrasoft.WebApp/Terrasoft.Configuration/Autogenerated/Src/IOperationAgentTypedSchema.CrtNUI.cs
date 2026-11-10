namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IOperationAgentTypedSchema

	/// <exclude/>
	public class IOperationAgentTypedSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IOperationAgentTypedSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IOperationAgentTypedSchema(IOperationAgentTypedSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5b084da8-1bf5-4242-9e04-24f04039b8b1");
			Name = "IOperationAgentTyped";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,77,107,194,64,16,134,207,10,254,135,193,94,44,148,228,174,105,64,68,36,7,91,209,208,251,154,76,226,194,102,55,221,15,169,136,255,189,187,27,19,84,26,233,41,204,228,125,102,222,153,29,78,42,84,53,201,16,82,148,146,40,81,232,96,33,120,65,75,35,137,166,130,195,104,120,30,13,7,70,81,94,194,238,164,52,86,179,135,216,2,140,97,230,212,42,88,33,71,73,51,171,177,170,23,137,165,171,145,112,141,178,176,93,166,144,124,214,216,84,158,151,200,181,151,133,97,8,145,50,85,69,228,41,190,198,233,169,198,28,104,11,130,40,64,31,236,167,165,129,56,60,104,233,240,6,175,205,158,209,236,134,125,232,25,165,95,132,25,124,131,116,139,202,48,29,195,217,219,232,236,110,164,107,163,41,170,41,108,154,98,141,224,209,168,79,108,81,27,201,21,104,105,16,104,1,149,144,8,228,72,40,35,123,134,65,199,221,90,28,236,133,96,176,182,202,249,145,48,234,132,112,134,18,245,12,46,238,183,119,131,60,111,12,221,187,91,163,62,136,188,179,246,15,103,28,127,52,100,221,35,181,187,148,152,9,153,171,30,135,62,35,155,10,241,162,23,142,194,86,227,160,100,201,77,101,119,109,231,137,186,237,174,80,127,88,7,137,61,21,53,121,157,61,49,188,67,173,250,141,130,22,62,252,54,104,250,246,234,51,53,145,164,2,110,79,251,125,124,101,199,79,71,240,128,231,143,130,230,176,228,190,197,228,110,26,127,51,241,21,74,114,229,6,249,243,161,46,205,233,223,37,125,238,23,46,213,80,220,108,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5b084da8-1bf5-4242-9e04-24f04039b8b1"));
		}

		#endregion

	}

	#endregion

}

