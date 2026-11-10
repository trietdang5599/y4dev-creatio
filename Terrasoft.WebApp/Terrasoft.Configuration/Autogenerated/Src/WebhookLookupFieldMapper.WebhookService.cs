namespace Terrasoft.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Terrasoft.Common;
    using Terrasoft.Core;
    using Terrasoft.Core.Entities;

    #region Class: WebhookLookupFieldMapper
    
    /// <summary>
    /// Provides logic for mapping lookup fields from webhook to entity.
    /// </summary>
    public class WebhookLookupFieldMapper : IFieldMapper {
        
        #region Fields: Private

        private readonly string _entityName;
        
        #endregion

        #region Constructors: Public

        /// <summary>
        /// Constructor to create WebhookLookupFieldMapper initialized by entityName.
        /// </summary>
        /// <param name="entityName">The entity name.</param>
        public WebhookLookupFieldMapper(string entityName) {
            _entityName = entityName;
        }

        #endregion

        #region Methods: Private

        private bool IsLookupColumnExists(string truncatedColumnName, EntitySchema entitySchema) {
            var schemaColumn = entitySchema.Columns.FirstOrDefault(x => 
                string.Equals(x.Name, truncatedColumnName, StringComparison.CurrentCultureIgnoreCase));
            return schemaColumn?.IsLookupType ?? false;
        }

        #endregion
        
        #region Methods: Public
        
        /// <inheritdoc cref="IFieldMapper.MapFields"/>
        public void MapFields(IEnumerable<string> webhookFields, List<WebhookColumnMap> mappedFields) {
            EntitySchema entitySchema = UserConnection.Current.EntitySchemaManager.GetInstanceByName(_entityName);
            foreach (string webhookFieldName in webhookFields) {
                if (webhookFieldName.EndsWith("id", StringComparison.CurrentCultureIgnoreCase)) {
                    string truncatedColumnName = webhookFieldName.Substring(0, webhookFieldName.Length - 2);
                    if (IsLookupColumnExists(truncatedColumnName, entitySchema)) {
                        mappedFields.Replace(truncatedColumnName, webhookFieldName);
                    }
                }
            }
        }
        
        #endregion
        
    }
    
    #endregion
}
