using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VhpDataEntities;

namespace BusinessLogic.Services.Interfaces
{
    public interface IProjectService
    {
        List<Projects> GetAll();
        List<Projects> GetActive();
        Projects GetById(int id);
        void Update(decimal id, string name, bool active);
        void Insert(string name, bool active);
        void Delete(int id);
    }
}
