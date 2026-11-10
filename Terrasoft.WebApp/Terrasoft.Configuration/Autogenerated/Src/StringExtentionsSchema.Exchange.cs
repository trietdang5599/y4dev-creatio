namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: StringExtentionsSchema

	/// <exclude/>
	public class StringExtentionsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public StringExtentionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public StringExtentionsSchema(StringExtentionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("57b5ada9-5411-44e8-a972-15aef76f4662");
			Name = "StringExtentions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("77ff850a-3558-415d-9b34-1a36190e74f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,145,65,107,131,64,16,133,207,6,242,31,166,73,33,90,68,210,28,122,104,8,4,130,135,66,115,178,208,67,201,97,171,19,93,106,214,176,51,150,22,241,191,119,221,213,148,164,165,212,155,111,222,251,124,51,130,18,7,164,163,72,17,158,80,107,65,213,158,163,77,165,246,50,175,181,96,89,169,40,126,78,198,163,102,60,242,106,146,42,135,228,147,24,15,203,241,200,40,83,141,185,177,192,166,20,68,247,144,176,54,142,248,131,81,117,73,178,30,169,24,181,18,37,16,27,94,10,105,231,253,97,5,227,108,172,255,4,221,34,23,85,102,176,15,61,193,141,47,121,100,73,176,21,244,134,89,124,16,178,244,185,144,52,232,84,213,58,197,0,186,5,60,239,93,104,56,10,205,4,171,126,18,37,199,82,178,63,91,207,130,165,181,200,61,248,214,18,61,162,202,185,128,171,21,44,134,188,167,145,107,173,250,172,11,180,39,114,119,75,3,182,233,151,249,206,141,251,196,245,164,233,198,81,82,191,186,102,254,60,52,165,185,136,182,82,249,139,208,134,251,79,6,65,123,99,159,117,227,88,183,187,118,98,105,237,63,110,240,199,250,223,93,134,229,127,109,115,23,14,199,185,232,115,86,98,138,42,115,191,202,190,59,245,92,52,218,23,87,229,95,141,97,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("57b5ada9-5411-44e8-a972-15aef76f4662"));
		}

		#endregion

	}

	#endregion

}

