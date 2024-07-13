using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioListas.modelos
{
    internal class ProductoDto
    {

        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public int  cantidad { get; set; }
        public double precio { get; set; }
    }
}
