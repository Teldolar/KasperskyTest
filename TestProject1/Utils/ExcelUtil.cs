using ExcelLibrary.SpreadSheet;

namespace TestProject1.Utils
{
    public static class ExcelUtil
    {
        public static object[] GetAllRawsFromExcel(string path)
        {
            var workbook = Workbook.Load(path);
            var worksheet = workbook.Worksheets[0];
            var cells = worksheet.Cells;
            var rows = new object[cells.LastRowIndex + 1];
            for (var rowIndex = cells.FirstRowIndex; rowIndex <= cells.LastRowIndex; rowIndex++)
            {
                var values = new string[cells.LastColIndex+1];
                for (var j = 0; j < 4; j++)
                {
                    values[j] = cells.GetRow(rowIndex).GetCell(j).Value.ToString();
                }
                rows[rowIndex] = values;
            }

            return rows;
        }
    }
}