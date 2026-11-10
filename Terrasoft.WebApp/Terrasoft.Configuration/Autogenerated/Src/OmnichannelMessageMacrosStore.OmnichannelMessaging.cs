namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Common;
	using Terrasoft.Core.Store;
	using System.Collections.Generic;

	#region Class: MessageMacrosConsts

	/// <summary>
	/// Contains GUID constants representing different types of message macros in the omnichannel system.
	/// </summary>
	public static class MessageMacrosConsts
	{
		/// <summary>
		/// GUID for the Chat Completed macro.
		/// </summary>
		public static readonly Guid ChatCompleted = new Guid("013DCE2C-6680-469C-B256-F41924FD2D78");

		/// <summary>
		/// GUID for the Chat Transferred to Queue macro.
		/// </summary>
		public static readonly Guid ChatTransferredToQueue = new Guid("97E04420-02CB-47D2-981B-120C10F9313A");

		/// <summary>
		/// GUID for the Chat Transferred to Agent macro.
		/// </summary>
		public static readonly Guid ChatTransferredToAgent = new Guid("9E436BB6-C2D7-45C4-AD1D-16161DBD20EB");

		/// <summary>
		/// GUID for the Chat Completed by Agent macro.
		/// </summary>
		public static readonly Guid ChatCompletedByAgent = new Guid("A63C3628-C932-49DB-936C-C9D67679733F");

		/// <summary>
		/// GUID for the Chat Completed by End User macro.
		/// </summary>
		public static readonly Guid ChatCompletedByEndUser = new Guid("B8E7F3A1-5D42-4C9E-A1B6-3E8F7D2C9A4E");
	}

	#endregion

	#region Class: OmnichannelMessageMacros

	/// <summary>
	/// Represents an omnichannel message macros.
	/// </summary>
	[Serializable]
	public class OmnichannelMessageMacros
	{
		/// <summary>
		/// Identifier of the message macros.
		/// </summary>
		public Guid Id {
			get; set;
		}

		/// <summary>
		/// Macros string.
		/// </summary>
		public string Macros {
			get; set;
		}

		/// <summary>
		/// Name of the class used for converting the macros.
		/// </summary>
		public string ConvertorClass {
			get; set;
		}
	}

	#endregion

	#region Class: OmnichannelMessageMacrosStore

	/// <summary>
	/// A store for omnichannel message macros, providing functionality to load and cache message macros.
	/// </summary>
	public class OmnichannelMessageMacrosStore
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Fields: Public

		public const string CacheKey = "OmniMessageMacrosCache";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="OmnichannelMessageMacrosStore"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public OmnichannelMessageMacrosStore(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Loads message macroses from the database.
		/// </summary>
		/// <returns>A list of <see cref="OmnichannelMessageMacros"/>.</returns>
		private List<OmnichannelMessageMacros> LoadMessageMacroses() {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OmniMessageMacros");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Macros");
			esq.AddColumn("ConvertorClass");
			return esq.GetEntityCollection(_userConnection)
			   .Select(entity => new OmnichannelMessageMacros {
				   Id = entity.PrimaryColumnValue,
				   Macros = entity.GetTypedColumnValue<string>("Macros"),
				   ConvertorClass = entity.GetTypedColumnValue<string>("ConvertorClass")
			   }).ToList();
		}

		/// <summary>
		/// Retrieves message macroses, either from cache or by loading them from the database.
		/// </summary>
		/// <returns>A list of <see cref="OmnichannelMessageMacros"/>.</returns>
		private List<OmnichannelMessageMacros> GetMessageMacroses() {
			var cache = _userConnection.SessionCache.WithLocalCaching();
			var cachedMacros = cache.GetValue<List<OmnichannelMessageMacros>>(CacheKey);
			if (cachedMacros != null && cachedMacros.Count > 0) {
				return cachedMacros;
			}
			var messageMacrosCollection = LoadMessageMacroses();
			cache.SetOrRemoveValue(CacheKey, messageMacrosCollection);
			return messageMacrosCollection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets a message macro by its unique identifier.
		/// </summary>
		/// <param name="id">The identifier of the macro.</param>
		/// <returns>The <see cref="OmnichannelMessageMacros"/> associated with the given ID, or null if not found.</returns>
		public virtual OmnichannelMessageMacros GetById(Guid id) {
			return GetMessageMacroses().FirstOrDefault(macros => macros.Id == id);
		}

		/// <summary>
		/// Clears the cached message macros.
		/// </summary>
		public void ClearCache() {
			_userConnection.SessionCache.WithLocalCaching().SetOrRemoveValue(CacheKey, null);
		}

		#endregion
	}

	#endregion

}

