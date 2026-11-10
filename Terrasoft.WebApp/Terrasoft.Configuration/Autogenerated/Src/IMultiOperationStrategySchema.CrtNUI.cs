namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IMultiOperationStrategySchema

	/// <exclude/>
	public class IMultiOperationStrategySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMultiOperationStrategySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMultiOperationStrategySchema(IMultiOperationStrategySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("adc64851-8f11-475d-84ca-1c46bf4d2941");
			Name = "IMultiOperationStrategy";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,145,207,106,196,32,16,198,207,89,216,119,24,182,151,22,74,188,183,169,151,45,44,129,254,57,108,251,0,54,142,97,32,209,116,212,66,40,251,238,213,13,201,210,221,22,68,157,241,247,205,167,142,85,61,250,65,53,8,111,200,172,188,51,161,220,58,107,168,141,172,2,57,187,94,125,175,87,69,244,100,91,216,143,62,96,127,127,22,39,190,235,176,201,176,47,119,104,145,169,73,76,162,174,24,219,148,133,218,6,100,147,76,238,160,126,142,93,160,215,1,167,234,251,144,86,108,199,35,62,196,143,142,26,160,153,254,31,46,242,157,10,33,4,84,62,246,189,226,81,206,137,71,7,110,22,64,26,213,160,88,245,140,6,108,122,234,195,6,109,160,48,190,164,253,70,200,139,83,198,198,177,246,181,78,135,229,226,33,206,77,38,217,101,69,153,103,112,6,166,92,89,137,35,248,183,238,228,37,223,45,125,70,4,210,89,103,8,217,255,146,126,57,210,233,97,203,71,92,251,192,249,255,79,206,183,240,68,62,84,187,72,90,194,82,248,38,183,234,48,181,2,173,158,186,145,195,195,15,147,168,241,51,247,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("adc64851-8f11-475d-84ca-1c46bf4d2941"));
		}

		#endregion

	}

	#endregion

}

