namespace Terrasoft.Configuration.Timeline
{
	using System.Collections.Generic;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class : TimelineDataLoaderFactory

	/// <summary>
	/// Manage instances of data loader`s.
	/// </summary>
	public class TimelineDataLoaderFactory<T> where T: class, ITimelineDataLoader
	{

		#region Fields: Private

		private readonly Dictionary<string, T> _loaderMap;
		private const string _defaultLoader = "EntitySchemaQuery";

		#endregion

		#region Properties: Protected 

		protected UserConnection UserConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="TimelineDataLoaderFactory"/> class.
		/// </summary>
		public TimelineDataLoaderFactory() {
			_loaderMap = new Dictionary<string, T>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimelineDataLoaderFactory"/> class.
		/// <param name="userConnection">Instance of the <see cref="UserConnection"/>.</param>
		/// </summary>
		public TimelineDataLoaderFactory(UserConnection userConnection): this() {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private T CreateLoaderInstance(string loaderName) {
			return UserConnection != null ? ClassFactory.Get<T>(loaderName,
				new ConstructorArgument("userConnection", UserConnection)) :
				ClassFactory.Get<T>(loaderName);
		}

		private T MapLoader(string loaderName) {
			var	loader = CreateLoaderInstance(loaderName);
			_loaderMap.Add(loaderName, loader);
			return loader;
		}

		#endregion

		#region Methods: Protected

		protected T GetLoaderInstance(string loaderName)	{
			return _loaderMap.ContainsKey(loaderName) ? _loaderMap[loaderName] : MapLoader(loaderName);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get instance of lader.
		/// </summary>
		/// <param name="loaderName">Loader name.</param>
		public T GetLoaderByName(string loaderName)	{
			return string.IsNullOrEmpty(loaderName) ? GetLoaderInstance(_defaultLoader) : GetLoaderInstance(loaderName);
		}

		#endregion
	}

	#endregion
}
 
