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
            
            //db.Database.Migrate();

            var migracoes = db.Database.GetPendingMigrations();
            foreach(var migracao in migracoes)
            {
                Console.WriteLine(migracao);
            }

            Console.WriteLine("Hello World!");
        }

    }
}
