namespace Terrasoft.Configuration.Timeline
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using AngleSharp;
	using AngleSharp.Dom;
	using Terrasoft.Core.Factories;

	#region Class: EmailContentProcessor

	/// <summary>
	/// Class responsible for processing email content, including generating email previews and splitting content into quotes.
	/// Implements the <see cref="IEmailContentProcessor"/> interface.
	/// </summary>
	[DefaultBinding(typeof(IEmailContentProcessor))]
	public class EmailContentProcessor : IEmailContentProcessor
	{
		#region Properties: Public

		/// <summary>
		/// Blockquote selectors.
		/// </summary>
		public static string[] BlockQuoteSelectors = new[] {
			"blockquote",
			"blockquote.gmail_quote",
			"div#appendonsend",
			"div#divRplyFwdMsg",
			"[id*='yahoo_quoted_']",
			"div[name='quote']",
			"blockquote[id*='quote_zmail']",
		};

		#endregion

		#region Methods: Private

		private IEnumerable<string> SplitByQuotations(string htmlContent, int startIndex, int count) {
			var positions = GetPositions(htmlContent, startIndex + count).OrderBy(p => p.start).Skip(startIndex).Take(count).ToList();
			return CreateQuotationsParts(positions, htmlContent);
		}

		private List<(int start, int end)> GetPositions(string htmlContent, int count = 0) {
			var quotationElements = GetQuotationElements(htmlContent);
			var positions = new List<(int start, int end)>();
			var quotationElementsCount = quotationElements.Count();
			if (count >= quotationElementsCount) {
				return positions;
			}
			count = count == 0 ? quotationElementsCount : Math.Min(count, quotationElementsCount);
			for (int i = 0; i <= count + 1; i++) {
				var element = quotationElements.ElementAt(Math.Min(i, quotationElementsCount - 1));
				var outerHtml = element.OuterHtml;
				var cutSelector = outerHtml.Substring(0, outerHtml.IndexOf(">") + 1);
				if (i == 0) {
					positions.Add((start: 0, end: cutSelector.Length));
					continue;
				}
				var lastPosition = positions[positions.Count - 1];
				int startPos = KMPSearch(htmlContent, cutSelector, lastPosition.end);
				int endPos = startPos + cutSelector.Length;
				if (startPos == -1) {
					startPos = lastPosition.end + outerHtml.Length;
					if (startPos > htmlContent.Length) {
						startPos = htmlContent.Length;
					}
					endPos = -1;
				}
				positions[positions.Count - 1] = (lastPosition.start, startPos);
				if (endPos > 0) {
					positions.Add((start: startPos, end: endPos));
				}
			}
			return positions;
		}

		private IEnumerable<string> CreateQuotationsParts(List<(int start, int end)> positions, string htmlContent) {
			var parts = new List<string>();
			if (positions.Count == 0) {
				return parts;
			}
			int lastIndex = positions.First().start;
			foreach (var (start, end) in positions) {
				if (start > lastIndex) {
					parts.Add(htmlContent.Substring(lastIndex, start - lastIndex));
				} else {
					parts.Add(htmlContent.Substring(start, end - start));
				}
				lastIndex = end;
			}
			return parts;
		}

		private IEnumerable<IElement> GetQuotationElements(string content) {
			var context = BrowsingContext.New();
			var document = context.OpenAsync(req => req.Content(content)).Result;
			var foundElements = BlockQuoteSelectors
				.SelectMany(document.QuerySelectorAll)
				.Distinct();
			return foundElements;
		}

		private int[] ComputeLPSArray(string pattern) {
			int length = 0;
			int i = 1;
			int[] lps = new int[pattern.Length];
			lps[0] = 0;

			while (i < pattern.Length) {
				if (pattern[i] == pattern[length]) {
					length++;
					lps[i] = length;
					i++;
				} else {
					if (length != 0) {
						length = lps[length - 1];
					} else {
						lps[i] = 0;
						i++;
					}
				}
			}
			return lps;
		}

		private int KMPSearch(string text, string pattern, int startIndex) {
			int[] lps = ComputeLPSArray(pattern);
			int i = startIndex;
			int j = 0;

			while (i < text.Length) {
				if (pattern[j] == text[i]) {
					i++;
					j++;
				}

				if (j == pattern.Length) {
					return i - j;
				} else if (i < text.Length && pattern[j] != text[i]) {
					if (j != 0) {
						j = lps[j - 1];
					} else {
						i++;
					}
				}
			}

			return -1;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public string GetPreview(string email) {
			return SplitByQuotations(email, 0, 1).FirstOrDefault() ?? email;
		}

		/// <inheritdoc/>
		public List<(int start, int end)> GetQuotationsPosition(string email) {
			return GetPositions(email).OrderBy(p => p.start).ToList();
		}

		#endregion

	}

	#endregion

}
