using EjercicioListas.modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace EjercicioListas.Logica
{
    public class Administrarinventario
    {
        List<ProductoDto> ListaProductos = new List<ProductoDto>();
        List<VentaDto> ListaVentas = new List<VentaDto>();
        
        
        public void Orquestador()
        {
            int administrar = 1;
            while (administrar==1)
            {
                Console.WriteLine("...ADMINISTRAR INVENTARIO...");
                Console.WriteLine("...1 INGRESAR EL PRODUCTO...");
                Console.WriteLine("...2 VENTA DE PRODUCTO...");
                Console.WriteLine("...3 REPORTE GENERAL...");

                Console.WriteLine("...10.SALIR...");
                int opcion=Convert.ToInt32(Console.ReadLine());
                if (opcion == 1)
                    ingresaProductos();
                else if (opcion == 2)
                    VentaProducto();
                else if (opcion == 3)
                    ReporteGeneral();

                else if (opcion == 10)
                    administrar = 0;

            }

        }
        
        private void ingresaProductos()
        {
            
            Console.WriteLine("---Ingresar Informacion del Producto---");
            Console.Write("nombre:");           
            ProductoDto producto = new ProductoDto();
            producto.Nombre = Console.ReadLine();
            Console.Write("precio:");           
            producto.precio=Convert.ToDouble(Console.ReadLine());
            Console.Write("cantidad:");
            producto.cantidad = Convert.ToInt32(Console.ReadLine());

            producto.idProducto = Idproducto();
            ListaProductos.Add(producto);
            Console.Clear();
        }
        private void VentaProducto()
        {
            Console.WriteLine("...VENTA DE PRODUCTO...");
            ListarProducto();
            Console.WriteLine("selecione un producto por ID");
            int idproducto=Convert.ToInt32(Console.ReadLine());

           ProductoDto productoSelec = ListaProductos.FirstOrDefault(x => x.idProducto == idproducto);
            //ListaProductos.FirstOrDefault(x => x.idProducto == idproducto);
            if (productoSelec  != null)
            {
                int cantidadCorrecta = 1;
                while (cantidadCorrecta == 1)
                {
                    Console.WriteLine("cantidad");
                    int cantidad = Convert.ToInt32(Console.ReadLine());
                    if (cantidad>productoSelec.cantidad)
                    {
                        Console.WriteLine($"En el inventario hay{productoSelec.cantidad} unidades por favor digite una cantidad menor o igual ");

                    }
                    else
                    {
                        int cantidadRestante = productoSelec.cantidad - cantidad;

                        ListaProductos.Remove(productoSelec);
                        ListaProductos.Add(new ProductoDto()
                        {
                            cantidad = cantidadRestante,
                            idProducto = idproducto,
                            Nombre = productoSelec.Nombre,
                            precio = productoSelec.precio

                        });
                        
                        ProcesoVenta(productoSelec,cantidad);
                        cantidadCorrecta = 2;
                    }
                }
            }
            else
            {
                Console.WriteLine("selecciones un producto valido");
                VentaProducto();
            }

        }

        private void ProcesoVenta(modelos.ProductoDto productoSelec, int cantidad)
        {
            throw new NotImplementedException();
        }

        public void ProcesoVenta(ProductoDto producto, int cantidad)
        {
            ListaVentas.Add(new VentaDto()
            {
                cantidad=cantidad,
                IdProducto=producto.idProducto,
                precio=producto.precio,
                Total=producto.precio*cantidad,
                idVenta=idVenta()
            });
            Console.WriteLine("venta realizada exitosamente");

        }
        //private void ListarProducto()
        //{
        //    throw new NotImplementedException();
        //}

        private void ListarProducto()
        {
            Console.WriteLine("");
            Console.WriteLine("LISTADO DE PRODUCTOS");
            Console.WriteLine($"ID-NOMBRE-CANTIDAD-PRECIO");
            foreach(var producto in ListaProductos)
            {
                Console.WriteLine($"{producto.idProducto}--{producto.Nombre}-{producto.cantidad}-{producto.precio}");
            }
            Console.WriteLine("");
        }

        private int Idproducto()
        {
            try
            {
                int id = ListaProductos.Max(x => x.idProducto) + 1; 
                    return id;
            }
            catch (Exception)
            {
                return 1;
            }
        }


        private int idVenta()
        {
            try
            {
                int id = ListaVentas.Max(x => x.idVenta) + 1;
                return id;
            }
            catch (Exception)
            {
                return 1;
            }
        }
        private void ReporteGeneral()

        {
            ListarProducto();
            foreach (var Venta in ListaVentas)
            {
                Console.WriteLine($"{Venta.IdProducto}--{Venta.cantidad}--{Venta.precio}--{Venta.Total}--");
            }
            var agrupacion = (from p in ListaVentas
                              group p by p.idproduct into grupo
                              select new
                              {
                                  Idproducto = grupo.Key,
                                  Cantidad = grupo.Sum(x => x.cantidad),
                                  ValorUnitario = grupo.FirstOrDefault().precio,
                                  Total = grupo.Sum(x => x.Total)
                              }).ToList();

            var producoMasVendido = ListaVentas.GroupBy(x => x.idproduct);
        }


    }

}


