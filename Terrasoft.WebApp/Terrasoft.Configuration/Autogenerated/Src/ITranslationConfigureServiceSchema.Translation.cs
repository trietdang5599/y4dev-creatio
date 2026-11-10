namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ITranslationConfigureServiceSchema

	/// <exclude/>
	public class ITranslationConfigureServiceSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITranslationConfigureServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITranslationConfigureServiceSchema(ITranslationConfigureServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2811bd82-3edc-4fba-a9ab-749eda63fb70");
			Name = "ITranslationConfigureService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,82,75,107,194,64,16,62,71,240,63,44,233,69,65,54,247,54,122,104,161,197,130,181,24,193,131,120,88,147,73,26,154,236,166,51,27,33,72,255,123,55,155,71,77,11,182,167,100,191,157,239,49,179,35,69,14,84,136,16,216,22,16,5,169,88,243,7,37,227,52,41,81,232,84,73,190,69,33,41,179,255,227,209,121,60,114,74,74,101,194,130,138,52,228,60,0,60,165,33,172,84,4,217,221,181,75,190,131,163,41,48,37,55,8,137,17,99,75,169,1,99,99,125,203,150,23,38,157,59,180,108,203,241,60,143,249,84,230,185,192,106,209,158,141,201,5,141,133,170,161,49,106,120,188,163,121,23,188,125,43,106,76,52,138,80,79,94,76,255,108,206,220,43,1,220,233,193,48,139,242,152,165,33,75,187,208,127,100,118,206,54,247,175,224,22,120,2,77,93,252,62,125,86,230,146,204,183,85,226,61,219,251,73,247,17,116,137,146,22,62,1,176,16,33,158,15,243,91,169,62,83,180,49,47,172,36,129,235,45,124,175,227,214,98,251,117,1,216,53,96,231,113,176,176,121,170,165,60,169,119,152,172,64,191,169,168,30,208,235,58,216,186,51,182,129,143,18,72,63,42,204,133,54,184,41,93,1,145,72,160,129,248,51,41,57,99,247,42,170,2,93,101,48,40,233,81,190,67,81,20,16,205,106,59,167,203,119,93,212,190,130,243,159,62,235,249,126,163,195,53,105,73,147,105,179,139,159,205,70,130,140,154,165,172,143,6,251,2,10,4,116,11,22,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2811bd82-3edc-4fba-a9ab-749eda63fb70"));
		}

		#endregion

	}

	#endregion

}

