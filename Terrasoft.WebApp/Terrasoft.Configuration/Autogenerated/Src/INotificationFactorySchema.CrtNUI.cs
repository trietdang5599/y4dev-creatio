namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: INotificationFactorySchema

	/// <exclude/>
	public class INotificationFactorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationFactorySchema(INotificationFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("105f1ef7-143f-4c69-82ab-4aee819c63e5");
			Name = "INotificationFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,144,207,10,194,48,12,198,207,14,246,14,197,147,94,214,7,112,238,50,16,118,217,201,23,136,93,42,5,151,142,180,19,134,248,238,182,115,243,15,83,200,33,77,242,251,190,164,4,45,186,14,20,138,35,50,131,179,218,103,165,37,109,206,61,131,55,150,210,228,150,38,171,16,82,74,145,187,190,109,129,135,98,122,87,228,145,117,164,181,101,161,24,3,66,103,65,214,27,109,212,200,139,142,237,213,52,200,217,172,33,63,68,186,254,116,49,74,152,151,78,85,127,176,7,80,222,242,16,230,226,14,139,13,198,66,25,77,177,249,239,185,52,125,86,58,96,104,5,133,251,247,107,117,1,231,234,144,174,139,50,166,99,57,203,229,56,243,70,24,125,207,228,138,250,167,87,46,231,126,4,190,14,153,182,172,200,121,32,133,27,231,57,254,211,203,118,187,11,200,61,77,66,60,0,59,161,37,242,145,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("105f1ef7-143f-4c69-82ab-4aee819c63e5"));
		}

		#endregion

	}

	#endregion

}

