using System;
using System.Windows.Forms;
using GestiPlus.Database;
using GestiPlus.Session;
using GestiPlus.Utils;

namespace GestiPlus
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void tsbNuevoProveedor_Click(object sender, EventArgs e)
        {
            var frmNuevoProveedor = new FrmEditProveedor();
            frmNuevoProveedor.Text = "Nuevo Proveedor";
            frmNuevoProveedor.ShowInTaskbar = false;
            frmNuevoProveedor.StartPosition = FormStartPosition.CenterScreen;

            if (frmNuevoProveedor.ShowDialog() == DialogResult.OK)
                ActualizarProveedores();
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            ActualizarProveedores();
        }

        private void tsbEditProveedor_Click(object sender, EventArgs e)
        {
            // Se edita el proveedor seleccionado.

            // Verificar si se ha seleccionado una fila
            var selectedRow = dvProveedores.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRow > 0)
            {
                var editProveedor = new FrmEditProveedor();

                editProveedor.Editando = true;

                var provee = new Proveedor();

                provee.IdProveedor =
                    int.Parse(dvProveedores.SelectedRows[selectedRow - 1].Cells["IdProveedor"].Value.ToString());
                provee.Nombre = dvProveedores.SelectedRows[selectedRow - 1].Cells["Nombre"].Value.ToString();
                provee.NIT = dvProveedores.SelectedRows[selectedRow - 1].Cells["NIT"].Value.ToString();
                provee.NRC = dvProveedores.SelectedRows[selectedRow - 1].Cells["NRC"].Value.ToString();
                provee.IdCategoria =
                    int.Parse(dvProveedores.SelectedRows[selectedRow - 1].Cells["idcategoria"].Value.ToString());
                provee.Direccion = dvProveedores.SelectedRows[selectedRow - 1].Cells["Direccion"].Value.ToString();
                provee.Contacto = dvProveedores.SelectedRows[selectedRow - 1].Cells["contacto"].Value.ToString();
                provee.Telefono = dvProveedores.SelectedRows[selectedRow - 1].Cells["telefono"].Value.ToString();
                provee.Activo = Convert.ToInt32(dvProveedores.SelectedRows[selectedRow - 1].Cells["activo"].Value);

                editProveedor.mProveedor = provee;
                editProveedor.Text = "Actualizar proveedor";
                editProveedor.ShowInTaskbar = false;
                editProveedor.StartPosition = FormStartPosition.CenterScreen;
                if (editProveedor.ShowDialog() == DialogResult.OK)
                    // Se actualizo el contacto, refrescar el grid
                    ActualizarProveedores();
            }
            else
            {
                MessageBox.Show("Debe de seleccionar primero un proveedor.", "No permitido");
            }
        }

        private void ActualizarProveedores()
        {
            // Obtener los proveedores
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str =
                "SELECT a.idproveedor as IdProveedor, trim(a.nombre) as Nombre, trim(a.NIT) as NIT, trim(a.NRC) as NRC, a.idcategoria, TRIM(b.categoria) as Categoria, trim(a.direccion) as Direccion, trim(a.contacto) as Contacto, trim(a.telefono) as Telefono, a.activo as Activo, trim(a.codempresa) as CodigoEmpresa FROM proveedores AS a INNER JOIN categoriasproveedores AS b ON a.idcategoria = b.idcategoria AND a.codempresa = b.codempresa WHERE a.codempresa = '" +
                Global.CodEmpresa + "'";

            var x = myConn.ShowDataInGridView(str);

            myConn.CloseConnection();

            dvProveedores.DataSource = x;

            dvProveedores.Columns["idproveedor"].Visible = false;
            dvProveedores.Columns["codigoempresa"].Visible = false;
            dvProveedores.Columns["idcategoria"].Visible = false;

            dvProveedores.Columns["Nombre"].HeaderText = "Nombre";
            dvProveedores.Columns["NIT"].HeaderText = "NIT";
            dvProveedores.Columns["NRC"].HeaderText = "NRC";
            dvProveedores.Columns["Categoria"].HeaderText = "Categoria";
            dvProveedores.Columns["Direccion"].HeaderText = "Dirección";
            dvProveedores.Columns["Contacto"].HeaderText = "Contacto";
            dvProveedores.Columns["Activo"].HeaderText = "Activo";

            for (var i = 0; i < dvProveedores.Columns.GetColumnCount(DataGridViewElementStates.Visible); i++)
                dvProveedores.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}