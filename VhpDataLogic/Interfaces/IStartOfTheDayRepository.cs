using System;
using VhpDataEntities;
namespace VhpDataLogic.Interfaces
{
    public interface IStartOfTheDayRepository
    {
        StartOfTheDay Get();
        void Insert(StartOfTheDay startOfTheDay);
    }
}
