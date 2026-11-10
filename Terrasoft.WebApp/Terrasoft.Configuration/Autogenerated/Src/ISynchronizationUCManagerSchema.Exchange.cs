namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ISynchronizationUCManagerSchema

	/// <exclude/>
	public class ISynchronizationUCManagerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISynchronizationUCManagerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISynchronizationUCManagerSchema(ISynchronizationUCManagerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e35281b7-8278-4872-974a-551e3823b083");
			Name = "ISynchronizationUCManager";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("77ff850a-3558-415d-9b34-1a36190e74f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,84,193,110,219,48,12,61,167,64,255,129,72,47,27,80,216,247,197,53,48,4,65,144,195,134,97,93,119,103,21,218,17,96,209,25,37,13,200,130,254,251,36,185,201,108,183,14,122,232,142,38,31,31,31,31,41,51,26,178,123,84,4,63,72,4,109,91,185,108,217,114,165,107,47,232,116,203,215,87,199,235,171,153,183,154,107,184,63,88,71,102,49,250,14,248,166,33,21,193,54,91,19,147,104,245,15,211,167,21,154,138,103,43,118,218,105,178,175,1,238,15,28,9,67,230,70,168,14,109,96,195,142,164,10,170,63,193,38,102,119,210,178,254,147,244,62,44,191,32,99,77,146,10,246,254,177,209,10,244,9,127,9,62,59,166,146,89,158,231,80,88,111,12,202,161,60,5,190,83,131,142,182,33,65,4,74,168,186,155,143,169,130,109,78,162,21,50,207,75,208,102,223,144,33,118,41,7,28,124,206,206,236,121,159,222,58,233,204,156,96,251,26,74,225,8,53,185,5,60,93,148,232,188,176,5,111,73,44,184,29,58,216,161,133,98,143,130,38,40,78,26,238,230,20,157,62,68,137,118,216,17,84,104,137,202,129,222,90,104,180,117,19,122,83,36,145,14,25,203,158,55,171,115,19,205,214,33,43,202,138,60,213,188,78,129,233,124,230,229,200,4,232,226,80,181,50,61,199,101,230,232,70,240,146,233,185,67,79,228,195,48,117,81,172,116,230,150,177,230,100,84,176,154,245,47,79,193,176,40,166,210,209,247,100,92,145,159,240,145,96,179,98,111,72,240,177,161,98,237,245,182,132,53,185,241,29,198,165,125,232,108,131,110,180,219,116,18,159,85,207,136,91,24,106,134,225,116,31,23,111,56,15,121,190,228,174,73,152,165,241,134,225,55,54,126,234,64,255,199,194,223,121,45,47,148,44,211,88,63,227,84,35,134,254,102,94,96,227,102,190,161,132,1,211,131,79,239,240,156,28,175,231,45,187,232,30,236,13,241,182,251,117,197,207,167,191,229,7,134,54,117,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e35281b7-8278-4872-974a-551e3823b083"));
		}

		#endregion

	}

	#endregion

}

