using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestiPlus.Utils;
using GestiPlus.Database;
using GestiPlus.Session;

namespace GestiPlus
{
    public partial class FrmEditCliente : Form
    {
        public Cliente mCliente;
        public bool Editando = false;

        public FrmEditCliente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que los campos requeridos no vayan vacios

            // Verificar si es nuevo o se esta actualizando.
            if (this.Editando)
            {
                // Actualizar el cliente
                this.mCliente.Nombre = txtNombre.Text.Trim();
                this.mCliente.NIT = txtNIT.Text.Trim();
                this.mCliente.NRC = txtNCR.Text.Trim();
                this.mCliente.TipoCliente = 1;
                this.mCliente.Direccion = txtDireccion.Text.Trim();
                this.mCliente.Activo = Convert.ToInt32(chkActivo.Checked);
                this.mCliente.Contacto = txtContacto.Text.Trim();
                this.mCliente.Telefono = txtTelefono.Text.Trim();
                this.mCliente.TipoCliente = Convert.ToInt32(cboTipoCliente.SelectedValue);
                this.mCliente.giro = txtgiro.Text.Trim();

                if (this.mCliente.Actualizar())
                    // Se actualizo el cliente
                    this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                // Nuevo cliente
                // Guardar en la BD
                this.mCliente.Nombre = txtNombre.Text.Trim();
                this.mCliente.NIT = txtNIT.Text.Trim();
                this.mCliente.NRC = txtNCR.Text.Trim();
                this.mCliente.TipoCliente = 0;
                this.mCliente.Direccion = txtDireccion.Text.Trim();
                this.mCliente.Activo = Convert.ToInt32(chkActivo.Checked);
                this.mCliente.Contacto = txtContacto.Text.Trim();
                this.mCliente.Telefono = txtTelefono.Text.Trim();
                this.mCliente.TipoCliente = Convert.ToInt32(cboTipoCliente.SelectedValue);
                this.mCliente.giro = txtgiro.Text.Trim();

                if (this.mCliente.Guardar())
                    // Se guardo el cliente
                    this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void FrmEditCliente_Load(object sender, EventArgs e)
        {

            // Cargar los tipos de cliente
            var myConn = new DbConnection();

            myConn.OpenConnection();

            var str =
                "SELECT idtipocliente, TRIM(tipocliente) AS tipocliente FROM tipoclientes where codempresa = '" + Global.CodEmpresa + "'";

            var dsEmpresas = myConn.DataSet(str, "clientes");

            //var x = dsEmpresas.Tables["clientes"];
            cboTipoCliente.DisplayMember = "tipocliente";
            cboTipoCliente.ValueMember = "idtipocliente";
            cboTipoCliente.DataSource = dsEmpresas.Tables["clientes"];

            myConn.CloseConnection();

            if (this.Editando == true)
            {
                this.btnGuardar.Text = "Actualizar";
                this.txtNCR.Text = this.mCliente.NRC;
                this.txtNIT.Text = this.mCliente.NIT;
                this.txtNombre.Text = this.mCliente.Nombre;
                this.chkActivo.Checked = Convert.ToBoolean(this.mCliente.Activo);
                this.txtDireccion.Text = this.mCliente.Direccion;
                this.txtContacto.Text = this.mCliente.Contacto;
                this.txtTelefono.Text = this.mCliente.Telefono;
                this.cboTipoCliente.SelectedValue = this.mCliente.TipoCliente;
                this.txtgiro.Text = this.mCliente.giro;
            }
            else
            {
                // Nuevo cliente
                this.mCliente = new Cliente();
            }
        }

        private void cboTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cod;
            string nombre;

            cod = cboTipoCliente.SelectedIndex;
            nombre = cboTipoCliente.SelectedIndex.ToString();
            //esta parte sirve para lo que se visualizara en el combo box
            switch (cod)
            {
                case 0: cboTipoCliente.Text = "3"; break;
                case 1: cboTipoCliente.Text = "2"; break;
                default: cboTipoCliente.Text = "1"; break;

            }
            switch (nombre)
            {
                case "Detalle": cboTipoCliente.Text = "Mayoreo"; break;
                case "Frecuente": cboTipoCliente.Text = "Frecuente"; break;
                default: cboTipoCliente.Text = "Detalle"; break;
            }
            
        }
    }
}