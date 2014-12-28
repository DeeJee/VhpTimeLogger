using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLogic.Helpers;
using VhpDataLogic.Interfaces;
using NLog;
using VhpDataEntities;

namespace VhpDataLogic
{
    public class WorkregistrationRepository : IWorkregistrationRepository
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public void PersistRegistrations(IEnumerable<WorkRegistration> workRegistrations)
        {
            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                foreach (var workRegistration in workRegistrations)
                {
                    if (workRegistration.ID == 0)
                    {
                        Insert(workRegistration, entities);
                    }
                    else
                    {
                        Update(workRegistration, entities);
                    }
                }
            }
        }

        public void Insert(WorkRegistration workRegistration, TimeloggerDatabaseEntities entities)
        {
            log.Info("Insert({0})", workRegistration);
            //using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                int id = GetId(entities);
                workRegistration.ID = id;
                DateTime now = DateTime.Now;
                workRegistration.DateCreated = now;
                workRegistration.DateModified = now;

                entities.AddObject("WorkRegistration", workRegistration);
                entities.SaveChanges();
            }
        }

        public void Update(WorkRegistration fromUi, TimeloggerDatabaseEntities entities)
        {
            log.Info("Update({0})", fromUi);
            //using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                WorkRegistration toDatabase = entities.WorkRegistration.First(w => w.ID == fromUi.ID);
                fromUi.CopyTo(toDatabase);

                entities.SaveChanges();
            }
        }

        private int GetId(TimeloggerDatabaseEntities entities)
        {
            log.Info("GetId");
            WorkRegistration registration = entities.WorkRegistration.OrderByDescending(o => o.ID).FirstOrDefault();
            if (registration == null)
            {
                return 1;
            }
            return registration.ID + 1;
        }

        public List<WorkRegistration> GetForDate(DateTime date)
        {
            log.Info("GetForDate({0})", date.ToString());
            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                int currentYear = DateTime.Now.Year;
                int currentMonth = DateTime.Now.Month;
                int currentDay = DateTime.Now.Day;

                //List<WorkRegistration> registrations = entities.WorkRegistration.Where(w => w.DateCreated.Year == currentYear &&
                //            w.DateCreated.Month == currentMonth &&
                //            w.DateCreated.Day == currentDay).ToList();

                List<WorkRegistration> registrations = entities.WorkRegistration.Where(w => w.DateWorkDone == date).ToList();

                return registrations;
            }            
        }

        public List<WorkRegistration> GetForPeriod(DateTime from, DateTime to)
        {
            log.Info("GetForPeriod({0}, {1})", from.ToString(), to.ToString());
            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                List<WorkRegistration> registrations = entities.WorkRegistration.Where(w =>
                            w.DateCreated >= from &&
                            w.DateCreated <= to
                            ).ToList();

                return registrations;
            }
        }
    }
}
