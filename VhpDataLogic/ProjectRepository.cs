using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VhpDataLogic.Interfaces;
using NLog;
using VhpDataEntities;

namespace VhpDataLogic
{
    public class ProjectRepository : IProjectRepository
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        public List<Projects> GetAll()
        {
            log.Info("GetAll");

            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                return entities.Projects.OrderBy(o=>o.Name).ToList();
            }
        }

        public List<Projects> GetActive()
        {
            log.Info("GetActive");

            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                return entities.Projects.Where(w=>w.Active).OrderBy(o=>o.Name).ToList();
            }
        }

        public Projects GetById(decimal id)
        {
            log.Info("GetById({0})",id);
            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                IEnumerable<Projects> projecten = entities.Projects.Where(w=>w.Id==id);
                if (projecten.Count() > 1)
                {
                    throw new Exception("Er wordt maar een item verwacht");
                }
                return projecten.First();
            }
        }

        public void Update(Projects project)
        {
            log.Info("Update({0})",project);
            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                var oldProject = entities.Projects.Where(p => p.Id == project.Id).First();
                oldProject.Name = project.Name;
                oldProject.Active = project.Active;
                entities.SaveChanges();
            }
        }

        public void Insert(Projects project)
        {
            log.Info("Insert({0})", project);
            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                project.Id = GetId(entities);
                entities.AddObject("Projects", project);
                entities.SaveChanges();
            }
        }

        public void Delete(Projects project)
        {            
            using (TimeloggerDatabaseEntities entities = new TimeloggerDatabaseEntities())
            {
                var entityToBeDeleted = entities.Projects.Where(w => w.Id == project.Id).First();
                log.Info("Delete({0})", entityToBeDeleted);
                entities.DeleteObject(entityToBeDeleted);
                entities.SaveChanges();
            }
        }

        public IEnumerable<Projects> GetPaged(int skip, int take)
        {
            using (var context = new TimeloggerDatabaseEntities())
            {
                var query = context.Projects
                  .OrderBy(c => c.Name);
                return query.Skip(skip).Take(take).ToList();
            }
        }

        private decimal GetId(TimeloggerDatabaseEntities entities)
        {
            log.Info("GetId");
            Projects project= entities.Projects.OrderByDescending(o => o.Id).FirstOrDefault();
            if (project == null)
            {
                return 1;
            }
            return project.Id + 1;
        }
    }
}