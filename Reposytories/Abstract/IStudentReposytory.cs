using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Reposytories.Concrete.EF;
namespace Reposytories.Abstract
{
    public interface IStudentReposytory
    {
        IEnumerable<Student> GetAllStudents();
        bool Add(Student student);
        bool Delete(Student student);
        bool Update(Student student);
    }
}
