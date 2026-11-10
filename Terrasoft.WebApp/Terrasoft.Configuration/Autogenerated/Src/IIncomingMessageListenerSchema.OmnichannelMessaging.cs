namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IIncomingMessageListenerSchema

	/// <exclude/>
	public class IIncomingMessageListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IIncomingMessageListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IIncomingMessageListenerSchema(IIncomingMessageListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e4621d47-b46b-4fa0-8ceb-e6a359374028");
			Name = "IIncomingMessageListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("92ff52b6-dfba-4556-90d8-6f4c37f69c5d");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,93,145,193,106,195,48,12,134,207,13,228,29,68,119,217,46,241,189,203,122,217,41,176,174,101,108,15,160,37,74,106,136,229,96,57,133,49,250,238,115,237,36,116,1,95,36,255,250,248,127,137,209,144,12,88,19,124,146,115,40,182,245,197,171,229,86,119,163,67,175,45,23,71,195,186,62,35,51,245,197,129,68,176,211,220,229,217,111,158,229,217,230,193,81,23,68,80,177,39,215,6,204,14,170,138,107,107,130,38,137,233,221,122,221,106,114,81,175,148,130,82,70,99,208,253,236,167,250,131,6,71,66,236,5,244,140,129,214,58,232,181,120,226,64,10,253,132,4,147,152,82,192,12,83,119,180,97,252,238,117,125,71,89,123,121,139,196,155,151,77,242,191,4,56,144,63,219,70,118,112,138,140,244,185,118,27,27,167,192,182,206,8,96,125,219,15,132,183,182,87,44,195,106,61,93,14,232,208,0,135,181,191,108,39,249,118,95,173,1,165,138,186,56,118,177,186,129,175,161,65,79,143,203,1,166,64,243,192,211,243,20,135,184,73,137,98,125,77,71,250,215,188,254,1,249,134,34,28,243,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e4621d47-b46b-4fa0-8ceb-e6a359374028"));
		}

		#endregion

	}

	#endregion

}

