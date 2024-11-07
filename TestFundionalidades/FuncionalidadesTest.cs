using creacion_de_empleados;

namespace TestFundionalidades
{
    public class FuncionalidadesTest
    {
        [Fact]
        public void TestSingletonInstance()
        {
            // Verificar que la instancia de Singleton no sea nula
            var instance1 = Funcionalidades.GetIntancia();
            var instance2 = Funcionalidades.GetIntancia();

            Assert.NotNull(instance1);
            Assert.Same(instance1, instance2); // Verificar que ambas instancias son las mismas
        }

        [Fact]
        public void TestCrearEmpleadoGerencial()
        {
            var funcionalidades = Funcionalidades.GetIntancia();

            // Intentar crear un empleado de tipo Gerencial
            bool isExisting = funcionalidades.Crear("001", "Juan Perez", "123456789", "Gerencial", 50.0, 40.0);

            // Verificar que el empleado se haya creado y que no sea duplicado
            Assert.False(isExisting);

            // Intentar crear otro empleado Gerencial, debe retornar true porque ya existe uno
            isExisting = funcionalidades.Crear("002", "Maria Gomez", "987654321", "Gerencial", 50.0, 40.0);
            Assert.True(isExisting);
        }

        [Fact]
        public void TestCrearEmpleadoAdministrativo()
        {
            var funcionalidades = Funcionalidades.GetIntancia();

            // Crear un empleado de tipo Administrativo
            bool isExisting = funcionalidades.Crear("003", "Luis Garcia", "123123123", "Administrativo", 30.0, 40.0);

            // Verificar que el empleado se haya creado correctamente
            Assert.False(isExisting);

            // Verificar si el empleado se encuentra en la lista
            var empleados = funcionalidades.Ver();
            Assert.Contains(empleados, e => e.GetCodigo() == "003" && e.GetNombre() == "Luis Garcia");
        }

        [Fact]
        public void TestCobrarEmpleado()
        {
            var funcionalidades = Funcionalidades.GetIntancia();

            // Crear un empleado Operativo
            funcionalidades.Crear("004", "Ana Lopez", "321321321", "Operativo", 20.0, 35.0);

            // Realizar cobro para el empleado creado
            string mensaje = funcionalidades.Cobrar("004");

            // Verificar que el cobro se realizó correctamente
            Assert.Equal("Cobro realizado correctamente...", mensaje);
        }

        [Fact]
        public void TestCobrarEmpleadoNoExistente()
        {
            var funcionalidades = Funcionalidades.GetIntancia();

            // Intentar cobrar a un empleado inexistente
            string mensaje = funcionalidades.Cobrar("999");

            // Verificar que el mensaje indique que no se encontró el empleado
            Assert.Equal("No se encontró un empleado con el código: 999...", mensaje);
        }

        [Fact]
        public void TestFlujoCompletoCrearYCobrarEmpleado()
        {
            var funcionalidades = Funcionalidades.GetIntancia();

            // Crear un empleado de tipo Operativo
            bool isExisting = funcionalidades.Crear("005", "Carlos Herrera", "456456456", "Operativo", 25.0, 40.0);
            Assert.False(isExisting); // Se debería crear sin problemas

            // Cobrar al empleado recién creado
            string mensaje = funcionalidades.Cobrar("005");
            Assert.Equal("Cobro realizado correctamente...", mensaje);

            // Verificar que el empleado sigue en la lista y con el código correcto
            var empleados = funcionalidades.Ver();
            Assert.Contains(empleados, e => e.GetCodigo() == "005" && e.GetNombre() == "Carlos Herrera");
        }

        [Fact]
        public void TestInteraccionEntreEmpleados()
        {
            var funcionalidades = Funcionalidades.GetIntancia();

            // Crear varios empleados de diferentes tipos
            funcionalidades.Crear("006", "Alice", "111111111", "Gerencial", 50.0, 40.0);
            funcionalidades.Crear("007", "Bob", "222222222", "Administrativo", 30.0, 40.0);
            funcionalidades.Crear("008", "Charlie", "333333333", "Operativo", 20.0, 35.0);

            // Verificar que todos los empleados fueron añadidos correctamente
            var empleados = funcionalidades.Ver();
            Assert.Equal(3, empleados.Count);
            Assert.Contains(empleados, e => e.GetCodigo() == "006" && e.GetNombre() == "Alice");
            Assert.Contains(empleados, e => e.GetCodigo() == "007" && e.GetNombre() == "Bob");
            Assert.Contains(empleados, e => e.GetCodigo() == "008" && e.GetNombre() == "Charlie");

            // Realizar cobros para los empleados creados
            Assert.Equal("Cobro realizado correctamente...", funcionalidades.Cobrar("006"));
            Assert.Equal("Cobro realizado correctamente...", funcionalidades.Cobrar("007"));
            Assert.Equal("Cobro realizado correctamente...", funcionalidades.Cobrar("008"));
        }

    }
}