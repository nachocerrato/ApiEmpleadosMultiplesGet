using ApiEmpleadosMultiplesGet.Repositories;
using LibrariesEmpleado;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpleadosMultiplesGet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        public RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Empleado>> Get()
        {
            return this.repo.GetEmpleados();
        }

        [HttpGet("{id}")]
        public ActionResult<Empleado> Get(int id)
        {
            return this.repo.FindEmpleado(id);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<string>> Oficios()
        {
            return this.repo.GetOficios();
        }

        [HttpGet]
        [Route("[action]/{oficio}")]
        public ActionResult<List<Empleado>> EmpleadosOficio(string oficio)
        {
            return this.repo.GetEmpleadosOficio(oficio);
        }

        [HttpGet]
        [Route("{oficio}/{salario}")]
        public ActionResult<List<Empleado>> EmpleadosSalarioOficio(string oficio, int salario)
        {
            return this.repo.GetEmpleadosSalario(oficio, salario);
        }
    }
}
