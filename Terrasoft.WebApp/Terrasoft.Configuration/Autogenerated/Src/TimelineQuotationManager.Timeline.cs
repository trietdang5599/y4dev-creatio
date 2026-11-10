namespace Terrasoft.Configuration.Timeline
{
	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Class : TimelineQuotationData

	/// <summary>
	///Represents a Dto for TimelineQuotationData.
	/// </summary>
	public class TimelineQuotationData
	{
		/// <summary>
		/// Positions of quotes in the given email.
		/// </summary>
		public List<(int Start, int End)> Positions { get; set; } = new List<(int Start, int End)>();

		/// <summary>
		/// Number of read chunks.
		/// </summary>
		public int ChunkNumber { get; set; } = 0;

		/// <summary>
		/// Is it the last quote from the given email.
		/// </summary>
		public bool IsLastQuote { get; set; } = true;
	}

	#endregion

	#region Class: TimelineQuotationManager

	/// <summary>
	/// Timeline quotation manager.
	/// </summary>
	public class TimelineQuotationManager
	{

		#region Properties: Protected

		private static readonly ConcurrentDictionary<Guid, TimelineQuotationData> EmailQuotePositions =
			new ConcurrentDictionary<Guid, TimelineQuotationData>();

		private IEmailContentProcessor _emailContentProcessor;
		protected IEmailContentProcessor EmailContentProcessor =>
			_emailContentProcessor ?? (_emailContentProcessor = ClassFactory.Get<IEmailContentProcessor>());


		protected UserConnection UserConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="TimelineQuotationManager"/> class.
		/// <param name="userConnection">Instance of the <see cref="UserConnection"/>.</param>
		/// </summary>
		public TimelineQuotationManager(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		// <summary>
		/// Initializes a new instance of the <see cref="TimelineQuotationManager"/> class.
		/// <param name="userConnection">Instance of the <see cref="UserConnection"/>.</param>
		/// <param name="emailContentProcessor">Instance of the <see cref="IEmailContentProcessor"/>.</param>
		/// </summary>
		public TimelineQuotationManager(UserConnection userConnection, IEmailContentProcessor emailContentProcessor) : this(userConnection) {
			_emailContentProcessor = emailContentProcessor;
		}

		#endregion

		#region Methods: Private

		private void LoadMorePositions(string body, int quoteNumber, TimelineQuotationData quotationData) {
			var maxSizeColumnValue = TimelineUtilities.GetEmailMaxSizeColumnValue(UserConnection);
			var currentPosition = quotationData.Positions.Count > 0 ? quotationData.Positions[quotationData.Positions.Count - 1].End : 0;
			var chunkCount = 1;
			var partSize = maxSizeColumnValue;
			var isLastChunk = false;
			while (currentPosition <= body.Length && quotationData.Positions.Count <= quoteNumber && partSize >= maxSizeColumnValue && !isLastChunk) {
				isLastChunk = currentPosition + maxSizeColumnValue * chunkCount > body.Length;
				partSize = isLastChunk ? body.Length - currentPosition : maxSizeColumnValue * chunkCount;
				var part = body.Substring(currentPosition, partSize);
				var additionalPositions = EmailContentProcessor.GetQuotationsPosition(part);
				if (additionalPositions.Count > 0) {
					for (int i = 0; i < additionalPositions.Count; i++) {
						additionalPositions[i] = (additionalPositions[i].start + currentPosition, additionalPositions[i].end + currentPosition);
						quotationData.Positions.Add(additionalPositions[i]);
					}
					currentPosition = quotationData.Positions[quotationData.Positions.Count - 1].End;
					chunkCount = 1;
				} else {
					chunkCount++;
				}
				quotationData.ChunkNumber++;
			}
			quotationData.IsLastQuote = !(currentPosition < body.Length - maxSizeColumnValue && partSize >= maxSizeColumnValue);
		}

		private string GetLastPartOfEmail(string body, int lastIndex) {
			return body.Substring(lastIndex, body.Length - lastIndex);
		}

		private string ExtractQuoteByNumber(int quoteNumber, string body, TimelineQuotationData quotationData) {
			return body.Substring(quotationData.Positions[quoteNumber - 1].Start, quotationData.Positions[quoteNumber - 1].End - quotationData.Positions[quoteNumber - 1].Start);
		}

		private string ExtractQuoteByPosition(string body, (int Start, int End) position) {
			return body.Substring(position.Start, position.End - position.Start);
		}

		private void AddLastPartOfEmailIfNeeded(string body, TimelineQuoteList result, TimelineQuotationData quotationData) {
			if (result.IsLastQuote && quotationData.Positions.Count > 0 && quotationData.Positions.Last().End < body.Length) {
				result.TimelineQuotes.Last().Content += GetLastPartOfEmail(body, quotationData.Positions.Last().End);
			}
		}

		private void AddLastPartOfEmailIfThereIsNoQuotes(string body, TimelineQuoteList result, TimelineQuotationData quotationData)	{
			if (result.TimelineQuotes.Count == 0 && quotationData.ChunkNumber > 1) {
				result.IsLastQuote = true;
				result.TimelineQuotes.Add(new TimelineQuote	{
					Content = GetLastPartOfEmail(body, TimelineUtilities.GetEmailMaxSizeColumnValue(UserConnection))
				});
			}
		}

		#endregion

		#region Methods: Protected

		protected virtual string GetEmailBody(Guid emailId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Activity");
			var bodyColumnName = esq.AddColumn("Body").Name;
			Entity entity = esq.GetEntity(UserConnection, emailId);
			if (entity != null) {
				return entity.GetTypedColumnValue<string>(bodyColumnName);
			} else {
				throw new ArgumentException($"Activity does not exist EmailId = {emailId}");
			}
		}

		private void FixFirstPartIfItNeeded(string body, TimelineQuoteList result, TimelineQuotationData quotationData) {
			var maxSize = TimelineUtilities.GetEmailMaxSizeColumnValue(UserConnection);
			if (quotationData.Positions.Count > 1 && ((quotationData.Positions[0].End < maxSize &&
				quotationData.Positions[1].End > maxSize) || quotationData.Positions[0].End > maxSize)) {
				result.TimelineQuotes[0].Content = body.Substring(maxSize, quotationData.Positions[1].End);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Loads given number of email quotes.
		/// </summary>
		/// <param name="emailId">Identifier of email.</param>
		/// <param name="quoteNumber">Number of quotes.</param>
		/// <returns>List of quotes.</returns>
		public TimelineQuoteList GetQuotesList(Guid emailId, int quoteNumber) {
			var body = GetEmailBody(emailId);
			var result = new TimelineQuoteList();
			TimelineQuotationData quotationData = EmailQuotePositions.GetOrAdd(emailId, new TimelineQuotationData());
			if (quotationData.Positions.Count < quoteNumber) {
				LoadMorePositions(body, quoteNumber, quotationData);
			}
			result.IsLastQuote = quotationData.IsLastQuote;
			IEnumerable<(int Start, int End)> positions = quoteNumber > 1 ? quotationData.Positions.Skip(quoteNumber - 1).Take(quotationData.Positions.Count + 1 - quoteNumber) : quotationData.Positions;
			foreach ((int Start, int End) position in positions) {
				result.TimelineQuotes.Add(new TimelineQuote	{
					Content = ExtractQuoteByPosition(body, position)
				});
			}
			AddLastPartOfEmailIfNeeded(body, result, quotationData);
			AddLastPartOfEmailIfThereIsNoQuotes(body, result, quotationData);
			if (quoteNumber == 2) {
				FixFirstPartIfItNeeded(body, result, quotationData);
			}
			return result;
		}

		#endregion

	}

	#endregion

}
