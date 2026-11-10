using System.Collections.Generic;
using Terrasoft.Core;

namespace Terrasoft.Configuration
{
	
	#region Class: CallMessagePublisher

	public class CallMessagePublisher : BaseMessagePublisher
	{

		#region Constructor: Public

		public CallMessagePublisher(UserConnection userConnection, Dictionary<string, string> entityFieldsData)
			: base(userConnection, entityFieldsData) {
			EntitySchemaName = "Activity";
		}

		#endregion

	}

	#endregion

}
