namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: INotificationCounterSchema

	/// <exclude/>
	public class INotificationCounterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationCounterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationCounterSchema(INotificationCounterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8b7d7230-b757-4090-bbb0-2b97d1bc90cb");
			Name = "INotificationCounter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,146,77,106,195,48,16,133,215,9,228,14,67,186,105,33,216,251,214,245,38,133,224,77,41,109,47,160,200,99,91,196,146,204,104,148,98,74,238,94,73,206,31,9,221,89,163,167,239,189,153,177,17,26,221,32,36,194,55,18,9,103,27,206,214,214,52,170,245,36,88,89,179,152,255,46,230,51,239,148,105,225,107,116,140,250,229,230,28,244,125,143,50,138,93,182,65,131,164,100,208,4,213,3,97,27,170,80,25,70,106,130,201,51,84,239,150,85,163,100,98,175,173,143,55,73,155,231,57,20,206,107,45,104,44,143,231,15,178,123,85,163,3,1,26,185,179,53,176,133,22,25,184,67,48,94,111,145,192,54,96,174,144,14,182,35,180,100,253,144,157,160,249,21,117,240,219,94,73,80,167,64,255,228,153,197,158,239,34,165,194,39,178,167,96,115,109,10,114,122,152,204,165,53,44,36,103,103,66,126,139,40,6,65,66,131,9,163,127,93,30,229,85,189,44,215,211,39,132,150,77,132,35,101,69,158,180,151,167,52,217,151,111,42,13,60,96,87,240,211,33,33,236,112,4,229,166,222,227,84,82,38,16,166,134,189,232,61,198,187,84,10,204,19,36,82,171,11,169,112,76,97,173,171,56,158,18,54,200,119,179,121,220,120,85,195,57,242,83,252,21,14,211,170,209,212,211,182,23,243,195,31,7,170,26,251,85,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8b7d7230-b757-4090-bbb0-2b97d1bc90cb"));
		}

		#endregion

	}

	#endregion

}

