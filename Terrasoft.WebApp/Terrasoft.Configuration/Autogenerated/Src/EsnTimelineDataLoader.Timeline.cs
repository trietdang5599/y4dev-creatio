namespace Terrasoft.Configuration.Timeline
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Configuration.ESN;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Nui.ServiceModel.DataContract;
	using DataValueType = Nui.ServiceModel.DataContract.DataValueType;

	#region EsnTimelineDataLoader

	/// <summary>
	/// Timeline data loader for feed.
	/// </summary>
	[DefaultBinding(typeof(ITimelineDataLoader), Name = "Feed")]
	public class EsnTimelineDataLoader : ITimelineDataLoader
	{

		#region Constructors: Public

		public EsnTimelineDataLoader(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Public

		private IEsnCenter _esnCenter;
		public IEsnCenter EsnCenter {
			get {
				if (_esnCenter == null) {
					var centerFactory = ClassFactory.Get<IEsnCenterFactory>();
					_esnCenter = centerFactory.CreateEsnCenter(UserConnection);
				}
				return _esnCenter;
			}
			set {
				_esnCenter = value;
			}
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection {
			get;
		}

		#endregion

		#region Methods: Private

		private Guid GetMasterEntitySchemaUId(string masterEntitySchemaName) {
			return UserConnection.EntitySchemaManager.GetItemByName(masterEntitySchemaName).UId;
		}

		private BoundTimelineEntity GetTimelineEntity(EsnReadMessageDTO message, TimelineBoundEntity entity) {
			return new BoundTimelineEntity {
				SchemaName = entity.SchemaName,
				BoundEntityName = entity.BoundEntityName,
				Id = message.Id,
				EntityId = message.EntityId,
				ColumnValues = GetColumnValues(message),
				Author = new LookupColumnValue {
					Value = message.CreatedBy.Value,
					DisplayValue = message.CreatedBy.DisplayValue,
					PrimaryImageValue = message.CreatedBy.PrimaryImageValue
				},
				Date = message.CreatedOn,
				SortColumn = message.CreatedOn
			};
		}

		private TimelineEntityCollection GetColumnValues(EsnReadMessageDTO message) {
			return new TimelineEntityCollection { new BoundEntityColumn {
					ColumnName = "Message",
					ColumnValue = new LookupColumnValue { Value = message.Message },
					ColumnDataType = new TimelineColumnDataType { DataValueType = DataValueType.MaxSizeText }
				}, new BoundEntityColumn {
					ColumnName = "Id",
					ColumnValue = new LookupColumnValue { Value = message.Id.ToString() } ,
				}, new BoundEntityColumn {
					ColumnName = "EntitySchemaName",
					ColumnValue = new LookupColumnValue{ Value = message.EntitySchemaName } ,
				}, new BoundEntityColumn {
					ColumnName = "EntitySchemaCaption",
					ColumnValue = new LookupColumnValue{ Value = message.EntitySchemaCaption },
				}, new BoundEntityColumn {
					ColumnName = "EntitySchemaUId",
					ColumnValue = new LookupColumnValue{ Value = message.EntitySchemaUId.ToString() }
				}, new BoundEntityColumn {
					ColumnName = "CommentCount",
					ColumnValue = new LookupColumnValue{ Value = message.CommentCount.ToString() }
				}, new BoundEntityColumn {
					ColumnName = "LikeCount",
					ColumnValue = new LookupColumnValue{ Value = message.LikeCount.ToString() }
				}, new BoundEntityColumn {
					ColumnName = "UserAccess",
					ColumnValue = new LookupColumnValue{ Value = message.UserAccess.ToString() }
				},};
		}

		private List<EsnReadMessageDTO> GetMessages(TimelineRequestConfig config, TimelineBoundEntity entity) {
			Guid schemaUId = GetMasterEntitySchemaUId(config.MasterEntitySchemaName);
			Guid masterRecordId = Guid.Parse(config.MasterRecordId);
			if (config.RecordId != null) {
				var singleMessage = EsnCenter.ReadMessage(schemaUId,
					masterRecordId, Guid.Parse(config.RecordId));
				return new List<EsnReadMessageDTO>() { singleMessage };
			}
			var readOptions = new EsnReadMessageOptions {
				ReadMessageCount = config.RowCount + config.Offset,
				OrderDirection = config.OrderDirection,
			};
			if (!string.IsNullOrEmpty(entity.Filters)) {
				readOptions.Filters = JsonConvert.DeserializeObject<Filters>(entity.Filters);
			}
			AddSearchFilter(config, readOptions);
			return EsnCenter.ReadEntityMessage(schemaUId,
				masterRecordId, readOptions).Skip(config.Offset).ToList();
		}

		private void AddSearchFilter(TimelineRequestConfig config, EsnReadMessageOptions readOptions) {
			if (config.Search.IsNotNullOrEmpty()) {
				var filter = new Filter {
					FilterType = Nui.ServiceModel.DataContract.FilterType.CompareFilter,
					ComparisonType = FilterComparisonType.Contain,
					LeftExpression = new BaseExpression {
						ExpressionType = EntitySchemaQueryExpressionType.SchemaColumn,
						ColumnPath = "Message"
					},
					RightExpression = new BaseExpression {
						ExpressionType = EntitySchemaQueryExpressionType.Parameter,
						Parameter = new Parameter {
							DataValueType = DataValueType.Text,
							Value = config.Search,
						}
					}
				};
				if (readOptions.Filters == null) {
					readOptions.Filters = new Filters() {
						Items = new Dictionary<string, Filter>()
					};
				}
				readOptions.Filters.Items.Add("search", filter);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Loads Timeline data for feed.
		/// </summary>
		/// <param name="entity">entity.</param>
		/// <param name="config">Timeline load config.</param>
		public List<BoundTimelineEntity> LoadData(TimelineBoundEntity entity, TimelineRequestConfig config) {
			List<EsnReadMessageDTO> messages = GetMessages(config, entity);
			var result = new List<BoundTimelineEntity>();
			foreach (var message in messages) {
				result.Add(GetTimelineEntity(message, entity));
			}
			return result;
		}

		#endregion

	}

	#endregion

}
