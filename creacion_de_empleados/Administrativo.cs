using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creacion_de_empleados
{
    internal class Administrativo : Empleado
    {
        public Administrativo(string codigo, string nombre, string cedula, string departamento,
            double precio_horas, double horas_trabajadas) : base(codigo, nombre, cedula, departamento, precio_horas,
                horas_trabajadas) { }

        public Administrativo() : base() { }
    }
}
