using Microsoft.EntityFrameworkCore;
using SegundoParcial.AP1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegundoParcial.AP1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Tareas> Tareas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Sources= Data\SegundoParcial.AP1.Db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Crear 4 proyectos
            modelBuilder.Entity<Proyecto>().HasData(new Proyecto { TareaId = 1, TipoTarea = "Analicis"});
            modelBuilder.Entity<Proyecto>().HasData(new Proyecto { TareaId = 2, TipoTarea = "Programacion"});
            modelBuilder.Entity<Proyecto>().HasData(new Proyecto { TareaId = 3, TipoTarea = "Prueba"});
            modelBuilder.Entity<Proyecto>().HasData(new Proyecto { TareaId = 4, TipoTarea = "Diseño"});
        }
    }
}
