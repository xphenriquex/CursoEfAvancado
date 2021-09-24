using System;
using System.Collections.Generic;
using System.Linq;
using CursoEfAvancado.Data;
using CursoEfAvancado.Domain;
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
            //Setup(db);
            //FiltroGlobal();
            IgnoreFiltroGlobal();
        }

        static void IgnoreFiltroGlobal()
        {
            using var db = new CursoEfAvancado.Data.ApplicationContext();
            Setup(db);

            var departamentos = db.Departamentos.IgnoreQueryFilters().Where(p => p.Id > 0).ToList();

            foreach (var departamento in departamentos)
            {
                Console.WriteLine($"Descrição: {departamento.Descricao} \t Excluido: {departamento.Excluido}");
            }
        }
        
        static void FiltroGlobal()
        {
            using var db = new CursoEfAvancado.Data.ApplicationContext();
            Setup(db);

            var departamentos = db.Departamentos.Where(p => p.Id > 0).ToList();

            foreach (var departamento in departamentos)
            {
                Console.WriteLine($"Descrição: {departamento.Descricao} \t Excluido: {departamento.Excluido}");
            }
        }

        static void Setup(CursoEfAvancado.Data.ApplicationContext  db)
        {
            if (db.Database.EnsureCreated())
            {
                db.Departamentos.AddRange(
                    new CursoEfAvancado.Domain.Departamento
                    {
                        Ativo = true,
                        Descricao = "Departamento 01",
                        Funcionarios = new System.Collections.Generic.List<CursoEfAvancado.Domain.Funcionario>
                        {
                            new CursoEfAvancado.Domain.Funcionario
                            {
                                Nome = "Rafael Almeida",
                                CPF = "99999999911",
                                RG= "2100062"
                            }
                        },
                        Excluido = true
                    },
                    new CursoEfAvancado.Domain.Departamento
                    {
                        Ativo = true,
                        Descricao = "Departamento 02",
                        Funcionarios = new System.Collections.Generic.List<CursoEfAvancado.Domain.Funcionario>
                        {
                            new CursoEfAvancado.Domain.Funcionario
                            {
                                Nome = "Bruno Brito",
                                CPF = "88888888811",
                                RG= "3100062"
                            },
                            new CursoEfAvancado.Domain.Funcionario
                            {
                                Nome = "Eduardo Pires",
                                CPF = "77777777711",
                                RG= "1100062"
                            }
                        }
                    });

                db.SaveChanges();
                db.ChangeTracker.Clear();
            }
        }
    }
}
