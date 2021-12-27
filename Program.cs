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
            
            FuncaoLEFT();
        }

         static void FuncaoLEFT()
        {
            CadastrarLivro();

            using var db = new ApplicationContext(); 

            var resultado = db.Livros.Select(p=> ApplicationContext.Left(p.Titulo, 10));
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
