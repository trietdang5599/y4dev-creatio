namespace Terrasoft.Configuration
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Store;
	using Terrasoft.Web.Common;
	using Terrasoft.Web.Common.ServiceRouting;
	using System.Web.SessionState;
	using Terrasoft.Common;

	#region Class: CurrentUserService

	/// <summary>
	/// Service for getting information about current user.
	/// </summary>
	/// <remarks>This service is accessible for external users, so it shouldn't get or set any sensitive information.
	/// </remarks>
	[ServiceContract]
	[DefaultServiceRoute, SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CurrentUserService : BaseService, IReadOnlySessionState
	{

		#region Class: UserCultureInfo

		/// <summary>
		/// POCO class for user's culture settings.
		/// </summary>
		[DataContract]
		public class UserCultureInfo
		{
			[DataMember(Name = "timeZoneCode")]
			public string TimeZoneCode { get; set; }

			[DataMember(Name = "timeZoneName")]
			public string TimeZoneName { get; set; }

			[DataMember(Name = "timeZoneId")]
			public Guid TimeZoneId { get; set; }

			[DataMember(Name = "cultureId")]
			public Guid CultureId { get; set; }

			[DataMember(Name = "cultureName")]
			public string CultureName { get; set; }

			[DataMember(Name = "cultureLanguage")]
			public string CultureLanguage { get; set; }

			[DataMember(Name = "dateTimeFormatId")]
			public Guid DateTimeFormatId { get; set; }

			[DataMember(Name = "dateTimeFormatName")]
			public string DateTimeFormatName { get; set; }
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get the current user's culture information.
		/// </summary>
		/// <returns>Culture information for the current user.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "cultureInfo")]
		public UserCultureInfo GetCurrentUserCulture() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit") {
				UseAdminRights = false,
				IgnoreDisplayValues = true
			};
			esq.PrimaryQueryColumn.IsVisible = false;
			var cultureIdColumn = esq.AddColumn("SysCulture.Id");
			var cultureNameColumn = esq.AddColumn("SysCulture.Name");
			var cultureLanguageColumn = esq.AddColumn("SysCulture.Language.Name");
			var timeZoneCodeColumn = esq.AddColumn("TimeZoneId");
			var timeZoneIdColumn = esq.AddColumn("[TimeZone:Code:TimeZoneId].Id");
			var timeZoneNameColumn = esq.AddColumn("[TimeZone:Code:TimeZoneId].Name");
			var dateTimeFormatIdColumn = esq.AddColumn("DateTimeFormat.Id");
			var dateTimeFormatNameColumn = esq.AddColumn("DateTimeFormat.Name");
			var entity = esq.GetEntity(UserConnection, UserConnection.CurrentUser.Id);
			if (entity == null) {
				return null;
			}
			return new UserCultureInfo {
				TimeZoneId = entity.GetTypedColumnValue<Guid>(timeZoneIdColumn.Name),
				TimeZoneCode = entity.GetTypedColumnValue<string>(timeZoneCodeColumn.Name),
				TimeZoneName = entity.GetTypedColumnValue<string>(timeZoneNameColumn.Name),
				CultureId = entity.GetTypedColumnValue<Guid>(cultureIdColumn.Name),
				CultureName = entity.GetTypedColumnValue<string>(cultureNameColumn.Name),
				CultureLanguage = entity.GetTypedColumnValue<string>(cultureLanguageColumn.Name),
				DateTimeFormatId = entity.GetTypedColumnValue<Guid>(dateTimeFormatIdColumn.Name),
				DateTimeFormatName = entity.GetTypedColumnValue<string>(dateTimeFormatNameColumn.Name)
			};
		}

		/// <summary>
		/// Gets the current user's home page code.
		/// </summary>
		/// <returns>Home page code.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "homePage")]
		public string GetCurrentUserHomePage() {
			var userId = UserConnection.CurrentUser.Id;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit") {
				UseAdminRights = false,
				IgnoreDisplayValues = true,
				Cache = UserConnection.SessionCache.WithLocalCaching("HomePage"),
				CacheItemName = $"HomePage_{userId}"
			};
			esq.PrimaryQueryColumn.IsVisible = false;
			var column = esq.AddColumn("HomePage.Id");
			var entity = esq.GetEntity(UserConnection, userId);
			var pageId = entity?.GetTypedColumnValue<Guid>(column.Name);
			return pageId.IsNullOrEmpty() ? string.Empty : pageId.ToString();
		}

		/// <summary>
		/// Gets the current user's mobile home page code.
		/// </summary>
		/// <returns>Mobile home page code.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "homePage")]
		public string GetCurrentUserMobileHomePage() {
			var userId = UserConnection.CurrentUser.Id;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit") {
				UseAdminRights = false,
				IgnoreDisplayValues = true,
				Cache = UserConnection.SessionCache.WithLocalCaching("MobileHomePage"),
				CacheItemName = $"MobileHomePage_{userId}"
			};
			esq.PrimaryQueryColumn.IsVisible = false;
			var column = esq.AddColumn("MobileHomePage.UId");
			var entity = esq.GetEntity(UserConnection, userId);
			var pageId = entity?.GetTypedColumnValue<Guid>(column.Name);
			return pageId.IsNullOrEmpty() ? string.Empty : pageId.ToString();
		}

		/// <summary>
		/// Gets is the current user synchronized with LDAP.
		/// </summary>
		/// <returns><c>true</c> if synchronized.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "isSynchronized")]
		public bool GetIsCurrentUserSynchronizedWithLdap() {
			var select = (Select)new Select(UserConnection)
					.Column("SynchronizeWithLDAP")
				.From("SysAdminUnit")
				.Where("Id").IsEqual(Column.Parameter(UserConnection.CurrentUser.Id));
			return select.ExecuteScalar<bool>();
		}

		#endregion

	}

	#endregion

}

