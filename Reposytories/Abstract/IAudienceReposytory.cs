using System.Collections.Generic;
using Models;
using Reposytories.Concrete.EF;
namespace Reposytories.Abstract
{
    public interface IAudienceReposytory
    {
        IEnumerable<Audience> GetAllAudiences();
        bool Add(Audience audience);
        bool Delete(Audience audience);
        bool Update(Audience audience);
        bool DeleteReference(Audience audience);
    }
}
