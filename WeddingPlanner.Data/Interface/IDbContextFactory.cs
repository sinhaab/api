using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingPlanner.Data.Interface
{
    public interface IDbContextFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        WeddingPlannerEntities GetDbContext();
    }
}
