
namespace GestiPlus
{
    partial class FrmCompras
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
            this.dvCompras = new System.Windows.Forms.DataGridView();
            this.tlsCompras = new System.Windows.Forms.ToolStrip();
            this.tsbNuevaCompra = new System.Windows.Forms.ToolStripButton();
            this.tsbEditCompra = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dvCompras)).BeginInit();
            this.tlsCompras.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvCompras
            // 
            this.dvCompras.AllowUserToAddRows = false;
            this.dvCompras.AllowUserToDeleteRows = false;
            this.dvCompras.AllowUserToResizeRows = false;
            this.dvCompras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvCompras.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dvCompras.Location = new System.Drawing.Point(0, 39);
            this.dvCompras.MultiSelect = false;
            this.dvCompras.Name = "dvCompras";
            this.dvCompras.RowTemplate.Height = 25;
            this.dvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvCompras.ShowCellErrors = false;
            this.dvCompras.ShowEditingIcon = false;
            this.dvCompras.ShowRowErrors = false;
            this.dvCompras.Size = new System.Drawing.Size(800, 381);
            this.dvCompras.TabIndex = 5;
            // 
            // tlsCompras
            // 
            this.tlsCompras.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tlsCompras.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tlsCompras.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevaCompra,
            this.tsbEditCompra});
            this.tlsCompras.Location = new System.Drawing.Point(0, 0);
            this.tlsCompras.Name = "tlsCompras";
            this.tlsCompras.Size = new System.Drawing.Size(800, 39);
            this.tlsCompras.TabIndex = 4;
            this.tlsCompras.Text = "toolStrip1";
            // 
            // tsbNuevaCompra
            // 
            this.tsbNuevaCompra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevaCompra.Image = global::GestiPlus.Properties.Resources.download;
            this.tsbNuevaCompra.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevaCompra.Name = "tsbNuevaCompra";
            this.tsbNuevaCompra.Size = new System.Drawing.Size(36, 36);
            this.tsbNuevaCompra.Text = "Nueva Compra";
            this.tsbNuevaCompra.ToolTipText = "Nueva Compra";
            this.tsbNuevaCompra.Click += new System.EventHandler(this.tsbNuevaCompra_Click);
            // 
            // tsbEditCompra
            // 
            this.tsbEditCompra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditCompra.Image = global::GestiPlus.Properties.Resources.Editar;
            this.tsbEditCompra.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditCompra.Name = "tsbEditCompra";
            this.tsbEditCompra.Size = new System.Drawing.Size(36, 36);
            this.tsbEditCompra.Text = "Editar Compra";
            this.tsbEditCompra.ToolTipText = "Editar Compra";
            this.tsbEditCompra.Click += new System.EventHandler(this.tsbEditCompra_Click);
            // 
            // FrmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.dvCompras);
            this.Controls.Add(this.tlsCompras);
            this.Name = "FrmCompras";
            this.Text = "Compras";
            this.Load += new System.EventHandler(this.FrmCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvCompras)).EndInit();
            this.tlsCompras.ResumeLayout(false);
            this.tlsCompras.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvCompras;
        private System.Windows.Forms.ToolStrip tlsCompras;
        private System.Windows.Forms.ToolStripButton tsbNuevaCompra;
        private System.Windows.Forms.ToolStripButton tsbEditCompra;
    }
}