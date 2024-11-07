using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creacion_de_empleados
{
    public class Funcionalidades
    {
        //Instancia estática privada de la clase Funcionalidades
        private static Funcionalidades instancia = null;
        private static readonly object padlock = new object();

        private List<Empleado> lista;
        private Gerencial empleadoGencial;
        private Administrativo adm;
        private Operativo ope;

        private Funcionalidades() 
        {
            lista = new List<Empleado>();
            adm = new Administrativo();
        }

        //Método para obtener la instancia del Singleton
        public static Funcionalidades GetIntancia()
        {
            lock (padlock)
            {
                if (instancia == null)
                {
                    instancia = new Funcionalidades();
                }
                return instancia;
            }
        }

        public string GeneralCodigo(String departamento)
        {
            string codigo = adm.GeneralCodigo(departamento);
            return codigo;
        }

        public bool CodigoExiste(string codigo)
        {
            foreach (Empleado empleado in lista)
            {
                if (empleado.GetCodigo() == codigo)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Crear(string codigo, string nombre, string cedula, string departamento, double precio_horas, double horas_trabajadas)
        {
            bool tipo = false;

            if (departamento == "Gerencial")
            {
                if (empleadoGencial == null)
                {
                    empleadoGencial = Gerencial.ObtenerInstancia(codigo, nombre, cedula, departamento, precio_horas, horas_trabajadas);
                    lista.Add(empleadoGencial);
                }
                else
                {
                    tipo = true;
                }
                
            }
            else if (departamento == "Administrativo")
            {
                adm = new Administrativo(codigo, nombre, cedula, departamento, precio_horas, horas_trabajadas);
                lista.Add(adm);
            }
            else
            {
                ope = new Operativo(codigo, nombre, cedula, departamento, precio_horas, horas_trabajadas);
                lista.Add(ope);
            }
            return tipo;
        }

        public List<Empleado> Ver()
        {
            return lista;
        }

        public string Cobrar(string codigo_empleado)
        {
            string mensaje;
            Empleado empleado = lista.FirstOrDefault(e => e.GetCodigo() == codigo_empleado);

            if (empleado != null)
            {
                double salario_neto = empleado.GetPrecioPOrHora() * empleado.GetHorasTrabajadas();

                empleado.SetSalario_neto(salario_neto);

                mensaje = $"Cobro realizado correctamente...";
            }
            else
            {      
                mensaje = $"No se encontró un empleado con el código: {codigo_empleado}...";
            }
            return mensaje;
        }
    }
}
