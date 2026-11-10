namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IGenAICompletionServiceProxySchema

	/// <exclude/>
	public class IGenAICompletionServiceProxySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IGenAICompletionServiceProxySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IGenAICompletionServiceProxySchema(IGenAICompletionServiceProxySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bb8c77e4-4a98-466a-ae64-a2cf7482521c");
			Name = "IGenAICompletionServiceProxy";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5931fdb4-cda3-48d2-808d-e41a5d931036");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,147,221,110,219,48,12,133,175,27,32,239,64,228,170,5,6,249,1,150,26,200,140,161,200,213,218,213,47,160,218,76,34,84,166,60,81,46,102,12,125,247,82,178,227,252,53,24,176,221,24,22,73,127,60,60,166,72,55,200,173,174,16,74,244,94,179,219,4,85,56,218,152,109,231,117,48,142,212,3,210,106,61,159,253,153,207,110,58,54,180,133,231,158,3,54,170,220,121,212,181,4,190,94,205,168,82,243,43,31,242,135,22,223,201,155,106,215,32,5,181,166,128,126,35,10,88,21,59,29,10,215,180,22,83,231,159,248,171,67,14,255,3,224,214,17,99,36,8,35,203,50,88,114,215,52,218,247,249,120,158,62,134,141,243,144,102,133,106,34,0,163,127,51,146,108,189,251,221,171,61,35,59,130,180,221,139,53,21,152,137,179,78,144,131,138,231,1,241,24,9,82,31,125,188,80,146,2,15,24,24,42,153,224,88,128,31,71,128,23,205,88,131,68,194,46,201,121,51,181,156,253,96,145,154,160,217,57,117,217,106,175,27,32,249,207,247,139,177,124,145,151,2,185,108,149,146,18,162,160,13,69,191,101,55,88,111,145,65,147,244,110,99,25,171,101,150,144,159,119,24,139,22,249,143,244,162,45,164,44,138,59,156,44,14,215,59,95,146,61,134,206,19,231,171,235,190,28,169,141,232,45,18,202,226,138,53,167,218,37,231,161,70,41,181,113,130,61,56,118,58,93,154,253,206,192,105,248,246,188,106,240,106,84,254,37,114,46,64,41,53,248,192,123,247,224,30,168,179,246,46,238,244,77,188,30,203,207,219,231,103,253,87,220,83,245,23,17,80,104,170,208,218,116,111,75,247,138,178,44,241,249,143,234,10,107,228,122,61,117,46,232,201,20,217,209,163,240,183,126,56,172,235,219,244,201,251,124,246,14,31,30,56,48,87,82,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bb8c77e4-4a98-466a-ae64-a2cf7482521c"));
		}

		#endregion

	}

	#endregion

}

