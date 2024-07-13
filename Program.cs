using EjercicioListas.Logica;
using System;
using System.Collections.Generic;
//Create a console application that allows you to:
//1 enter
//  a-name
//  b-quantity
//  c-price
//2 make the sale of a product
//3 make a report
//  a-reporting how many products have been sold
//  b-how many are in inventory
//  c-which is the best-selling
namespace EjercicioListas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Administrarinventario objadministrarinventario = new Administrarinventario();
            objadministrarinventario.Orquestador();


        }

        
    }

}
