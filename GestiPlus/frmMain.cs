using System;
using System.Windows.Forms;
using GestiPlus.Session;

namespace GestiPlus
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ShowLogin();
        }

        private void ShowLogin()
        {
            var login = new FrmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                stlUsuario.Text = Global.UserName;
                Text = "GestiPlus " + " [" + Global.NombreEmpresa + "]";
            }
            else
            {
                Application.Exit();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var confirmacion = MessageBox.Show("Esta seguro que desea salir del sistema?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.No)
            {
                e.Cancel = true;
                if (string.IsNullOrEmpty(Global.UserName)) ShowLogin();
            }
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void proveedoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var frmProveedores = new FrmProveedores();
            frmProveedores.MdiParent = this;
            frmProveedores.WindowState = FormWindowState.Maximized;
            frmProveedores.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmClientes = new FrmClientes();
            frmClientes.MdiParent = this;
            frmClientes.WindowState = FormWindowState.Maximized;
            frmClientes.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmProductos = new FrmProductos();
            frmProductos.MdiParent = this;
            frmProductos.WindowState = FormWindowState.Maximized;
            frmProductos.Show();
        }

        private void comprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmCompras = new FrmCompras();
            frmCompras.MdiParent = this;
            frmCompras.WindowState = FormWindowState.Maximized;
            frmCompras.Show();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmVentas = new FrmVentas();
            frmVentas.WindowState = FormWindowState.Maximized;
            frmVentas.ShowInTaskbar = false;
            frmVentas.MdiParent = this;
            frmVentas.Show();
        }

        private void configuraciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmConfig = new FrmConfiguracion();
            frmConfig.MdiParent = this;
            frmConfig.Show();
        }
    }
}