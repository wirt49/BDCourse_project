using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reposytories.Abstract;
using Models;
namespace Reposytories.Concrete.EF
{
    public class AudienceReposytory: IAudienceReposytory
    {
        public IEnumerable<Audience> GetAllAudiences()
        {
            using (var dbContext = new SheduleEntities())
            {
                return dbContext.Audience.ToList();
            }
        }

        public bool Add(Audience audience)
        {
            using (var dbContext = new SheduleEntities())
            {
                dbContext.Audience.Add(audience);
                dbContext.SaveChanges();
                return true;
            }
        }

        public bool DeleteReference(Audience audience)
        {
            using (var dbContext = new SheduleEntities())
            {
                var dblesson = dbContext.Lesson.Where(x => x.Audience == audience.Id).FirstOrDefault();
                if (dblesson != null)
                {
                    dbContext.Lesson.Remove(dblesson);
                    dbContext.SaveChanges();
                }
                return true;
            }
        }
        public bool Delete(Audience audience)
        {
            using (var dbContext = new SheduleEntities())
            {
                var dbAudience = dbContext.Audience.Where(x => x.Id == audience.Id).FirstOrDefault();
                if (dbAudience != null)
                {
                    dbContext.Audience.Remove(dbAudience);
                    dbContext.SaveChanges();
                }
                return true;
            }
        }

        public bool Update(Audience audience)
        {
            using (var dbContext = new SheduleEntities())
            {
                var old = dbContext.Audience.FirstOrDefault(s => s.Id == audience.Id);
                old.Number = audience.Number;
                dbContext.SaveChanges();
            }
            return true;
        }
    }
}
