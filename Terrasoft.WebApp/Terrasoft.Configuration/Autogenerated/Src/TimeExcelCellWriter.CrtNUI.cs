namespace Terrasoft.Configuration.ExportToExcel
{
	using System;

	#region Class: TimeExcelCellWriter

	/// <summary>
	/// Time excel cell writer.
	/// </summary>	
	public class TimeExcelCellWriter : DateExcelCellWriter
	{
		#region Properties: Public

		///<inheritdoc />
		public override ExcelCellFormat ExcelCellFormat => ExcelCellFormat.Time;

		#endregion

		#region Methods: Protected

		///<inheritdoc />
		protected override DateTime GetAdjustedDateTimeValue(DateTime value) {
			return default(DateTime).Add(value.TimeOfDay);
		}

		#endregion
	}

	#endregion
}
