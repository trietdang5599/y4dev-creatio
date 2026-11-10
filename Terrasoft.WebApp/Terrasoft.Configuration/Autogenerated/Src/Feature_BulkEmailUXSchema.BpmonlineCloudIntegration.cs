namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: Feature_BulkEmailUXSchema

	/// <exclude/>
	public class Feature_BulkEmailUXSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public Feature_BulkEmailUXSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public Feature_BulkEmailUXSchema(Feature_BulkEmailUXSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("367fd656-546b-48c6-a198-3648b8f650c7");
			Name = "Feature_BulkEmailUX";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fc1a2769-1cc9-44d3-a1a6-003d1b8450f5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,77,142,49,15,130,48,16,133,103,72,248,15,23,38,93,248,1,18,23,17,19,7,55,72,88,143,114,212,198,210,146,94,59,25,254,187,5,53,58,220,93,242,238,123,47,15,192,224,68,60,163,32,104,200,57,100,59,250,162,178,102,84,50,56,244,202,154,44,125,102,105,18,88,25,9,149,163,85,43,46,241,4,71,141,149,82,71,189,204,210,136,204,161,215,74,128,208,200,12,167,160,31,245,132,74,183,29,28,224,195,223,200,227,128,30,35,188,102,126,29,127,236,110,15,219,39,185,114,109,176,215,52,192,17,188,11,84,110,234,153,88,56,53,175,181,162,158,191,17,6,127,167,95,8,48,121,31,75,49,180,93,190,217,150,184,226,44,47,52,160,120,172,237,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("367fd656-546b-48c6-a198-3648b8f650c7"));
		}

		#endregion

	}

	#endregion

}

