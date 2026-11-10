namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EntityActivitiesOwnerInfoSchema

	/// <exclude/>
	public class EntityActivitiesOwnerInfoSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EntityActivitiesOwnerInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EntityActivitiesOwnerInfoSchema(EntityActivitiesOwnerInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f495a412-7027-454b-a334-1948a1100b0a");
			Name = "EntityActivitiesOwnerInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,146,209,106,131,48,20,134,175,43,248,14,7,122,175,247,237,24,140,50,134,55,109,193,189,64,150,156,216,128,73,36,39,86,68,250,238,211,164,117,50,70,183,238,70,200,201,241,255,190,156,196,48,141,212,48,142,240,142,206,49,178,210,103,59,107,164,170,90,199,188,178,38,77,134,52,89,181,164,76,5,101,79,30,245,54,77,198,202,218,97,53,110,195,174,102,68,27,120,53,94,249,254,133,123,117,86,94,33,29,58,131,174,48,210,134,230,60,207,225,137,90,173,153,235,159,175,235,210,91,135,4,106,236,113,58,160,192,32,71,162,177,7,188,5,126,98,166,66,176,83,16,88,9,44,102,247,217,45,47,95,4,54,237,71,173,56,240,73,230,158,203,106,8,62,179,253,209,217,6,221,212,180,129,99,200,136,251,223,133,67,161,16,56,38,75,21,125,48,80,178,185,123,169,115,243,121,107,149,184,234,20,2,6,168,208,111,129,166,207,229,23,142,156,204,3,199,214,98,62,123,156,198,31,152,135,90,196,83,255,151,106,176,123,156,186,199,238,81,234,126,124,127,95,211,4,226,39,212,236,62,138,188,155,30,99,28,107,25,126,8,41,63,32,215,104,68,188,233,176,142,213,101,113,149,38,151,79,237,44,141,72,3,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f495a412-7027-454b-a334-1948a1100b0a"));
		}

		#endregion

	}

	#endregion

}

