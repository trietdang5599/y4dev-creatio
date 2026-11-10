namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: TagListenerSchema

	/// <exclude/>
	public class TagListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TagListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TagListenerSchema(TagListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f257232b-0e51-4712-b42a-73d1a3575eef");
			Name = "TagListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,84,193,110,219,48,12,61,167,64,255,129,115,15,181,129,66,190,183,73,128,54,72,219,0,93,59,44,217,46,195,14,138,205,56,26,108,201,144,228,116,217,208,127,47,37,217,169,147,165,235,197,134,40,242,241,145,124,148,228,21,154,154,103,8,11,212,154,27,181,178,108,162,228,74,20,141,230,86,40,121,122,242,247,244,100,208,24,33,11,152,111,141,197,234,234,224,204,230,152,53,90,216,237,219,69,31,171,170,148,60,126,163,145,77,165,21,86,160,249,208,129,77,55,40,237,251,126,183,60,179,74,7,36,242,57,211,88,16,121,152,148,220,152,75,88,240,226,65,16,87,137,218,95,167,105,10,67,211,84,21,215,219,113,123,238,28,96,165,52,156,83,196,57,160,75,190,5,244,169,89,23,151,246,2,127,120,126,91,79,174,3,136,231,217,26,43,254,72,157,133,17,68,132,20,37,63,201,183,110,150,165,200,32,115,148,250,140,224,18,110,184,193,35,72,20,228,154,191,171,230,51,218,181,202,169,158,47,90,108,184,69,95,203,160,14,7,88,42,85,194,204,76,26,173,9,227,155,65,125,207,205,83,141,97,142,119,154,75,139,24,79,219,154,252,47,1,143,63,16,43,136,63,5,19,163,192,235,188,18,242,171,40,214,214,116,30,3,141,182,209,18,172,110,240,202,91,94,252,247,174,17,57,88,94,92,103,25,26,51,203,169,226,22,231,14,237,98,91,99,62,81,101,83,201,239,188,108,112,232,188,199,177,107,73,231,31,37,1,109,70,182,144,241,30,75,226,236,48,247,206,163,48,203,48,103,143,62,60,140,25,199,129,234,64,226,51,144,136,13,145,117,222,215,186,104,42,98,21,71,13,53,133,46,36,102,174,37,209,5,188,213,220,179,39,45,167,174,228,253,44,108,194,229,68,35,117,60,238,213,253,14,20,235,77,131,205,242,0,252,18,230,118,134,50,15,131,109,207,255,76,217,11,38,92,30,42,214,27,238,185,204,75,52,64,65,66,82,6,235,22,163,47,90,182,11,77,15,99,135,53,215,188,2,73,42,29,69,134,168,160,142,198,94,125,16,78,108,152,122,151,227,17,24,141,23,107,36,74,136,144,105,92,141,162,32,172,27,164,245,65,143,67,109,55,81,58,118,212,44,151,244,194,100,74,90,46,164,35,105,41,214,51,132,156,91,190,151,170,93,19,181,161,5,23,57,194,70,145,194,158,228,172,43,48,86,203,95,212,220,150,229,5,28,205,11,216,9,119,195,117,215,146,17,180,234,79,66,236,213,155,246,63,92,155,118,95,118,235,96,215,90,61,131,19,90,247,250,77,127,103,88,187,144,152,116,71,60,217,173,210,21,183,177,243,121,80,25,47,197,31,190,44,113,238,47,105,7,246,222,47,146,98,219,64,182,195,97,143,202,235,142,112,88,168,62,74,46,218,247,36,233,239,224,146,94,15,214,239,80,215,26,252,159,222,130,117,223,248,242,10,28,36,160,150,15,6,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateTagRightsExceptionLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateTagRightsExceptionLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("122baa28-9059-4d1e-ed30-fc219fb1da77"),
				Name = "TagRightsException",
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				CreatedInSchemaUId = new Guid("f257232b-0e51-4712-b42a-73d1a3575eef"),
				ModifiedInSchemaUId = new Guid("f257232b-0e51-4712-b42a-73d1a3575eef")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f257232b-0e51-4712-b42a-73d1a3575eef"));
		}

		#endregion

	}

	#endregion

}

