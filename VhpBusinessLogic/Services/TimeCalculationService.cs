using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Services
{
    public class TimeCalculationService
    {
        public int CalculateTimeToGo(DateTime startOfTheDay, DateTime now, int minutesAlreadyLogged)
        {
            TimeSpan timePassed = DateTime.Now - startOfTheDay;
            int teGaan = (int)timePassed.TotalMinutes - minutesAlreadyLogged;
            return teGaan;
        }
    }
}
