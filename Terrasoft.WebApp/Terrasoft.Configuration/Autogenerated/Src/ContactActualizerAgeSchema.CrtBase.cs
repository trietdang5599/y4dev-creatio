namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ContactActualizerAgeSchema

	/// <exclude/>
	public class ContactActualizerAgeSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactActualizerAgeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactActualizerAgeSchema(ContactActualizerAgeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b6997510-8ca5-4b43-92fb-c0f6cd54daae");
			Name = "ContactActualizerAge";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("79c177f7-ba6c-471b-a777-73cb1e762283");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,83,203,110,194,48,16,60,131,196,63,172,224,66,165,10,245,76,148,74,16,122,108,139,212,242,1,198,217,4,171,198,142,252,168,74,17,255,222,205,131,64,66,210,30,122,203,238,206,204,62,60,81,108,143,54,99,28,225,29,141,97,86,39,110,22,105,149,136,212,27,230,132,86,163,225,113,52,28,120,43,84,218,128,24,12,70,67,170,76,12,166,4,3,136,36,179,118,14,68,118,140,187,5,119,158,73,241,141,139,20,11,92,230,183,82,112,224,57,234,6,100,8,5,115,88,50,139,141,28,241,142,5,187,110,67,76,235,140,231,78,155,57,172,11,205,18,80,233,119,41,79,55,22,13,21,20,242,124,35,240,141,240,142,26,111,169,241,180,157,62,194,233,159,210,247,32,148,131,104,231,213,199,27,17,202,240,153,125,173,48,53,136,175,201,154,25,38,37,74,97,247,87,208,181,209,28,109,126,240,21,74,118,232,159,47,159,109,32,18,152,214,29,224,17,30,206,133,129,219,9,59,187,148,194,203,32,65,1,56,213,252,238,145,110,197,122,112,97,207,78,237,54,93,219,245,76,220,70,133,157,167,185,106,80,61,213,4,85,92,58,165,105,27,34,102,104,156,64,114,40,125,59,186,33,198,213,235,158,67,208,159,228,111,17,35,144,195,114,187,63,41,39,220,225,133,254,16,8,31,97,92,189,255,56,248,157,181,201,98,230,176,228,70,90,250,189,170,21,200,48,127,177,75,222,138,20,90,220,165,48,110,151,231,199,65,231,170,229,1,154,201,211,15,163,255,39,212,222,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b6997510-8ca5-4b43-92fb-c0f6cd54daae"));
		}

		#endregion

	}

	#endregion

}

