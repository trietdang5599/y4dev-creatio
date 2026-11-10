namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ConsumerInfoSchema

	/// <exclude/>
	public class ConsumerInfoSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ConsumerInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ConsumerInfoSchema(ConsumerInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("12a01026-e84b-495c-b275-01c91bdee21b");
			Name = "ConsumerInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4e5fe717-963e-416c-b3c1-b2bb720a6449");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,144,65,75,196,48,16,133,207,45,244,63,132,221,139,94,250,3,118,241,180,94,100,81,150,173,120,17,15,217,248,90,130,77,82,102,38,66,93,246,191,155,166,42,40,43,130,183,153,247,222,124,225,197,107,7,30,180,129,186,7,145,230,208,74,189,9,190,181,93,36,45,54,248,186,9,198,234,190,42,143,85,89,68,182,190,83,205,200,2,87,239,163,23,235,80,55,160,20,176,111,57,190,174,202,148,91,18,186,180,168,77,175,153,87,42,1,57,58,208,141,111,67,246,31,175,181,232,164,10,105,35,79,73,24,226,161,183,70,153,41,255,35,94,28,243,201,23,115,71,97,0,137,69,2,239,242,217,236,103,230,45,220,1,116,113,151,90,169,43,181,120,193,184,184,156,248,159,15,176,208,212,96,139,81,77,125,138,162,131,172,243,192,31,195,233,119,26,195,16,228,44,176,201,214,63,152,175,32,78,173,206,66,31,102,239,15,234,18,254,121,254,154,188,207,234,119,241,244,14,195,42,56,60,230,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("12a01026-e84b-495c-b275-01c91bdee21b"));
		}

		#endregion

	}

	#endregion

}

