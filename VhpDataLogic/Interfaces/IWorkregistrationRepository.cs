using System;
using VhpDataEntities;
using System.Linq;
using System.Collections.Generic;
namespace VhpDataLogic.Interfaces
{
    public interface IWorkregistrationRepository
    {
        List<WorkRegistration> GetForPeriod(DateTime from, DateTime to);
        List<WorkRegistration> GetForDate(DateTime date);
        void Insert(WorkRegistration workRegistration, TimeloggerDatabaseEntities entities);
        void Update(WorkRegistration registration, TimeloggerDatabaseEntities entities);

        void PersistRegistrations(IEnumerable<WorkRegistration> registrations);
    }
}
