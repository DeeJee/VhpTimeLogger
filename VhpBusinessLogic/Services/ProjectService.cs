using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Services.Interfaces;
using VhpDataLogic.Interfaces;
using VhpDataLogic;
using VhpDataEntities;

namespace BusinessLogic.Services
{
    public class ProjectService : IProjectService
    {
        IProjectRepository repository;
        public ProjectService()
        {
            this.repository = new ProjectRepository();
        }

        public List<Projects> GetAll()
        {
            return repository.GetAll();
        }

        public List<Projects> GetActive()
        {
            return repository.GetActive();
        }

        public Projects GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(decimal id, string name, bool active)
        {
            var project = new Projects { Id = id, Name = name, Active = active };
            repository.Update(project);            
        }

        public void Insert(string name, bool active)
        {
            var project = new Projects { Name = name, Active = active };
            repository.Insert(project);            
        }

        public void Delete(int id)
        {
            var project = new Projects { Id=id};
            repository.Delete(project);
        }
    }
}
