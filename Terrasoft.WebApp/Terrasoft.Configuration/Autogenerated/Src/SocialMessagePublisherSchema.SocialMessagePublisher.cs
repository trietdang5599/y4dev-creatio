namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SocialMessagePublisherSchema

	/// <exclude/>
	public class SocialMessagePublisherSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SocialMessagePublisherSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SocialMessagePublisherSchema(SocialMessagePublisherSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("338fe51c-5d19-4505-9d2c-889953ea22f6");
			Name = "SocialMessagePublisher";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("203eb078-3e33-4e60-b9e9-a0b134c55d99");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,144,77,106,195,48,16,133,215,54,248,14,67,186,73,33,228,0,78,219,69,146,38,171,150,130,219,3,76,148,137,35,144,165,48,35,45,140,201,221,43,201,129,226,166,5,129,244,70,223,188,249,9,162,109,11,77,47,158,186,229,198,25,67,202,107,103,101,185,39,75,172,213,170,42,67,70,62,137,25,197,157,124,164,152,98,184,42,45,118,36,23,84,52,249,180,39,221,6,198,228,82,149,67,85,22,241,60,48,181,81,195,198,160,72,13,141,83,26,205,27,137,96,75,31,225,96,180,156,137,147,101,113,73,74,129,74,224,63,28,212,176,70,161,251,244,98,200,22,63,213,226,28,158,131,242,142,107,200,156,26,129,91,145,191,237,231,95,66,28,83,237,184,9,8,19,185,128,173,206,15,228,254,41,186,199,213,44,96,188,95,128,172,215,190,223,105,50,71,217,162,199,199,84,172,168,225,16,219,157,255,246,185,131,97,200,248,107,142,55,234,76,29,190,199,13,195,51,204,38,157,206,86,137,187,222,102,37,123,28,199,205,122,140,78,131,215,111,153,210,9,18,228,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("338fe51c-5d19-4505-9d2c-889953ea22f6"));
		}

		#endregion

	}

	#endregion

}

