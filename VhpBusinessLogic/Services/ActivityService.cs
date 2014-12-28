using BusinessLogic.Services.Interfaces;
using VhpDataLogic.Interfaces;
using DataLogic;
using System.Linq;
using System.Collections.Generic;
using VhpDataEntities;
using VhpDataLogic;

namespace BusinessLogic.Services
{
    public class ActivityService:IActivityService
    {
        IActivityRepository repository;
        public ActivityService()
        {
            repository = new ActivityRepository();
        }

        public List<Activities> GetAll()
        {
            return repository.GetAll();
        }

        public List<Activities> GetActive()
        {
            return repository.GetActive();
        }

        public void Insert(string name, bool active)
        {
            var activity = new Activities { Name = name, Active = active };
            repository.Insert(activity);    
        }

        public void Update(int id, string name, bool active)
        {
            var activity = new Activities { Id = id, Name = name, Active = active };
            repository.Update(activity);   
        }

        public void Delete(int id)
        {
            var activity = new Activities { Id = id };
            repository.Delete(activity);
        }
    }
}
