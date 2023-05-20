using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBDD_Proyecto
{
    public class Ventas
    {
        public int Numero;
        public int Serie;
        public DateTime Fecha;
        public int CodigoCliente;
        public string NitEmpresa;

        public int Cantidad;
        public int idProducto;

        public Ventas(int numero, int serie, DateTime fecha,
            int codigoCliente, string nitEmpresa, int cantidad, int idProducto)
        {
            Numero = numero;
            Serie = serie;
            Fecha = fecha;
            CodigoCliente = codigoCliente;
            NitEmpresa = nitEmpresa;
            Cantidad = cantidad;
            this.idProducto = idProducto;
        }
    }
}
