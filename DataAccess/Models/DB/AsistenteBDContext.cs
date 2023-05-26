﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models.DB
{
    public partial class AsistenteBDContext : DbContext
    {
        public AsistenteBDContext()
        {
        }

        public AsistenteBDContext(DbContextOptions<AsistenteBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Relacion> Relacions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=AsistenteBD.mssql.somee.com;Initial Catalog=AsistenteBD;User ID=AsistenteCaronte_SQLLogin_1;Password=j57tky9se3;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.AsignacionNueva)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.AsignacionVieja)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.Obligatorio)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.PensumViejo)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<Curso>().HasData(
            //PRIMER SEMESTRE-----------------------------------------------------------------------------------------------
            new Curso { CursoId = "17", Nombre = "SOCIAL HUMANISTICA 1", PreRequisitos = " ", Creditos = 4, Semestre = 1, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "101", Nombre = "MATE BASICA 1", PreRequisitos = " ", Creditos = 7, Semestre = 1, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "69", Nombre = "TECNICA COMPLEMENTARIA 1", PreRequisitos = " ", Creditos = 3, Semestre = 1, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "39", Nombre = "DEPORTES 1", PreRequisitos = " ", Creditos = 1, Semestre = 1, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "348", Nombre = "QUIMICA GENERAL 1", PreRequisitos = " ", Creditos = 3, Semestre = 1, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "6", Nombre = "IDIOMA TECNICO 1", PreRequisitos = " ", Creditos = 2, Semestre = 1, Obligatorio = false, CrMin = 0, PensumViejo = true },

            //SEGUNDO SEMESTRE-----------------------------------------------------------------------------------------------
            new Curso { CursoId = "19", Nombre = "SOCIAL HUMANISTICA 2", PreRequisitos = "17", Creditos = 4, Semestre = 2, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "103", Nombre = "MATE BASICA 2", PreRequisitos = "101", Creditos = 7, Semestre = 2, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "5", Nombre = "TECNICAS DE ESTUDIO Y DE INVESTIGACION", PreRequisitos = " ", Creditos = 3, Semestre = 2, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "147", Nombre = "FISICA BASICA", PreRequisitos = "101", Creditos = 5, Semestre = 2, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "40", Nombre = "DEPORTES 2", PreRequisitos = "39", Creditos = 1, Semestre = 2, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "8", Nombre = "IDIOMA TECNICO 2", PreRequisitos = "101", Creditos = 2, Semestre = 2, Obligatorio = false, CrMin = 0, PensumViejo = true },

            //TERCER SEMESTRE-----------------------------------------------------------------------------------------------
            new Curso { CursoId = "795", Nombre = "LOGICA DE SISTEMAS", PreRequisitos = "103", Creditos = 2, Semestre = 3, Obligatorio = true, CrMin = 33, PensumViejo = true },

            new Curso { CursoId = "960", Nombre = "MATE COMPUTO 1", PreRequisitos = "103", Creditos = 5, Semestre = 3, Obligatorio = true, CrMin = 33, PensumViejo = true },

            new Curso { CursoId = "770", Nombre = "INTRODUCCION A LA PROGAMACION Y COMPUTACION 1", PreRequisitos = "103", Creditos = 4, Semestre = 3, Obligatorio = true, CrMin = 33, PensumViejo = true },

            new Curso { CursoId = "107", Nombre = "MATE INTERMEDIA 1", PreRequisitos = "103", Creditos = 10, Semestre = 3, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "150", Nombre = "FISICA 1", PreRequisitos = "103,147", Creditos = 5, Semestre = 3, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "9", Nombre = "IDIOMA TECNICO 3", PreRequisitos = "8", Creditos = 2, Semestre = 3, Obligatorio = false, CrMin = 0, PensumViejo = true },

            //CUARTO SEMESTRE-----------------------------------------------------------------------------------------------
            new Curso { CursoId = "732", Nombre = "ESTADISTICA 1", PreRequisitos = "107,5", Creditos = 5, Semestre = 4, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "796", Nombre = "LENGUAJES FORMALES Y DE PROGRAMACION", PreRequisitos = "770,795,960", Creditos = 3, Semestre = 4, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "962", Nombre = "MATE COMPUTO 2", PreRequisitos = "960,770,795", Creditos = 5, Semestre = 4, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "771", Nombre = "INTRODUCCION A LA PROGRAMACION Y COMPUTACION 2", PreRequisitos = "107,770,795,960", Creditos = 5, Semestre = 4, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "10", Nombre = "LOGICA", PreRequisitos = "19", Creditos = 2, Semestre = 4, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "112", Nombre = "MATE INTERMEDIA 2", PreRequisitos = "107", Creditos = 5, Semestre = 4, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "114", Nombre = "MATE INTERMEDIA 3", PreRequisitos = "107", Creditos = 5, Semestre = 4, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "152", Nombre = "FISICA 2", PreRequisitos = "107,150", Creditos = 6, Semestre = 4, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "11", Nombre = "IDIOMA TECNICO 4", PreRequisitos = "9", Creditos = 2, Semestre = 4, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "2025", Nombre = "PRACTICA INICIAL", PreRequisitos = "103,107", Creditos = 0, Semestre = 4, Obligatorio = true, CrMin = 0, PensumViejo = true },

            //QUINTO SEMESTRE-----------------------------------------------------------------------------------------------
            new Curso { CursoId = "736", Nombre = "ANALISIS PROBABILISTICO", PreRequisitos = "732", Creditos = 4, Semestre = 5, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "777", Nombre = "ORGANIZACION DE LENGUAJES Y COMPILADORES 1", PreRequisitos = "771,796,962", Creditos = 4, Semestre = 5, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "964", Nombre = "ORGANIZACION COMPUTACIONAL", PreRequisitos = "152,771,962", Creditos = 3, Semestre = 5, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "772", Nombre = "ESTRUCTURA DE DATOS", PreRequisitos = "771,796,962", Creditos = 5, Semestre = 5, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "18", Nombre = "FILOSOFIA DE LA CIENCIA", PreRequisitos = "19", Creditos = 3, Semestre = 5, Obligatorio = false, CrMin = 90, PensumViejo = true },

            new Curso { CursoId = "116", Nombre = "MATE APLICADA 3", PreRequisitos = "112,114", Creditos = 5, Semestre = 5, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "118", Nombre = "MATE APLICADA 1", PreRequisitos = "112,114", Creditos = 6, Semestre = 5, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "368", Nombre = "PRINCIPIOS DE METROLOGIA", PreRequisitos = "732,152,348", Creditos = 3, Semestre = 5, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "650", Nombre = "CONTABILIDAD 1", PreRequisitos = " ", Creditos = 3, Semestre = 5, Obligatorio = false, CrMin = 90, PensumViejo = true },

            new Curso { CursoId = "28", Nombre = "ECOLOGIA", PreRequisitos = " ", Creditos = 3, Semestre = 5, Obligatorio = false, CrMin = 90, PensumViejo = true },

            //SEXTO SEMESTRE-----------------------------------------------------------------------------------------------
            new Curso { CursoId = "722", Nombre = "TEORIA DE SISTEMAS 1", PreRequisitos = "732,772,116,118", Creditos = 5, Semestre = 6, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "601", Nombre = "INVESTIGACION DE OPERACIONES 1", PreRequisitos = "771,732", Creditos = 5, Semestre = 6, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "14", Nombre = "ECONOMIA", PreRequisitos = "732", Creditos = 4, Semestre = 6, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "781", Nombre = "ORGANIZACION DE LENGUAJES Y COMPILADORES 2", PreRequisitos = "777,772", Creditos = 5, Semestre = 6, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "778", Nombre = "ARQUITECTURA DE COMPUTADORES Y ENSAMBLADORES 1", PreRequisitos = "796,964", Creditos = 5, Semestre = 6, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "773", Nombre = "MANEJO E IMPLEMENTACION DE ARCHIVOS", PreRequisitos = "772,796", Creditos = 4, Semestre = 6, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "122", Nombre = "MATE APLICADA 4", PreRequisitos = "118", Creditos = 4, Semestre = 6, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "120", Nombre = "MATE APLICADA 2", PreRequisitos = "118", Creditos = 6, Semestre = 6, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "200", Nombre = "ING. ELECTRICA 1", PreRequisitos = "114,152", Creditos = 5, Semestre = 6, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "652", Nombre = "CONTABILIDAD 2", PreRequisitos = "650", Creditos = 3, Semestre = 6, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "335", Nombre = "GESTION DE DESASTRES", PreRequisitos = "28", Creditos = 3, Semestre = 6, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "3662", Nombre = "LEGISLACION 1", PreRequisitos = " ", Creditos = 0, Semestre = 6, Obligatorio = false, CrMin = 90, PensumViejo = true },

            new Curso { CursoId = "3022", Nombre = "PSICOLOGIA INDUSTRIAL", PreRequisitos = " ", Creditos = 0, Semestre = 6, Obligatorio = false, CrMin = 90, PensumViejo = true },

            //SEPTIMO SEMESTRE-----------------------------------------------------------------------------------------------
            new Curso { CursoId = "724", Nombre = "TEORIA DE SISTEMAS 2", PreRequisitos = "722,601,736", Creditos = 5, Semestre = 7, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "603", Nombre = "INVETIGACION DE OPERACIONES 2", PreRequisitos = "601", Creditos = 5, Semestre = 7, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "734", Nombre = "ESTADISTICA 2", PreRequisitos = "732", Creditos = 5, Semestre = 7, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "281", Nombre = "SISTEMAS OPERATIVOS 1", PreRequisitos = "781,778", Creditos = 5, Semestre = 7, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "779", Nombre = "ARQUITECTURA DE COMPUTADORAS Y ENSAMBLADORES 2", PreRequisitos = "778", Creditos = 4, Semestre = 7, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "970", Nombre = "REDES DE COMPUTADORAS 1", PreRequisitos = "773,778", Creditos = 4, Semestre = 7, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "774", Nombre = "SISTEMAS DE BASES DE DATOS 1", PreRequisitos = "773", Creditos = 5, Semestre = 7, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "656", Nombre = "ADMINISTRACION DE EMPRESAS 1", PreRequisitos = " ", Creditos = 5, Semestre = 7, Obligatorio = false, CrMin = 150, PensumViejo = true },

            new Curso { CursoId = "654", Nombre = "CONTABILIDAD 3", PreRequisitos = "652", Creditos = 3, Semestre = 7, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "2036", Nombre = "PRACTICA INTERMEDIA", PreRequisitos = "778,777,773,2025", Creditos = 0, Semestre = 7, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "3664", Nombre = "LEGISLACION 2", PreRequisitos = "3662", Creditos = 0, Semestre = 7, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "3658", Nombre = "ADMINISTRACION DE PERSONAL", PreRequisitos = "3022", Creditos = 0, Semestre = 7, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "700", Nombre = "INGENIERIA ECONOMICA 1", PreRequisitos = "732", Creditos = 5, Semestre = 7, Obligatorio = false, CrMin = 0, PensumViejo = true },

            //OCTAVO SEMESTRE-----------------------------------------------------------------------------------------------
            new Curso { CursoId = "285", Nombre = "SISTEMAS OPERATIVOS 2", PreRequisitos = "281", Creditos = 4, Semestre = 8, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "975", Nombre = "REDES DE COMPUTADORAS 2", PreRequisitos = "970", Creditos = 4, Semestre = 8, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "775", Nombre = "SISTEMAS DE BASES DE DATOS 2", PreRequisitos = "281,774", Creditos = 4, Semestre = 8, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "283", Nombre = "ANALISIS Y DISENIO DE SISTEMAS 1", PreRequisitos = "774", Creditos = 5, Semestre = 8, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "797", Nombre = "SEMINARIO DE SISTEMAS 1", PreRequisitos = "724", Creditos = 3, Semestre = 8, Obligatorio = true, CrMin = 170, PensumViejo = true },


            //NOVENO SEMESTRE-----------------------------------------------------------------------------------------------
            new Curso { CursoId = "729", Nombre = "MODELACION Y SIMULACION 1", PreRequisitos = "724,603", Creditos = 5, Semestre = 9, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "786", Nombre = "SISTEMAS ORGANIZACIONALES GERENZIALES 1", PreRequisitos = "283,722", Creditos = 4, Semestre = 9, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "972", Nombre = "INTELIGENCIA ARTIFICIAL 1", PreRequisitos = "781,775,724", Creditos = 4, Semestre = 9, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "966", Nombre = "SEGURIDAD Y AUDITORIA DE REDES", PreRequisitos = "975", Creditos = 4, Semestre = 9, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "785", Nombre = "ANALISIS Y DISENIO DE SISTEMAS 2", PreRequisitos = "283", Creditos = 5, Semestre = 9, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "788", Nombre = "SISTEMAS APLICADOS 1", PreRequisitos = "283", Creditos = 5, Semestre = 9, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "738", Nombre = "BASES DE DATOS AVANZADAS", PreRequisitos = "775", Creditos = 5, Semestre = 9, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "798", Nombre = "SEMINARIO DE SISTEMAS 2", PreRequisitos = "797", Creditos = 3, Semestre = 9, Obligatorio = true, CrMin = 190, PensumViejo = true },

            new Curso { CursoId = "288", Nombre = "INTRODUCCION A LA EVALUACION DE IMPACTO AMBIENTAL", PreRequisitos = " ", Creditos = 4, Semestre = 9, Obligatorio = false, CrMin = 190, PensumViejo = true },

            new Curso { CursoId = "702", Nombre = "INGENIERIA ECONOMICA 2", PreRequisitos = "700", Creditos = 4, Semestre = 9, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "1", Nombre = "ETICA PROFESIONAL", PreRequisitos = " ", Creditos = 4, Semestre = 9, Obligatorio = false, CrMin = 200, PensumViejo = true },

            new Curso { CursoId = "2009", Nombre = "PRACTICA FINAL", PreRequisitos = "2036", Creditos = 0, Semestre = 9, Obligatorio = true, CrMin = 200, PensumViejo = true },

            //DECIMO SEMESTRE-----------------------------------------------------------------------------------------------
            new Curso { CursoId = "787", Nombre = "SISTEMAS ORGANIZACIONALES Y GERENCIALES 2", PreRequisitos = "786", Creditos = 4, Semestre = 10, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "790", Nombre = "EMPREDEDORES DE NEG. INFORMATICOS", PreRequisitos = "786", Creditos = 4, Semestre = 10, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "720", Nombre = "MODELACION Y SIMULACION 2", PreRequisitos = "729", Creditos = 5, Semestre = 10, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "968", Nombre = "INTELIGENCIA ARTIFICIAL 2", PreRequisitos = "972", Creditos = 4, Semestre = 10, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "974", Nombre = "REDES DE NUEVA GENERACION", PreRequisitos = "975", Creditos = 4, Semestre = 10, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "780", Nombre = "SOFTWARE AVANZADO", PreRequisitos = "785", Creditos = 6, Semestre = 10, Obligatorio = true, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "789", Nombre = "SISTEMAS APLICADOS 2", PreRequisitos = "785,788", Creditos = 5, Semestre = 10, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "735", Nombre = "AUDITORIA DE PROYECTOS DE SOFTWARE", PreRequisitos = "785", Creditos = 5, Semestre = 10, Obligatorio = false, CrMin = 0, PensumViejo = true },

            new Curso { CursoId = "7990", Nombre = "SEMINARIO DE INVESTIGACION EPS", PreRequisitos = " ", Creditos = 4, Semestre = 10, Obligatorio = false, CrMin = 225, PensumViejo = true },

            new Curso { CursoId = "710", Nombre = "PLANEAMIENTO", PreRequisitos = " ", Creditos = 6, Semestre = 10, Obligatorio = false, CrMin = 190, PensumViejo = true },

            new Curso { CursoId = "706", Nombre = "PREPARACION Y EVALUACION DE PROYECTOS 1", PreRequisitos = "700", Creditos = 4, Semestre = 10, Obligatorio = false, CrMin = 190, PensumViejo = true },

            new Curso { CursoId = "799", Nombre = "SEMINARIO DE INVESTIGACION", PreRequisitos = "798", Creditos = 3, Semestre = 10, Obligatorio = true, CrMin = 220, PensumViejo = true }


            //new Curso { CursoId = "14", Nombre = "ECONOMIA", PreRequisitos = "732", Creditos = 4, Semestre = 6, Obligatorio = true, CrMin = 0 }

            );


            modelBuilder.Entity<Relacion>(entity =>
            {
                entity.ToTable("Relacion");

                entity.HasIndex(e => e.AspNetUserId, "IX_Relacion_AspNetUserId");

                entity.HasIndex(e => e.CursoId, "IX_Relacion_CursoId");

                entity.Property(e => e.Color).HasColumnName("color");

                entity.HasOne(d => d.AspNetUser)
                    .WithMany(p => p.Relacions)
                    .HasForeignKey(d => d.AspNetUserId);

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Relacions)
                    .HasForeignKey(d => d.CursoId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
