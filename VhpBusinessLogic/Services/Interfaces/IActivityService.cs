using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VhpDataEntities;

namespace BusinessLogic.Services.Interfaces
{
    public interface IActivityService
    {
        List<Activities> GetAll();
        List<Activities> GetActive();
    }
}
