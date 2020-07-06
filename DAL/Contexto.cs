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
        public DbSet<DetalleTarea> DetalleTarea { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Sources= Data\SegundoParcial.AP1.Db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Crear 4 proyectos
            modelBuilder.Entity<Proyecto>().HasData(new Proyecto { ProyectoId = 1, Descripcion = "Analicis", fecha = DateTime.Now});
            modelBuilder.Entity<Proyecto>().HasData(new Proyecto { ProyectoId = 2, Descripcion = "Programacion", fecha = DateTime.Now });
            modelBuilder.Entity<Proyecto>().HasData(new Proyecto { ProyectoId = 3, Descripcion = "Prueba", fecha = DateTime.Now });
            modelBuilder.Entity<Proyecto>().HasData(new Proyecto { ProyectoId = 4, Descripcion = "Diseño", fecha = DateTime.Now });
        }
    }
}
