namespace Creatio.Copilot
{
	using Terrasoft.Core;

	/// <summary>
	/// Factory that creates a fully-resolved <see cref="ICopilotSessionManager"/> bound to a
	/// supplied <see cref="UserConnection"/>.
	/// </summary>
	/// <remarks>
	/// Resolving <see cref="ICopilotSessionManager"/> directly with a non-inheriting constructor
	/// argument does not propagate the connection to nested dependencies (e.g. the history storage),
	/// which then fall back to the ambient connection binding. That binding is absent on non-HTTP /
	/// background / actor threads, making the resolution throw there. This factory composes the
	/// session manager with the supplied connection propagated to every nested dependency, so it is
	/// deterministic in any execution context.
	/// </remarks>
	public interface ICopilotSessionManagerFactory
	{
		/// <summary>
		/// Creates a fully-resolved <see cref="ICopilotSessionManager"/> bound to
		/// <paramref name="userConnection"/>.
		/// </summary>
		/// <param name="userConnection">The user connection propagated to the session manager and all
		/// of its nested dependencies.</param>
		/// <returns>A session manager that does not rely on an ambient <see cref="UserConnection"/>
		/// binding.</returns>
		ICopilotSessionManager Create(UserConnection userConnection);
	}
}

