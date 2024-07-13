using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioListas.modelos
{
    internal class VentaDto
    {

        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
    }
}
