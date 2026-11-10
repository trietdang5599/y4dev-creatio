namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Configuration.ESN;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Messaging.Common;

	#region Class: FeedNotifier

	[DefaultBinding(typeof(FeedNotifier))]
	public class FeedNotifier {

		#region Fields: Private

		readonly ILog _logger = LogManager.GetLogger("FeedNotifier");

		#endregion

		#region Properties: Private

		private Entity Entity { get; }

		private UserConnection UserConnection { get; }

		#endregion

		#region Constructors: Public

		public FeedNotifier(Entity entity) {
			Entity = entity ?? throw new ArgumentNullException(nameof(entity));
			UserConnection = Entity.UserConnection;
		}

		#endregion

		#region Methods: Public

		public virtual void SendUpdateDeleteSocialMessage(string operation) {
			try {
				if (operation.IsNullOrEmpty()) {
					_logger.Info("SocialMessage notification without operation impossible.");
					return;
				}
				SimpleMessage simpleMessage = CreateSimpleMessage(operation);
				List<Guid> subscriptors = GetSubscriptors();
				MsgChannelManager manager = MsgChannelManager.Instance;
				manager.Post(subscriptors, simpleMessage);
			} catch (Exception ex) {
				_logger.Error("Error occurred during send SocialMessage notification.", ex);
			}
		}

		public SimpleMessage CreateSimpleMessage(string operation) {
			var socialMessageId = Entity.GetTypedColumnValue<Guid>("Id");
			var sysAdminUnitId = UserConnection.CurrentUser.Id;
			var entityId = GetEntityId();
			var parentMessageId = Entity.GetTypedColumnValue<Guid>("ParentId");
			var entityName = GetTargetSchemaName();
			return new SimpleMessage {
				Id = socialMessageId,
				Header = {
					Sender = "UpdateSocialMessage"
				},
				Body = $"{{ \"sysAdminUnitId\": \"{sysAdminUnitId}\"," +
				$"\"channelId\": \"{entityId}\"," +
				$"\"operation\": \"{operation}\"," +
				$"\"parentId\": \"{parentMessageId}\"," +
				$"\"entityName\": \"{entityName}\"}}"
			};
		}

		public string GetTargetSchemaName() {
			Guid entitySchemaUId = GetEntitySchemaUId();
			EntitySchema currentEntitySchema = UserConnection.EntitySchemaManager.GetInstanceByUId(entitySchemaUId);
			string targetSchemaName = currentEntitySchema.Name;
			return targetSchemaName;
		}

		public Guid GetEntitySchemaUId() {
			Guid entitySchemaUId = Entity.GetTypedColumnValue<Guid>("EntitySchemaUId");
			if (entitySchemaUId.IsEmpty()) {
				entitySchemaUId = GetParentEntitySchemaUId(Entity.GetTypedColumnValue<Guid>("ParentId"));
			}
			return entitySchemaUId;
		}

		public Guid GetParentEntitySchemaUId(Guid parentId) {
			Select select = new Select(UserConnection)
					.Column("EntitySchemaUId")
					.From("SocialMessage")
					.Where("Id").IsEqual(Column.Parameter(parentId)) as Select;
			return select.ExecuteScalar<Guid>();
		}

		public Guid GetEntityId() {
			if (!GetIsComment()) {
				return Entity.GetTypedColumnValue<Guid>("EntityId");
			}
			var parentId = Entity.GetTypedColumnValue<Guid>("ParentId");
			Select select = new Select(UserConnection)
				.Column("EntityId")
				.From("SocialMessage")
				.Where("Id").IsEqual(Column.Parameter(parentId)) as Select;
			return select.ExecuteScalar<Guid>();
		}

		public bool GetIsComment() {
			var parentId = Entity.GetTypedColumnValue<Guid>("ParentId");
			return parentId.IsNotEmpty();
		}

		public List<Guid> GetSubscriptors() {
			var channelId = GetEntityId();
			List<Guid> channelSubscriptors = new List<Guid>();
			string roleSubscriptionTable = "SocialSubscription";
			string roleSubscriptionColumnPath = "=[SysUserInRole:SysRole:SysAdminUnit].SysUser.Id";
			List<Guid> roleSubscriptors = GetChannelSubscriptors(channelId, roleSubscriptionTable, roleSubscriptionColumnPath);
			string userSubscriptionTable = "SocialSubscription";
			string userSubscriptionColumnPath = "=[SysUserInRole:SysUser:SysAdminUnit].SysUser.Id";
			List<Guid> userSubscriptors = GetChannelSubscriptors(channelId, userSubscriptionTable, userSubscriptionColumnPath);
			string userUnsubscriptionTable = "SocialUnsubscription";
			string userUnsubscriptionColumnPath = "=[SysUserInRole:SysUser:SysAdminUnit].SysUser.Id";
			List<Guid> userUnsubscriptors = GetChannelSubscriptors(channelId, userUnsubscriptionTable, userUnsubscriptionColumnPath);
			channelSubscriptors.AddRange(roleSubscriptors);
			channelSubscriptors.AddRange(userSubscriptors);
			List<Guid> usersWithNoRightsForMessage = GetUsersWithoutRightsForMessage(channelSubscriptors);
			channelSubscriptors.RemoveAll(subscriptor => userUnsubscriptors.Contains(subscriptor) || usersWithNoRightsForMessage.Contains(subscriptor));
			return channelSubscriptors.Distinct().ToList();
		}

		public List<Guid> GetChannelSubscriptors(Guid channelId, string subscriptionTable, string columnPath) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, subscriptionTable) {
				UseAdminRights = false
			};
			var column = esq.AddColumn(columnPath);
			var currentChannelFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "EntityId", channelId);
			esq.Filters.Add(currentChannelFilter);
			EntityCollection channelSubscriptors = esq.GetEntityCollection(UserConnection);
			var list = new List<Guid>();
			foreach (var subscriptor in channelSubscriptors) {
				list.Add(subscriptor.GetTypedColumnValue<Guid>(column.Name));
			}
			return list;
		}

		public List<Guid> GetUsersWithoutRightsForMessage(List<Guid> channelSubscriptors) {
			var result = new List<Guid>();
			var userAccess = Entity.GetTypedColumnValue<int>("UserAccess");
			if (userAccess == (int)UserAccess.External || !channelSubscriptors.Any()) {
				return result;
			}
			Select select = new Select(UserConnection)
				.Column("Id")
				.From("SysAdminUnit")
				.Where("Id").In(Column.Parameters(channelSubscriptors))
				.And("ConnectionType").IsEqual(Column.Parameter(1)) as Select;
			using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(executor)) {
					while (reader.Read()) {
						result.Add(reader.GetColumnValue<Guid>("Id"));
					}
				}
			}
			return result;
		}

		#endregion

	}

	#endregion

}

