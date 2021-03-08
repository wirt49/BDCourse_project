using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Reposytories.Concrete.EF;
namespace Reposytories.Abstract
{
    public interface ISubjectReposytory
    {
        IEnumerable<Subject> GetAllSubjects();
        bool Add(Subject subject);
        bool Delete(Subject subject);
        bool Update(Subject subject);
        bool DeleteReference(Subject subject);
    }
}
