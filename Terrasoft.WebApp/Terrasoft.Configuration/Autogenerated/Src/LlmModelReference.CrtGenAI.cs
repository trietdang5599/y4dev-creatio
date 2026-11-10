namespace Terrasoft.Configuration.GenAI
{
    using System;

    #region Class: LlmModelReference

    /// <summary>
    /// Lightweight reference to an LLM model containing only essential identification data.
    /// </summary>
    [Serializable]
    public class LlmModelReference
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
    }

    #endregion
}

