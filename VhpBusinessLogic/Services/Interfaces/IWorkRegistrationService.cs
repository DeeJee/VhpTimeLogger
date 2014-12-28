using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLogic;
using VhpDataEntities;

namespace BusinessLogic.Services.Interfaces
{
    public interface IWorkRegistrationService
    {
        List<WorkRegistration> GetForPeriod(DateTime from, DateTime to);
        List<WorkRegistration> GetForDate(DateTime date);
        //void Insert(WorkRegistration workRegistration);
        //void Update(WorkRegistration workRegistration);
    }
}
