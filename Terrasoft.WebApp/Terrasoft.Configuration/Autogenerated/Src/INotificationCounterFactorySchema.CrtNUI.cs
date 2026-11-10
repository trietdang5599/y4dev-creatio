namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: INotificationCounterFactorySchema

	/// <exclude/>
	public class INotificationCounterFactorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationCounterFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationCounterFactorySchema(INotificationCounterFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("77f3b853-df5f-4ea2-af13-167cb7ffd1ed");
			Name = "INotificationCounterFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,82,193,78,195,48,12,61,175,82,255,193,26,23,184,52,119,232,122,153,96,218,5,33,216,15,100,153,219,69,106,147,202,118,144,42,180,127,39,77,41,155,96,66,220,146,247,158,159,159,101,59,221,33,247,218,32,236,144,72,179,175,165,88,123,87,219,38,144,22,235,93,158,125,228,217,34,176,117,13,188,13,44,216,69,190,109,209,140,36,23,27,116,72,214,60,228,89,84,221,16,54,17,133,173,19,164,58,154,222,195,246,217,139,173,173,73,94,107,31,70,230,73,27,241,52,164,18,165,20,148,28,186,78,211,80,125,253,95,200,191,219,3,50,104,232,80,142,254,0,226,65,27,131,204,32,71,4,211,106,230,72,215,158,160,65,145,49,90,194,39,123,46,102,95,117,97,220,135,125,107,13,216,57,218,223,201,22,227,208,191,194,37,224,21,37,144,227,232,196,162,93,12,5,190,142,42,140,253,9,235,213,242,154,239,82,85,176,31,46,85,151,162,13,249,208,71,201,119,75,245,179,103,217,107,210,29,184,184,172,213,178,73,242,106,23,39,78,207,4,23,165,74,154,115,9,77,57,171,243,182,254,23,180,84,115,229,104,181,125,116,161,67,210,251,22,203,107,5,21,108,80,174,224,124,203,66,227,98,82,196,187,120,31,139,211,116,35,232,14,211,153,228,217,233,19,97,121,252,37,126,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("77f3b853-df5f-4ea2-af13-167cb7ffd1ed"));
		}

		#endregion

	}

	#endregion

}

