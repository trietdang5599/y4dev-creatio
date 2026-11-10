namespace Terrasoft.Configuration
{
	using System;
	using System.Globalization;
	using System.Text.RegularExpressions;
	using Terrasoft.Core.Factories;

	#region Class: DateTimeLandingiTypeWebhookHandler

	/// <summary>
	/// Webhook handler for DateTime type from Landingi.
	/// </summary>
	/// <seealso cref="Terrasoft.Configuration.ICustomTypeWebhookHandler" />
	[DefaultBinding(typeof(ICustomTypeWebhookHandler), Name = "DateTimeLandingiTypeWebhookHandler")]
	public class DateTimeLandingiTypeWebhookHandler : ICustomTypeWebhookHandler
	{

		/// <summary>
		/// The regex search pattern.
		/// </summary>
		private static readonly string _regexSearchPattern = @"\W";

		#region Properties: Public

		/// <summary>
		/// Provider name.
		/// </summary>
		public string ProviderName => WebhookSourceConstants.Landingi;

		/// <summary>
		/// Handling type.
		/// </summary>
		public Type Type => typeof(DateTime);

		#endregion

		#region Methods: Public
		string[] _formats = new[] { "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd", "yyyy-dd-MM" };

		/// <summary>
		/// Handling webhook parameter value.
		/// </summary>
		/// <param name="input">String value of webhook parameter for Handling.</param>
		/// <returns></returns>
		public object Handle(string input) {
			string formattedDateString = Regex.Replace(input, _regexSearchPattern, "-");
			var dateTimeFormatInfo = new DateTimeFormatInfo();
			if (DateTime.TryParseExact(formattedDateString, _formats, dateTimeFormatInfo, DateTimeStyles.None,
				out var result)) {
				return result;
			}
			return null;
		}

		#endregion

	}

	#endregion

}

