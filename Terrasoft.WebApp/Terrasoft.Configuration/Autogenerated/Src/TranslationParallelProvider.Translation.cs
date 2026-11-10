 namespace Terrasoft.Configuration.Translation
{
	using System;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;

	#region Class: TranslationParallelProvider

	public class TranslationParallelProvider : TranslationProvider
	{

		#region Constructors: Public

		public TranslationParallelProvider(UserConnection userConnection, ITranslationLogger translationLogger)
			: base(userConnection, translationLogger) {
		}

		#endregion

		#region Methods: Protected

		protected override Update GetTranslationUpdateQuery(string key, string columnName, string columnValue, string isChangedColumnName) {
			Update update = new Update(UserConnection, TranslationSchemaName)
				.Set(columnName, Column.Parameter(columnValue));
			if (UserConnection.DBEngine.DBEngineType == DBEngineType.PostgreSql) {
				update.Where(Func.Upper(TranslationKeyColumnName))
					.IsEqual(Func.Upper(Column.Parameter(key)));
			} else {
				update.Where(TranslationKeyColumnName)
					.IsEqual(Column.Parameter(key));
			}
			if (!string.IsNullOrEmpty(isChangedColumnName)) {
				update.And(isChangedColumnName).IsNotEqual(Column.Parameter(true));
			}
			return update;
		}

		protected override Insert GetTranslationInsertQuery(string key, string columnName, string columnValue) {
			return new Insert(UserConnection)
				.Into(TranslationSchemaName)
				.Set(TranslationKeyColumnName, Column.Parameter(key))
				.Set(columnName, Column.Parameter(columnValue));
		}

		protected override int ExecuteQuery(IDBCommand query) {
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				return query.Execute(dbExecutor);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Executes action in transaction.
		/// <param name="action">Action.</param>
		/// </summary>
		public override void Transaction(Action action) {
			action();
		}

		#endregion

	}

	#endregion

}
