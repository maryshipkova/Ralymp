using System.Collections;
using System.Collections.Generic;
using OfficeOpenXml;

namespace Ralymp.ExcelParser
{
    public static class ExcelCustomExtensions
    {
        public static IEnumerable<ExcelRow> EnumerateRows(this ExcelWorksheet worksheet)
        {
            ExcelCellAddress start = worksheet.Dimension.Start;
            ExcelCellAddress end = worksheet.Dimension.End;
            for (int row = start.Row; row <= end.Row; row++)
            {
                yield return worksheet.Row(row);
            }
        }
    }
}