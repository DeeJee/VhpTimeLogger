using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Services;

namespace VhpTimeLogger
{
    public class ProjectDataSource
    {
        private static string[] projecten;

        public static string[] GetData()
        {
            if (projecten == null)
            {
                projecten = new ProjectService().GetActive().Select(s=>s.Name).ToArray();
            }
            return projecten;
        }

        public static void Flush()
        {
            projecten = null;
        }
    }
}
