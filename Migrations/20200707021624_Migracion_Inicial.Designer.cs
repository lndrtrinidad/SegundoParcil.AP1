﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SegundoParcial.AP1.DAL;

namespace SegundoParcial.AP1.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200707021624_Migracion_Inicial")]
    partial class Migracion_Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("SegundoParcial.AP1.Entidades.DetalleTarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Requerimiento")
                        .HasColumnType("TEXT");

                    b.Property<int>("TareaId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Tiempo")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.ToTable("DetalleTarea");
                });

            modelBuilder.Entity("SegundoParcial.AP1.Entidades.Proyecto", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoTarea")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("TareaId");

                    b.ToTable("Proyecto");

                    b.HasData(
                        new
                        {
                            TareaId = 1,
                            TipoTarea = "Analicis",
                            fecha = new DateTime(2020, 7, 6, 22, 16, 23, 372, DateTimeKind.Local).AddTicks(7037)
                        },
                        new
                        {
                            TareaId = 2,
                            TipoTarea = "Programacion",
                            fecha = new DateTime(2020, 7, 6, 22, 16, 23, 377, DateTimeKind.Local).AddTicks(1531)
                        },
                        new
                        {
                            TareaId = 3,
                            TipoTarea = "Prueba",
                            fecha = new DateTime(2020, 7, 6, 22, 16, 23, 377, DateTimeKind.Local).AddTicks(1878)
                        },
                        new
                        {
                            TareaId = 4,
                            TipoTarea = "Diseño",
                            fecha = new DateTime(2020, 7, 6, 22, 16, 23, 377, DateTimeKind.Local).AddTicks(1930)
                        });
                });

            modelBuilder.Entity("SegundoParcial.AP1.Entidades.Tareas", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoTarea")
                        .HasColumnType("TEXT");

                    b.HasKey("TareaId");

                    b.ToTable("Tareas");
                });

            modelBuilder.Entity("SegundoParcial.AP1.Entidades.DetalleTarea", b =>
                {
                    b.HasOne("SegundoParcial.AP1.Entidades.Proyecto", null)
                        .WithMany("Detalle")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}