namespace creacion_de_empleados
{
    public class Gerencial : Empleado
    {
        //Campo estático para almacenar la única instancia de Gerencial
        private static Gerencial instancia = null;
        private static readonly object padlock = new object();

        //Constructor privado para evitar la creación de instancias externas
        private Gerencial(string codigo, string nombre, string cedula, string departamento,
            double precio_horas, double horas_trabajadas) : base(codigo, nombre, cedula, departamento, precio_horas,
                horas_trabajadas)
        { }

        // Método para obtener la instancia de Gerencial
        public static Gerencial ObtenerInstancia(string codigo, string nombre, string cedula,
            string departamento, double precio_horas, double horas_trabajadas)
        {
            // Asegura que solo un hilo puede acceder a esta sección
            lock (padlock)
            {
                // Verificación
                if (instancia == null)
                {
                    instancia = new Gerencial(codigo, nombre, cedula, departamento, precio_horas, horas_trabajadas);
                }
            }
            return instancia;
        }

    }
}
