using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Infrastructure.EFModel
{
    public class PaymentsContext : DbContext
    {
        public PaymentsContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Payment> Payment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
