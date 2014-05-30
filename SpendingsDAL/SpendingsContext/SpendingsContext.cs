using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendingsBL.Entities;

namespace SpendingsDAL.SpendingsContext
{
    public class SpendingsContext: DbContext
    {
        public DbSet<PurchaseEntity> Purchase { get; set; }
    }
}
