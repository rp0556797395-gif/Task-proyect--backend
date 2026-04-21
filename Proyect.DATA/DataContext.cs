using Microsoft.EntityFrameworkCore;
using Proyect.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Tasks> listtask { get; set; }
        public DbSet<Clients> listclient { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=mytask");
        }

        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        // כאן מגדירים שהיישות Task אינה צריכה מפתח ראשי (אם זה הכוונה)
        //        modelBuilder.Entity<Tasks>().HasNoKey();
        //    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // כאן אתה מגדיר את המפתח הראשי ל-Task
            modelBuilder.Entity<Tasks>().HasKey(t => t.Code);  // הגדרה מפורשת של המפתח הראשי
        }
    }
}
