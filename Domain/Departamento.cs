using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CursoEfAvancado.Domain
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Ativo { get; set; }
        public bool Excluido { get; set; }

        public List<Funcionario> Funcionarios { get; set; }
    }
}