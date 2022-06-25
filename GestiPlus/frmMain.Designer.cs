
namespace GestiPlus
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.stBar = new System.Windows.Forms.StatusStrip();
            this.stlUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.kryptonRibbonContext1 = new Krypton.Ribbon.KryptonRibbonContext();
            this.ribMenu = new Krypton.Ribbon.KryptonRibbon();
            this.buttonSpecHelp = new Krypton.Toolkit.ButtonSpecAny();
            this.kryptonRibbonRecentDoc1 = new Krypton.Ribbon.KryptonRibbonRecentDoc();
            this.kryptonRibbonRecentDoc2 = new Krypton.Ribbon.KryptonRibbonRecentDoc();
            this.buttonSpecAppMenu1 = new Krypton.Ribbon.ButtonSpecAppMenu();
            this.kryptonRibbonContext2 = new Krypton.Ribbon.KryptonRibbonContext();
            this.kryptonRibbonContext3 = new Krypton.Ribbon.KryptonRibbonContext();
            this.ribtCompras = new Krypton.Ribbon.KryptonRibbonTab();
            this.ribtVentas = new Krypton.Ribbon.KryptonRibbonTab();
            this.ribtInventarios = new Krypton.Ribbon.KryptonRibbonTab();
            this.ribtReportes = new Krypton.Ribbon.KryptonRibbonTab();
            this.ribtConfiguracion = new Krypton.Ribbon.KryptonRibbonTab();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.empresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.comprasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kryptonManager1 = new Krypton.Toolkit.KryptonManager(this.components);
            this.stBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribMenu)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stBar
            // 
            this.stBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stlUsuario});
            this.stBar.Location = new System.Drawing.Point(0, 398);
            this.stBar.Name = "stBar";
            this.stBar.Size = new System.Drawing.Size(800, 22);
            this.stBar.TabIndex = 1;
            this.stBar.Text = "statusStrip1";
            // 
            // stlUsuario
            // 
            this.stlUsuario.Image = ((System.Drawing.Image)(resources.GetObject("stlUsuario.Image")));
            this.stlUsuario.Name = "stlUsuario";
            this.stlUsuario.Size = new System.Drawing.Size(97, 17);
            this.stlUsuario.Text = " SIN SESSIÓN";
            // 
            // kryptonRibbonContext1
            // 
            this.kryptonRibbonContext1.ContextTitle = "Context Tools";
            // 
            // ribMenu
            // 
            this.ribMenu.ButtonSpecs.AddRange(new Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecHelp});
            this.ribMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ribMenu.InDesignHelperMode = true;
            this.ribMenu.Name = "ribMenu";
            this.ribMenu.QATLocation = Krypton.Ribbon.QATLocation.Hidden;
            this.ribMenu.RibbonAppButton.AppButtonRecentDocs.AddRange(new Krypton.Ribbon.KryptonRibbonRecentDoc[] {
            this.kryptonRibbonRecentDoc1,
            this.kryptonRibbonRecentDoc2});
            this.ribMenu.RibbonAppButton.AppButtonShowRecentDocs = false;
            this.ribMenu.RibbonAppButton.AppButtonSpecs.AddRange(new Krypton.Ribbon.ButtonSpecAppMenu[] {
            this.buttonSpecAppMenu1});
            this.ribMenu.RibbonAppButton.AppButtonText = "Archivo";
            this.ribMenu.RibbonContexts.AddRange(new Krypton.Ribbon.KryptonRibbonContext[] {
            this.kryptonRibbonContext2,
            this.kryptonRibbonContext3});
            this.ribMenu.RibbonStyles.BackStyle = Krypton.Toolkit.PaletteBackStyle.HeaderForm;
            this.ribMenu.RibbonStyles.QATButtonStyle = Krypton.Toolkit.ButtonStyle.Form;
            this.ribMenu.RibbonTabs.AddRange(new Krypton.Ribbon.KryptonRibbonTab[] {
            this.ribtCompras,
            this.ribtVentas,
            this.ribtInventarios,
            this.ribtReportes,
            this.ribtConfiguracion});
            this.ribMenu.SelectedContext = null;
            this.ribMenu.SelectedTab = this.ribtCompras;
            this.ribMenu.Size = new System.Drawing.Size(800, 143);
            this.ribMenu.TabIndex = 7;
            this.ribMenu.Visible = false;
            // 
            // buttonSpecHelp
            // 
            this.buttonSpecHelp.Image = ((System.Drawing.Image)(resources.GetObject("buttonSpecHelp.Image")));
            this.buttonSpecHelp.UniqueName = "c57b210907bc4cfeb0e4e0abf874e271";
            // 
            // buttonSpecAppMenu1
            // 
            this.buttonSpecAppMenu1.UniqueName = "a57e60844730435f92d56aa5010b6b6a";
            // 
            // kryptonRibbonContext2
            // 
            this.kryptonRibbonContext2.ContextTitle = "Context Tools";
            // 
            // kryptonRibbonContext3
            // 
            this.kryptonRibbonContext3.ContextTitle = "Context Tools";
            // 
            // ribtCompras
            // 
            this.ribtCompras.KeyTip = "C";
            this.ribtCompras.Text = "Compras";
            // 
            // ribtVentas
            // 
            this.ribtVentas.KeyTip = "V";
            this.ribtVentas.Text = "Ventas";
            // 
            // ribtInventarios
            // 
            this.ribtInventarios.KeyTip = "I";
            this.ribtInventarios.Text = "Inventarios";
            // 
            // ribtReportes
            // 
            this.ribtReportes.KeyTip = "R";
            this.ribtReportes.Text = "Reportes";
            // 
            // ribtConfiguracion
            // 
            this.ribtConfiguracion.Text = "Configuración";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.comprasToolStripMenuItem,
            this.ventasToolStripMenuItem,
            this.inventariosToolStripMenuItem,
            this.configuraciónToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.acercaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.empresaToolStripMenuItem,
            this.toolStripMenuItem2,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
            // 
            // empresaToolStripMenuItem
            // 
            this.empresaToolStripMenuItem.Name = "empresaToolStripMenuItem";
            this.empresaToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.empresaToolStripMenuItem.Text = "&Empresa";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(121, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click_1);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proveedoresToolStripMenuItem,
            this.toolStripMenuItem3,
            this.comprasToolStripMenuItem1});
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.comprasToolStripMenuItem.Text = "&Compras";
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.proveedoresToolStripMenuItem.Text = "&Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(142, 6);
            // 
            // comprasToolStripMenuItem1
            // 
            this.comprasToolStripMenuItem1.Name = "comprasToolStripMenuItem1";
            this.comprasToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.comprasToolStripMenuItem1.Text = "Compras";
            this.comprasToolStripMenuItem1.Click += new System.EventHandler(this.comprasToolStripMenuItem1_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.toolStripMenuItem4,
            this.ventaToolStripMenuItem});
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.ventasToolStripMenuItem.Text = "&Ventas";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(118, 6);
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.ventaToolStripMenuItem.Text = "Venta";
            this.ventaToolStripMenuItem.Click += new System.EventHandler(this.ventaToolStripMenuItem_Click);
            // 
            // inventariosToolStripMenuItem
            // 
            this.inventariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem});
            this.inventariosToolStripMenuItem.Name = "inventariosToolStripMenuItem";
            this.inventariosToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.inventariosToolStripMenuItem.Text = "&Inventarios";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.productosToolStripMenuItem.Text = "&Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem1});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.configuraciónToolStripMenuItem.Text = "Co&nfiguración";
            // 
            // configuraciónToolStripMenuItem1
            // 
            this.configuraciónToolStripMenuItem1.Name = "configuraciónToolStripMenuItem1";
            this.configuraciónToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.configuraciónToolStripMenuItem1.Text = "Configuración";
            this.configuraciónToolStripMenuItem1.Click += new System.EventHandler(this.configuraciónToolStripMenuItem1_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.reportesToolStripMenuItem.Text = "&Reportes";
            // 
            // acercaToolStripMenuItem
            // 
            this.acercaToolStripMenuItem.Name = "acercaToolStripMenuItem";
            this.acercaToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.acercaToolStripMenuItem.Text = "Ac&erca";
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = Krypton.Toolkit.PaletteModeManager.Office365Blue;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.ribMenu);
            this.Controls.Add(this.stBar);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "GestiPlus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.stBar.ResumeLayout(false);
            this.stBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribMenu)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stBar;
        private System.Windows.Forms.ToolStripStatusLabel stlUsuario;
        private Krypton.Ribbon.KryptonRibbonContext kryptonRibbonContext1;
        private Krypton.Ribbon.KryptonRibbon ribMenu;
        private Krypton.Ribbon.KryptonRibbonTab ribtCompras;
        private Krypton.Ribbon.KryptonRibbonContext kryptonRibbonContext2;
        private Krypton.Ribbon.KryptonRibbonRecentDoc kryptonRibbonRecentDoc1;
        private Krypton.Ribbon.ButtonSpecAppMenu buttonSpecAppMenu1;
        private Krypton.Ribbon.KryptonRibbonTab ribtVentas;
        private Krypton.Ribbon.KryptonRibbonTab ribtInventarios;
        private Krypton.Ribbon.KryptonRibbonTab ribtReportes;
        private Krypton.Ribbon.KryptonRibbonTab ribtConfiguracion;
        private Krypton.Toolkit.ButtonSpecAny buttonSpecHelp;
        private Krypton.Ribbon.KryptonRibbonContext kryptonRibbonContext3;
        private Krypton.Ribbon.KryptonRibbonRecentDoc kryptonRibbonRecentDoc2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem empresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaToolStripMenuItem;
        private Krypton.Toolkit.KryptonManager kryptonManager1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem1;
    }
}

