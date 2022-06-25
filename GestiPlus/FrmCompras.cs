using System;
using System.Windows.Forms;
using GestiPlus.Database;
using GestiPlus.Session;

namespace GestiPlus
{
    public partial class FrmCompras : Form
    {
        public FrmCompras()
        {
            InitializeComponent();
        }

        private void tsbNuevaCompra_Click(object sender, EventArgs e)
        {
            var frmNuevaCompra = new FrmEditCompra();
            frmNuevaCompra.Text = "Nueva Compra";
            frmNuevaCompra.ShowInTaskbar = false;
            frmNuevaCompra.StartPosition = FormStartPosition.CenterScreen;

            if (frmNuevaCompra.ShowDialog() == DialogResult.OK)
                ActualizarCompras();
        }

        private void ActualizarCompras()
        {
            // Obtener los proveedores
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str =
                "select c.idcompra, c.tipocompra, c.numero, p.nombre, c.fecha, c.subtotal, c.iva, c.total from compras as c inner join proveedores as p on c.idproveedor = p.idproveedor and c.codempresa = p.codempresa where c.codempresa = '" +
                Global.CodEmpresa + "'";

            var x = myConn.ShowDataInGridView(str);

            myConn.CloseConnection();

            dvCompras.DataSource = x;

            dvCompras.Columns["idcompra"].Visible = false;
            //dvCompras.Columns["codigoempresa"].Visible = false;
            //dvCompras.Columns["idtipocliente"].Visible = false;

            dvCompras.Columns["tipocompra"].HeaderText = "Tipo Documento";
            dvCompras.Columns["numero"].HeaderText = "Numero";
            dvCompras.Columns["nombre"].HeaderText = "Nombre del proveedor";
            dvCompras.Columns["fecha"].HeaderText = "Fecha";
            dvCompras.Columns["subtotal"].HeaderText = "SubTotal";
            dvCompras.Columns["iva"].HeaderText = "IVA";
            dvCompras.Columns["total"].HeaderText = "Total";
            //dvCompras.Columns["Activo"].HeaderText = "Activo";

            for (var i = 0; i < dvCompras.Columns.GetColumnCount(DataGridViewElementStates.Visible); i++)
                dvCompras.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void tsbEditCompra_Click(object sender, EventArgs e)
        {
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            ActualizarCompras();
        }
    }
}