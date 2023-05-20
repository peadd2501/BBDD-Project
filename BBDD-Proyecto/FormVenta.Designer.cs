namespace BBDD_Proyecto
{
    partial class FormVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbClientes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.cbProductos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSerie = new System.Windows.Forms.ComboBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.txtIdEmpresa = new System.Windows.Forms.TextBox();
            this.btnVenta = new System.Windows.Forms.Button();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtIdFactura = new System.Windows.Forms.TextBox();
            this.txtPrecioP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVentas
            // 
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(19, 182);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVentas.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVentas.Size = new System.Drawing.Size(973, 256);
            this.dgvVentas.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(551, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cliente:";
            // 
            // cbClientes
            // 
            this.cbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.Location = new System.Drawing.Point(607, 54);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(121, 21);
            this.cbClientes.TabIndex = 2;
            this.cbClientes.SelectedValueChanged += new System.EventHandler(this.cbClientes_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(397, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Módulo de Ventas";
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Location = new System.Drawing.Point(169, 15);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.ReadOnly = true;
            this.txtIdProducto.Size = new System.Drawing.Size(75, 20);
            this.txtIdProducto.TabIndex = 20;
            this.txtIdProducto.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(541, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(607, 108);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(121, 20);
            this.txtCantidad.TabIndex = 5;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // cbProductos
            // 
            this.cbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductos.FormattingEnabled = true;
            this.cbProductos.Location = new System.Drawing.Point(135, 83);
            this.cbProductos.Name = "cbProductos";
            this.cbProductos.Size = new System.Drawing.Size(226, 21);
            this.cbProductos.TabIndex = 3;
            this.cbProductos.SelectedValueChanged += new System.EventHandler(this.cbProductos_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Producto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(559, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Serie:";
            // 
            // cbSerie
            // 
            this.cbSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerie.FormattingEnabled = true;
            this.cbSerie.Items.AddRange(new object[] {
            "FEL001",
            "FEL002"});
            this.cbSerie.Location = new System.Drawing.Point(607, 82);
            this.cbSerie.Name = "cbSerie";
            this.cbSerie.Size = new System.Drawing.Size(121, 21);
            this.cbSerie.TabIndex = 4;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(250, 15);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(75, 20);
            this.txtIdCliente.TabIndex = 24;
            this.txtIdCliente.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Fecha:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Empresa:";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(135, 57);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(226, 21);
            this.cbEmpresa.TabIndex = 1;
            this.cbEmpresa.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cbEmpresa.SelectedValueChanged += new System.EventHandler(this.cbEmpresa_SelectedValueChanged);
            // 
            // txtIdEmpresa
            // 
            this.txtIdEmpresa.Location = new System.Drawing.Point(331, 15);
            this.txtIdEmpresa.Name = "txtIdEmpresa";
            this.txtIdEmpresa.ReadOnly = true;
            this.txtIdEmpresa.Size = new System.Drawing.Size(64, 20);
            this.txtIdEmpresa.TabIndex = 29;
            this.txtIdEmpresa.Visible = false;
            // 
            // btnVenta
            // 
            this.btnVenta.Location = new System.Drawing.Point(734, 54);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(222, 77);
            this.btnVenta.TabIndex = 6;
            this.btnVenta.Text = "Facturar";
            this.btnVenta.UseVisualStyleBackColor = true;
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(135, 111);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(226, 20);
            this.txtFecha.TabIndex = 7;
            // 
            // txtIdFactura
            // 
            this.txtIdFactura.Location = new System.Drawing.Point(844, 18);
            this.txtIdFactura.Name = "txtIdFactura";
            this.txtIdFactura.ReadOnly = true;
            this.txtIdFactura.Size = new System.Drawing.Size(38, 20);
            this.txtIdFactura.TabIndex = 32;
            this.txtIdFactura.Visible = false;
            // 
            // txtPrecioP
            // 
            this.txtPrecioP.Location = new System.Drawing.Point(888, 18);
            this.txtPrecioP.Name = "txtPrecioP";
            this.txtPrecioP.ReadOnly = true;
            this.txtPrecioP.Size = new System.Drawing.Size(53, 20);
            this.txtPrecioP.TabIndex = 33;
            this.txtPrecioP.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(441, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 34;
            this.label3.Text = "Detalle";
            // 
            // FormVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1004, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrecioP);
            this.Controls.Add(this.txtIdFactura);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.btnVenta);
            this.Controls.Add(this.txtIdEmpresa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbSerie);
            this.Controls.Add(this.txtIdProducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cbProductos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbClientes);
            this.Controls.Add(this.dgvVentas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Store - Venta";
            this.Load += new System.EventHandler(this.FormVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbClientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.ComboBox cbProductos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSerie;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.TextBox txtIdEmpresa;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtIdFactura;
        private System.Windows.Forms.TextBox txtPrecioP;
        private System.Windows.Forms.Label label3;
    }
}