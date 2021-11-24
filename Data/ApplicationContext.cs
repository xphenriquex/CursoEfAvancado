using System;
using System.IO;
using CursoEfAvancado.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace CursoEfAvancado.Data
{
    public class ApplicationContext : DbContext
    {
        //private readonly StreamWriter _writer = new StreamWriter("meu_log_do_ef_core.txt", append: true);
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection="Data Source=localhost\\SQLEXPRESS;Database=DevIO-02;Integrated Security=true;pooling=true;";
            optionsBuilder
            .UseSqlServer(strConnection)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AI");
            //RAFAEL -> rafael
            //Jõao -> Joao

            modelBuilder.Entity<Departamento>().Property(p=>p.Descricao).UseCollation("SQL_Latin1_General_CP1_CS_AS");

              modelBuilder
                .HasSequence<int>("MinhaSequencia", "sequencias")
                .StartsAt(1)
                .IncrementsBy(2)
                .HasMin(1)
                .HasMax(10)
                .IsCyclic();

            modelBuilder.Entity<Departamento>().Property(p=>p.Id).HasDefaultValueSql("NEXT VALUE FOR sequencias.MinhaSequencia");


        }
    }
}