using SistemaGestionCarros.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionCarros
{
    public class Vendedor : Empleado
    {
        // Constructor de la clase con parametros heredados de la clase Empleado
        public Vendedor(int id, string nombre) : base(id, nombre)
        {
            Rol = Roles.Vendedor;
        }

        public override void RegistrarVenta(Vehiculo vehiculo, Cliente cliente, DateTime fechaVenta)
        {
            Venta venta = new(this, cliente, vehiculo, fechaVenta); // Se crea una nueva venta
            cliente.AgregarCompra(venta); // Se agrega la venta a la lista de compras del cliente
            vehiculo.CambiarEstado(Estados.Vendido); // Se cambia el estado del vehiculo a vendido
            Console.WriteLine($"Venta registrada por {Nombre} , el {fechaVenta} a {cliente.Nombre} por el vehiculo {vehiculo.Marca} {vehiculo.Modelo}"); // Se imprime un mensaje de confirmacion
        }

    }
}
