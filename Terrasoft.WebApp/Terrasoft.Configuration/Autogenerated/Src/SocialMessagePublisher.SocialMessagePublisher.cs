using System.Collections.Generic;
using Terrasoft.Core;

namespace Terrasoft.Configuration
{
	
	#region Class: SocialMessagePublisher

	public class SocialMessagePublisher : BaseMessagePublisher
	{

		#region Constructor: Public

		public SocialMessagePublisher(UserConnection userConnection, Dictionary<string, string> entityFieldsData)
			: base(userConnection, entityFieldsData) {
			EntitySchemaName = "SocialMessage";
		}

		#endregion

	}

	#endregion

}
