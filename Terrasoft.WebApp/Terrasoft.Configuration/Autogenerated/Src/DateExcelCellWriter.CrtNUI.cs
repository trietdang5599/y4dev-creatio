namespace Terrasoft.Configuration.ExportToExcel
{
	using System;

	#region Class: DateExcelCellWriter

	/// <summary>
	/// Date excel cell writer.
	/// </summary>
	public class DateExcelCellWriter : DecimalExcelCellWriter
	{
		#region Properties: Public

		///<inheritdoc />
		public override ExcelCellFormat ExcelCellFormat => ExcelCellFormat.Date;

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Gets an adjusted date and time value.
		/// </summary>
		/// <param name="value">The value to adjust.</param>
		/// <returns>An adjusted date and time value.</returns>
		protected virtual DateTime GetAdjustedDateTimeValue(DateTime value) {
			return value.Date;
		}

		///<inheritdoc />
		protected override string FormatValue(object value) {
			var result = string.Empty;
			if (DateTime.TryParse(value.ToString(), out var dateValue)) {
				try {
					result = GetAdjustedDateTimeValue(dateValue).ToOADate().ToString(OpenXmlNumberFormatInfo);
				} catch (OverflowException ex) {
					Log.Error($"DateExcelCellWriter. Could not format value: {dateValue}. Exception: {ex}");
				}
			}
			return result;
		}

		#endregion
	}

	#endregion
}
