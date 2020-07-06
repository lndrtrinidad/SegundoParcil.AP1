using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegundoParcial.AP1.DAL
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Sources= Data\SegundoParcial.AP1.Db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                
        }
    }
}
