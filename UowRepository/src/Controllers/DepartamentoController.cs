using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using src.Data.Repositories;
using src.Domain;

namespace EFCore.UowRepository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {

        private readonly ILogger<DepartamentoController> _logger;
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoController(ILogger<DepartamentoController> logger, IDepartamentoRepository departamentoRepository)
        {
            _logger = logger;
            _departamentoRepository = departamentoRepository;
        }

        //departamento/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id/*,[FromServices]IDepartamentoRepository repository*/)
        {
            var departamento = await _departamentoRepository.GetByIdAsync(id);
            return Ok(departamento);
        }

        //departamento
        [HttpPost]
        public IActionResult CreateDepartamento(Departamento departamento)
        {
            _departamentoRepository.Add(departamento);

            var saved = _departamentoRepository.Save();
            
            return Ok(departamento);
        }
    }
}
