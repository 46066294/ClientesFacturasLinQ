using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesFacturas
{
    public class Cliente:GeneralClienteFactura<Cliente>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

        //public List<Factura> facturasCliente { get; set; } 

        public Cliente(int idCliente, string nombre)
        {
            id = idCliente;
            name = nombre;
            phone = "555";
        }
    }
}
