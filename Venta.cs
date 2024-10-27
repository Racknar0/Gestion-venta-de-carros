using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionCarros
{
    public class Venta(Empleado empleado, Cliente cliente, Vehiculo vehiculo, DateTime fechaVenta)
    {
        public Empleado Empleado { get; private set; } = empleado;
        public Cliente Cliente { get; private set; } = cliente;
        public Vehiculo Vehiculo { get; private set; } = vehiculo;
        public DateTime FechaVenta { get; private set; } = fechaVenta;

    }
}
