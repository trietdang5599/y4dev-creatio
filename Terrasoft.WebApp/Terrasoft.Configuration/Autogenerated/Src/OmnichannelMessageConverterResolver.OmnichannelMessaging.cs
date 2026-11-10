namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: OmnichannelMessageConverterResolver

	/// <summary>
	/// Resolves and caches omnichannel message macros converters.
	/// </summary>
	public class OmnichannelMessageConverterResolver
	{
		#region Fields: Private

		private OmnichannelMessageMacrosStore _store;
		private readonly UserConnection _userConnection;
		private readonly Dictionary<Guid, IOmnichannelMessageMacrosConverter> _convertersCache = new Dictionary<Guid, IOmnichannelMessageMacrosConverter>();

		#endregion

		#region Properties: Private

		/// <summary>
		/// Lazy-loaded store for omnichannel message macros.
		/// </summary>
		private OmnichannelMessageMacrosStore Store => _store ?? (_store = new OmnichannelMessageMacrosStore(_userConnection));

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="OmnichannelMessageConverterResolver"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public OmnichannelMessageConverterResolver(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Retrieves the converter for the specified macros ID, using cache if available.
		/// </summary>
		/// <param name="macrosId">The identifier of the macros.</param>
		/// <returns>The corresponding <see cref="IOmnichannelMessageMacrosConverter"/> or null if not found.</returns>
		public IOmnichannelMessageMacrosConverter GetConverterByMacros(Guid macrosId) {
			if (_convertersCache.TryGetValue(macrosId, out var cachedConverter)) {
				return cachedConverter;
			}
			OmnichannelMessageMacros macros = Store.GetById(macrosId);
			if (macros == null) {
				return null;
			}
			if (!ClassFactory.TryGet(macros.ConvertorClass, out IOmnichannelMessageMacrosConverter converter, new ConstructorArgument("userConnection", _userConnection))) {
				return null;
			}
			_convertersCache[macrosId] = converter;
			return converter;
		}

		#endregion
	}

	#endregion

}

