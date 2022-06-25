using System;
using System.Drawing;
using System.Windows.Forms;
using GestiPlus.Database;
using GestiPlus.Session;
using GestiPlus.Utils;

namespace GestiPlus
{
    public partial class FrmBuscar : Form
    {
        public TipoBusqueda._tipoBusqueda Busqueda;
        public string ResultadoBusqueda = "";

        private string sql = "";

        public FrmBuscar()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var cod = dvBuscar.CurrentRow.Cells[0].Value.ToString();
            ResultadoBusqueda = cod;
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmBuscar_Load(object sender, EventArgs e)
        {
            switch (Busqueda)
            {
                case TipoBusqueda._tipoBusqueda.Cliente:
                    BuscarCliente("");
                    break;

                case TipoBusqueda._tipoBusqueda.Producto:
                    // Logica para cargar los productos
                    BuscarProducto("");
                    break;

                case TipoBusqueda._tipoBusqueda.Proveedor:
                    BuscarProveedor("");
                    break;
            }

            txtBuscar.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            switch (Busqueda)
            {
                case TipoBusqueda._tipoBusqueda.Cliente:
                    BuscarCliente(txtBuscar.Text);
                    break;

                case TipoBusqueda._tipoBusqueda.Producto:
                    // Logica para cargar los productos
                    BuscarProducto(txtBuscar.Text);
                    break;

                case TipoBusqueda._tipoBusqueda.Proveedor:
                    BuscarProveedor(txtBuscar.Text);
                    break;
            }
        }

        private void BuscarProducto(string condicion)
        {
            sql =
                "SELECT  TRIM(a.CODIGO) AS codigo, TRIM(a.nombre) as nombre, a.stock, b.preciodetalle FROM productos as a inner join precios as b on a.idproducto = b.idproducto where a.nombre like '%" +
                condicion + "%' and a.codempresa = '" +
                Global.CodEmpresa + "'";

            var conn = new DbConnection();
            conn.OpenConnection();

            var datos = conn.ShowDataInGridView(sql);
            dvBuscar.DataSource = datos;
            dvBuscar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dvBuscar.Columns[0].HeaderText = "Código";
            var ancho = dvBuscar.Width / 1.55;
            var test = Convert.ToInt32(ancho);
            dvBuscar.Columns[1].Width = test;
            dvBuscar.Columns[1].HeaderText = "Producto";
            dvBuscar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dvBuscar.Columns[2].HeaderText = "Existencia";
            dvBuscar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dvBuscar.Columns[3].HeaderText = "Precio al Detalle";

            foreach (DataGridViewRow row in dvBuscar.Rows)
                if (Convert.ToInt32(row.Cells[2].Value) <= 3)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }

            conn.CloseConnection();
        }

        private void BuscarProveedor(string condicion)
        {
            sql =
                "SELECT  TRIM(NRC) AS NRC, TRIM(nombre) as nombre FROM proveedores where nombre LIKE '%" +
                condicion + "%' and codempresa = '" +
                Global.CodEmpresa + "'";

            var conn = new DbConnection();
            conn.OpenConnection();

            var datos = conn.ShowDataInGridView(sql);
            dvBuscar.DataSource = datos;
            dvBuscar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dvBuscar.Columns[0].HeaderText = "Código";
            var ancho = dvBuscar.Width / 1.3;
            var test = Convert.ToInt32(ancho);
            dvBuscar.Columns[1].Width = test;
            dvBuscar.Columns[1].HeaderText = "Proveedor";

            conn.CloseConnection();
        }

        private void BuscarCliente(string condicion)
        {
            sql =
                "SELECT  TRIM(a.NRC) AS NRC, TRIM(a.nombre) as nombre, TRIM(b.tipocliente) as tipocliente FROM clientes as a inner join tipoclientes as b on a.idtipocliente = b.idtipocliente where a.nombre LIKE '%" +
                condicion + "%' and a.codempresa = '" +
                Global.CodEmpresa + "'";

            var conn = new DbConnection();
            conn.OpenConnection();

            var datos = conn.ShowDataInGridView(sql);
            dvBuscar.DataSource = datos;
            dvBuscar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dvBuscar.Columns[0].HeaderText = "Código";
            var ancho = dvBuscar.Width / 1.4;
            var test = Convert.ToInt32(ancho);
            dvBuscar.Columns[1].Width = test;
            dvBuscar.Columns[1].HeaderText = "Cliente";
            dvBuscar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dvBuscar.Columns[2].HeaderText = "Tipo Cliente";

            conn.CloseConnection();
        }
    }
}