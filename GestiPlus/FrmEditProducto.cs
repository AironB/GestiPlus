using System;
using System.Windows.Forms;
using GestiPlus.Database;
using GestiPlus.Session;
using GestiPlus.Utils;

namespace GestiPlus
{
    public partial class FrmEditProducto : Form
    {
        public bool Editando = false;
        public Producto mProducto;

        public FrmEditProducto()
        {
            InitializeComponent();
        }

        private void FrmEditProducto_Load(object sender, EventArgs e)
        {
            // Obtener las unidades

            var myConn = new DbConnection();

            myConn.OpenConnection();

            var str =
                "SELECT idpresentacion, TRIM(presentacion) AS Presentacion FROM presentaciones where codempresa = '" +
                Global.CodEmpresa + "'";

            var dsEmpresas = myConn.DataSet(str, "Presentaciones");

            var x = dsEmpresas.Tables["Presentaciones"];
            cboPresentacion.DisplayMember = "Presentacion";
            cboPresentacion.ValueMember = "idpresentacion";
            cboPresentacion.DataSource = dsEmpresas.Tables["Presentaciones"];

            myConn.CloseConnection();

            txtStock.Text = "0";

            if (Editando)
            {
                btnGuardar.Text = "Actualizar";

                txtCodigo.Text = mProducto.Codigo;
                txtNombre.Text = mProducto.Nombre;
                chkActivo.Checked = Convert.ToBoolean(mProducto.Activo);
                numPrecioDetalle.Text = mProducto.preciodetalle.ToString();
                numPrecioFrecuente.Text = mProducto.preciofrecuente.ToString();
                numPrecioMayoreo.Text = mProducto.preciomayoreo.ToString();
                cboPresentacion.SelectedValue = mProducto.IdPresentacion;
                txtStock.Text = mProducto.stock.ToString();
                lbliddetalleprecio.Text = mProducto.IdDetallePrecio.ToString();
            }
            else
            {
                // Nuevo cliente
                mProducto = new Producto();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que los campos requeridos no vayan vacios

            // Verificar si es nuevo o se esta actualizando.
            if (Editando)
            {
                // Actualizar el producto
                mProducto.Nombre = txtNombre.Text.Trim();
                mProducto.Activo = Convert.ToInt32(chkActivo.Checked);
                mProducto.IdPresentacion = Convert.ToInt32(cboPresentacion.SelectedValue);
                mProducto.IdDetallePrecio = Convert.ToInt32(lbliddetalleprecio.Text);
                mProducto.preciodetalle = numPrecioDetalle.Value;
                mProducto.preciofrecuente = numPrecioFrecuente.Value;
                mProducto.preciomayoreo = numPrecioMayoreo.Value;

                if (mProducto.Actualizar())
                    // Se actualizo el producto
                    DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                // Nuevo proveedor
                // Guardar en la BD

                mProducto.Codigo = txtCodigo.Text.Trim();
                mProducto.Nombre = txtNombre.Text.Trim();
                mProducto.Activo = Convert.ToInt32(chkActivo.Checked);
                mProducto.IdPresentacion = Convert.ToInt32(cboPresentacion.SelectedValue);
                mProducto.preciodetalle = numPrecioDetalle.Value;
                mProducto.preciofrecuente = numPrecioFrecuente.Value;
                mProducto.preciomayoreo = numPrecioMayoreo.Value;

                if (mProducto.Guardar())
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}