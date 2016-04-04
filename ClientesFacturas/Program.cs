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

            //Query syntax
            var results = from c in Clientes
                          join f in Facturas on c.id equals f.idCliente
                          group  new { c, f } by new { c.name/*, f.idCliente*/ }
                          into fc
                          select new { fc.First().c.name, totalImporte = fc.Sum(x => x.f.importe), idFact = fc.Count() }; // this is where I am not sure what to do

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n");

            //Method syntax
            var results2 = Facturas.Join(Clientes,
                            f => f.idCliente,
                            c => c.id,
                            (f, c) => new
                            {
                                Facturas = f,
                                Clientes = c
                            }).GroupBy(c => c.Clientes, c => c.Facturas)
                            .Select(c => new { Sum = c.Sum(x => x.importe), Nombre = c.Key.name, Count = c.Count() });

            foreach(var item in results2)
            {
                Console.WriteLine(item);
            }

            //var factura = new Factura(1, 2, 2000);
            //var factura = Facturas;
            var v = Factura.GetPage(Facturas, 1, 2);
            foreach(var i in v)
            {
                Console.WriteLine(i.id);
            }

        }

        
    }
}
