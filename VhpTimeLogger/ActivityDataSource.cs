using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Services.Interfaces;
using BusinessLogic.Services;

namespace VhpTimeLogger
{
    public class ActivityDataSource
    {
        private static string[] activities;

        public static string[] GetData()
        {
            if (activities == null)
            {
                activities = new ActivityService().GetActive().Select(s=>s.Name).ToArray();
            }
            return activities;
        }

        public static void Flush()
        {
            activities = null;
        }
    }
}
