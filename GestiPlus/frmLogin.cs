using System;
using System.Drawing;
using System.Windows.Forms;
using GestiPlus.Database;
using GestiPlus.Security;
using GestiPlus.Session;

namespace GestiPlus
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool logueado;

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                errUsuario.SetError(txtUsuario, "Debe de ingresar su nombre de usuario.");
                txtUsuario.Focus();
                txtUsuario.BackColor = Color.Red;
                txtUsuario.ForeColor = Color.White;
                return;
            }

            txtUsuario.BackColor = Color.White;
            txtUsuario.ForeColor = Color.Black;
            errUsuario.Clear();

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errPassword.SetError(txtPassword, "Debe de ingresar su contraseña.");
                txtPassword.Focus();
                txtPassword.BackColor = Color.Red;
                txtPassword.ForeColor = Color.White;
                return;
            }

            txtPassword.BackColor = Color.White;
            txtPassword.ForeColor = Color.Black;
            errPassword.Clear();

            var myConn = new DbConnection();
            myConn.OpenConnection();

            var pwd = Crypto.EncryptString(Crypto.Ckey, txtPassword.Text.Trim());

            var str = "SELECT * FROM USERS WHERE usuario = '" + txtUsuario.Text.Trim() + "' and password = '" + pwd +
                      "' and codempresa = '" + cboEmpresa.SelectedValue + "'";

            var drUser = myConn.DataReader(str);

            if (drUser.HasRows)
            {
                // Se logueo correctamente
                logueado = true;

                Global.UserName = txtUsuario.Text.Trim();
                Global.CodEmpresa = cboEmpresa.SelectedValue.ToString();
                Global.NombreEmpresa = cboEmpresa.Text.Trim();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta!", "Inicio de Sesión", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                logueado = false;
            }

            if (!drUser.IsClosed) drUser.Close();

            // Obtener datos de la empresa donde se logeo.
            str = "select * from empresas where codempresa = '" + Global.CodEmpresa + "'";
            var drEmpresa = myConn.DataReader(str);
            if (drEmpresa.HasRows)
            {
                drEmpresa.Read();
                Global.NRC = drEmpresa["NRC"].ToString().Trim();
                Global.NIT = drEmpresa["NIT"].ToString().Trim();
                Global.Representante = drEmpresa["Representante"].ToString().Trim();
                Global.Giro = drEmpresa["Giro"].ToString().Trim();
                Global.Direccion = drEmpresa["Direccion"].ToString().Trim();
                Global.Resolucion = drEmpresa["Resolucion"].ToString().Trim();
                Global.DeResolucion = drEmpresa["DeResolucion"].ToString().Trim();
                Global.AResolucion = drEmpresa["AResolucion"].ToString().Trim();
                Global.FechaResolucion = drEmpresa["FechaResolucion"].ToString().Trim();

                drEmpresa.Close();
            }

            myConn.CloseConnection();

            if (logueado) DialogResult = DialogResult.OK;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            var myConn = new DbConnection();

            myConn.OpenConnection();

            var str =
                "SELECT idempresa, TRIM(codempresa) AS codempresa, TRIM(NombreEmpresa) AS NombreEmpresa, TRIM(NRC) AS NRC, TRIM(NIT) AS NIT FROM Empresas";

            var dsEmpresas = myConn.DataSet(str, "Empresas");

            var x = dsEmpresas.Tables["Empresas"];
            cboEmpresa.DisplayMember = "NombreEmpresa";
            cboEmpresa.ValueMember = "codempresa";
            cboEmpresa.DataSource = dsEmpresas.Tables["Empresas"];

            myConn.CloseConnection();
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}