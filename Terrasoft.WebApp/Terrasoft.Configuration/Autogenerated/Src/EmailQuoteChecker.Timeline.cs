namespace Terrasoft.Configuration.Timeline
{
	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;

	#region Class: EmailQuoteChecker

	/// <summary>
	/// Provides logic to determine whether an email should be trimmed
	/// based on the presence of base64-encoded inline images and quoted content blocks.
	/// </summary>
	public static class EmailQuoteChecker
    {

		#region Constants: Private

		private static readonly Lazy<List<Regex>> _quoteRegexes;
		private static readonly Lazy<Regex> _base64ImgRegex;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="EmailQuoteChecker"/> class.
		/// Quote selectors are retrieved from <see cref="TimelineUtilities.BlockQuoteSelectors"/> and
		/// </summary>
		static EmailQuoteChecker() {
			_quoteRegexes = new Lazy<List<Regex>>(() => {
			var list = new List<Regex>();
				foreach (var selector in EmailContentProcessor.BlockQuoteSelectors) {
					var pattern = ConvertSelectorToRegexPattern(selector);
					list.Add(new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled));
				}
				return list;
			});
			_base64ImgRegex = new Lazy<Regex>(() =>  new Regex(
				@"<img\s+[^>]*src=[""']data:image\/[a-zA-Z]+;base64,[^""']+[""'][^>]*>",
					RegexOptions.IgnoreCase | RegexOptions.Compiled));
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Converts a CSS-like selector into a regular expression pattern that matches
		/// corresponding HTML quote elements.
		/// </summary>
		/// <param name="selector">The selector string (e.g., "blockquote", "div#id", "div[name='quote']").</param>
		/// <returns>A regular expression pattern string that can be used to find the HTML element.</returns>
		private static string ConvertSelectorToRegexPattern(string selector) {
			if (selector.Contains("#")) {
				var parts = selector.Split('#');
				return $@"<{parts[0]}\b[^>]*\bid\s*=\s*([""'])?{Regex.Escape(parts[1])}\1?";
			}
			if (selector.Contains("[id*=")) {
				var inner = selector.Replace("[id*='", "").Replace("']", "");
				return $@"<[^>]+\bid\s*=\s*([""'])?[^""'>]*{Regex.Escape(inner)}[^""'>]*\1?";
			}
			if (selector.Contains("[name=")) {
				var inner = selector.Replace("div[name='", "").Replace("']", "");
				return $@"<div\b[^>]*\bname\s*=\s*([""'])?{Regex.Escape(inner)}\1?";
			}
			if (selector.Contains(".")) {
				var parts = selector.Split('.');
				return $@"<{parts[0]}\b[^>]*\bclass\s*=\s*([""'])?[^""'>]*\b{Regex.Escape(parts[1])}\b[^""'>]*\1?";
			}
			return $@"<{selector}\b";
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Determines whether an email can be trimmed by checking for base64-encoded images and
		/// quoted blocks.
		/// </summary>
		/// <param name="emailHtml">The full HTML content of the email message.</param>
		/// <param name="defaultStartIndex">
		/// </param>
		/// <param name="quoteStartIndex">
		/// When quoted content is found, this will contain the index of the first quote block;
		/// otherwise, it will be set to the provided <paramref name="defaultStartIndex"/>.
		/// </param>
		/// <returns>
		/// Returns <c>true</c> if:
		/// - the email is empty,
		/// - no base64-encoded images are present,
		/// - or a quote block exists in the HTML;
		/// Returns <c>false</c> if a base64 image is present and no quote block is found.
		/// </returns>
		public static bool ShouldTrimEmail(string emailHtml, int defaultStartIndex, out int quoteStartIndex) {
			quoteStartIndex = defaultStartIndex;
			if (string.IsNullOrWhiteSpace(emailHtml))
				return true;
			if (!emailHtml.Contains("data:image/"))
				return true;
			if (!_base64ImgRegex.Value.IsMatch(emailHtml))
				return true;
			foreach (var regex in _quoteRegexes.Value) {
				var match = regex.Match(emailHtml);
				if (match.Success) {
					quoteStartIndex = match.Index;
					return true;
				}
			}
			return false;
		}

		#endregion
	}

	#endregion
}
