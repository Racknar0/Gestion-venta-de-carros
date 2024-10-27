using SistemaGestionCarros.enums;

namespace SistemaGestionCarros
{
    internal class Program
    {
        // Listas para almacenar los datos
        private static List<Vehiculo> vehiculos = [];
        private static List<Cliente> clientes = [];
        private static List<Empleado> empleados = [];
        private static List<Venta> ventas = [];

        static void Main(string[] args)
        {

            bool ejecutar = true;
            while (ejecutar)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Gestión de Venta de Carros ===");
                Console.WriteLine("1. Gestionar Vehículos");
                Console.WriteLine("2. Gestionar Clientes");
                Console.WriteLine("3. Gestionar Empleados");
                Console.WriteLine("4.Gestionar Ventas ");
                Console.WriteLine("5 Listar Vehículos");
                Console.WriteLine("6 Listar Clientes");
                Console.WriteLine("7 Listar Ventas");
                Console.WriteLine("8 Listar Empleados");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        GestionarVehiculos();
                        break;

                    case "2":
                        GestionarClientes();
                        break;

                    case "3":
                        GestionarEmpleados();
                        break;

                    case "4":
                        GestionarVentas();
                        
                        break;

                    case "5":
                        ListarVehiculos();
                        break;

                    case "6":
                        ListarClientes();
                        break;

                    case "7":
                        ListarVentas();
                        break;

                    case "8":
                        ListarEmpleados();
                        break;

                    case "0":
                        ejecutar = false;
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }

            }


            static void GestionarVehiculos()
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Vehículos ===");
                Console.Write("Número de serie: ");
                string numeroSerie = Console.ReadLine();
                Console.Write("Marca: ");
                string marca = Console.ReadLine();
                Console.Write("Modelo: ");
                string modelo = Console.ReadLine();
                Console.Write("Año: ");
                int anio = int.Parse(Console.ReadLine());
                Console.Write("Precio de Venta: ");
                decimal precioVenta = decimal.Parse(Console.ReadLine());
                Console.Write("Escriba 1 si el vehículo está disponible o 2 si está vendido: ");
                string estado = Console.ReadLine();
                Vehiculo vehiculo = new(numeroSerie, marca, modelo, anio, precioVenta);
                vehiculo.CambiarEstado(estado == "1" ? Estados.Disponible : Estados.Vendido);
                vehiculos.Add(vehiculo);

