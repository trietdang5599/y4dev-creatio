namespace Terrasoft.Configuration.GenAI
{

	#region Interface: ILlmModelCategoryRepository

	public interface ILlmModelCategoryRepository
	{
		LlmModelReference FindByCategory(string code);

		void ClearCache();
	}

	#endregion
}
