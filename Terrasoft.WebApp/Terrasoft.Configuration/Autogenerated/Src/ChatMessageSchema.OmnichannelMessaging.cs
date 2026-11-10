namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ChatMessageSchema

	/// <exclude/>
	public class ChatMessageSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ChatMessageSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ChatMessageSchema(ChatMessageSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("21c9a1d7-90b7-429c-ad25-dd578ea023a7");
			Name = "ChatMessage";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,83,219,78,219,64,16,125,6,137,127,24,241,212,190,56,31,0,165,130,4,161,72,164,84,141,223,170,62,76,236,73,178,210,94,162,153,49,106,138,248,247,206,230,70,156,26,171,60,196,217,245,185,204,241,177,55,98,32,89,97,69,80,18,51,74,154,107,49,76,113,238,22,13,163,186,20,139,167,16,93,181,196,24,201,23,19,18,193,133,139,139,139,243,151,139,243,179,70,108,9,71,132,239,156,158,93,77,44,197,40,5,116,177,184,143,234,212,145,92,29,216,211,181,40,133,211,189,205,244,158,170,60,80,138,7,138,196,174,250,135,243,163,49,183,64,197,212,80,244,238,207,38,159,177,140,55,24,12,224,90,154,16,144,215,55,187,253,208,163,8,84,41,170,37,33,134,121,98,176,156,10,97,243,20,36,197,94,56,56,82,254,28,161,162,53,160,140,149,254,178,27,171,102,230,93,5,213,198,109,104,250,109,9,100,80,238,96,43,152,80,152,17,127,250,102,109,194,23,184,116,245,229,231,172,221,139,31,26,87,195,184,222,102,237,84,96,163,203,196,109,85,30,150,147,88,16,184,221,224,61,6,185,153,182,92,148,115,121,165,1,125,58,250,173,221,58,3,122,116,181,227,237,251,106,139,119,229,140,246,40,28,86,125,25,214,43,234,180,41,13,128,124,233,107,78,173,160,101,160,168,210,246,120,116,162,215,59,163,219,3,233,6,222,214,210,99,235,228,46,237,95,117,219,119,150,146,135,241,17,220,227,146,216,217,113,65,95,190,215,242,211,17,161,55,77,201,24,197,163,82,221,153,230,13,238,113,9,88,113,146,146,194,42,51,59,27,159,28,40,232,9,218,187,23,88,144,94,129,228,203,235,251,83,242,25,27,119,29,128,225,6,248,95,155,154,188,123,38,94,79,21,181,145,238,175,172,69,249,10,219,255,143,14,184,103,62,61,121,46,42,140,142,225,83,207,51,251,189,254,5,56,117,159,242,60,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("21c9a1d7-90b7-429c-ad25-dd578ea023a7"));
		}

		#endregion

	}

	#endregion

}

