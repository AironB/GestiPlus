using System;
using System.Windows.Forms;
using GestiPlus.Database;
using GestiPlus.Session;
using GestiPlus.Utils;

namespace GestiPlus
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void tsbNuevoProducto_Click(object sender, EventArgs e)
        {
            var frmNuevoProducto = new FrmEditProducto();
            frmNuevoProducto.Text = "Nuevo Producto";
            frmNuevoProducto.ShowInTaskbar = false;
            frmNuevoProducto.StartPosition = FormStartPosition.CenterScreen;

            if (frmNuevoProducto.ShowDialog() == DialogResult.OK)
                ActualizarProductos();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            ActualizarProductos();
        }

        private void tsbEditProducto_Click(object sender, EventArgs e)
        {
            // Se edita el producto seleccionado

            // Verificar si se ha seleccionado un producto
            var selectedRow = dvProductos.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRow > 0)
            {
                var editProducto = new FrmEditProducto();
                editProducto.Editando = true;

                var item = new Producto();
                item.IdProducto =
                    Convert.ToInt32(dvProductos.SelectedRows[selectedRow - 1].Cells["idproducto"].Value);
                item.Nombre = dvProductos.SelectedRows[selectedRow - 1].Cells["nombre"].Value.ToString();
                item.Codigo = dvProductos.SelectedRows[selectedRow - 1].Cells["codigo"].Value.ToString();
                item.Activo = Convert.ToInt32(dvProductos.SelectedRows[selectedRow - 1].Cells["activo"].Value);
                item.IdPresentacion =
                    Convert.ToInt32(dvProductos.SelectedRows[selectedRow - 1].Cells["idpresentacion"].Value);
                item.IdDetallePrecio =
                    Convert.ToInt32(dvProductos.SelectedRows[selectedRow - 1].Cells["iddetalleprecio"].Value);
                item.preciodetalle = (decimal)dvProductos.SelectedRows[selectedRow - 1].Cells["preciodetalle"].Value;
                item.preciofrecuente =
                    (decimal)dvProductos.SelectedRows[selectedRow - 1].Cells["preciofrecuente"].Value;
                item.preciomayoreo = (decimal)dvProductos.SelectedRows[selectedRow - 1].Cells["preciomayoreo"].Value;
                item.stock = (decimal)dvProductos.SelectedRows[selectedRow - 1].Cells["stock"].Value;

                editProducto.mProducto = item;
                editProducto.Text = "Actualizar producto: " + item.Nombre;
                editProducto.ShowInTaskbar = false;
                editProducto.StartPosition = FormStartPosition.CenterScreen;
                if (editProducto.ShowDialog() == DialogResult.OK)
                    ActualizarProductos();
            }
            else
            {
                MessageBox.Show("Debe de seleccionar primero un producto.", "No permitido");
            }
        }

        private void ActualizarProductos()
        {
            // Obtener los proveedores
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str =
                "SELECT P.idproducto, P.codigo, P.nombre, p1.presentacion, p2.preciodetalle, p2.preciofrecuente, p2.preciomayoreo, P.activo, P.stock, p.codempresa, p.idpresentacion, p.iddetalleprecio FROM productos p INNER JOIN presentaciones p1 ON p.idpresentacion = p1.idpresentacion AND p.codempresa = p1.codempresa INNER JOIN precios p2 ON p.iddetalleprecio = p2.idprecio AND p.codempresa = p2.codempresa WHERE p.codempresa = '" +
                Global.CodEmpresa.Trim() + "'";

            var x = myConn.ShowDataInGridView(str);

            myConn.CloseConnection();

            dvProductos.DataSource = x;

            dvProductos.Columns["idproducto"].Visible = false;
            dvProductos.Columns["codempresa"].Visible = false;
            dvProductos.Columns["idpresentacion"].Visible = false;
            dvProductos.Columns["iddetalleprecio"].Visible = false;

            dvProductos.Columns["codigo"].HeaderText = "Código";
            dvProductos.Columns["nombre"].HeaderText = "Nombre";
            dvProductos.Columns["presentacion"].HeaderText = "Presentación";
            dvProductos.Columns["preciodetalle"].HeaderText = "Precio al detalle";
            dvProductos.Columns["preciofrecuente"].HeaderText = "Precio Cli. Frecuente";
            dvProductos.Columns["preciomayoreo"].HeaderText = "Precio al mayoreo";
            dvProductos.Columns["activo"].HeaderText = "Activo";
            dvProductos.Columns["stock"].HeaderText = "Stock";

            for (var i = 0; i < dvProductos.Columns.GetColumnCount(DataGridViewElementStates.Visible); i++)
                dvProductos.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}