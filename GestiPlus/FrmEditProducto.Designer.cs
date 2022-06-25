
namespace GestiPlus
{
    partial class FrmEditProducto
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.picTop = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.chkActivo = new Krypton.Toolkit.KryptonCheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPresentacion = new Krypton.Toolkit.KryptonComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.numPrecioDetalle = new System.Windows.Forms.NumericUpDown();
            this.numPrecioFrecuente = new System.Windows.Forms.NumericUpDown();
            this.numPrecioMayoreo = new System.Windows.Forms.NumericUpDown();
            this.lbliddetalleprecio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPresentacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioFrecuente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMayoreo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(460, 294);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 21);
            this.btnGuardar.TabIndex = 29;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(541, 294);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 21);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // picTop
            // 
            this.picTop.BackColor = System.Drawing.Color.White;
            this.picTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.picTop.Location = new System.Drawing.Point(0, 0);
            this.picTop.Name = "picTop";
            this.picTop.Size = new System.Drawing.Size(628, 47);
            this.picTop.TabIndex = 28;
            this.picTop.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 31;
            this.label1.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(77, 66);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(125, 23);
            this.txtCodigo.TabIndex = 32;
            // 
            // chkActivo
            // 
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Location = new System.Drawing.Point(549, 67);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(58, 20);
            this.chkActivo.TabIndex = 34;
            this.chkActivo.Values.Text = "Activo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 35;
            this.label2.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(265, 66);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(278, 23);
            this.txtNombre.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 14);
            this.label3.TabIndex = 37;
            this.label3.Text = "Presentación:";
            // 
            // cboPresentacion
            // 
            this.cboPresentacion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboPresentacion.DropButtonStyle = Krypton.Toolkit.ButtonStyle.ListItem;
            this.cboPresentacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPresentacion.DropDownWidth = 168;
            this.cboPresentacion.IntegralHeight = false;
            this.cboPresentacion.Location = new System.Drawing.Point(106, 127);
            this.cboPresentacion.Name = "cboPresentacion";
            this.cboPresentacion.Size = new System.Drawing.Size(168, 21);
            this.cboPresentacion.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cboPresentacion.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 14);
            this.label4.TabIndex = 39;
            this.label4.Text = "Precio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(345, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 40;
            this.label5.Text = "Al Detalle:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(345, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 14);
            this.label6.TabIndex = 41;
            this.label6.Text = "Cliente Frecuente:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(345, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 14);
            this.label7.TabIndex = 42;
            this.label7.Text = "Al Mayoreo:";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(22, 243);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(65, 14);
            this.lblStock.TabIndex = 46;
            this.lblStock.Text = "Existencia:";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(106, 240);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(100, 23);
            this.txtStock.TabIndex = 47;
            this.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numPrecioDetalle
            // 
            this.numPrecioDetalle.DecimalPlaces = 2;
            this.numPrecioDetalle.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numPrecioDetalle.Location = new System.Drawing.Point(466, 128);
            this.numPrecioDetalle.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPrecioDetalle.Name = "numPrecioDetalle";
            this.numPrecioDetalle.Size = new System.Drawing.Size(100, 23);
            this.numPrecioDetalle.TabIndex = 48;
            this.numPrecioDetalle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numPrecioFrecuente
            // 
            this.numPrecioFrecuente.DecimalPlaces = 2;
            this.numPrecioFrecuente.Location = new System.Drawing.Point(466, 154);
            this.numPrecioFrecuente.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPrecioFrecuente.Name = "numPrecioFrecuente";
            this.numPrecioFrecuente.Size = new System.Drawing.Size(100, 23);
            this.numPrecioFrecuente.TabIndex = 49;
            this.numPrecioFrecuente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numPrecioMayoreo
            // 
            this.numPrecioMayoreo.DecimalPlaces = 2;
            this.numPrecioMayoreo.Location = new System.Drawing.Point(466, 180);
            this.numPrecioMayoreo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPrecioMayoreo.Name = "numPrecioMayoreo";
            this.numPrecioMayoreo.Size = new System.Drawing.Size(100, 23);
            this.numPrecioMayoreo.TabIndex = 50;
            this.numPrecioMayoreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbliddetalleprecio
            // 
            this.lbliddetalleprecio.AutoSize = true;
            this.lbliddetalleprecio.Location = new System.Drawing.Point(522, 247);
            this.lbliddetalleprecio.Name = "lbliddetalleprecio";
            this.lbliddetalleprecio.Size = new System.Drawing.Size(87, 14);
            this.lbliddetalleprecio.TabIndex = 51;
            this.lbliddetalleprecio.Text = "iddetalleprecio";
            this.lbliddetalleprecio.Visible = false;
            // 
            // FrmEditProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 327);
            this.Controls.Add(this.lbliddetalleprecio);
            this.Controls.Add(this.numPrecioMayoreo);
            this.Controls.Add(this.numPrecioFrecuente);
            this.Controls.Add(this.numPrecioDetalle);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboPresentacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.picTop);
            this.Name = "FrmEditProducto";
            this.Text = "FrmEditProducto";
            this.Load += new System.EventHandler(this.FrmEditProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPresentacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioFrecuente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMayoreo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox picTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private Krypton.Toolkit.KryptonCheckBox chkActivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private Krypton.Toolkit.KryptonComboBox cboPresentacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.NumericUpDown numPrecioDetalle;
        private System.Windows.Forms.NumericUpDown numPrecioFrecuente;
        private System.Windows.Forms.NumericUpDown numPrecioMayoreo;
        private System.Windows.Forms.Label lbliddetalleprecio;
    }
}