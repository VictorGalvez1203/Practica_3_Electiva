using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace creacion_de_empleados
{
    public partial class Form1 : Form
    {
        private Funcionalidades instancia;
        private string codigoCreado;
        private string departamento;
        public Form1()
        {
            InitializeComponent();
            instancia = Funcionalidades.GetIntancia();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            label8.ForeColor = Color.Black;
            label8.Text = "Estado...";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string codigo = textBox1.Text;
            string nombre = textBox2.Text;
            string cedula = textBox3.Text;
            label8.ForeColor = Color.Red;

            if (!double.TryParse(textBox4.Text, out double precios_horas))
            {
                label8.Text = "El valor de 'Precio por Hora' no es válido...";
                return;
            }

            if (!double.TryParse(textBox5.Text, out double trabajadas_horas))
            {
                label8.Text = "El valor de 'Horas Trabajadas' no es válido...";
                return;
            }

            if (string.IsNullOrEmpty(departamento) || 
                string.IsNullOrEmpty(codigo) || 
                string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(cedula) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                label8.Text = "Algun campo esta vacio...";
                return;
            }
            else
            {
                bool gerencial = instancia.Crear(codigo, nombre, cedula, departamento, precios_horas, trabajadas_horas);

                if (gerencial)
                {
                    label8.Text = "Ya existe un empleado Gerencial...";
                    
                }
                else
                {
                    label8.ForeColor = Color.Green;
                    label8.Text = "Empleado creado...";
                }
                
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            departamento = comboBox1.Text;
            do
            {
                codigoCreado = instancia.GeneralCodigo(departamento);
            } while (instancia.CodigoExiste(codigoCreado));

            textBox1.Text = codigoCreado;

            label8.ForeColor = Color.Green;
            label8.Text = "Código generado correctamente...";
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            List<Empleado> empleados = instancia.Ver();

            foreach (Empleado empleado in empleados)
            {
                listBox1.Items.Add($"Empleado: {empleado.GetNombre()}");
                listBox1.Items.Add($"Código: {empleado.GetCodigo()}");
                listBox1.Items.Add($"Departamento: {empleado.GetDepartamento()}");
                listBox1.Items.Add($"Cédula: {empleado.Getcedula()}");
                listBox1.Items.Add($"Precio por Hora: {empleado.GetPrecioPOrHora():F2}");
                listBox1.Items.Add($"Horas Trabajadas: {empleado.GetHorasTrabajadas()}");
                listBox1.Items.Add($"Salario Neto: {empleado.GetSalario_neto():F2}");
                listBox1.Items.Add("-------------------------------------");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string codigo = textBox6.Text;


            listBox2.Items.Clear();

            if (!string.IsNullOrEmpty(codigo))
            {
                string mensaje = instancia.Cobrar(codigo);

                List<Empleado> empleados = instancia.Ver();
                foreach (Empleado empleado in empleados)
                {
                    if (empleado.GetCodigo() == codigo)
                    {
                        listBox2.Items.Add($"Código: {empleado.GetCodigo()}");
                        listBox2.Items.Add($"Empleado: {empleado.GetNombre()}");
                        listBox2.Items.Add($"Departamento: {empleado.GetDepartamento()}");
                        listBox2.Items.Add($"Salario Neto: {empleado.GetSalario_neto():F2}");
                    }
                }

                if (mensaje.Contains("Cobro realizado correctamente..."))
                {
                    label9.ForeColor = Color.Green;
                    label9.Text = mensaje;
                }
                else
                {
                    label9.ForeColor = Color.Red;
                    label9.Text = mensaje;
                }
            }
            else
            {
                label9.ForeColor = Color.Red;
                label9.Text = "EL campo código esta vacio...";
            }

            textBox6.Clear();
        }
    }
}
