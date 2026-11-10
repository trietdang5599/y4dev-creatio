namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ChatLanguageIteratorSchema

	/// <exclude/>
	public class ChatLanguageIteratorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ChatLanguageIteratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ChatLanguageIteratorSchema(ChatLanguageIteratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bfb32ab4-18f2-0b7b-7c32-952642edc498");
			Name = "ChatLanguageIterator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,82,77,107,194,64,16,61,71,240,63,12,241,162,80,146,187,95,135,218,139,80,104,41,245,84,122,24,183,147,184,176,217,200,126,80,108,241,191,119,118,99,212,168,135,122,8,97,222,188,121,243,102,102,53,86,100,183,40,8,222,201,24,180,117,225,178,69,173,11,89,122,131,78,214,186,223,251,237,247,18,111,165,46,59,20,67,147,126,143,51,3,67,37,211,96,161,208,218,49,44,54,232,158,81,151,30,75,90,58,98,141,218,68,94,158,231,48,181,190,170,208,236,230,135,184,37,64,193,159,146,214,133,38,235,29,188,84,90,6,33,80,7,37,155,181,10,249,153,196,214,175,149,20,32,66,231,155,141,97,12,143,104,233,218,79,18,102,58,89,175,181,117,198,11,78,241,4,175,81,53,122,190,50,221,184,214,210,73,84,242,135,44,104,250,6,201,213,168,121,131,117,193,100,34,16,134,138,89,122,203,80,154,207,51,56,10,231,151,202,211,45,26,172,64,243,77,102,169,183,100,216,153,38,17,206,144,206,87,28,131,56,2,217,52,143,236,88,124,216,196,173,150,195,85,71,7,186,178,163,80,157,140,97,205,107,26,94,164,146,102,75,73,171,248,230,21,79,60,139,51,47,207,193,143,79,104,152,73,72,181,199,59,103,92,152,24,61,156,232,140,58,20,110,169,239,173,219,32,195,234,238,186,39,42,208,171,127,176,247,147,240,219,55,15,97,64,250,171,121,45,49,110,208,46,184,255,3,43,177,157,69,75,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bfb32ab4-18f2-0b7b-7c32-952642edc498"));
		}

		#endregion

	}

	#endregion

}

