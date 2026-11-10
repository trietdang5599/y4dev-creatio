namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;

	#region Interface: IDBExceptionHandler

	/// <summary>
	/// Provides methods for handling database exceptions.
	/// </summary>
	public interface IDBExceptionHandler
	{

		#region Methods: Public

		/// <summary>
		/// Determines whether the specified exception is caused by a foreign key constraint violation.
		/// </summary>
		/// <param name="exception">The exception to evaluate.</param>
		/// <returns>
		/// <c>true</c> if the exception is a foreign key constraint violation; otherwise, <c>false</c>.
		/// </returns>
		bool GetIsForeignKeyException(Exception exception);

		/// <summary>
		/// Enriches the specified exception with additional information about the foreign key constraint violation.
		/// </summary>
		/// <param name="exception">The original exception.</param>
		/// <param name="userConnection">The user connection instance.</param>
		/// <param name="entitySchema">The schema of the entity involved in the exception.</param>
		/// <param name="entity">The entity instance involved in the exception.</param>
		/// <returns>
		/// An exception containing additional details about the foreign key constraint violation.
		/// </returns>
		Exception EnrichExceptionWithForeignKeyInfo(Exception exception, UserConnection userConnection,
			EntitySchema entitySchema, Entity entity);

		#endregion

	}

	#endregion

	#region Class: DBExceptionHandler

	/// <inheritdoc />
	public class DBExceptionHandler : IDBExceptionHandler
	{

		#region Methods: Private

		private static bool TryFetchReferenceEntity(UserConnection userConnection, Entity entity,
				EntitySchemaColumn entitySchemaColumn, out Guid recordId) {
			EntitySchema referenceSchema = entitySchemaColumn.ReferenceSchema;
			recordId = entity.GetTypedColumnValue<Guid>(entitySchemaColumn);
			Entity referenceEntity = referenceSchema.CreateEntity(userConnection);
			referenceEntity.UseAdminRights = false;
			return referenceEntity.ExistInDB(recordId);
		}

		private static string GetUserMessage(EntitySchema schema, EntitySchemaColumn schemaColumn, Guid value) {
			string message = string.Format(
				"The value in column \"{0}\" (\"{1}\") of entity \"{2}\" refers to a non-existent record in the \"{3}\" " +
				"lookup by its identifier (\"{4}\").\n\n" + "Possible reasons\n" +
				"• The value provided in the process element for \"{0}\" is invalid.\n" +
				"• The referenced \"{3}\" record could have been deleted.\n" +
				"• The referenced value in \"{3}\" might not yet have been created.\n" +
				"• An invalid ID could have been entered into \"{0}\".\n" +
				"• \"{0}\" could have been cleared (or set to empty) even though it must contain a value.\n\n" +
				"Recommended actions\n" + "• Verify that the value set for \"{0}\" exists and is accessible.\n" +
				"• Select a valid value for \"{0}\" from the available list.\n" +
				"• If you believe the value in \"{0}\" should exist, contact your system administrator.\n\n",
				schemaColumn.Caption, schemaColumn.Name, schema.Name, schemaColumn.ReferenceSchema.Name, value);
			return message;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public bool GetIsForeignKeyException(Exception exception) {
			if (!(exception is DbOperationException dbOperationException)) {
				return false;
			}
			string message = dbOperationException.Message;
			return message.IndexOf("foreign key constraint", StringComparison.OrdinalIgnoreCase) >= 0 ||
				message.IndexOf("ORA-02291: integrity constraint", StringComparison.OrdinalIgnoreCase) >= 0;
		}

		/// <inheritdoc />
		public Exception EnrichExceptionWithForeignKeyInfo(Exception exception, UserConnection userConnection,
				EntitySchema entitySchema, Entity entity) {
			IEnumerable<EntityColumnValue> changedColumnValues = entity.GetChangedColumnValues();
			foreach (EntityColumnValue entityColumnValue in changedColumnValues) {
				EntitySchemaColumn schemaColumn = entityColumnValue.Column;
				if (!schemaColumn.HasForeignKey || entityColumnValue.Value == null) {
					continue;
				}
				bool isFetched = TryFetchReferenceEntity(userConnection, entity, schemaColumn, out Guid entityValue);
				if (isFetched) {
					continue;
				}
				string message = GetUserMessage(entitySchema, schemaColumn, entityValue);
				var dbOperationException = new DbOperationException(message, exception);
				return dbOperationException;
			}
			return exception;
		}

		#endregion

	}

	#endregion

}

