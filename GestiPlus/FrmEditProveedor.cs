using System;
using System.Windows.Forms;
using GestiPlus.Database;
using GestiPlus.Session;
using GestiPlus.Utils;

namespace GestiPlus
{
    public partial class FrmEditProveedor : Form
    {
        public bool Editando = false;
        public Proveedor mProveedor;

        public FrmEditProveedor()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que los campos requeridos no vayan vacios

            mProveedor.Nombre = txtNombre.Text.Trim();
            mProveedor.NIT = txtNIT.Text.Trim();
            mProveedor.NRC = txtNCR.Text.Trim();
            mProveedor.IdCategoria = 0;
            mProveedor.Direccion = txtDireccion.Text.Trim();
            mProveedor.Activo = Convert.ToInt32(chkActivo.Checked);
            mProveedor.Contacto = txtContacto.Text.Trim();
            mProveedor.Telefono = txtTelefono.Text.Trim();
            mProveedor.IdCategoria = (int)cboTipoProveedor.SelectedValue;

            // Verificar si es nuevo o se esta actualizando.
            if (Editando)
            {
                // Actualizar el proveedor
                if (mProveedor.Actualizar())
                    // Se actualizo el proveedor
                    DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                // Nuevo proveedor
                // Guardar en la BD
                if (mProveedor.Guardar())
                    // Se guardo el proveedor
                    DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FrmEditProveedor_Load(object sender, EventArgs e)
        {
            var myConn = new DbConnection();

            myConn.OpenConnection();

            var str =
                "select idcategoria, categoria from categoriasproveedores where codempresa = '" + Global.CodEmpresa +
                "'";

            var dsEmpresas = myConn.DataSet(str, "categoriasproveedores");

            var x = dsEmpresas.Tables["categoriasproveedores"];
            cboTipoProveedor.DisplayMember = "categoria";
            cboTipoProveedor.ValueMember = "idcategoria";
            cboTipoProveedor.DataSource = dsEmpresas.Tables["categoriasproveedores"];

            myConn.CloseConnection();

            if (Editando)
            {
                btnGuardar.Text = "Actualizar";
                txtNCR.Text = mProveedor.NRC;
                txtNIT.Text = mProveedor.NIT;
                txtNombre.Text = mProveedor.Nombre;
                chkActivo.Checked = Convert.ToBoolean(mProveedor.Activo);
                txtDireccion.Text = mProveedor.Direccion;
                txtContacto.Text = mProveedor.Contacto;
                txtTelefono.Text = mProveedor.Telefono;
                cboTipoProveedor.SelectedValue = mProveedor.IdCategoria;
            }
            else
            {
                // Nuevo proveedor
                mProveedor = new Proveedor();
            }
        }
    }
}