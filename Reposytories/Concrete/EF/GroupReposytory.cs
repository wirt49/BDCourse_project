using Models;
using Reposytories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposytories.Concrete.EF
{
    public class GroupReposytory : IGroupReposytory
    {
        public bool Add(Groups groups)
        {
            using (var dbContext = new SheduleEntities())
            {
                dbContext.Groups.Add(groups);
                dbContext.SaveChanges();
                return true;
            }
        }

        public IEnumerable<Groups> GetAllGroups()
        {
            using (var dbContext = new SheduleEntities())
            {
                return dbContext.Groups.ToList();
            }
        }

        public bool DeleteReference(Groups groups)
        {
            using (var dbContext = new SheduleEntities())
            {
                var dblesson = dbContext.Lesson.Where(x => x.Academic_group == groups.Id).FirstOrDefault();
                var dbstudent = dbContext.Student.Where(x => x.Group_number == groups.Id).FirstOrDefault();
                if (dblesson != null)
                {
                    dbContext.Lesson.Remove(dblesson);
                   
                }
                if(dbstudent != null)
                {
                    dbContext.Student.Remove(dbstudent);
                    dbContext.SaveChanges();
                }
                return true;
            }
        }

        public bool Delete(Groups groups)
        {
            using (var dbContext = new SheduleEntities())
            {
                var dbGroup = dbContext.Groups.Where(x => x.Id == groups.Id).FirstOrDefault();
                dbContext.Groups.Remove(dbGroup);
                dbContext.SaveChanges();

                return true;
            }
        }
        public bool Update(Groups groups)
        {
            using (var dbContext = new SheduleEntities())
            {
                var old = dbContext.Groups.FirstOrDefault(s => s.Id == groups.Id);
                old.Name = groups.Name;
                dbContext.SaveChanges();
            }
            return true;
        }
    }
}
