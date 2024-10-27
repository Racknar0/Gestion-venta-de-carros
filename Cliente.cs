using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionCarros
{
    public class Cliente(int id, string nombre, string direccion)
    
    {
        public int ID { get; private set; } = id;
        public string Nombre { get; private set; } = nombre;
        public string Direccion { get; private set; } = direccion;

        // Lista de Ventas
        public List<Venta> Compras { get; private set; } = new List<Venta>();

        // Metodo para registrar una venta
        public void AgregarCompra(Venta venta)
        {
            Compras.Add(venta);
        }
    }
}
