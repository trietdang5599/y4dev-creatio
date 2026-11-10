namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IncomingMessageNotifierSchema

	/// <exclude/>
	public class IncomingMessageNotifierSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IncomingMessageNotifierSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IncomingMessageNotifierSchema(IncomingMessageNotifierSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bc6fbb0e-f49b-4d6a-b97a-206ce6b2a400");
			Name = "IncomingMessageNotifier";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("92ff52b6-dfba-4556-90d8-6f4c37f69c5d");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,205,84,77,75,3,49,16,61,111,161,255,97,208,203,246,96,246,238,71,65,43,21,193,47,252,56,137,135,152,157,109,3,187,201,146,100,43,69,250,223,157,77,54,165,182,174,32,136,120,219,236,204,188,121,239,205,36,138,87,104,107,46,16,30,209,24,110,117,225,216,68,171,66,206,26,195,157,212,138,221,86,74,138,57,87,10,75,118,141,214,242,153,84,179,225,224,125,56,72,26,75,159,240,176,180,14,43,170,42,75,20,109,137,101,23,168,208,72,113,180,206,217,4,55,200,166,92,56,109,36,90,202,160,156,125,131,51,170,131,73,201,173,61,132,75,37,116,69,85,161,27,222,104,39,11,137,198,167,102,89,6,199,182,169,42,110,150,227,238,124,143,181,65,139,202,89,16,45,194,129,234,42,160,208,6,194,129,56,148,146,120,18,47,11,252,85,55,14,20,190,65,21,90,176,136,156,109,64,63,159,99,193,155,210,157,73,149,83,125,234,150,53,234,34,189,236,161,55,26,189,80,81,221,188,150,82,4,30,125,66,128,36,246,106,76,90,99,215,142,76,37,150,57,89,114,103,228,130,59,244,22,36,117,56,128,117,52,33,1,87,164,235,120,27,240,170,19,59,142,18,227,143,206,242,100,31,85,30,154,116,231,56,3,154,159,51,77,59,31,234,251,224,91,180,241,174,89,15,239,116,4,158,119,178,221,13,78,188,207,223,115,76,71,237,166,36,171,239,153,93,163,155,107,111,134,247,56,4,253,212,164,154,211,186,185,92,147,241,6,139,147,189,31,237,50,235,27,198,30,100,99,239,119,152,233,66,203,28,78,243,60,210,222,217,132,24,216,182,188,207,27,70,96,233,118,238,166,19,127,45,238,30,43,189,192,223,211,23,240,254,149,68,31,91,174,41,166,107,148,174,54,106,139,154,232,5,65,46,230,208,111,70,124,86,64,170,157,187,22,81,146,152,196,158,234,156,174,110,180,36,88,209,122,241,229,246,119,255,62,95,136,213,7,7,117,179,65,179,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bc6fbb0e-f49b-4d6a-b97a-206ce6b2a400"));
		}

		#endregion

	}

	#endregion

}

