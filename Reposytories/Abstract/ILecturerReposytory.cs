using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Reposytories.Concrete.EF;
namespace Reposytories.Abstract
{
    public interface ILecturerReposytory
    {
        IEnumerable<Lecturer> GetAllLecturers();
        bool Add(Lecturer lecturer);
        bool Delete(Lecturer lecturer);
        bool DeleteReference(Lecturer lecturer);
        bool Update(Lecturer lecturer);
    }
}
