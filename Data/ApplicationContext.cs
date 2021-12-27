using System;
using CursoEfAvancado.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CursoEfAvancado.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Livro> Livros {get;set;}

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
            Funcoes.MinhasFuncoes.RegistarFuncoes(modelBuilder);
        }

        // [DbFunction(name: "LEFT", IsBuiltIn = true)]
        // public static string Left(string dados, int quantidade){
        //     throw new NotImplementedException();
        // }
    }
}