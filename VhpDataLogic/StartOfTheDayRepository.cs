using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VhpDataLogic.Interfaces;
using System.Data;
using VhpDataEntities;

namespace VhpDataLogic
{
    public class StartOfTheDayRepository : IStartOfTheDayRepository
    {
        public StartOfTheDay Get()
        {
            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                DateTime date = DateTime.Now.Date;
                return entities.StartOfTheDay.FirstOrDefault(s => s.Date == date);
            }
        }

        public void Insert(StartOfTheDay startOfTheDay)
        {
            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                int id = GetId(entities);
                startOfTheDay.Id = id;
                entities.AddObject("StartOfTheDay", startOfTheDay);
                entities.SaveChanges();
            }
        }

        private int GetId(TimeloggerDatabaseEntities entities)
        {
            StartOfTheDay startOfTheDay = entities.StartOfTheDay.OrderByDescending(o => o.Id).FirstOrDefault();
            if (startOfTheDay == null)
            {
                return 1;
            }
            return startOfTheDay.Id + 1;
        }
    }
}
