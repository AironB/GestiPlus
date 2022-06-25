
namespace GestiPlus
{
    partial class FrmProductos
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
            this.dvProductos = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNuevoProducto = new System.Windows.Forms.ToolStripButton();
            this.tsbEditProducto = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dvProductos)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvProductos
            // 
            this.dvProductos.AllowUserToAddRows = false;
            this.dvProductos.AllowUserToDeleteRows = false;
            this.dvProductos.AllowUserToResizeRows = false;
            this.dvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dvProductos.Location = new System.Drawing.Point(0, 39);
            this.dvProductos.MultiSelect = false;
            this.dvProductos.Name = "dvProductos";
            this.dvProductos.RowTemplate.Height = 25;
            this.dvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvProductos.ShowCellErrors = false;
            this.dvProductos.ShowEditingIcon = false;
            this.dvProductos.ShowRowErrors = false;
            this.dvProductos.Size = new System.Drawing.Size(800, 381);
            this.dvProductos.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevoProducto,
            this.tsbEditProducto});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNuevoProducto
            // 
            this.tsbNuevoProducto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevoProducto.Image = global::GestiPlus.Properties.Resources.download;
            this.tsbNuevoProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevoProducto.Name = "tsbNuevoProducto";
            this.tsbNuevoProducto.Size = new System.Drawing.Size(36, 36);
            this.tsbNuevoProducto.Text = "Nuevo Prodcuto";
            this.tsbNuevoProducto.ToolTipText = "Nuevo Producto";
            this.tsbNuevoProducto.Click += new System.EventHandler(this.tsbNuevoProducto_Click);
            // 
            // tsbEditProducto
            // 
            this.tsbEditProducto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditProducto.Image = global::GestiPlus.Properties.Resources.Editar;
            this.tsbEditProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditProducto.Name = "tsbEditProducto";
            this.tsbEditProducto.Size = new System.Drawing.Size(36, 36);
            this.tsbEditProducto.Text = "Editar Producto";
            this.tsbEditProducto.ToolTipText = "Editar Producto";
            this.tsbEditProducto.Click += new System.EventHandler(this.tsbEditProducto_Click);
            // 
            // FrmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.dvProductos);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmProductos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.FrmProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvProductos)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvProductos;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNuevoProducto;
        private System.Windows.Forms.ToolStripButton tsbEditProducto;
    }
}