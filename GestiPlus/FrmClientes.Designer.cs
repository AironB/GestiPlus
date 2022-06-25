
namespace GestiPlus
{
    partial class FrmClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientes));
            this.dvClientes = new System.Windows.Forms.DataGridView();
            this.tlsClientes = new System.Windows.Forms.ToolStrip();
            this.tsbNuevoCliente = new System.Windows.Forms.ToolStripButton();
            this.tsbEditCliente = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dvClientes)).BeginInit();
            this.tlsClientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvClientes
            // 
            this.dvClientes.AllowUserToAddRows = false;
            this.dvClientes.AllowUserToDeleteRows = false;
            this.dvClientes.AllowUserToResizeRows = false;
            this.dvClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvClientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dvClientes.Location = new System.Drawing.Point(0, 39);
            this.dvClientes.MultiSelect = false;
            this.dvClientes.Name = "dvClientes";
            this.dvClientes.RowTemplate.Height = 25;
            this.dvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvClientes.ShowCellErrors = false;
            this.dvClientes.ShowEditingIcon = false;
            this.dvClientes.ShowRowErrors = false;
            this.dvClientes.Size = new System.Drawing.Size(800, 381);
            this.dvClientes.TabIndex = 3;
            // 
            // tlsClientes
            // 
            this.tlsClientes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tlsClientes.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tlsClientes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevoCliente,
            this.tsbEditCliente});
            this.tlsClientes.Location = new System.Drawing.Point(0, 0);
            this.tlsClientes.Name = "tlsClientes";
            this.tlsClientes.Size = new System.Drawing.Size(800, 39);
            this.tlsClientes.TabIndex = 2;
            this.tlsClientes.Text = "toolStrip1";
            // 
            // tsbNuevoCliente
            // 
            this.tsbNuevoCliente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevoCliente.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevoCliente.Image")));
            this.tsbNuevoCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevoCliente.Name = "tsbNuevoCliente";
            this.tsbNuevoCliente.Size = new System.Drawing.Size(36, 36);
            this.tsbNuevoCliente.Text = "Nuevo Cliente";
            this.tsbNuevoCliente.ToolTipText = "Nuevo Cliente";
            this.tsbNuevoCliente.Click += new System.EventHandler(this.tsbNuevoCliente_Click);
            // 
            // tsbEditCliente
            // 
            this.tsbEditCliente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditCliente.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditCliente.Image")));
            this.tsbEditCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditCliente.Name = "tsbEditCliente";
            this.tsbEditCliente.Size = new System.Drawing.Size(36, 36);
            this.tsbEditCliente.Text = "Editar Cliente";
            this.tsbEditCliente.Click += new System.EventHandler(this.tsbEditCliente_Click);
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.dvClientes);
            this.Controls.Add(this.tlsClientes);
            this.Name = "FrmClientes";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.FrmClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvClientes)).EndInit();
            this.tlsClientes.ResumeLayout(false);
            this.tlsClientes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvClientes;
        private System.Windows.Forms.ToolStrip tlsClientes;
        private System.Windows.Forms.ToolStripButton tsbNuevoCliente;
        private System.Windows.Forms.ToolStripButton tsbEditCliente;
    }
}