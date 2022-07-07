
using Microsoft.EntityFrameworkCore;
using MyDotnetCoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDotnetCoreWebApp.Data
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext (DbContextOptions<RegistrationContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        //public DbSet<MyDotnetCoreWebApp.Models.Person> Person { get; set; }
    }
}
