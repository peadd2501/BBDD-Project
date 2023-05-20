using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace BBDD_Proyecto
{
    public class Procedimientos
    {
        //atributos del procedimiento
        DBConection conn = new DBConection();
        SqlCommand Cmd;
        SqlDataReader Dr;
        DataTable Dt;


        //Cargar datos de una tabla de la BBDD a un DataGridView

        public DataTable CargarDatos (string Tabla)
        {
            Dt = new DataTable ("CargarDatos");
            Cmd = new SqlCommand("Select * from " + Tabla, conn.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);
            Dr.Close();

            conn.Cerrar();
            return Dt;
        }

        public DataTable CargarCompras (string Tabla)
        {
            Dt = new DataTable("CargarDatos");
            Cmd = new SqlCommand("	Select compras.id_producto 'ID Producto', products.Descripcion 'Producto', compras.descripcion " +
                "'Descripción Compra', cantidad 'Cantidad compra', fecha 'Fecha compra' from compras, products " +
                "where products.id_producto = compras.id_producto", conn.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);
            Dr.Close();

            conn.Cerrar();
            return Dt;
        }

        public DataTable CargarVentas()
        {
            Dt = new DataTable("CargarDatos");
            Cmd = new SqlCommand("select id_sale 'ID Venta', cantidad 'Cantidad Venta', product 'ID Producto', Descripcion 'Producto', Price 'Precio', Sales_h.Serie 'Serie Factura', " +
                " factura 'No. de Factura', Fecha 'Fecha de emisión', codigo_cliente 'ID Cliente', Nombre 'Nombre Cliente' from Sales_d, Sales_h, " +
                "products, customer where factura = Numero and codigo_cliente = id_customer and product = id_producto; ", conn.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);
            Dr.Close();

            conn.Cerrar();
            return Dt;
        }

        public int CargarStockInProducto(int id)
        {
            //select stock_in from Inventory where id_product = 
            Cmd = new SqlCommand("select stock_in from Inventory where id_product = " + id, conn.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                id = Dr.GetInt32(0);
            }
            Dr.Close();
            conn.Cerrar();

            return id;
        }

        public DataTable CargarInventarios()
        {
            Dt = new DataTable("CargarDatos");
            Cmd = new SqlCommand("Select id_inventory 'ID Inventario', id_product 'ID Producto', Descripcion 'Producto', FechaRegistro 'Registro Producto'," +
                " stock_in 'En Stock', date_int 'Fecha entrada', entries 'Entradas', date_out 'Fecha salida', outlets 'Salidas' from Inventory, products" +
                " where id_product = id_producto", conn.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);
            Dr.Close();

            conn.Cerrar();
            return Dt;
        }

        //Metodo Generico para llenar los ComboBox
        public void LlenarComboBox(string Tabla, string NombreColumna, ComboBox xCBox)
        {
            Cmd = new SqlCommand("Select * From " + Tabla, conn.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                xCBox.Items.Add(Dr[NombreColumna].ToString());
            }
            Dr.Close ();
        }

        //Metodo Generico para llenar un textBox
        public void LlenarTextBox (string Select, string Tabla, string nombreCliente, TextBox txtBox, String whereCondition)
        {
            Cmd = new SqlCommand("select "+ Select + " from " + Tabla + " where " + whereCondition + " = '" + nombreCliente + "'", conn.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                String resultado = Dr.GetInt32(0).ToString();

                txtBox.Text = resultado;
            }
            Dr.Close();
            conn.Cerrar ();
        }
        //Metodo Generico para llenar un textBox string
        public void LlenarTextBoxString(string Select, string Tabla, string nombreCliente, TextBox txtBox, String whereCondition)
        {
            Cmd = new SqlCommand("select " + Select + " from " + Tabla + " where " + whereCondition + " = '" + nombreCliente + "'", conn.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                String resultado = Dr.GetString(0);

                txtBox.Text = resultado;
            }
            Dr.Close();
        }

        public void LlenarTextBoxDecimal(string Select, string Tabla, string nombreCliente, TextBox txtBox, String whereCondition)
        {
            Cmd = new SqlCommand("select " + Select + " from " + Tabla + " where " + whereCondition + " = '" + nombreCliente + "'", conn.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                decimal resultado = Dr.GetDecimal(0);

                txtBox.Text = resultado.ToString();
            }
            Dr.Close();
        }

        public void InsertCompras(TextBox cDescripcion, TextBox cIdProducto, TextBox cCantidad)
        {
            Cmd = new SqlCommand("Insert into compras(descripcion, id_producto, cantidad, fecha) values (@descripcion, @id_producto, @cantidad, @fecha)", conn.Abrir());
            Cmd.Parameters.AddWithValue("@descripcion", cDescripcion.Text);
            Cmd.Parameters.AddWithValue("@id_producto", int.Parse(cIdProducto.Text));
            Cmd.Parameters.AddWithValue("@cantidad", int.Parse(cCantidad.Text));
            Cmd.Parameters.AddWithValue("@fecha", DateTime.Now);

            Cmd.ExecuteNonQuery();

            conn.Cerrar();
        }

        public void InsertVentas(TextBox vIdEmpresa, TextBox vIdProducto, TextBox vIdCliente, ComboBox vSerie,
            TextBox vCantidad, TextBox idFactura)
        {
            //Insert en la tabla Sales_h
            Cmd = new SqlCommand("INSERT INTO Sales_h (Serie, Fecha, codigo_cliente, nit_empresa)" +
                " VALUES (@Serie, @Fecha, @codigo_cliente, @nit_empresa); SELECT SCOPE_IDENTITY()", conn.Abrir());

            Cmd.Parameters.AddWithValue("@Serie", vSerie.Text);
            Cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
            Cmd.Parameters.AddWithValue("@codigo_cliente", int.Parse(vIdCliente.Text));
            Cmd.Parameters.AddWithValue("@nit_empresa", vIdEmpresa.Text);

            int idVenta = Convert.ToInt32(Cmd.ExecuteScalar());
            idFactura.Text = idVenta.ToString();

            // Insertar registro en Sales_d
            SqlCommand cmdSalesD = new SqlCommand("INSERT INTO Sales_d (cantidad, product, factura, serie)" +
                " VALUES (@cantidad, @product, @factura, @serie)", conn.Abrir());
            cmdSalesD.Parameters.AddWithValue("@cantidad", int.Parse(vCantidad.Text));
            cmdSalesD.Parameters.AddWithValue("@product", int.Parse(vIdProducto.Text));
            cmdSalesD.Parameters.AddWithValue("@factura", idVenta);
            cmdSalesD.Parameters.AddWithValue("@serie", vSerie.Text);
            cmdSalesD.ExecuteNonQuery();

            conn.Cerrar();
        }

        public void InsertProductos(TextBox pDescripcion, ComboBox cbCategoria, ComboBox cbMarca, TextBox Precio)
        {
            int idMarca = 0;
            int idCategoria = 0;
            switch (cbMarca.Text)
            {//"Pepsico\r\nCoca-Cola Company\r\nNestlé\r\nBimbo\r\nMarca sin especificar"
                case "Pepsico":
                    {
                        idMarca = 1;
                    }
                    break;
                case "Coca-Cola Company":
                    {
                        idMarca = 2;
                    }
                    break;
                case "Nestlé":
                    {
                        idMarca = 3;
                    }
                    break;
                case "Bimbo":
                    {
                        idMarca = 4;
                    }
                    break;
                case "Marca sin especificar":
                    {
                        idMarca = 5;
                    }
                    break;
                default:
                    idMarca = 0;
                    break;
            }

            switch (cbCategoria.Text)
            {//Abarrotes Botanas Bebidas Otros
                case "Abarrotes":
                    {
                        idCategoria = 1;
                    }
                    break;
                case "Botanas":
                    {
                        idCategoria = 2;
                    }
                    break;
                case "Bebidas":
                    {
                        idCategoria = 3;
                    }
                    break;
                case "Otros":
                    {
                        idCategoria = 4;
                    }
                    break;
                default:
                    idCategoria = 0;
                    break;
            }

            string query = "INSERT INTO products (Descripcion, id_marca, id_categoria, FechaRegistro, Price) VALUES (@Descripcion, @IdMarca, @IdCategoria, @FechaRegistro, @Precio)";
            Cmd = new SqlCommand(query, conn.Abrir());
            Cmd.Parameters.AddWithValue("@Descripcion", pDescripcion.Text);
            Cmd.Parameters.AddWithValue("@IdMarca", idMarca);
            Cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
            Cmd.Parameters.AddWithValue("@FechaRegistro", DateTime.Now);
            Cmd.Parameters.AddWithValue("@Precio", decimal.Parse(Precio.Text));

            Cmd.ExecuteNonQuery();

            conn.Cerrar();
        }
    }
}