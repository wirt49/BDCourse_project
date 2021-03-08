using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Reposytories.Abstract;
namespace Reposytories.Concrete.EF
{
    public class LessonReposytory : ILessonReposytory
    {
        public IEnumerable<Lesson> GetAllLessons()
        {
            using (var dbContext = new SheduleEntities())
            {
                return dbContext.Lesson.ToList();
            }
        }

        public bool Add(Lesson lesson)
        {
            using (var dbContext = new SheduleEntities())
            {
                dbContext.Lesson.Add(lesson);
                dbContext.SaveChanges();
                return true;
            }
        }
        public bool Delete(Lesson lesson)
        {
            using (var dbContext = new SheduleEntities())
            {
                var dbLesson = dbContext.Lesson.Where(x => x.Id == lesson.Id).FirstOrDefault();
                dbContext.Lesson.Remove(dbLesson);
                dbContext.SaveChanges();

                return true;
            }
        }

        public bool Update(Lesson lesson)
        {
            using (var dbContext = new SheduleEntities())
            {
                var old = dbContext.Lesson.FirstOrDefault(s => s.Id == lesson.Id);
                old.Subject = lesson.Subject;
                old.Lecturer = lesson.Lecturer;
                old.Audience = lesson.Audience;
                old.Academic_group = lesson.Academic_group;
                old.Time = lesson.Time;
                old.Day = lesson.Day;
                old.Type = lesson.Type;
                dbContext.SaveChanges();
            }
            return true;
        }
    }
}
