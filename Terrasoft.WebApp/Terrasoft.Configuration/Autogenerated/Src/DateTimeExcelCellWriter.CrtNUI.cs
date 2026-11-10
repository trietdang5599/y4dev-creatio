namespace Terrasoft.Configuration.ExportToExcel
{
	using System;

	#region Class: DateTimeExcelCellWriter

	/// <summary>
	/// DateTime excel cell writer.
	/// </summary>
	public class DateTimeExcelCellWriter : DateExcelCellWriter
	{
		#region Properties: Public

		///<inheritdoc />
		public override ExcelCellFormat ExcelCellFormat => ExcelCellFormat.DateTime;

		#endregion

		#region Methods: Protected

		///<inheritdoc />
		protected override DateTime GetAdjustedDateTimeValue(DateTime value) {
			return value;
		}

		#endregion
	}

	#endregion
}
