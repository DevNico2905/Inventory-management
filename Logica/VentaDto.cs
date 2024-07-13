using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioListas.Logica
{
    public class VentaDto

    {
        internal object idproduct;

        public int idVenta { get; set; }
        public int IdProducto { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
        public double Total { get; set; }
    }
}
