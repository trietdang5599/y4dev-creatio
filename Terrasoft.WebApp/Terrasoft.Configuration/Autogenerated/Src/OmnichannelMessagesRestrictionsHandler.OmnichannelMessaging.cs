namespace Terrasoft.Configuration.Omnichannel.Messaging
{
    using System;
    using System.Linq;
    using OmnichannelMessaging;
    using OmnichannelProviders.Domain.Entities;
    using Terrasoft.Common;
    using Terrasoft.Core;
    using Terrasoft.Core.Factories;
    using MessageType = OmnichannelProviders.Domain.Entities.MessageType;
    using SysSettings = Core.Configuration.SysSettings;

    #region Class: OmnichannelMessagesRestrictionsHandler
    
    /// <summary>
    /// Class to check message restrictions.
    /// </summary>
    public class OmnichannelMessagesRestrictionsHandler
    {

        #region Fields: Private

        private readonly UserConnection _userConnection;
        private readonly ChatRepository _chatRepository;
        private readonly MessageManager _messageManager;
        private readonly ChatOperatorNotifier _operatorNotifier;

        #endregion

        #region Constructors: Public

        /// <summary>
        /// Constructor to initialize class.
        /// </summary>
        public OmnichannelMessagesRestrictionsHandler(UserConnection userConnection) {
            _userConnection = userConnection;
            _chatRepository = new ChatRepository(userConnection);
            _messageManager = new MessageManager(userConnection);
            _operatorNotifier = ClassFactory.Get<ChatOperatorNotifier>();
        }

        #endregion

        #region Methods: Private

        private bool CheckLargeAttachments(MessagingMessage message) {
            bool hasValidMessage = true;
            var maxFileSize = SysSettings.GetValue(_userConnection, "MaxFileSize", 0);
            var maxFileSizeBytes = maxFileSize * 1024 * 1024;
            if (maxFileSizeBytes > 0 && message.Attachments != null && message.Attachments.Any(x => x.Content.Length > maxFileSizeBytes)) {
                var error = new LocalizableString(_userConnection.Workspace.ResourceStorage, "OmnichannelMessagingService",
                    "LocalizableStrings.FileTooBigError.Value").ToString();
                MessagingMessage errorMessage = new MessagingMessage(message) {
                    Attachments = null,
                    Message = error,
                    MessageType = MessageType.Text
                };
                _chatRepository.AddMessage(errorMessage, out _);
                _messageManager.AddSystemMessage(errorMessage);
                _operatorNotifier.NewConversationMessageNotify(errorMessage as UnifiedMessage);
                message.Attachments = message.Attachments.Where(x => x.Content.Length <= maxFileSizeBytes).ToList();
                if (string.IsNullOrEmpty(message.Message) && message.Attachments.Count == 0) {
                    hasValidMessage = false;
                }
            }
            return hasValidMessage;
        }

        #endregion

        #region Methods: Public

        /// <summary>
        /// Check large attachments restrictions.
        /// </summary>
        /// <param name="message">Message with attachments.</param>
        /// <returns>True, if message has valid content, otherwise - false.</returns>
        public bool CheckLargeAttachmentsRestrictions(MessagingMessage message) {
            return CheckLargeAttachments(message);
        }

        #endregion
    }
    
    #endregion
} 
