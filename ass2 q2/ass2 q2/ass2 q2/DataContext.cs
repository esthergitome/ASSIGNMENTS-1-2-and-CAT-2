using Microsoft.EntityFrameworkCore;
using Safaricom_Points;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteExample
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Yobi_Main\Yobi_Campo BSD\YEAR 4 BSD\Year 4 SEM 2\BSD 3202 Advanced Application Programming\AAP Assignments\Assignment 2\sqlite.db");
        }

        public DbSet<Subscriptions> Subscription { get; set; }
    }
}
