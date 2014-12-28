using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VhpDataEntities;
using Yogesh.ExcelXml;
using System.Diagnostics;
using VhpDataLogic;

namespace BusinessLogic
{
    public class Uitdraai
    {
        private int rowIndex;

        public ExcelXmlWorkbook Create(DateTime from, DateTime to)
        {
            ExcelXmlWorkbook book = new ExcelXmlWorkbook();
            Worksheet sheet = book[0];

            var list = new WorkregistrationRepository().GetForPeriod(from, to);
            List<IGrouping<DateTime, WorkRegistration>> groups = list.OrderBy(o => o.DateWorkDone)
                                                                     .ThenBy(t => t.Project)
                                                                     .ThenBy(t => t.Activity)
                                                                     .GroupBy(g => g.DateWorkDone).ToList();

            CreateReportHeader(sheet, from, to);

            foreach (IGrouping<DateTime, WorkRegistration> group in groups)
            {
                EmptyLine();
                foreach (WorkRegistration registration in group)
                {
                    PrintLine(registration, sheet);
                }
            }

            SetColumnWidth(new int[] { 70, 70, 70, 200, 200, 50, 200, 100, 100 }, sheet);


            return book;
        }

        private void SetColumnWidth(int[] columnWidths, Worksheet sheet)
        {
            int index = 0;
            foreach (int width in columnWidths)
            {
                sheet.Columns(index).Width = width;
                index++;
            }
        }

        private void PrintLine(WorkRegistration line, Worksheet sheet)
        {
            sheet[rowIndex][0].Value = line.DateWorkDone.ToString(Constants.DateMask);
            sheet[rowIndex][1].Value = line.WorkedFrom.ToShortTimeString();
            sheet[rowIndex][2].Value = line.WorkedTo.ToShortTimeString();
            sheet[rowIndex][3].Value = line.Project;
            sheet[rowIndex][4].Value = line.Activity;
            sheet[rowIndex][5].Value = line.TimeSpent;
            sheet[rowIndex][6].Value = line.Description;
            sheet[rowIndex][7].Value = line.DateCreated;
            sheet[rowIndex][8].Value = line.DateModified;
            rowIndex++;
        }

        private void EmptyLine()
        {
            rowIndex++;
        }

        private void CreateReportHeader(Worksheet sheet, DateTime van, DateTime tot)
        {
            Range range = new Range(sheet[rowIndex][0], sheet[rowIndex][3]);
            range.Merge();
            sheet[rowIndex][0].Value = String.Format("Specificatie van {0} tm {1}", van.ToString(Constants.DateMask), tot.ToString(Constants.DateMask));
            EmptyLine();
            sheet[rowIndex][0].Value = "Datum";
            sheet[rowIndex][1].Value = "Van";
            sheet[rowIndex][2].Value = "Tot";
            sheet[rowIndex][3].Value = "Project";
            sheet[rowIndex][4].Value = "Activiteit";
            sheet[rowIndex][5].Value = "Tijdsduur";
            sheet[rowIndex][6].Value = "Omschrijving";
            sheet[rowIndex][7].Value = "Aanmaak datum";
            sheet[rowIndex][8].Value = "Datum aangepast";
            rowIndex++;
        }
    }
}
