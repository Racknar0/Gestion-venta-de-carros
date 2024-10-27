using SistemaGestionCarros.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionCarros
{
    public class Vehiculo(string numeroSerie, string marca, string modelo, int anio, decimal precio)
    {
        // Propiedades
        public string NumeroSerie { get; private set; } = numeroSerie;
        public string Marca { get; private set; } = marca;
        public string Modelo { get; private set; } = modelo;
        public int Anio { get; private set; } = anio;
        public decimal Precio { get; private set; } = precio;
        public Estados Estado { get; private set; } = Estados.Disponible;


        // Metodo para cambiar el estado del vehiculo
        public void CambiarEstado(Estados estado)
        {
            Estado = estado;
        }


    }
}
