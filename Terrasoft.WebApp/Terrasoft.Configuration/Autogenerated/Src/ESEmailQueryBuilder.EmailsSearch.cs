 namespace Terrasoft.Configuration.EmailsSearch
{
	using Terrasoft.Configuration;
	using Terrasoft.Configuration.GlobalSearch;
	using Terrasoft.Core;
    using Terrasoft.Core.Factories;
    using SysSettings = Terrasoft.Core.Configuration.SysSettings;

	#region class: ESEmailQueryBuilder
	
	[DefaultBinding(typeof(IESEmailQueryBuilder))]
	public class ESEmailQueryBuilder : ESQueryBuilder, IESEmailQueryBuilder
    {
		#region Properties: Private

		private UserConnection UserConnection { get; }

		private const int DefaultShouldMatch = 40;

		#endregion

		#region Properties: Protected

		protected override int MinimumShouldMatchPercentage {
			get {
				var shouldMatch = SysSettings.GetValue(UserConnection, "GlobalSearchShouldMatchPercent", 0);
				return shouldMatch != 0 ? shouldMatch : DefaultShouldMatch;
			}
		}

		#endregion

		#region Constructors: Public

		public ESEmailQueryBuilder(UserConnection userConnection, ISearchColumnNameProvider searchColumnNameProvider)
			: base(searchColumnNameProvider) {
			UserConnection = userConnection;
		}

		#endregion
	}

	#endregion
}

