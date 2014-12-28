using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Services.Interfaces;
using VhpDataLogic.Interfaces;
using VhpDataLogic;
using VhpDataEntities;

namespace BusinessLogic.Services
{
    public class WorkregistrationService : IWorkRegistrationService
    {
        IWorkregistrationRepository repository;

        public WorkregistrationService()
        {
            repository = new WorkregistrationRepository();
        }

        public List<WorkRegistration> GetForPeriod(DateTime from, DateTime to)
        {
            return repository.GetForPeriod(from, to);   
        }

        public List<WorkRegistration> GetForDate(DateTime date)
        {
            return repository.GetForDate(date);
        }

        //public void Insert(WorkRegistration registration)
        //{
        //    if (registration.DateWorkDone == DateTime.MinValue)
        //    {
        //        DateTime now = DateTime.Now;
        //        registration.DateWorkDone = new DateTime(now.Year, now.Month, now.Day);
        //    }
        //    repository.Insert(registration);
        //}

        //public void Update(WorkRegistration workRegistration)
        //{
        //    repository.Update(workRegistration);
        //}

        //public void PersistRegistration(WorkRegistration registration)
        //{
        //    if (registration.ID == 0)
        //    {
        //        Insert(registration);
        //    }
        //    else
        //    {
        //        Update(registration);
        //    }                        
        //}

        public void PersistRegistrations(IEnumerable<WorkRegistration> registrations)
        {
            repository.PersistRegistrations(registrations);
        }
    }
}
