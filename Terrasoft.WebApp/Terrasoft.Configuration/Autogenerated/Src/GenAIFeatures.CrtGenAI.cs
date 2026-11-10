namespace Terrasoft.Configuration.GenAI
{
	using Creatio.FeatureToggling;

	public static class GenAIFeatures
	{
		public class GenerateDcm : FeatureMetadata
		{
			public GenerateDcm() {
				IsEnabled = true;
				Description = "Use AI for generating Dcm for application";
			}
		}

		public class GenerateDemoData : FeatureMetadata
		{
			public GenerateDemoData() {
				IsEnabled = true;
				Description = "Use AI for generating demo data for application";
			}
		}

		public class GenerateNextSteps : FeatureMetadata
		{
			public GenerateNextSteps() {
				IsEnabled = true;
				Description = "Use AI for generating next steps for application";
			}
		}

		public class Copilot : FeatureMetadata
		{
			public Copilot() {
				IsEnabled = true;
				Description = "Use Creatio AI";
			}
		}

		public class UseMockServiceForAIRequest : FeatureMetadata
		{
			public UseMockServiceForAIRequest() {
				IsEnabled = false;
				Description = "Use mock service for AI request";
			}
		}

		public class ShowSystemIntent : FeatureMetadata
		{
			public ShowSystemIntent() {
				IsEnabled = false;
				Description = "Show System intent for creatio.ai in the Skills section";
			}
		}

		public class AddCaptionToDescription : FeatureMetadata
		{
			public AddCaptionToDescription() {
				IsEnabled = true;
				Description = "Add caption to the description of Skill, action, property";
			}
		}

		public class CopilotEngineClusterMode : FeatureMetadata
		{
			public CopilotEngineClusterMode() {
				IsEnabled = false;
				Description = "Enables Creatio AI engine cluster (web-farm) mode";
			}
		}

		public class SilentAssignFreeSkillsToDefaultAgentScript : FeatureMetadata
		{
			public SilentAssignFreeSkillsToDefaultAgentScript() {
				IsEnabled = true;
				Description = "Enables silent execution of DefaultAgentsSubIntentsInstallScriptExecutor installation script";
			}
		}

		public class SummarizeCopilotSessionMessages : FeatureMetadata
		{
			public SummarizeCopilotSessionMessages() {
				IsEnabled = false;
				Description = "Summarize Creatio.AI session messages";
			}
		}

		public class IncludeSystemMessagesInSummarization : FeatureMetadata
		{
			public IncludeSystemMessagesInSummarization() {
				IsEnabled = true;
				Description = "Include system messages in Summarize Creatio.AI request";
			}
		}

		public class LogCreatioAIRequest : FeatureMetadata
		{
			public LogCreatioAIRequest() {
				IsEnabled = false;
				Description = "Logs creatio.ai request sending it to the client via web-sockets";
			}
		}

		public class MultiLlmSupport : FeatureMetadata
		{
			public MultiLlmSupport() {
				IsEnabled = true;
				Description = "Support multiple LLM model providers and model selection";
			}
		}

		public class GenerateIntentSelectionReason : FeatureMetadata
		{
			public GenerateIntentSelectionReason() {
				IsEnabled = true;
				Description = "Use AI for generating reason in tool calls when switching between Agents/Skills";
			}
		}
		
		public class CacheLLMModelCategoriesDefault : FeatureMetadata
		{
			public CacheLLMModelCategoriesDefault() {
				IsEnabled = false;
				Description = "Enables cache for default LLM model code";
			}
		}

		public class SplitSystemIntentsIntoSeparateMessages : FeatureMetadata
		{
			public SplitSystemIntentsIntoSeparateMessages() {
				IsEnabled = true;
				Description = "Do not concatenate system intents; keep each in a separate message";
			}
		}

		public class UseSystemRoleForWorkflowSkillPrompt : FeatureMetadata
		{
			public UseSystemRoleForWorkflowSkillPrompt() {
				IsEnabled = true;
				Description = "Use system role for Workflow skill prompt; when turned off, the user role is used";
			}
		}
	}
}

