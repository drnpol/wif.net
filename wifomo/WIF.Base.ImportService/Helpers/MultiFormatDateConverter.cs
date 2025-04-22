using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;

namespace WIF.Base.ImportService.Helpers
{
    public class MultiFormatDateConverter : ITypeConverter
    {
        private readonly string[] _dateFormats = { "MM/dd/yyyy H:mm", "dd/MM/yyyy H:mm", "yyyy-MM-dd HH:mm:ss" };

        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            foreach (var format in _dateFormats)
            {
                if (DateTime.TryParseExact(text, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                {
                    return date;
                }
            }

            throw new TypeConverterException(this, memberMapData, text, row.Context, $"Cannot convert '{text}' to DateTime using the provided formats.");
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value is DateTime date)
            {
                return date.ToString(_dateFormats[0], CultureInfo.InvariantCulture); // Use the first format for writing
            }

            return string.Empty;
        }
    }
}
