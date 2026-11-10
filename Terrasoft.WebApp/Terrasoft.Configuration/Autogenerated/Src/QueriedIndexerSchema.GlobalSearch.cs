namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: QueriedIndexerSchema

	/// <exclude/>
	public class QueriedIndexerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public QueriedIndexerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public QueriedIndexerSchema(QueriedIndexerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5329f48a-37fa-49fb-9285-1a0aa78ae731");
			Name = "QueriedIndexer";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3c3a921b-299a-4f38-a040-5c0154a25bee");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,82,203,110,194,48,16,60,131,212,127,88,169,151,32,33,127,0,168,23,232,67,61,84,165,60,62,192,196,11,88,50,118,106,175,81,17,226,223,235,216,9,36,85,210,147,229,221,153,241,204,174,53,63,162,43,120,142,176,70,107,185,51,59,98,115,163,119,114,239,45,39,105,52,123,83,102,203,213,10,185,205,15,15,195,203,195,112,224,157,212,251,22,222,34,123,209,36,73,162,155,118,2,250,4,231,70,249,163,222,144,84,157,196,38,148,189,107,129,63,161,31,128,1,250,104,113,31,212,96,174,184,115,19,248,242,104,37,138,136,65,27,17,133,223,42,153,67,94,2,254,244,97,2,51,238,240,134,30,92,34,227,46,106,180,35,235,115,50,54,104,47,162,80,66,84,162,109,185,172,182,182,196,111,143,142,158,57,241,153,151,74,132,151,100,111,107,92,234,13,106,106,156,223,121,133,186,73,106,22,71,17,62,129,109,48,158,253,163,218,77,134,11,92,171,140,161,144,98,182,51,127,32,29,140,40,227,90,67,152,19,138,42,113,125,5,115,10,139,145,2,225,100,164,128,82,184,109,62,75,7,96,60,198,80,119,63,11,76,171,95,159,11,188,217,107,85,131,191,24,239,196,239,225,203,80,240,4,253,179,101,241,172,86,209,104,103,201,0,219,56,180,97,147,58,184,15,207,164,113,15,58,159,31,223,60,247,124,206,240,249,28,113,157,35,91,162,138,180,212,116,175,18,149,88,112,34,180,122,52,237,221,40,235,152,86,51,103,162,118,111,40,85,219,197,235,47,207,28,201,6,184,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5329f48a-37fa-49fb-9285-1a0aa78ae731"));
		}

		#endregion

	}

	#endregion

}

