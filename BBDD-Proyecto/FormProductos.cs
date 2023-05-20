using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBDD_Proyecto
{
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
        }

        Procedimientos procedimientos = new Procedimientos();

        private void FormProductos_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = procedimientos.CargarDatos("products");
            txtFecha.Text = DateTime.Now.ToShortDateString();
            panel1.Visible = false;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtDescripcionProducto.Text != "" && cbCategoria.Text != "" && cbMarca.Text != "" && txtPrecio.Text != "")
            {
                procedimientos.InsertProductos(txtDescripcionProducto, cbCategoria, cbMarca, txtPrecio);
                dgvProductos.DataSource = procedimientos.CargarDatos("products");

                MessageBox.Show("Producto agregado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se ha ingresado uno o más valores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Limpiar()
        {
            txtDescripcionProducto.Text = string.Empty;
            cbCategoria.SelectedIndex = -1;
            cbMarca.SelectedIndex = -1;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora la tecla presionada
            }
        }
    }
}
