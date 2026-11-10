namespace Terrasoft.Configuration.ExportToExcel
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Xml;
	using DocumentFormat.OpenXml;
	using Terrasoft.Common;

	#region Class: StringExcelCellWriter

	/// <summary>
	/// String excel cell writer.
	/// </summary>
	public class StringExcelCellWriter : BaseExcelCellWriter
	{

		#region Properties: Protected

		protected string OpenXmlTypeTagAttribute => "t";

		protected string OpenXmlStringTypeAttribute => "str";

		protected int MaxCellCharactersCount => 32767;

		#endregion		

		#region Properties: Public
		
		///<inheritdoc />
		public override ExcelCellFormat ExcelCellFormat => ExcelCellFormat.String;

		#endregion

		#region Methods: Private
		
		/// <summary>
		/// Remove hexadecimal symbols.
		/// </summary>
		/// <param name="txt">Replacment text with hexadecimal symbols.</param>
		/// <returns>Text without hexadecimal symbols.</returns>
		private string RemoveHexadecimalSymbols(string txt) {
			string pattern = "[\x00-\x08\x0B\x0C\x0E-\x1F]";
			return Regex.Replace(txt, pattern, string.Empty, RegexOptions.Compiled);
		}
		
		private string RemoveInvalidXmlChars(string txt) {
			try {
				XmlConvert.VerifyXmlChars(txt);
				return txt;
			} catch {
				var validChars = txt.Where(XmlConvert.IsXmlChar).ToArray();
				return new string(validChars);
			}
		}
		
		#endregion
		
		#region Methods: Protected

		///<inheritdoc />
		protected override string FormatValue(object value) {
			if (!(value is string stringValue)) {
				stringValue = value.ToString();
			}
			stringValue = RemoveHexadecimalSymbols(stringValue);
			stringValue = StringUtilities.ConvertHtmlToPlainText(stringValue);
			stringValue = RemoveInvalidXmlChars(stringValue);
			if (stringValue.Length > MaxCellCharactersCount) {
				stringValue = stringValue.Substring(0, MaxCellCharactersCount);
			}
			return stringValue;
		}

		///<inheritdoc />
		protected override IEnumerable<OpenXmlAttribute> GetOpenXmlAttributes() {
			var openXmlAttributes = base.GetOpenXmlAttributes().ToList();
			openXmlAttributes.Add(new OpenXmlAttribute(OpenXmlTypeTagAttribute, null, OpenXmlStringTypeAttribute));
			return openXmlAttributes;
		}

		#endregion

	}

	#endregion
	
}