                Console.WriteLine($"Vehículo {marca} {modelo} registrado correctamente. Presione una tecla para continuar.");
                Console.ReadKey();
            }

            static void GestionarClientes()
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Clientes ===");
                Console.Write("ID del Cliente: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Dirección: ");
                string direccion = Console.ReadLine();


                Cliente cliente = new(id, nombre, direccion);
                clientes.Add(cliente);

                Console.WriteLine($"Cliente {nombre} registrado correctamente. Presione una tecla para continuar.");
                Console.ReadKey();
            }


            //static void GestionarVentas()
            //{
            //    Console.Clear();
            //    Console.WriteLine("=== Gestión de Ventas ===");

            //    Console.Write("ID del Empleado que realiza la venta: ");
            //    int empleadoId = int.Parse(Console.ReadLine());
            //    Empleado empleado = empleados.Find(e => e.ID == empleadoId);

            //    if (empleado == null)
            //    {
            //        Console.WriteLine("Empleado no encontrado. Presione una tecla para continuar.");
            //        Console.ReadKey();
            //        return;
            //    }

            //    Console.Write("ID del Cliente que compra el vehículo: ");
            //    int clienteId = int.Parse(Console.ReadLine());
            //    Cliente cliente = clientes.Find(c => c.ID == clienteId);
            //    if (cliente == null)
            //    {
            //        Console.WriteLine("Cliente no encontrado. Presione una tecla para continuar."); 
            //        Console.ReadKey();
            //        return;
            //    }

            //    Console.Write("Número de serie del Vehículo vendido: ");
            //    string numeroSerie = Console.ReadLine();
            //    Vehiculo vehiculo = vehiculos.Find(v => v.NumeroSerie == numeroSerie);
            //    if (vehiculo == null || vehiculo.Estado == Estados.Vendido)
            //    {
            //        Console.WriteLine("Vehículo no encontrado o ya vendido. Presione una tecla para continuar.");
            //        Console.ReadKey();
            //        return;
            //    }

            //    Console.Write("Fecha de Venta (dd/MM/yyyy): ");
            //    DateTime fechaVenta = DateTime.Parse(Console.ReadLine());

            //    Venta venta = new(empleado, cliente, vehiculo, fechaVenta);
            //    ventas.Add(venta);
            //    cliente.AgregarCompra(venta);
            //    vehiculo.CambiarEstado(Estados.Vendido);

            //    Console.WriteLine($"Venta registrada por {empleado.Nombre} el {fechaVenta}. Vehículo {vehiculo.Marca} {vehiculo.Modelo} vendido a {cliente.Nombre}. Presione una tecla para continuar.");
            //    Console.ReadKey();
            //}

            static void GestionarVentas()
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Ventas ===");

                // Listar empleados y permitir seleccionar uno
                Console.WriteLine("Seleccione un empleado para registrar la venta:");
                for (int i = 0; i < empleados.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {empleados[i].Nombre} - {empleados[i].Rol}");
                }
                Console.Write("Seleccione un número: ");
                int empleadoIndex = int.Parse(Console.ReadLine()) - 1;

                if (empleadoIndex < 0 || empleadoIndex >= empleados.Count)
                {
                    Console.WriteLine("Empleado no válido. Presione una tecla para continuar.");
                    Console.ReadKey();
                    return;
                }
                Empleado empleado = empleados[empleadoIndex];

                // Listar clientes y permitir seleccionar uno
                Console.WriteLine("\nSeleccione un cliente que compra el vehículo:");
                for (int i = 0; i < clientes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {clientes[i].Nombre}");
                }
                Console.Write("Seleccione un número: ");
                int clienteIndex = int.Parse(Console.ReadLine()) - 1;

                if (clienteIndex < 0 || clienteIndex >= clientes.Count)
                {
                    Console.WriteLine("Cliente no válido. Presione una tecla para continuar.");
                    Console.ReadKey();
                    return;
                }
                Cliente cliente = clientes[clienteIndex];

                // Listar vehículos disponibles y permitir seleccionar uno
                Console.WriteLine("\nSeleccione un vehículo disponible para la venta:");
                List<Vehiculo> vehiculosDisponibles = vehiculos.FindAll(v => v.Estado == Estados.Disponible);
                for (int i = 0; i < vehiculosDisponibles.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {vehiculosDisponibles[i].Marca} {vehiculosDisponibles[i].Modelo} - {vehiculosDisponibles[i].NumeroSerie}");
                }
                Console.Write("Seleccione un número: ");
                int vehiculoIndex = int.Parse(Console.ReadLine()) - 1;

                if (vehiculoIndex < 0 || vehiculoIndex >= vehiculosDisponibles.Count)
                {
                    Console.WriteLine("Vehículo no válido. Presione una tecla para continuar.");
                    Console.ReadKey();
                    return;
                }
                Vehiculo vehiculo = vehiculosDisponibles[vehiculoIndex];

                // Pedir la fecha de la venta
                Console.Write("Fecha de Venta (dd/MM/yyyy): ");
                DateTime fechaVenta = DateTime.Parse(Console.ReadLine());

                // Registrar la venta
                Venta venta = new Venta(empleado, cliente, vehiculo, fechaVenta);
                ventas.Add(venta);
                cliente.AgregarCompra(venta);
                vehiculo.CambiarEstado(Estados.Vendido);

                Console.WriteLine($"\nVenta registrada correctamente.");
                Console.WriteLine($"Empleado: {empleado.Nombre}");
                Console.WriteLine($"Cliente: {cliente.Nombre}");
                Console.WriteLine($"Vehículo: {vehiculo.Marca} {vehiculo.Modelo}");
                Console.WriteLine($"Fecha de Venta: {fechaVenta}");
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }

            static void GestionarEmpleados()
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Empleados ===");
                Console.Write("ID del Empleado: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Nombre del Empleado: ");
                string nombre = Console.ReadLine();
                Console.Write("Rol (Vendedor/Gerente): ");
                string rolInput = Console.ReadLine();

                Empleado empleado;

                if (rolInput.Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
                {
                    empleado = new Vendedor(id, nombre);

                } else if (rolInput.Equals("Gerente", StringComparison.OrdinalIgnoreCase))
                {
                    empleado = new Gerente(id, nombre);

                } else
                {
                    Console.WriteLine("Rol no válido. Presione una tecla para continuar.");
                    Console.ReadKey();
                    return;
                }

                empleados.Add(empleado);
                Console.WriteLine("Empleado registrado correctamente. Presione una tecla para continuar.");
                Console.ReadKey();
            }

            static void ListarVehiculos()
            {
                Console.Clear();
                Console.WriteLine("=== Listado de Vehículos ===");
                foreach (var vehiculo in vehiculos)
                {
                    Console.WriteLine($"Número de serie: {vehiculo.NumeroSerie}");
                    Console.WriteLine($"Marca: {vehiculo.Marca}");
                    Console.WriteLine($"Modelo: {vehiculo.Modelo}");
                    Console.WriteLine($"Año: {vehiculo.Anio}");
                    Console.WriteLine($"Precio de Venta: {vehiculo.Precio}");
                    Console.WriteLine($"Estado: {vehiculo.Estado}");
                    Console.WriteLine();
                }
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }

            static void ListarClientes()
            {
                Console.Clear();
                Console.WriteLine("=== Listado de Clientes ===");
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"ID: {cliente.ID}");
                    Console.WriteLine($"Nombre: {cliente.Nombre}");
                    Console.WriteLine($"Dirección: {cliente.Direccion}");
                    Console.WriteLine();
                }
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }

            static void ListarVentas()
            {
                Console.Clear();
                Console.WriteLine("=== Listado de Ventas ===");
                foreach (var venta in ventas)
                {
                    Console.WriteLine($"Fecha: {venta.FechaVenta}");
                    Console.WriteLine($"Vendedor: {venta.Empleado.Nombre}");
                    Console.WriteLine($"Cliente: {venta.Cliente.Nombre}");
                    Console.WriteLine($"Vehículo: {venta.Vehiculo.Marca} {venta.Vehiculo.Modelo}");
                    Console.WriteLine();
                }
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }

            static void ListarEmpleados()
            {
                Console.Clear();
                Console.WriteLine("=== Listado de Empleados ===");
                foreach (var empleado in empleados)
                {
                    Console.WriteLine($"ID: {empleado.ID}");
                    Console.WriteLine($"Nombre: {empleado.Nombre}");
                    Console.WriteLine($"Rol: {empleado.Rol}");
                    Console.WriteLine();
                }
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }

        }
    }
}
