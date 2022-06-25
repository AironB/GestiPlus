
namespace GestiPlus
{
    partial class FrmProveedores
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNuevoProveedor = new System.Windows.Forms.ToolStripButton();
            this.tsbEditProveedor = new System.Windows.Forms.ToolStripButton();
            this.dvProveedores = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevoProveedor,
            this.tsbEditProveedor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNuevoProveedor
            // 
            this.tsbNuevoProveedor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevoProveedor.Image = global::GestiPlus.Properties.Resources.download;
            this.tsbNuevoProveedor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevoProveedor.Name = "tsbNuevoProveedor";
            this.tsbNuevoProveedor.Size = new System.Drawing.Size(36, 36);
            this.tsbNuevoProveedor.Text = "Nuevo Proveedor";
            this.tsbNuevoProveedor.ToolTipText = "Nuevo Proveedor";
            this.tsbNuevoProveedor.Click += new System.EventHandler(this.tsbNuevoProveedor_Click);
            // 
            // tsbEditProveedor
            // 
            this.tsbEditProveedor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditProveedor.Image = global::GestiPlus.Properties.Resources.Editar;
            this.tsbEditProveedor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditProveedor.Name = "tsbEditProveedor";
            this.tsbEditProveedor.Size = new System.Drawing.Size(36, 36);
            this.tsbEditProveedor.Text = "Editar Proveedor";
            this.tsbEditProveedor.Click += new System.EventHandler(this.tsbEditProveedor_Click);
            // 
            // dvProveedores
            // 
            this.dvProveedores.AllowUserToAddRows = false;
            this.dvProveedores.AllowUserToDeleteRows = false;
            this.dvProveedores.AllowUserToResizeRows = false;
            this.dvProveedores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvProveedores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dvProveedores.Location = new System.Drawing.Point(0, 39);
            this.dvProveedores.MultiSelect = false;
            this.dvProveedores.Name = "dvProveedores";
            this.dvProveedores.RowTemplate.Height = 25;
            this.dvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvProveedores.ShowCellErrors = false;
            this.dvProveedores.ShowEditingIcon = false;
            this.dvProveedores.ShowRowErrors = false;
            this.dvProveedores.Size = new System.Drawing.Size(800, 381);
            this.dvProveedores.TabIndex = 1;
            // 
            // FrmProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.dvProveedores);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmProveedores";
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.FrmProveedores_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNuevoProveedor;
        private System.Windows.Forms.DataGridView dvProveedores;
        private System.Windows.Forms.ToolStripButton tsbEditProveedor;
    }
}