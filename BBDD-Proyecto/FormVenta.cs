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
    public partial class FormVenta : Form
    {
        public FormVenta()
        {
            InitializeComponent();
            txtFecha.Text = DateTime.Now.ToShortDateString();
        }
        Procedimientos procedimientos;
        PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;

        private void FormVenta_Load(object sender, EventArgs e)
        {
            procedimientos = new Procedimientos();
            procedimientos.LlenarComboBox("company", "Nombre", cbEmpresa);
            procedimientos.LlenarComboBox("customer", "Nombre", cbClientes);
            procedimientos.LlenarComboBox("products", "Descripcion", cbProductos);
            dgvVentas.DataSource = procedimientos.CargarVentas();

        }

        private void cbProductos_SelectedValueChanged(object sender, EventArgs e)
        {
            procedimientos = new Procedimientos();
            procedimientos.LlenarTextBox("id_producto", "products", cbProductos.Text, txtIdProducto, "Descripcion");
            procedimientos.LlenarTextBoxDecimal("Price", "products", txtIdProducto.Text, txtPrecioP, "id_producto");

        }

        private void cbClientes_SelectedValueChanged(object sender, EventArgs e)
        {
            procedimientos = new Procedimientos();
            procedimientos.LlenarTextBox("id_customer", "customer", cbClientes.Text, txtIdCliente, "Nombre");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbEmpresa_SelectedValueChanged(object sender, EventArgs e)
        {
            procedimientos = new Procedimientos();
            procedimientos.LlenarTextBoxString("NIT", "company", cbEmpresa.Text, txtIdEmpresa, "Nombre");
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            procedimientos = new Procedimientos();
            try
            {
                int stockProducto = procedimientos.CargarStockInProducto(int.Parse(txtIdProducto.Text));

                if (txtIdEmpresa.Text != "" && txtIdProducto.Text != "" && txtIdCliente.Text != "" && cbSerie.Text != "" && txtCantidad.Text != ""
                    && stockProducto >= int.Parse(txtCantidad.Text))
                {
                    procedimientos.InsertVentas(txtIdEmpresa, txtIdProducto, txtIdCliente, cbSerie, txtCantidad, txtIdFactura);
                    dgvVentas.DataSource = procedimientos.CargarVentas();

                    MessageBox.Show("Venta realizada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AccionImprimir();

                }
                else if(stockProducto < int.Parse(txtCantidad.Text))
                {
                    MessageBox.Show("No hay stock del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void Limpiar()
        {
            cbEmpresa.SelectedIndex = -1;
            cbSerie.SelectedIndex = -1;
            cbProductos.SelectedIndex = -1;
            cbClientes.SelectedIndex = -1;
            txtCantidad.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void PrintButton_Click(object sender, EventArgs e)
        {

        }

        private void AccionImprimir()
        {
            printDocument1 = new PrintDocument();
            PrinterSettings settings = new PrinterSettings();


            printDocument1.PrinterSettings = settings;
            printDocument1.PrintPage += Imprimir;

            printDocument1.Print();
        }
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora la tecla presionada
            }
        }

        private void Imprimir ( object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 8);
            int ancho = 500;
            int y = 20;

            e.Graphics.DrawString("  ------------------- Comprobante Venta --------------------", font, Brushes.Black, new RectangleF(0,  y+= 20, ancho, 20));
            e.Graphics.DrawString("  Empresa: \t" + cbEmpresa.Text, font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString("  Factura: \t" + cbSerie.Text + txtIdFactura.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("  Cliente: \t" + cbClientes.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("  Fecha: \t" + txtFecha.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));

            e.Graphics.DrawString("  --------------------------- Producto ----------------------------", font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString("  " + txtIdProducto.Text + " -- " + cbProductos.Text + " -- Q. " + txtPrecioP.Text + " -- " + 
                txtCantidad.Text, font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));

            decimal resultado = decimal.Parse(txtPrecioP.Text) * decimal.Parse(txtCantidad.Text);
            e.Graphics.DrawString("  ----------------------------- TOTAL -----------------------------", font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString("  Q. "+ resultado.ToString(), font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString("  ---------------------------------------------------------------------", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));

            Limpiar();

        }
    }
}