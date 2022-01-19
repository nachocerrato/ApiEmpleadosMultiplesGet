using ApiEmpleadosMultiplesGet.Data;
using LibrariesEmpleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpleadosMultiplesGet.Repositories
{
    public class RepositoryEmpleados
    {
        EmpleadosContext context;

        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        public List<Empleado> GetEmpleados()
        {
            var consulta = from datos in this.context.Empleados
                           select datos;
            return consulta.ToList();
        }

        public Empleado FindEmpleado(int id)
        {
            return this.context.Empleados.SingleOrDefault(x => x.IdDepartamento == id);
        }

        public List<string> GetOficios()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            return consulta.ToList();
        }

        public List<Empleado> GetEmpleadosOficio(string oficio)
        {
            var consulta = from datos in this.context.Empleados
                         where datos.Oficio == oficio
                         select datos;
            return consulta.ToList();
        }

        public List<Empleado> GetEmpleadosSalario(string oficio, int salario)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.Oficio == oficio
                           && datos.Salario >= salario
                           select datos;
            return consulta.ToList();
        }
    }
}
