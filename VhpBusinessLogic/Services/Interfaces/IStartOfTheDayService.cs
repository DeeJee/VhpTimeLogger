using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Services.Interfaces
{
    public interface IStartOfTheDayService
    {
        DateTime? Get();
        void Insert(DateTime startOfTheDay);
    }
}
