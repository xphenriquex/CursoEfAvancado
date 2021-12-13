using System;
using System.Reflection;
using CursoEfAvancado.Conversores;
using CursoEfAvancado.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;

namespace CursoEfAvancado.Data
{
    public class ApplicationContext : DbContext
    {
        //private readonly StreamWriter _writer = new StreamWriter("meu_log_do_ef_core.txt", append: true);
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Conversor> Conversores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


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
            /*modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AI");
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
            */

            /*modelBuilder
                .Entity<Departamento>()
                .HasIndex(p=> new { p.Descricao,s p.Ativo})
                .HasDatabaseName("idx_meu_indice_composto")
                .HasFilter("Descricao IS NOT NULL")
                .HasFillFactor(80)
                .IsUnique();*/

            /*modelBuilder.Entity<Estado>().HasData(new[] 
            {
                new Estado { Id = 1, Nome = "Sao Paulo"},
                new Estado { Id = 2, Nome = "Sergipe"}
            });*/

            /*modelBuilder.HasDefaultSchema("cadastros"); 
            modelBuilder.Entity<Estado>().ToTable("Estados", "SegundoEsquema");*/

            /*var conversao = new ValueConverter<Versao, string>(p => p.ToString(), p => (Versao)Enum.Parse(typeof(Versao), p));

            var conversao1 = new EnumToStringConverter<Versao>();

            modelBuilder.Entity<Conversor>()
                .Property(p => p.Versao)
                .HasConversion(conversao1);*/
            
            //.HasConversion(conversao);
            //.HasConversion(p=>p.ToString(), p=> (Versao)Enum.Parse(typeof(Versao), p));
            //.HasConversion<string>();

            /*modelBuilder.Entity<Conversor>()
                .Property(p => p.Status)
                .HasConversion(new ConversorCustomizado());*/

            //modelBuilder.Entity<Departamento>().Property<DateTime>("UltimaAtualizacao");

            //modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

        }
    }
}