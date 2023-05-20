using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBDD_Proyecto
{
    public partial class FormCompra : Form
    {
        public FormCompra()
        {
            InitializeComponent();
        }
        PrintDocument printDocument1;
        Procedimientos procedimientos = new Procedimientos();
        private void FormCompra_Load(object sender, EventArgs e)
        {
            procedimientos.LlenarComboBox("products", "Descripcion", cbProductos);
            dgvCompras.DataSource = procedimientos.CargarCompras("compras");
            txtFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora la tecla presionada
            }
        }

        private void txtIdProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cbProductos_SelectedValueChanged(object sender, EventArgs e)
        {
            procedimientos.LlenarTextBox("id_producto", "products", cbProductos.Text, txtIdProducto, "Descripcion");
            procedimientos.LlenarTextBoxDecimal("Price", "products", txtIdProducto.Text, txtPrecioP, "id_producto");

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtDescripcionCompra.Text != "" && txtIdProducto.Text != "" && txtCantidad.Text != "" && txtFecha.Text != "")
                {
                    procedimientos.InsertCompras(txtDescripcionCompra, txtIdProducto, txtCantidad);
                    dgvCompras.DataSource = procedimientos.CargarCompras("compras");

                    MessageBox.Show("Compra realizada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AccionImprimir();

                }
                else
                {
                    MessageBox.Show("No se ha ingresado uno o más valores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void AccionImprimir()
        {
            printDocument1 = new PrintDocument();
            PrinterSettings settings = new PrinterSettings();


            printDocument1.PrinterSettings = settings;
            printDocument1.PrintPage += Imprimir;

            printDocument1.Print();
        }
        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 8);
            int ancho = 500;
            int y = 20;

            e.Graphics.DrawString("  ------------------- Comprobante Compra --------------------", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("  Descripción: \t" + txtDescripcionCompra.Text, font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString("  Fecha: \t" + txtFecha.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));

            e.Graphics.DrawString("  ---------------------------- Producto -----------------------------", font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString("  " + txtIdProducto.Text + " -- " + cbProductos.Text + " -- Q. " + txtPrecioP.Text + " -- " +
                txtCantidad.Text, font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));

            decimal resultado = decimal.Parse(txtPrecioP.Text) * decimal.Parse(txtCantidad.Text);
            e.Graphics.DrawString("  ------------------------------ TOTAL ------------------------------", font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString("  Q. " + resultado.ToString(), font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString("  -----------------------------------------------------------------------", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));

            Limpiar();

        }

        private void Limpiar()
        {
            cbProductos.SelectedIndex = -1;
            txtDescripcionCompra.Text = "";
            txtCantidad.Text = "";
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
