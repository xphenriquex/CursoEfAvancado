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
            ConsultarDepartamentos();
        }

        static void ConsultarDepartamentos()
        {
            using var db = new Data.ApplicationContext();

            var departamentos = db.Departamentos.Where(p => p.Id > 0).ToArray();
        }
    }
}
