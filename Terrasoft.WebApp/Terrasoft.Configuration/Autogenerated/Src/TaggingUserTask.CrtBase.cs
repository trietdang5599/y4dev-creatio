namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
	using Terrasoft.Common;
	using Terrasoft.Configuration.RelatedRecords;
	using Terrasoft.Configuration.Tagging;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;

	#region Class: TaggingUserTask

	/// <exclude/>
	public partial class TaggingUserTask
	{

		#region Enums: TaggingAction

		/// <summary>
		/// Tagging action enum.
		/// </summary>
		private enum TaggingActionEnum
		{
			AddTags,
			RemoveTags
		}

		#endregion

		#region Methods: Private

		private TaggingActionEnum GetTaggingActionFromParameters() {
			TaggingAction.CheckArgumentNullOrWhiteSpace(nameof(TaggingAction));
			return (TaggingActionEnum)Enum.Parse(typeof(TaggingActionEnum), TaggingAction, true);
		}

		private RelatedRecordsHandlerResult AddTags(ITaggingHandler taggingHandler) {
			var taggingHandlerData = CreateTaggingHandlerData();
			return taggingHandler.AddTags(taggingHandlerData);
		}

		private RelatedRecordsHandlerResult RemoveTags(ITaggingHandler taggingHandler) {
			var taggingManagerData = CreateTaggingHandlerData();
			return taggingHandler.RemoveTags(taggingManagerData);
		}

		private RelatedRecordsHandlerData CreateTaggingHandlerData() {
			IDictionary<string, string> defaultValues = null;
			if (!string.IsNullOrEmpty(DefaultValues)) {
				defaultValues = JsonConvert.DeserializeObject<IDictionary<string, string>>(DefaultValues);
			}
			return new RelatedRecordsHandlerData {
				MainRecordsEsqSerialized = TagsEsqSerialized,
				RelatedRecordsEsqSerialized = RecordsEsqSerialized,
				RelatedInMainRecordsSchemaName = TagInRecordSchemaName,
				MainRecordColumnName = TagColumnName,
				RelatedRecordColumnName = RecordColumnName,
				DefaultValues = defaultValues
			};
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Executes of tagging action.
		/// </summary>
		/// <param name="context">Process executing context.</param>
		/// <returns><c>true</c>.</returns>
		/// <exception cref="NotSupportedException">Throws when the tagging action is not supported.</exception>
		protected override bool InternalExecute(ProcessExecutingContext context) {
			try {
				RelatedRecordsHandlerResult handlerResult;
				ITaggingHandler taggingHandler = ClassFactory.Get<ITaggingHandler>(
					new ConstructorArgument("userConnection", UserConnection));
				TaggingActionEnum taggingAction = GetTaggingActionFromParameters();
				switch (taggingAction) {
					case TaggingActionEnum.AddTags: {
						handlerResult = AddTags(taggingHandler);
						break;
					}
					case TaggingActionEnum.RemoveTags: {
						handlerResult = RemoveTags(taggingHandler);
						break;
					}
					default: {
						throw new NotSupportedException(TaggingAction);
					}
				}
				ProcessedRecordsCount = handlerResult.ProcessedRecordsCount;
				ProcessedExceptionMessage = handlerResult.Exception?.Message;
			} catch (Exception e) {
				ProcessedRecordsCount = -1;
				ProcessedExceptionMessage = e.Message;
			}
			return true;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public override string GetExecutionData() {
			return string.Empty;
		}

		#endregion

	}

	#endregion

}
