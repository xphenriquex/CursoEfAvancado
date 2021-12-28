using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using CursoEfAvancado.Data;
using CursoEfAvancado.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEfAvancado
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new ApplicationContext();
            
            //FuncaoLEFT();
            //FuncaoDefinidaPeloUsuario();
            DateDIFF();
        }
        static void DateDIFF()
        {
            CadastrarLivro();

            using var db = new ApplicationContext(); 
 
            /*var resultado = db
                .Livros
                .Select(p=>  EF.Functions.DateDiffDay(p.CadastradoEm, DateTime.Now));
                */

            var resultado = db
                .Livros
                .Select(p=>  Funcoes.MinhasFuncoes.DateDiff("DAY", p.CadastradoEm, DateTime.Now));

            foreach(var diff in resultado)
            {
                Console.WriteLine(diff);
            }
        }

        static void FuncaoDefinidaPeloUsuario()
        {
            CadastrarLivro();

            using var db = new ApplicationContext(); 

            db.Database.ExecuteSqlRaw(@"
                CREATE FUNCTION ConverterParaLetrasMaiusculas(@dados VARCHAR(100))
                RETURNS VARCHAR(100)
                BEGIN
                    RETURN UPPER(@dados)
                END");


            var resultado = db.Livros.Select(p=> Funcoes.MinhasFuncoes.LetrasMaiusculas(p.Titulo));
            foreach(var parteTitulo in resultado)
            {
                Console.WriteLine(parteTitulo);
            }
        }
         static void FuncaoLEFT()
        {
            CadastrarLivro();

            using var db = new ApplicationContext(); 

            var resultado = db.Livros.Select(p=> Funcoes.MinhasFuncoes.Left(p.Titulo, 10));
            foreach(var parteTitulo in resultado)
            {
                Console.WriteLine(parteTitulo);
            }
        }

        static void CadastrarLivro()
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                db.Livros.Add(
                    new Livro
                    {
                        Titulo = "Introdução ao Entity Framework Core",
                        Autor = "Rafael",
                    }); 

                db.SaveChanges();
            }
        }
    }
}
