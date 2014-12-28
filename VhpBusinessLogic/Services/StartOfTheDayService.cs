using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Services.Interfaces;
using VhpDataLogic.Interfaces;
using VhpDataLogic;
using VhpDataEntities;

namespace VhpBusinessLogic.Services
{
    public class StartOfTheDayService:IStartOfTheDayService
    {
        IStartOfTheDayRepository repository;

        public StartOfTheDayService()
        {
            repository=new StartOfTheDayRepository();
        }


        public DateTime? Get()
        {
            StartOfTheDay start = repository.Get();
            if (start == null)
            {
                return null;
            }
            return repository.Get().StartTime;            
        }

        public void Insert(DateTime start)
        {
            StartOfTheDay startOfTheDay = new StartOfTheDay { StartTime = start, Date = DateTime.Now.Date };            
            repository.Insert(startOfTheDay);
        }
    }
}
