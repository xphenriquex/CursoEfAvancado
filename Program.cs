using System;
using System.Collections.Generic;
using System.Linq;
using CursoEfAvancado.Data;
using CursoEfAvancado.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CursoEfAvancado
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new ApplicationContext();
            
            //Collations();
            //PropagarDados();
            //Esquema();
            //ConversorDeValor();
            ConversorCustomizado();
        }

    
        static void ConversorCustomizado()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.Conversores.Add(
                new Conversor
                {
                    Status = Status.Devolvido,
                });

            db.SaveChanges();

            var conversorEmAnalise = db.Conversores.AsNoTracking().FirstOrDefault(p => p.Status == Status.Analise);

            var conversorDevolvido = db.Conversores.AsNoTracking().FirstOrDefault(p => p.Status == Status.Devolvido);
        }

        static void ConversorDeValor() => Esquema();

         static void Esquema()
        {
            using var db = new ApplicationContext();

            var script = db.Database.GenerateCreateScript();

            Console.WriteLine(script);
        }

        static void PropagarDados()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var script = db.Database.GenerateCreateScript();
            Console.WriteLine(script);
        }
        
        static void Collations()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
