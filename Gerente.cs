using SistemaGestionCarros.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionCarros
{
    internal class Gerente : Empleado
    {
        public Gerente(int id, string nombre) : base(id, nombre)
        {
            Rol = Roles.Gerente;
        }

        public override void RegistrarVenta(Vehiculo vehiculo, Cliente cliente, DateTime fechaVenta)
        {
            // El gerente puede tener permisos adicionales, pero sigue el mismo proceso de registro.
            Venta venta = new(this, cliente, vehiculo, fechaVenta);
            cliente.AgregarCompra(venta);
            vehiculo.CambiarEstado(Estados.Vendido);
            Console.WriteLine($"Venta registrada por {Nombre} el {fechaVenta}. Vehículo {vehiculo.Marca} {vehiculo.Modelo} vendido a {cliente.Nombre}.");
        }
    }
    
}
