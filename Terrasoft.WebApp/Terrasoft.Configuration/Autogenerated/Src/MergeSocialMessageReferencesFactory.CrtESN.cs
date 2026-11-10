namespace Terrasoft.Configuration.ESN
{
	using System.Collections.Generic;
	using Terrasoft.Configuration.Deduplication;
	using Terrasoft.Core.Factories;

	#region MergeSocialMessageReferencesFactory

	/// <summary>
	/// Provides social message's aggregate references. 
	/// </summary>
	[DefaultBinding(typeof(IMergeReferencesFactory), Name = "MergeSocialMessageReferencesFactory")]
	public class MergeSocialMessageReferencesFactory : IMergeReferencesFactory
	{

		#region Fields: Private

		private static readonly MergeReferenceCollection _references = new MergeReferenceCollection {
			{
				"SocialMessage", new List<string> {
					"EntityId"
				}
			}
		};

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public MergeReferenceCollection GetReferences(string schemaName) => _references;

		#endregion

	}

	#endregion

}
