using System.Collections.Generic;
using Models;
using Reposytories.Concrete;
namespace Reposytories.Abstract
{
    public interface IGroupReposytory
    {
        IEnumerable<Groups> GetAllGroups();
        bool Add(Groups groups);
        bool Delete(Groups groups);
        bool DeleteReference(Groups groups);
        bool Update(Groups groups);
    }
}
