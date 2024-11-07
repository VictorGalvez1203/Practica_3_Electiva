using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creacion_de_empleados
{
    public abstract class Empleado
    {
        private string cedula;
        private string codigo;
        private string nombre;
        private string departamento;
        private double precio_por_hora;
        private double horas_trabajadas;
        private double salario_neto;

        public Empleado(string codigo, string nombre, string cedula, string departamento, 
            double precio_horas, double horas_trabajadas)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.codigo = codigo;
            this.departamento = departamento;
            this.precio_por_hora = precio_horas;
            this.horas_trabajadas = horas_trabajadas;
            this.salario_neto = 0;
        }

        public Empleado() { }


        public string GeneralCodigo(string departamento)
        {
            string codigoGenerado = "";
            string valoresNumeros = "";

            Random generalNumeros = new Random();

            for (int i = 0; i < 4; i++)
            {
                int numeroAleatorio = generalNumeros.Next(0,10);
                valoresNumeros += numeroAleatorio.ToString();
            }

            if (departamento == "Gerencial")
            {
                codigoGenerado = $"GER-{valoresNumeros}";
            }else if (departamento == "Administrativo")
            {
                codigoGenerado = $"ADM-{valoresNumeros}";
            }
            else if(departamento == "Operativo")
            {
                codigoGenerado = $"OPE-{valoresNumeros}";
            }
            return codigoGenerado;
        }

        public string GetCodigo()
        {
            return codigo;
        }

        public double GetPrecioPOrHora()
        {
            return precio_por_hora;
        }

        public double GetHorasTrabajadas()
        {
            return horas_trabajadas;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public string Getcedula() 
        {
            return cedula;
        }

        public string GetDepartamento() 
        { 
            return departamento;
        }

        public double GetSalario_neto()
        {
            return salario_neto;
        }

        public void SetSalario_neto(double salario_neto)
        {
            this.salario_neto = salario_neto;
        }
    }
}
