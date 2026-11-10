namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: INotificationMessageBuilderSchema

	/// <exclude/>
	public class INotificationMessageBuilderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationMessageBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationMessageBuilderSchema(INotificationMessageBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b0a82eba-e0ad-4ba7-bced-e8d42f2a5640");
			Name = "INotificationMessageBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,146,77,107,2,49,16,134,207,43,248,31,6,122,105,47,238,93,75,161,246,96,247,96,17,218,254,128,104,102,119,3,38,145,204,164,32,210,255,222,124,232,118,21,86,244,180,217,201,188,79,158,124,24,161,145,118,98,131,240,133,206,9,178,53,79,222,172,169,85,227,157,96,101,205,120,116,24,143,10,79,202,52,240,185,39,70,61,235,254,255,35,75,36,18,77,168,133,176,214,214,132,158,208,245,224,176,9,8,168,12,163,171,195,34,83,168,62,44,171,90,109,18,59,167,112,238,213,86,162,75,145,178,44,225,153,188,214,194,237,95,142,255,43,103,127,148,68,2,141,220,90,73,192,22,214,49,3,166,7,11,179,137,54,57,81,202,30,102,231,215,91,181,1,117,18,185,238,81,28,146,75,231,31,4,118,232,88,33,77,97,149,72,121,254,82,54,21,22,200,4,214,1,197,111,208,54,113,29,116,96,107,224,22,65,72,173,12,120,163,120,210,33,250,166,197,194,43,25,79,250,53,54,126,135,190,74,66,188,130,162,104,144,103,105,64,199,193,239,81,19,141,204,166,231,218,203,124,92,55,56,167,157,19,136,211,25,246,188,175,89,166,88,37,31,159,102,247,176,91,20,114,144,91,45,169,121,79,13,57,152,199,119,174,176,182,114,63,192,39,118,241,229,166,200,60,180,221,72,30,122,104,3,59,200,193,142,125,113,65,249,218,206,139,161,246,7,84,83,243,229,139,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b0a82eba-e0ad-4ba7-bced-e8d42f2a5640"));
		}

		#endregion

	}

	#endregion

}

