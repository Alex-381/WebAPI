using SchoolLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibrary.Domain.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("ABCSchoolDB")
        {
            Database.SetInitializer<DatabaseContext>(new CreateDatabaseIfNotExists<DatabaseContext>());

            // remove this line before going into production
            // Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
    }
}
