using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GestiPlus.Database;
using GestiPlus.Session;
using GestiPlus.Utils;

namespace GestiPlus
{
    public partial class FrmEditCompra : Form
    {
        //private DetalleCompra[] detalleCompra;

        private decimal ivaCompra;
        private decimal subtotalCompra;
        private decimal totalCompra;

        public FrmEditCompra()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FrmEditCompra_Load(object sender, EventArgs e)
        {
            KeyPreview = true;

            // Obtener los tipos de compras
            TipoDocumento[] list =
            {
                new(1, "Factura"),
                new(2, "Credito Fiscal")
            };
            cboTipoDocumento.DataSource = list;
            cboTipoDocumento.DisplayMember = "NombreDocumento";
            cboTipoDocumento.ValueMember = "IdDocumento";

            dvDetalle.Columns["iva"].Visible = false;

            for (var i = 0; i < dvDetalle.Columns.GetColumnCount(DataGridViewElementStates.Visible); i++)
                dvDetalle.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dvDetalle.Columns["producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dvDetalle.Columns["producto"].Width = 500;

            // Reiniciando los valores de la compra
            subtotalCompra = 0.00M;
            ivaCompra = 0.00M;
            totalCompra = 0.00M;

            txtSubTotal.Text = subtotalCompra.ToString().Trim();
            txtIVA.Text = ivaCompra.ToString().Trim();
            txtTotal.Text = totalCompra.ToString().Trim();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            var _buscar = new FrmBuscar();
            _buscar.Busqueda = TipoBusqueda._tipoBusqueda.Proveedor;
            if (_buscar.ShowDialog() == DialogResult.OK)
            {
                // Agregar el producto
                txtProveedor.Text = _buscar.ResultadoBusqueda;
                ValidarProveedor();
            }
        }

        private void txtProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ValidarProveedor();
        }

        private void ValidarProveedor()
        {
            // Validar el proveedor
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str =
                "SELECT idproveedor, nombre from proveedores WHERE NRC = '" + txtProveedor.Text.Trim() +
                "' and codempresa ='" +
                Global.CodEmpresa + "'";

            var x = myConn.DataReader(str);

            if (x.HasRows)
            {
                x.Read();
                lblNombreProveedor.Text = x["nombre"].ToString();
                lblIdProveedor.Text = x["idproveedor"].ToString();
                txtCodigoProducto.Focus();
            }
            else
            {
                MessageBox.Show("No se encontró el proveedor");
                lblNombreProveedor.Text = "";
                x.Close();
                myConn.CloseConnection();
                txtProveedor.Focus();
            }

            x.Close();
            myConn.CloseConnection();
        }

