using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesFacturas
{
    public class Program
    {
        static void Main(string[] args)
        {
            var Clientes = new List<Cliente>()
            {
                new Cliente(1, "primero"),
                new Cliente(2, "segundo"),
                new Cliente(3, "tercero"),
                new Cliente(4, "cuarto")
            };

            
            var Facturas = new List<Factura>()
            {
                new Factura(1, 1, 1001),
                new Factura(1, 2, 1002),
                new Factura(3, 2, 1003),
                new Factura(4, 3, 1004)
            };


            var results = from c in Clientes
                          join f in Facturas on c.id equals f.idCliente
                          group  new { c, f } by new { c.name/*, f.idCliente*/ }
                          into fc
                          select new { fc.First().c.name, totalImporte = fc.Sum(x => x.f.importe), idFact = fc.Count() }; // this is where I am not sure what to do


            foreach(var item in results)
            {
                Console.WriteLine(item);
            }
        }
    }
}
