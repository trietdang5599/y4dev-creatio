namespace Terrasoft.Configuration
{
	using Terrasoft.Core;

	#region Class: ChatLanguageIterator

	/// <summary>
	/// Iterator for listing by OmniChat languages.
	/// </summary>
	public class ChatLanguageIterator : BaseLanguageIterator
	{
		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="ChatLanguageIterator"/>. 
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ChatLanguageIterator(UserConnection userConnection)
			: base(userConnection)		{
			LanguageRules = new ILanguageRule[] {
				new OmniChatLanguageRule(UserConnection),
				new ContactInOmniChatLanguageRule(UserConnection),
				new ChannelInOmniChatLanguageRule(UserConnection),
				new DefaultLanguageRule(UserConnection),
			};
		}

		#endregion

	}

	#endregion

}
