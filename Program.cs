using System;
using System.Collections.Generic;
using System.Linq;
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

            //TesteInterceptacao();
            TesteInterceptacaoSaveChanges();
        }

        static void TesteInterceptacaoSaveChanges()
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                db.Funcoes.Add(new Funcao
                {
                    Descricao1 = "Teste"
                });

                db.SaveChanges();
            }
        }

        static void TesteInterceptacao()
        {
            using (var db = new ApplicationContext())
            {
                var consulta = db
                    .Funcoes
                    .TagWith("Use NOLOCK")
                    .FirstOrDefault(); 

                Console.WriteLine($"Consulta: {consulta?.Descricao1}");
            }
        }
    }
}
