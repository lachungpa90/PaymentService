using Microsoft.EntityFrameworkCore;
using PaymentAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {

        }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }

    }
}
