using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reposytories.Abstract;
using Models;

namespace Reposytories.Concrete.EF
{
    public class LecturerReposytory: ILecturerReposytory
    {
        public IEnumerable<Lecturer> GetAllLecturers()
        {
            using (var dbContext = new SheduleEntities())
            {
               return dbContext.Lecturer.ToList();
            }
        }
        public bool Add(Lecturer lecturer)
        {
            using (var dbContext = new SheduleEntities())
            {
                dbContext.Lecturer.Add(lecturer);
                dbContext.SaveChanges();
                return true;
            }
        }

        public bool DeleteReference(Lecturer lecturer)
        {
            using (var dbContext = new SheduleEntities())
            {
                var dblesson = dbContext.Lesson.Where(x => x.Lecturer == lecturer.Id).FirstOrDefault();
                if (dblesson != null)
                {
                    dbContext.Lesson.Remove(dblesson);
                    dbContext.SaveChanges();
                }
                return true;
            }
        }
        public bool Delete(Lecturer lecturer)
        {
            using (var dbContext = new SheduleEntities())
            {

                var dbLecturer = dbContext.Lecturer.Where(x => x.Id == lecturer.Id).FirstOrDefault();
                if (dbLecturer != null)
                {
                    dbContext.Lecturer.Remove(dbLecturer);
                    dbContext.SaveChanges();
                }
                return true;
            }
        }

        public bool Update(Lecturer lecturer)
        {
            using (var dbContext = new SheduleEntities())
            {
                var old = dbContext.Lecturer.FirstOrDefault(s => s.Id == lecturer.Id);
                old.FirstName = lecturer.FirstName;
                old.LastName = lecturer.LastName;
                old.Reputation = lecturer.Reputation;
                old.Phone = lecturer.Phone;
                dbContext.SaveChanges();
            }
            return true;
        }
    }
}
