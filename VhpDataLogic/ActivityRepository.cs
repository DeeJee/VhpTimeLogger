using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VhpDataLogic.Interfaces;
using NLog;
using VhpDataEntities;

namespace VhpDataLogic
{
    public class ActivityRepository : IActivityRepository
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        public List<Activities> GetAll()
        {
            log.Info("GetAll");
            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                return entities.Activities.ToList();
            }
        }

        public List<Activities> GetActive()
        {
            log.Info("GetActive");
            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                return entities.Activities.Where(w => w.Active).ToList();
            }
        }

        public void Update(Activities activity)
        {
            log.Info("Update({0})", activity);
            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                var oldProject = entities.Activities.Where(p => p.Id == activity.Id).First();
                oldProject.Name = activity.Name;
                oldProject.Active = activity.Active;
                entities.SaveChanges();
            }
        }

        public void Insert(Activities activity)
        {
            log.Info("Insert({0})", activity);
            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                activity.Id = GetId(entities);
                entities.AddObject("Activities", activity);
                entities.SaveChanges();
            }
        }

        public void Delete(Activities activity)
        {
            log.Info("Delete({0})", activity);
            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                var entityToBeDeleted = entities.Activities.Where(w => w.Id == activity.Id).First();
                entities.DeleteObject(entityToBeDeleted);
                entities.SaveChanges();
            }
        }

        private decimal GetId(TimeloggerDatabaseEntities entities)
        {
            log.Info("GetId");
            Activities activity = entities.Activities.OrderByDescending(o => o.Id).FirstOrDefault();
            if (activity == null)
            {
                return 1;
            }
            return activity.Id + 1;
        }
    }
}
