namespace Creatio.Copilot
{
	using System;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	/// <summary>
	/// Default <see cref="ICopilotSessionManagerFactory"/> implementation.
	/// </summary>
	/// <inheritdoc cref="ICopilotSessionManagerFactory"/>
	[DefaultBinding(typeof(ICopilotSessionManagerFactory))]
	public class CopilotSessionManagerFactory : ICopilotSessionManagerFactory
	{

		#region Methods: Public

		/// <inheritdoc/>
		public ICopilotSessionManager Create(UserConnection userConnection) {
			if (userConnection == null) {
				throw new ArgumentNullException(nameof(userConnection));
			}
			// Compose the session manager graph explicitly, threading the supplied connection into every
			// dependency. Building the graph here (instead of resolving ICopilotSessionManager with a
			// non-inheriting constructor argument) guarantees no nested dependency falls back to the
			// ambient UserConnection binding, so resolution is deterministic on non-HTTP / background /
			// actor threads where no ambient connection exists.
			var historyStorage = new CopilotHistoryStorage(userConnection,
				ClassFactory.Get<IDocumentTool>(), new CopilotIntentsStorage(userConnection));
			return new CopilotSessionManager(userConnection, historyStorage,
				new CopilotPromptFactory(userConnection),
				new DefaultCopilotPromptVariableResolverFactory(userConnection));
		}

		#endregion

	}
}

