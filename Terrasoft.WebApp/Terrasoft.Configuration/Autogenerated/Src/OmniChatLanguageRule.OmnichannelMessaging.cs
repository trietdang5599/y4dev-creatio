namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Configuration.Omnichannel.Messaging;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;

	/// <summary>
	/// Class, provides language, from OmniChat by DetectLanguage column.
	/// </summary>
	public class OmniChatLanguageRule : BaseLanguageRule
	{

		#region Constructors: Public

		/// <summary>
		/// Creates instance of <see cref="ContactInOmniChatLanguageRule"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public OmniChatLanguageRule(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Provides language from OmniChat, using Contact.
		/// </summary>
		/// <param name="omniChatId">OmniChat entity identifier.</param>
		/// <inheritdoc />
		public override Guid GetLanguageId(Guid omniChatId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "OmniChat");
			var languageColumnName = esq.AddColumn("Language.Id").Name;
			OmnichatEsqColumnsAppender.AddLoggedColumns(esq);
			Entity omniChatEntity = esq.GetEntity(UserConnection, omniChatId);
			Guid languageId = omniChatEntity.GetTypedColumnValue<Guid>(languageColumnName);
			return languageId;
		}

		#endregion

	}
} 
