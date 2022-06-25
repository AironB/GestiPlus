using System;
using System.Windows.Forms;
using GestiPlus.Database;
using GestiPlus.Session;
using GestiPlus.Utils;

namespace GestiPlus
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void tsbNuevoCliente_Click(object sender, EventArgs e)
        {
            var frmNuevoCliente = new FrmEditCliente();
            frmNuevoCliente.Text = "Nuevo Cliente";
            frmNuevoCliente.ShowInTaskbar = false;
            frmNuevoCliente.StartPosition = FormStartPosition.CenterScreen;

            if (frmNuevoCliente.ShowDialog() == DialogResult.OK)
                ActualizarClientes();
        }

        private void ActualizarClientes()
        {
            // Obtener los proveedores
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str =
                "SELECT a.idcliente as IdCliente, trim(a.nombre) as Nombre, trim(a.NIT) as NIT, trim(a.NRC) as NRC, a.idtipocliente, TRIM(b.tipocliente) AS TipoCliente, trim(a.direccion) as Direccion, trim(a.contacto) as Contacto, trim(a.telefono) as Telefono, a.activo as Activo, trim(a.codempresa) as CodigoEmpresa FROM clientes AS a INNER JOIN tipoclientes AS b ON a.idtipocliente = b.idtipocliente WHERE a.codempresa ='" +
                Global.CodEmpresa + "'";

            var x = myConn.ShowDataInGridView(str);

            myConn.CloseConnection();

            dvClientes.DataSource = x;

            dvClientes.Columns["idcliente"].Visible = false;
            dvClientes.Columns["codigoempresa"].Visible = false;
            dvClientes.Columns["idtipocliente"].Visible = false;

            dvClientes.Columns["Nombre"].HeaderText = "Nombre";
            dvClientes.Columns["NIT"].HeaderText = "NIT";
            dvClientes.Columns["NRC"].HeaderText = "NRC";
            dvClientes.Columns["TipoCliente"].HeaderText = "Tipo de Cliente";
            dvClientes.Columns["Direccion"].HeaderText = "Dirección";
            dvClientes.Columns["Contacto"].HeaderText = "Contacto";
            dvClientes.Columns["Telefono"].HeaderText = "Telefono";
            dvClientes.Columns["Activo"].HeaderText = "Activo";

            for (var i = 0; i < dvClientes.Columns.GetColumnCount(DataGridViewElementStates.Visible); i++)
                dvClientes.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            ActualizarClientes();
        }

        private void tsbEditCliente_Click(object sender, EventArgs e)
        {
            // Se edita el cliente seleccionado.

            // Verificar si se ha seleccionado una fila
            var selectedRow = dvClientes.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRow > 0)
            {
                var editCliente = new FrmEditCliente();

                editCliente.Editando = true;

                var client = new Cliente();

                client.IdCliente =
                    int.Parse(dvClientes.SelectedRows[selectedRow - 1].Cells["idcliente"].Value.ToString());
                client.Nombre = dvClientes.SelectedRows[selectedRow - 1].Cells["nombre"].Value.ToString();
                client.NIT = dvClientes.SelectedRows[selectedRow - 1].Cells["NIT"].Value.ToString();
                client.NRC = dvClientes.SelectedRows[selectedRow - 1].Cells["NRC"].Value.ToString();
                client.TipoCliente =
                    int.Parse(dvClientes.SelectedRows[selectedRow - 1].Cells["idtipocliente"].Value.ToString());
                client.Direccion = dvClientes.SelectedRows[selectedRow - 1].Cells["Direccion"].Value.ToString();
                client.Contacto = dvClientes.SelectedRows[selectedRow - 1].Cells["Contacto"].Value.ToString();
                client.Telefono = dvClientes.SelectedRows[selectedRow - 1].Cells["Telefono"].Value.ToString();
                client.Activo = Convert.ToInt32(dvClientes.SelectedRows[selectedRow - 1].Cells["activo"].Value);

                editCliente.mCliente = client;
                editCliente.Text = "Actualizar proveedor";
                editCliente.ShowInTaskbar = false;
                editCliente.StartPosition = FormStartPosition.CenterScreen;
                if (editCliente.ShowDialog() == DialogResult.OK)
                    // Se actualizo el contacto, refrescar el grid
                    ActualizarClientes();
            }
            else
            {
                MessageBox.Show("Debe de seleccionar primero un cliente.", "No permitido");
            }
        }
    }
}