        private void txtProveedor_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProveedor.Text))
                ValidarProveedor();
        }

        private void FrmEditCompra_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnBuscarProveedor_Click(sender, e);
                    break;

                case Keys.F3:
                    btnBuscarProducto_Click(sender, e);
                    break;

                case Keys.F8:
                    btnAgregar_Click(sender, e);
                    break;

                case Keys.F9:
                    btnEliminar_Click(sender, e);
                    break;
            }

            e.Handled = false;
        }

        private void txtCodigoProducto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoProducto.Text))
                ValidarProducto();
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ValidarProducto();
        }

        private void ValidarProducto()
        {
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str =
                "SELECT p.idproducto, p.codigo, p.nombre, p1.idpresentacion, p1.presentacion FROM productos p INNER JOIN presentaciones p1 ON P.idpresentacion = p1.idpresentacion AND p.codempresa = p1.codempresa WHERE P.codigo = '" +
                txtCodigoProducto.Text.Trim() + "' AND p.codempresa ='" + Global.CodEmpresa + "'";

            var x = myConn.DataReader(str);

            if (x.HasRows)
            {
                x.Read();
                lblIdProducto.Text = x["idproducto"].ToString();
                txtNombreProducto.Text = x["nombre"].ToString();
                numCantidad.Focus();
            }
            else
            {
                MessageBox.Show("No se encontró el producto.");
                txtNombreProducto.Text = "";
                x.Close();
                myConn.CloseConnection();
                txtCodigoProducto.Focus();
            }

            x.Close();
            myConn.CloseConnection();
        }

        private void numCantidad_Enter(object sender, EventArgs e)
        {
            numCantidad.Select(0, numCantidad.Text.Length);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que los datos sean correctos, no vienen campos vacios?
            if (string.IsNullOrEmpty(txtNumDoc.Text))
            {
                MessageBox.Show("Debe ingresar el número del documento antes de guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumDoc.BackColor = Color.Red;
                txtNumDoc.ForeColor = Color.White;
                txtNumDoc.Focus();
                return;
            }
            else
            {
                txtNumDoc.BackColor = Color.White;
                txtNumDoc.ForeColor = Color.Black;
            }

            if (string.IsNullOrEmpty(txtProveedor.Text))
            {
                MessageBox.Show("Debe seleccionar un proveedor antes de guardar.","Validación",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtProveedor.BackColor = Color.Red;
                txtProveedor.ForeColor = Color.White;
                txtProveedor.Focus();
                return;
            }
            else
            {
                txtProveedor.BackColor = Color.White;
                txtProveedor.ForeColor = Color.Black;
            }

            if(dvDetalle.Rows.Count <= 0)
            {
                MessageBox.Show("Debe ingresar al menos un producto antes de guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardar el encabezado
            var conIVA = Convert.ToInt32(cboTipoDocumento.SelectedValue) == 1;
            string tipoCompra;
            if (conIVA)
                tipoCompra = "FAC";
            else
                tipoCompra = "CCF";

            var numero = txtNumDoc.Text.Trim();
            var idproveedor = lblIdProveedor.Text.Trim();
            var fecha = dtpFecha.Value;
            var subtotal = txtSubTotal.Text.Trim();
            var iva = txtIVA.Text.Trim();
            var total = txtTotal.Text.Trim();

            //

            // Obtener todas las posiciones del documento y agregarlas al array para guardarlo.
            var numRegistros = dvDetalle.Rows.Count;
            //DetalleCompra[] detCompras;
            //detCompras = new DetalleCompra[numRegistros];

            var detCompras = new List<DetalleCompra>();

            for (var i = 0; i < numRegistros; i++)
            {
                var cod = dvDetalle.Rows[i].Cells["idproducto"].Value;
                var prod = dvDetalle.Rows[i].Cells["producto"].Value;
                var cant = dvDetalle.Rows[i].Cells["cantidad"].Value;
                var preuni = dvDetalle.Rows[i].Cells["preciounitario"].Value;
                var tot = dvDetalle.Rows[i].Cells["total"].Value;

                detCompras.Add(new DetalleCompra(Convert.ToInt32(cod), "", Convert.ToDecimal(cant),
                    Convert.ToDecimal(preuni), 0.00M, Convert.ToDecimal(tot), ""));
            }

            var compra = new EncabezadoCompra(tipoCompra, numero, Convert.ToInt32(idproveedor), fecha,
                Convert.ToDecimal(subtotal), Convert.ToDecimal(iva), Convert.ToDecimal(total),
                detCompras);

            if (compra.Guardar())
                //
                DialogResult = DialogResult.OK;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // verificar que los datos esten llenos antes de agregar la fila.
            if (!string.IsNullOrEmpty(txtCodigoProducto.Text.Trim()) && numCantidad.Value > 0 && numTotal.Value > 0)
            {
                var conIVA = false;
                conIVA = Convert.ToInt32(cboTipoDocumento.SelectedValue) == 1;

                var _idproducto = lblIdProducto.Text.Trim();
                var _codigo = txtCodigoProducto.Text.Trim();
                var _producto = txtNombreProducto.Text.Trim();
                var _cantidad = numCantidad.Value;
                var _total = numTotal.Value;

                decimal _preciounitario;
                decimal _iva;

                _preciounitario = Math.Round(_total / _cantidad, 2);

                // Agregar los valores al
                if (conIVA)
                {
                    // Es factura, ya lleva el IVA incluido
                    _preciounitario = Math.Round(_total / _cantidad, 2);
                    _iva = 0M;

                    subtotalCompra += _total;
                    totalCompra += _total;
                }
                else
                {
                    _preciounitario = Math.Round(_total / _cantidad, 2);
                    _iva = Math.Round(_preciounitario * 0.13M, 2);
                    var preciosiniva = Math.Round(_total / 1.13M, 2);
                    var valorIva = Math.Round(preciosiniva * 0.13M, 2);

                    subtotalCompra += preciosiniva;
                    ivaCompra += valorIva;
                    totalCompra += _total;
                }

                dvDetalle.Rows.Add(_codigo, _idproducto, _producto, _cantidad, _preciounitario, _iva, _total);

                txtSubTotal.Text = subtotalCompra.ToString().Trim();
                txtIVA.Text = ivaCompra.ToString().Trim();
                txtTotal.Text = totalCompra.ToString().Trim();

                // Limpiar los datos despues de agregarlos.
                lblIdProducto.Text = "";
                txtCodigoProducto.Text = "";
                txtNombreProducto.Text = "";
                numCantidad.Value = 0;
                numTotal.Value = 0;
                txtCodigoProducto.Focus();
            }
            else
            {
                MessageBox.Show("Debe de ingresar un producto antes de agregarlo.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila
            var selectedRow = dvDetalle.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRow > 0)
            {
                // Preguntar si realmente se quiere eliminar el prodcuto.
                var msg = "Esta seguro que desea quitar el prodcuto seleccionado?";
                if (MessageBox.Show(msg, "Desea continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                {
                    var conIVA = false;
                    conIVA = Convert.ToInt32(cboTipoDocumento.SelectedValue) == 1;

                    var rTotal = Convert.ToDecimal(dvDetalle.Rows[selectedRow - 1].Cells["total"].Value);

                    var rSubTotal = conIVA ? rTotal : Math.Round(rTotal / 1.13M, 2);
                    var rIva = Math.Round(rSubTotal * 0.13M, 2);

                    subtotalCompra -= rSubTotal;
                    if (conIVA)
                        ivaCompra = 0.00M;
                    else
                        ivaCompra -= rIva;
                    //ivaCompra -= rIva;
                    totalCompra -= rTotal;

                    txtSubTotal.Text = subtotalCompra.ToString().Trim();
                    txtIVA.Text = ivaCompra.ToString().Trim();
                    txtTotal.Text = totalCompra.ToString().Trim();

                    dvDetalle.Rows.RemoveAt(dvDetalle.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar primero un producto.", "No permitido");
            }
        }

        private void numTotal_Enter(object sender, EventArgs e)
        {
            numTotal.Select(0, numTotal.Text.Length);
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            var _buscar = new FrmBuscar();
            _buscar.Busqueda = TipoBusqueda._tipoBusqueda.Producto;
            if (_buscar.ShowDialog() == DialogResult.OK)
            {
                // Agregar el producto
                txtCodigoProducto.Text = _buscar.ResultadoBusqueda;
                ValidarProducto();
            }
        }
    }
}