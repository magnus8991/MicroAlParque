﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(MicroAlParqueContext))]
    [Migration("20201105130950_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidad.ListaChequeo", b =>
                {
                    b.Property<int>("ListaChequeoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RestauranteId")
                        .HasColumnType("int");

                    b.HasKey("ListaChequeoId");

                    b.HasIndex("RestauranteId");

                    b.ToTable("ListasDeChequeo");
                });

            modelBuilder.Entity("Entidad.Persona", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("Int");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("PrimerApellido")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.HasKey("Identificacion");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Entidad.Pregunta", b =>
                {
                    b.Property<int>("PreguntaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Enunciado")
                        .HasColumnType("nvarchar(190)")
                        .HasMaxLength(190);

                    b.HasKey("PreguntaId");

                    b.ToTable("Preguntas");
                });

            modelBuilder.Entity("Entidad.Respuesta", b =>
                {
                    b.Property<int>("RespuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContenidoRespuesta")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("PreguntaId")
                        .HasColumnType("int");

                    b.HasKey("RespuestaId");

                    b.HasIndex("Identificacion");

                    b.HasIndex("PreguntaId");

                    b.ToTable("Respuestas");
                });

            modelBuilder.Entity("Entidad.RespuestaChequeo", b =>
                {
                    b.Property<int>("RespuestaChequeoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContenidoRespuesta")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int?>("ListaChequeoId")
                        .HasColumnType("int");

                    b.Property<int>("PreguntaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Puntaje")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("RespuestaChequeoId");

                    b.HasIndex("ListaChequeoId");

                    b.HasIndex("PreguntaId");

                    b.ToTable("RespuestaChequeo");
                });

            modelBuilder.Entity("Entidad.Restaurante", b =>
                {
                    b.Property<int>("IdRestaurante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(35)")
                        .HasMaxLength(35);

                    b.HasKey("IdRestaurante");

                    b.HasIndex("Identificacion");

                    b.ToTable("Restaurantes");
                });

            modelBuilder.Entity("Entidad.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("TipoUsuario")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("UsuarioId");

                    b.HasIndex("Identificacion");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Entidad.ManipuladorDeAlimento", b =>
                {
                    b.HasBaseType("Entidad.Persona");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("NivelEducativo")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("PaisDeProcedencia")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<int>("RestauranteId")
                        .HasColumnType("int");

                    b.HasIndex("RestauranteId");

                    b.HasDiscriminator().HasValue("ManipuladorDeAlimento");
                });

            modelBuilder.Entity("Entidad.ListaChequeo", b =>
                {
                    b.HasOne("Entidad.Restaurante", null)
                        .WithMany()
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entidad.Respuesta", b =>
                {
                    b.HasOne("Entidad.ManipuladorDeAlimento", null)
                        .WithMany()
                        .HasForeignKey("Identificacion");

                    b.HasOne("Entidad.Pregunta", null)
                        .WithMany()
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entidad.RespuestaChequeo", b =>
                {
                    b.HasOne("Entidad.ListaChequeo", null)
                        .WithMany("RespuestaChequeos")
                        .HasForeignKey("ListaChequeoId");

                    b.HasOne("Entidad.Pregunta", null)
                        .WithMany()
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entidad.Restaurante", b =>
                {
                    b.HasOne("Entidad.Persona", null)
                        .WithMany()
                        .HasForeignKey("Identificacion");
                });

            modelBuilder.Entity("Entidad.Usuario", b =>
                {
                    b.HasOne("Entidad.Persona", null)
                        .WithMany()
                        .HasForeignKey("Identificacion");
                });

            modelBuilder.Entity("Entidad.ManipuladorDeAlimento", b =>
                {
                    b.HasOne("Entidad.Restaurante", null)
                        .WithMany()
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
