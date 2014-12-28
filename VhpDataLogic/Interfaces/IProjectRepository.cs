using System;
using System.Collections.Generic;
using VhpDataEntities;
namespace VhpDataLogic.Interfaces
{
    public interface IProjectRepository
    {
        List<Projects> GetAll();
        List<Projects> GetActive();
        Projects GetById(decimal id);
        void Update(Projects project);
        void Insert(Projects project);
        void Delete(Projects project);
    }
}
