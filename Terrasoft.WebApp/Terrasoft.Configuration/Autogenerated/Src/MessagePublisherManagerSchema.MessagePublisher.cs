namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: MessagePublisherManagerSchema

	/// <exclude/>
	public class MessagePublisherManagerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MessagePublisherManagerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MessagePublisherManagerSchema(MessagePublisherManagerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f427a0bd-0b35-4b26-946c-3c6a5598a4f9");
			Name = "MessagePublisherManager";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7c74fc90-4a57-4e68-9eda-fe0982d1250d");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,82,193,78,2,49,16,61,215,196,127,24,195,101,73,200,126,128,138,198,64,48,28,48,36,106,60,154,186,59,64,117,105,201,180,139,217,16,255,221,105,187,32,187,128,137,137,23,200,204,190,190,55,239,205,104,185,68,187,146,25,194,19,18,73,107,102,46,29,24,61,83,243,146,164,83,70,159,159,109,206,207,68,105,149,158,195,99,101,29,46,175,90,53,227,139,2,51,15,182,233,61,106,36,149,253,96,246,105,9,79,245,211,145,204,156,33,133,150,17,140,233,16,206,153,15,6,133,180,246,18,38,104,173,156,227,180,124,43,148,93,32,77,164,230,146,2,116,229,155,25,100,30,121,26,40,54,1,188,35,30,41,44,152,120,74,106,45,29,70,81,177,138,21,16,202,220,232,162,130,103,139,196,105,232,232,14,94,203,70,93,191,234,160,206,35,107,83,130,129,214,81,233,125,177,80,152,178,150,137,19,159,152,53,105,137,54,53,187,224,215,33,68,107,20,232,195,193,108,66,124,253,62,224,4,221,194,228,63,41,52,67,48,111,239,76,5,247,232,198,236,67,234,12,19,182,227,87,23,162,126,224,195,233,193,80,5,53,73,213,117,252,216,131,248,127,3,51,78,56,183,67,233,228,118,230,181,36,248,52,244,17,238,237,169,90,225,148,204,90,229,72,60,125,88,116,60,130,138,143,200,93,143,95,142,33,111,146,110,112,38,124,19,156,255,233,31,231,244,36,190,78,118,211,214,47,9,93,73,58,190,189,232,131,46,139,2,110,225,142,125,176,109,67,233,128,183,239,112,231,217,227,122,237,205,247,26,238,46,3,201,223,18,63,60,135,181,81,57,212,199,240,31,73,47,91,231,197,65,37,227,246,205,117,247,215,187,167,182,71,25,83,83,51,72,14,24,235,248,182,170,162,13,72,183,118,106,146,175,211,17,197,110,179,201,189,111,222,149,159,177,159,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f427a0bd-0b35-4b26-946c-3c6a5598a4f9"));
		}

		#endregion

	}

	#endregion

}

