using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesFacturas
{
    public class GeneralClienteFactura<T>
    {
        public virtual void Save()
        {
            var type = typeof(T);
            Object[] myPropertyInfo;
            // Get the properties of 'Type' class object.
            myPropertyInfo = type.GetProperties();
            Console.WriteLine("Properties of System.Type are:");
            for (int i = 0; i < myPropertyInfo.Length; i++)
            {
                Console.WriteLine(myPropertyInfo[i]);
            }
        }
    }
}
