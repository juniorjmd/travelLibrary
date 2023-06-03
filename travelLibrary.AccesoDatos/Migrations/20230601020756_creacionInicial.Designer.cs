﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using travelLibrary.AccesoDatos.Data;

#nullable disable

namespace travelLibrary.AccesoDatos.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20230601020756_creacionInicial")]
    partial class creacionInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("travelLibrary.Models.Autores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("travelLibrary.Models.Autores_has_libros", b =>
                {
                    b.Property<int>("Autores_id")
                        .HasColumnType("int");

                    b.Property<int>("Libros_ISBN")
                        .HasColumnType("int");

                    b.HasIndex("Autores_id");

                    b.HasIndex("Libros_ISBN");

                    b.ToTable("Autores_has_libros");
                });

            modelBuilder.Entity("travelLibrary.Models.Editoriales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sede")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Editoriales");
                });

            modelBuilder.Entity("travelLibrary.Models.Libros", b =>
                {
                    b.Property<int>("ISBN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ISBN"));

                    b.Property<int>("Editoriales_id")
                        .HasColumnType("int");

                    b.Property<string>("Sinopsis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("n_paginas")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("VARCHAR");

                    b.HasKey("ISBN");

                    b.HasIndex("Editoriales_id");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("travelLibrary.Models.Autores_has_libros", b =>
                {
                    b.HasOne("travelLibrary.Models.Autores", "Autor")
                        .WithMany()
                        .HasForeignKey("Autores_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("travelLibrary.Models.Libros", "Libro")
                        .WithMany()
                        .HasForeignKey("Libros_ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Libro");
                });

            modelBuilder.Entity("travelLibrary.Models.Libros", b =>
                {
                    b.HasOne("travelLibrary.Models.Editoriales", "Editorial")
                        .WithMany()
                        .HasForeignKey("Editoriales_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editorial");
                });
#pragma warning restore 612, 618
        }
    }
}
