using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Reposytories.Abstract;
namespace Reposytories.Concrete.EF
{
    public class HistoryReposytory: IHistoryReposytory
    {
        public IEnumerable<History> GetAllHistory()
        {
            using (var dbContext = new SheduleEntities())
            {
                return dbContext.History.ToList();
            }
        }
    }
}
