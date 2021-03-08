using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reposytories.Abstract;
using Models;
namespace Reposytories.Concrete.EF
{
    public class SubjectReposytory: ISubjectReposytory
    {
        public IEnumerable<Subject> GetAllSubjects()
        {
            using (var dbContext = new SheduleEntities())
            {
                return dbContext.Subject.ToList();
            }
        }

        public bool Add(Subject subject)
        {
            using (var dbContext = new SheduleEntities())
            {
                dbContext.Subject.Add(subject);
                dbContext.SaveChanges();
                return true;
            }
        }

        public bool DeleteReference(Subject subject)
        {
            using (var dbContext = new SheduleEntities())
            {
                var dblesson = dbContext.Lesson.Where(x => x.Subject == subject.Id).FirstOrDefault();
                if (dblesson != null)
                {
                    dbContext.Lesson.Remove(dblesson);
                    dbContext.SaveChanges();
                }
                return true;
            }
        }

        public bool Delete(Subject subject)
        {
            using (var dbContext = new SheduleEntities())
            {
                var dbSubject = dbContext.Subject.Where(x => x.Id == subject.Id).FirstOrDefault();
                dbContext.Subject.Remove(dbSubject);
                dbContext.SaveChanges();

                return true;
            }
        }

        public bool Update(Subject subject)
        {
            using (var dbContext = new SheduleEntities())
            {
                var old = dbContext.Subject.FirstOrDefault(s => s.Id == subject.Id);
                old.Name = subject.Name;
            }
            return true;
        }
    }
}
