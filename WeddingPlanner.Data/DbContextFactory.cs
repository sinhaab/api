using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingPlanner.Data.Interface;

namespace WeddingPlanner.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        public DbContextFactory()
        {
        }

        public WeddingPlannerEntities GetDbContext()
        {
            return new WeddingPlannerEntities();
        }
    }
}
