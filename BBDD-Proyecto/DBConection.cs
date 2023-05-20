using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace BBDD_Proyecto
{
    public class DBConection
    {       
        //estableciendo la conexion con el archivo de la App.Config
        private SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDDBB"].ConnectionString);

        //metodo que permite el acceso a la BBDD, o abrir la BBDD
        public SqlConnection Abrir()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }


        //metodo que permite el Cerrar acceso a la BBDD
        public SqlConnection Cerrar()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
