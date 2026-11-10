namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EmailUserTaskAppEventListenerSchema

	/// <exclude/>
	public class EmailUserTaskAppEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailUserTaskAppEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailUserTaskAppEventListenerSchema(EmailUserTaskAppEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b705c5b2-4b1a-4681-ad77-4eae6a95afd7");
			Name = "EmailUserTaskAppEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("da7de29a-d2b3-4248-bf8e-b7a592dc81f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,144,193,106,2,65,12,134,207,187,176,239,16,240,210,94,124,0,61,137,236,65,168,40,168,244,60,206,198,117,112,55,179,36,89,17,138,239,110,58,91,139,80,90,138,167,33,201,255,255,95,38,228,90,148,206,121,132,45,50,59,137,7,29,207,35,227,120,205,209,163,136,21,116,8,117,207,78,67,164,34,255,40,242,34,207,122,9,84,63,56,222,113,111,194,182,141,52,77,243,17,99,109,114,152,55,78,100,2,101,235,66,179,19,228,173,147,211,172,235,202,51,146,190,5,81,36,228,100,232,250,125,19,60,248,79,253,223,114,152,192,226,103,68,102,123,101,223,216,37,234,49,86,6,94,167,216,68,184,35,206,49,84,176,34,139,216,168,99,125,185,103,217,63,21,47,10,126,120,95,33,37,94,127,241,150,84,61,227,220,216,69,109,193,167,201,95,254,127,211,71,72,213,112,19,171,134,222,99,171,200,175,55,78,133,104,78,0,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b705c5b2-4b1a-4681-ad77-4eae6a95afd7"));
		}

		#endregion

	}

	#endregion

}

