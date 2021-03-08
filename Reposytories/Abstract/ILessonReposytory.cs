using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Reposytories.Concrete.EF;
namespace Reposytories.Abstract
{
    public interface ILessonReposytory
    {
        IEnumerable<Lesson> GetAllLessons();
        bool Add(Lesson lesson);
        bool Delete(Lesson lesson);
        bool Update(Lesson lesson);
    }
}
