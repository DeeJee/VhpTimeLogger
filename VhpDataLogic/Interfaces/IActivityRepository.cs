using System;
using System.Collections.Generic;
using VhpDataEntities;
namespace VhpDataLogic.Interfaces
{
    public interface IActivityRepository
    {
        List<Activities> GetAll();
        List<Activities> GetActive();
        void Delete(Activities activity);
        void Insert(Activities activity);
        void Update(Activities activity);
    }
}
