namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IGenAIAppServiceProxySchema

	/// <exclude/>
	public class IGenAIAppServiceProxySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IGenAIAppServiceProxySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IGenAIAppServiceProxySchema(IGenAIAppServiceProxySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3ee72a1c-d041-475f-a38f-018f0a240ed0");
			Name = "IGenAIAppServiceProxy";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5931fdb4-cda3-48d2-808d-e41a5d931036");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,143,193,74,196,64,12,134,207,91,232,59,228,168,32,237,3,236,178,176,218,69,10,30,132,250,2,227,152,214,64,103,58,76,82,177,200,190,187,51,211,181,45,40,30,147,124,255,151,196,42,131,236,148,70,120,65,239,21,15,173,20,15,131,109,169,27,189,18,26,108,241,136,246,84,231,217,87,158,237,70,38,219,65,51,177,160,9,84,223,163,142,8,71,6,61,233,253,194,172,178,179,13,131,119,131,86,138,218,10,250,54,236,226,89,26,240,16,40,203,18,14,60,26,163,252,116,188,214,11,9,237,224,33,193,160,156,235,73,167,155,128,209,127,80,152,58,63,124,78,197,143,164,220,88,220,248,26,104,160,69,84,39,203,201,185,102,206,62,199,104,0,227,95,187,39,98,57,36,224,108,133,100,58,66,250,72,9,166,154,144,239,167,10,89,123,114,113,255,13,139,143,95,190,173,173,219,253,226,153,135,171,162,210,166,17,213,33,255,31,219,172,175,148,168,77,62,84,127,68,239,224,247,213,120,189,54,105,47,121,118,129,111,214,219,160,119,224,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3ee72a1c-d041-475f-a38f-018f0a240ed0"));
		}

		#endregion

	}

	#endregion

}

