using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesFacturas
{
    public class Factura:GeneralClienteFactura<Factura>
    {
        public int idCliente { get; set; }
        public int id { get; set; }
        public DateTime date { get; set; }
        public int importe { get; set; }
        //public Cliente cliente { get; set; }

        public Factura(int idCliente, int idFact, int importParam)
        {
            id = idFact;
            this.idCliente = idCliente;
            importe = importParam;
            date = DateTime.Now;
        }

        public static IEnumerable<Factura> GetPage(IEnumerable<Factura> factura, int paginas, int totalPorPagina)
        {
            return factura.Skip((paginas - 1) * totalPorPagina).Take(totalPorPagina);
        }
    }
}
