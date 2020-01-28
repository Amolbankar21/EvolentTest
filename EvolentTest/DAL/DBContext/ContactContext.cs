
using EvolentTest.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvolentTest.DAL.DBContext
{
    public class RepositoryContext : DbContext
    {       

        public RepositoryContext(DbContextOptions options)
           : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=EvolentHealth.db");
        }
    }
}
