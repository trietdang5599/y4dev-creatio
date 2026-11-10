namespace Terrasoft.Configuration.Omnichannel.Messaging
{
    using System.Linq;
    using Terrasoft.Common;
    using Terrasoft.Core;
    using Terrasoft.Core.Entities;

    #region Class: OmnichatEsqColumnsAppender

    /// <summary>
    /// Class to adding logged columns to Omnichat.
    /// </summary>
    public static class OmnichatEsqColumnsAppender
    {

        #region Methods: Public

        /// <summary>
        /// Adds logged columns to esq.
        /// </summary>
        /// <param name="esq">Omnichat esq.</param>
        public static void AddLoggedColumns(EntitySchemaQuery esq) {
            if (esq.RootSchema.IsTrackChangesInDB) {
                esq.RootSchema.Columns.ForEach(c => {
                    if (c.IsTrackChangesInDB && !esq.Columns.Any(x => x.Name == c.Name)) {
                        esq.AddColumn(c.Name);
                    }
                });
            }
        }

        #endregion
    }
    
    #endregion
} 
