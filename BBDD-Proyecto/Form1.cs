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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCompra formCompra = new FormCompra();
            formCompra.ShowDialog();
        }

        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            FormVenta formVenta = new FormVenta();
            formVenta.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            FormInventario formInventario = new FormInventario();
            formInventario.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FormProductos formProductos = new FormProductos();
            formProductos.ShowDialog();
        }
    }
}
