﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(MicroAlParqueContext))]
    partial class MicroAlParqueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("RestauranteId")
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ListaChequeoId");

                    b.HasIndex("RestauranteId");

                    b.ToTable("ListasDeChequeo");
                });

            modelBuilder.Entity("Entidad.ManipuladorDeAlimento", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("NivelEducativo")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("PaisDeProcedencia")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("PrimerApellido")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<int>("SedeId")
                        .HasColumnType("int");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.HasKey("Identificacion");

                    b.HasIndex("SedeId");

                    b.ToTable("Manipuladores");
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

                    b.Property<string>("PerteneceA")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.HasKey("PreguntaId");

                    b.ToTable("Preguntas");
                });

            modelBuilder.Entity("Entidad.Propietario", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<int>("Edad")
                        .HasColumnType("int");

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

                    b.ToTable("Propietario");
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
                    b.Property<string>("NIT")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(35)")
                        .HasMaxLength(35);

                    b.Property<string>("PropietarioIdentificacion")
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("NIT");

                    b.HasIndex("PropietarioIdentificacion");

                    b.ToTable("Restaurantes");
                });

            modelBuilder.Entity("Entidad.Sede", b =>
                {
                    b.Property<int>("SedeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("RestauranteId")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("SedeId");

                    b.HasIndex("RestauranteId");

                    b.ToTable("Sedes");
                });

            modelBuilder.Entity("Entidad.Usuario", b =>
                {
                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Contrasena")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("PrimerApellido")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.HasKey("NombreUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Entidad.ListaChequeo", b =>
                {
                    b.HasOne("Entidad.Restaurante", null)
                        .WithMany()
                        .HasForeignKey("RestauranteId");
                });

            modelBuilder.Entity("Entidad.ManipuladorDeAlimento", b =>
                {
                    b.HasOne("Entidad.Sede", null)
                        .WithMany()
                        .HasForeignKey("SedeId")
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
                    b.HasOne("Entidad.Propietario", "Propietario")
                        .WithMany()
                        .HasForeignKey("PropietarioIdentificacion");
                });

            modelBuilder.Entity("Entidad.Sede", b =>
                {
                    b.HasOne("Entidad.Restaurante", null)
                        .WithMany()
                        .HasForeignKey("RestauranteId");
                });
#pragma warning restore 612, 618
        }
    }
}
