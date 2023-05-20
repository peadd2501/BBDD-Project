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
    public partial class FormInventario : Form
    {
        public FormInventario()
        {
            InitializeComponent();
        }

        Procedimientos procedimientos = new Procedimientos();
        private void FormInventario_Load(object sender, EventArgs e)
        {
            dgvInventario.DataSource = procedimientos.CargarInventarios();
            dgvInventario.ClearSelection();
        }
    }
}
