using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yogesh.ExcelXml;
using System.Diagnostics;
using VhpDataLogic;
using VhpDataEntities;

namespace BusinessLogic
{
    public class GroupedReport
    {
        private int rowIndex;

        public ExcelXmlWorkbook Create(DateTime from, DateTime to)
        {
            ExcelXmlWorkbook book = new ExcelXmlWorkbook();
            Worksheet sheet = book[0];

            CreateReportHeader(sheet, from, to);

            WorkregistrationRepository repo = new WorkregistrationRepository();

            List<WorkRegistration> list = repo.GetForPeriod(from, to).OrderBy(o => o.DateWorkDone).ThenBy(t => t.Project).ThenBy(t => t.Activity).ToList();
            var projecten = from project in list
                            group project by project.Project
                                into projectGroup
                                select new
                                {
                                    Name = projectGroup.Key,
                                    Activities = from activity in projectGroup
                                                 group activity by activity.Activity into activityGroup
                                                 select new
                                                 {
                                                     Name = activityGroup.Key,
                                                     TimeSpent = activityGroup.Sum(a => a.TimeSpent)
                                                 }
                                };

            EmptyLine();
            decimal totaal = 0;
            foreach (var project in projecten)
            {
                CreateProjectHeader(sheet, project.Name);
                rowIndex++;
                decimal subTotaal = 0;
                foreach (var activity in project.Activities)
                {
                    sheet[rowIndex][0].Value = activity.Name;
                    sheet[rowIndex][1].Value = ConvertToUren(activity.TimeSpent);
                    subTotaal += activity.TimeSpent;
                    rowIndex++;
                }
                totaal += subTotaal;
                sheet[rowIndex][0].Value = "Subtotaal";
                sheet[rowIndex][1].Value = ConvertToUren(subTotaal);
                rowIndex++;

                EmptyLine();
            }
            sheet[rowIndex][0].Value = "Totaal";
            sheet[rowIndex][1].Value = ConvertToUren(totaal);

            SetColumnWidth(new int[] { 200, 70 }, sheet);

            return book;
        }

        private decimal ConvertToUren(decimal subTotaal)
        {
            //conversion to hours
            decimal result = subTotaal / 60;
            //rounding to nearest quarter
            decimal rounded = Math.Round(result * 4, MidpointRounding.ToEven) / 4;
            return rounded;
        }

        private void EmptyLine()
        {
            rowIndex++;
        }

        private void CreateProjectHeader(Worksheet sheet, string project)
        {
            //Project: 1000 algemeen
            //Activiteit        Tijdsduur
            sheet[rowIndex][0].Value = String.Format("Project: {0}", project);
            rowIndex++;
            sheet[rowIndex][0].Value = "Activiteit";
            sheet[rowIndex][1].Value = "Tijdsduur (uur)";
        }



        private void CreateReportHeader(Worksheet sheet, DateTime van, DateTime tot)
        {
            //Specificatie van 01-06-2013 tm 15-06-2013
            sheet[rowIndex++][0].Value = "Urenspecificatie: Ronald Jansen";
            EmptyLine();
            sheet[rowIndex][0].Value = "Van (datum)";
            sheet[rowIndex++][1].Value = van.ToString("dd-MM-yyyy");
            sheet[rowIndex][0].Value = "Tot (datum)";
            sheet[rowIndex++][1].Value = tot.ToString("dd-MM-yyyy");
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
    }
}
