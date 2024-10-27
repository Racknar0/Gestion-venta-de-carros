using SistemaGestionCarros.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionCarros
{
    public abstract class Empleado(int id, string nombre)
    {
        public int ID { get; private set; } = id;
        public string Nombre { get; private set; } = nombre;
        public Roles Rol { get; protected set; }

        public abstract void RegistrarVenta(Vehiculo vehiculo, Cliente cliente , DateTime fechaVenta);
    }
}
