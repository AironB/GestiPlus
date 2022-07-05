using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
using GestiPlus.Database;
using GestiPlus.Session;
using GestiPlus.Utils;
using Factura;

namespace GestiPlus
{
    public partial class FrmVentas : Form
    {
        private string nomImpresora;

        //private decimal ivaCompra;
        private int numProductos;

        private int numVenta;

        //private decimal subtotalCompra;
        private decimal totalCompra;

        private string TipoPago;

        public Totales totales;

        private int NumCorteZ = 0;

        private CorteZ DataZ = new CorteZ();

        private List<DetalleVenta> VentaItems = new();

        public FrmVentas()
        {
            InitializeComponent();
        }

        private void FrmVentas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    // Buscar Producto
                    btnBuscarProducto_Click(sender, e);
                    break;

                case Keys.F2:
                    // Generar Corte X
                    break;

                case Keys.F3:
                    // Generar Corte Z
                    btnZ_Click(sender, e);
                    break;

                case Keys.F4:
                    // Buscar cliente
                    btnFindClient_Click(sender, e);
                    break;

                case Keys.F5:
                    btnAgregar_Click(sender, e);
                    break;

                case Keys.F6:
                    btnEliminar_Click(sender, e);
                    break;

                case Keys.F8:
                    btnTicket_Click(sender, e);
                    break;

                case Keys.F9:
                    btnFactura_Click(sender, e);
                    break;

                case Keys.F10:
                    btnCCF_Click(sender, e);
                    break;

                case Keys.F12:
                    if (Salir()) Close();
                    break;
            }

            e.Handled = false;
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            KeyPreview = true;

            for (var i = 0; i < dvDetalle.Columns.GetColumnCount(DataGridViewElementStates.Visible); i++)
                dvDetalle.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dvDetalle.Columns["producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dvDetalle.Columns["producto"].Width = 500;

            numProductos = 0;

            txtIdCliente.Text = "";
            var tE = new KeyEventArgs(Keys.Enter);
            txtIdCliente_KeyDown(sender, tE);
            txtCodigoProducto.Focus();

            var x = new DbConnection();

            x.OpenConnection();
            //aca estyamos pasandole el valor de la tabla configuraciones donde tiene el nombre del impresor de Tickets
            var sql = "Select TRIM(TicketPrinter) as TicketPrinter from Configuraciones where codempresa = '" +
                      Global.CodEmpresa + "'";
            var rd = x.DataReader(sql);
            //var sql2 = "Select TRIM(TicketFact) as TicketPrinter from Configuraciones where codempresa = '" +
            //          Global.CodEmpresa + "'";
            if (rd.HasRows)
            {
                rd.Read();
                nomImpresora = rd["TicketPrinter"].ToString();
            }

            rd.Close();
            x.CloseConnection();

            totales = new Totales(0.0M, 0.0M, 0.0M);
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

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ValidarProducto();
        }

        private void txtCodigoProducto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoProducto.Text))
                ValidarProducto();
        }

        private void numCantidad_Enter(object sender, EventArgs e)
        {
            numCantidad.Select(0, numCantidad.Text.Length);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // verificar que los datos esten llenos antes de agregar la fila.
            if (!string.IsNullOrEmpty(txtCodigoProducto.Text.Trim()) && numCantidad.Value > 0)
            {
                var _idproducto = lblIdProducto.Text.Trim();
                var _codigo = txtCodigoProducto.Text.Trim();
                var _producto = txtNombreProducto.Text.Trim();
                var _cantidad = numCantidad.Value;
                var _total = 0.0M;

                var _preciounitario = GetPrecioUnitario(Convert.ToInt32(_idproducto));

                _total = _preciounitario * _cantidad;
                numProductos += 1;

                totalCompra += _total;

                dvDetalle.Rows.Add(numProductos, _idproducto, _codigo, _producto, _preciounitario, _cantidad, _total);

                txtTotal.Text = totalCompra.ToString().Trim();

                totales.Total = totalCompra;

                // Limpiar los datos despues de agregarlos.
                lblIdProducto.Text = "";
                txtCodigoProducto.Text = "";
                txtNombreProducto.Text = "";
                numCantidad.Value = 0;
                txtCodigoProducto.Focus();
            }
            else
            {
                MessageBox.Show("Debe de ingresar un producto antes de agregarlo.");
            }
        }

        private decimal GetPrecioUnitario(int idProducto, int tipoPrecio = 1)
        {
            var resultado = 0.00M;
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str = "select preciodetalle, preciofrecuente, preciomayoreo from precios where idproducto = " +
                      idProducto + " and codempresa = '" + Global.CodEmpresa + "'";

            var ds = myConn.DataReader(str);

            if (ds.HasRows)
            {
                ds.Read();
                switch (tipoPrecio)
                {
                    case 1:
                        resultado = Convert.ToDecimal(ds["preciodetalle"]);
                        break;

                    case 2:
                        resultado = Convert.ToDecimal(ds["preciofrecuente"]);
                        break;

                    case 3:
                        resultado = Convert.ToDecimal(ds["preciomayoreo"]);
                        break;
                }
            }
            else
            {
                MessageBox.Show("No se logró recuperar el precio del producto.");
            }

            ds.Close();

            return resultado;
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
                    //var conIVA = false;
                    //conIVA = Convert.ToInt32(cboTipoDocumento.SelectedValue) == 1;
                    var rowIndex = dvDetalle.CurrentCell.RowIndex;
                    var rTotal = Convert.ToDecimal(dvDetalle.Rows[rowIndex].Cells["subtotal"].Value);

                    numProductos -= 1;
                    totalCompra -= rTotal;

                    txtTotal.Text = totalCompra.ToString().Trim();

                    totales.Total = totalCompra;

                    dvDetalle.Rows.RemoveAt(dvDetalle.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar primero un producto.", "No permitido");
            }
        }

        private bool Salir()
        {
            var _Salir = false;
            var msg = "Esta seguro que desea salir de la venta?";
            if (MessageBox.Show(msg, "Desea continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
                _Salir = true;

            return _Salir;
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            if (TieneItems())
            {
                var frmPVenta = new FrmPreVenta();
                frmPVenta.Total = txtTotal.Text;
                frmPVenta.StartPosition = FormStartPosition.CenterScreen;
                if (frmPVenta.ShowDialog() == DialogResult.OK)
                {
                    //totales = frmPVenta._totales;
                    TipoPago = frmPVenta.TipoPago;
                    totales.Efectivo = frmPVenta._totales.Efectivo;
                    totales.Cambio = frmPVenta._totales.Cambio;
                    GuardarVenta('T');
                }
            }
            else
            {
                MessageBox.Show("Tiene que agregar items a la venta.");
            }
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            if (TieneItems())
            {
                //var frmVenta = new FrmPreVente();
                GuardarVentaFact('F');
                //aca llamamos a la clase factura
                

                clsfactura.CreaTicket Ticket1 = new clsfactura.CreaTicket();

                // Ticket1.TextoCentro("Empresa xxxxx "); //imprime una linea de descripcion
                //Ticket1.TextoCentro("**********************************");

                Ticket1.TextoIzquierda("");
                Ticket1.TextoDerecha("Factura consumidor final"); //imprime una linea de descripcion
                Ticket1.TextoDerecha(/*No Fac:*/ "0120102");
                Ticket1.TextoDerecha(DateTime.Now.ToShortDateString());
                // Ticket1.TextoIzquierda("Le Atendio: xxxx");
                Ticket1.TextoIzquierda("");
                //clsFactura.CreaTicket.LineasGuion();

                clsfactura.CreaTicket.EncabezadoVenta();
                //clsFactura.CreaTicket.LineasGuion();
                foreach (DataGridViewRow r in dvDetalle.Rows)
                {
                    // PROD                     //PrECIO                                    CANT                         TOTAL
                    Ticket1.AgregaArticulo(r.Cells[1].Value.ToString(), double.Parse(r.Cells[2].Value.ToString()), int.Parse(r.Cells[3].Value.ToString()), double.Parse(r.Cells[4].Value.ToString())); //imprime una linea de descripcion
                }


                clsfactura.CreaTicket.LineasGuion();
                Ticket1.TextoDerecha(" ");
                Ticket1.AgregaTotales("Total", double.Parse(txtTotal.Text)); // imprime linea con total
                Ticket1.TextoDerecha(" ");
                //Ticket1.AgregaTotales("Efectivo Entregado:", double.Parse(txtEfectivo.Text));
                //Ticket1.AgregaTotales("Efectivo Devuelto:", double.Parse(lblDevolucion.Text));


                // Ticket1.LineasTotales(); // imprime linea 

                Ticket1.TextoIzquierda(" ");
                //   Ticket1.TextoCentro("**********************************");
                // Ticket1.TextoCentro("*     Gracias por preferirnos    *");

                //Ticket1.TextoCentro("**********************************");
                Ticket1.TextoIzquierda(" ");
                string impresora = "Microsoft XPS Document Writer";
                Ticket1.ImprimirTiket(impresora);

                MessageBox.Show("Gracias por preferirnos");

                this.Close();

                LimpiarImprimir();
                //cmbproductos.Focus();
                //MessageBox.Show("Gracias por preferirnos");
            }
                
            else
                MessageBox.Show("Tiene que agregar items a la venta.");
        }

        private void btnCCF_Click(object sender, EventArgs e)
        {
            if (TieneItems())
                GuardarVentaCCF('C');
            else
                MessageBox.Show("Tiene que agregar items a la venta.");
        }

        private void GuardarVenta(char tipoVenta)
        {
            // Validar que los datos sean correctos, no vienen campos vacios?

            // Guardar el encabezado

            var _tipoVenta = tipoVenta.ToString();

            //var numerofact = GetCorrelFact();
           // var numeroccf = GetCorrelccf();
            var numero = GetCorrelTicket();
            numVenta = numero;
            var idcliente = lblIdCliente.Text.Trim();
            var fecha = DateTime.Today;
            var subtotal = 0.00M;
            var iva = 0.00M;
            var total = txtTotal.Text.Trim();

            switch (_tipoVenta)
            {
                case "T":
                    // El precio ya tiene iva, no detallarlo
                    //
                    break;

                case "F":
                    // El precio ya tiene iva, no detallarlo

                    break;

                case "C":
                    // Detallar IVA
                    break;
            }

            //

            // Obtener todas las posiciones del documento y agregarlas al array para guardarlo.
            var numRegistros = dvDetalle.Rows.Count;
            //DetalleCompra[] detCompras;
            //detCompras = new DetalleCompra[numRegistros];

            var detVenta = new List<DetalleVenta>();

            for (var i = 0; i < numRegistros; i++)
            {
                var cod = dvDetalle.Rows[i].Cells["idproducto"].Value;
                var prod = dvDetalle.Rows[i].Cells["producto"].Value;
                var cant = dvDetalle.Rows[i].Cells["cantidad"].Value;
                var preuni = dvDetalle.Rows[i].Cells["preciounitario"].Value;
                var tot = dvDetalle.Rows[i].Cells["subtotal"].Value;

                detVenta.Add(new DetalleVenta(Convert.ToInt32(cod), prod.ToString().Trim(), Convert.ToDecimal(cant),
                    Convert.ToDecimal(preuni), 0.00M, Convert.ToDecimal(tot), ""));
            }

            VentaItems = detVenta;

            var venta = new EncabezadoVenta(_tipoVenta, numero.ToString(), Convert.ToInt32(idcliente), fecha,
                Convert.ToDecimal(subtotal), Convert.ToDecimal(iva), Convert.ToDecimal(total),
                detVenta, TipoPago);

            if (venta.Guardar())
                LimpiarImprimir();
        }
        //esto sirve para guardar una venta con factura
        private void GuardarVentaFact(char tipoVenta)
        {
            // Validar que los datos sean correctos, no vienen campos vacios?

            // Guardar el encabezado

            var _tipoVenta = tipoVenta.ToString();

            var numero = GetCorrelFact();
            //var numeroccf = GetCorrelccf();
            // var numero = GetCorrelTicket();
            numVenta = numero;
            var idcliente = lblIdCliente.Text.Trim();
            var nrccliente = label3.Text.Trim();
            var fecha = DateTime.Today;
            var subtotal = 0.00M;
            var iva = 0.00M;
            var total = txtTotal.Text.Trim();

            switch (_tipoVenta)
            {
                case "T":
                    // El precio ya tiene iva, no detallarlo
                    //
                    break;

                case "F":
                    // El precio ya tiene iva, no detallarlo

                    break;

                case "C":
                    // Detallar IVA
                    break;
            }

            //

            //// Obtener todas las posiciones del documento y agregarlas al array para guardarlo.
            var numRegistros = dvDetalle.Rows.Count;
            ////DetalleCompra[] detCompras;
            ////detCompras = new DetalleCompra[numRegistros];

            var detVenta = new List<DetalleVenta>();

            for (var i = 0; i < numRegistros; i++)
            {
                var cod = dvDetalle.Rows[i].Cells["idproducto"].Value;
                var prod = dvDetalle.Rows[i].Cells["producto"].Value;
                var cant = dvDetalle.Rows[i].Cells["cantidad"].Value;
                var preuni = dvDetalle.Rows[i].Cells["preciounitario"].Value;
                var tot = dvDetalle.Rows[i].Cells["subtotal"].Value;

                detVenta.Add(new DetalleVenta(Convert.ToInt32(cod), prod.ToString().Trim(), Convert.ToDecimal(cant),
                    Convert.ToDecimal(preuni), 0.00M, Convert.ToDecimal(tot), ""));
            }

            VentaItems = detVenta;
            label3.Text = txtIdCliente.Text;
            var venta = new EncabezadoVenta(_tipoVenta, numero.ToString(), Convert.ToInt32(idcliente), fecha,
                Convert.ToDecimal(subtotal), Convert.ToDecimal(iva), Convert.ToDecimal(total),
               detVenta, TipoPago);

            if (venta.GuardarFactura())
                LimpiarImprimir();
        }
        //hasta aca
        //esta parte es para los creditos fiscales
        private void GuardarVentaCCF(char tipoVenta)
        {
            // Validar que los datos sean correctos, no vienen campos vacios?

            // Guardar el encabezado

            var _tipoVenta = tipoVenta.ToString();

            //var numero = GetCorrelFact();
            var numero = GetCorrelccf();
            // var numero = GetCorrelTicket();
            numVenta = numero;
            var idcliente = lblIdCliente.Text.Trim();
            var fecha = DateTime.Today;
            var subtotal = 0.00M;
            var iva = 0.00M;
            var total = txtTotal.Text.Trim();

            switch (_tipoVenta)
            {
                case "T":
                    // El precio ya tiene iva, no detallarlo
                    //
                    break;

                case "F":
                    // El precio ya tiene iva, no detallarlo

                    break;

                case "C":
                    // Detallar IVA
                    break;
            }

            //

            // Obtener todas las posiciones del documento y agregarlas al array para guardarlo.
            var numRegistros = dvDetalle.Rows.Count;
            //DetalleCompra[] detCompras;
            //detCompras = new DetalleCompra[numRegistros];

            var detVenta = new List<DetalleVenta>();

            for (var i = 0; i < numRegistros; i++)
            {
                var cod = dvDetalle.Rows[i].Cells["idproducto"].Value;
                var prod = dvDetalle.Rows[i].Cells["producto"].Value;
                var cant = dvDetalle.Rows[i].Cells["cantidad"].Value;
                var preuni = dvDetalle.Rows[i].Cells["preciounitario"].Value;
                var tot = dvDetalle.Rows[i].Cells["subtotal"].Value;

                detVenta.Add(new DetalleVenta(Convert.ToInt32(cod), prod.ToString().Trim(), Convert.ToDecimal(cant),
                    Convert.ToDecimal(preuni), 0.00M, Convert.ToDecimal(tot), ""));
            }

            VentaItems = detVenta;

            var venta = new EncabezadoVenta(_tipoVenta, numero.ToString(), Convert.ToInt32(idcliente), fecha,
                Convert.ToDecimal(subtotal), Convert.ToDecimal(iva), Convert.ToDecimal(total),
                detVenta, TipoPago);

            if (venta.GuardarCCF())
                LimpiarImprimir();
        }
        //hasta aca
        private void txtIdCliente_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoProducto.Text))
                ValidarCliente();
        }

        private void ValidarCliente()
        {
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str =
                "select a.idcliente, a.nombre, b.idtipocliente, a.nrc, a.direccion, a.nit, a.giro from clientes as a inner join tipoclientes as b on a.idtipocliente = b.idtipocliente where a.nrc ='" +
                txtIdCliente.Text.Trim() + "' AND a.codempresa ='" + Global.CodEmpresa + "'";

            var x = myConn.DataReader(str);

            if (x.HasRows)
            {
                x.Read();
                lblIdCliente.Text = x["idcliente"].ToString();
                lblNombreCliente.Text = x["nombre"].ToString();
                lbldireccion.Text = x["direccion"].ToString();
                label3.Text = x["nrc"].ToString();
                lblIdTipoCliente.Text = x["idtipocliente"].ToString();
                lblgiro.Text = x["giro"].ToString();
                txtCodigoProducto.Focus();
            }
            else
            {
                MessageBox.Show("No se encontró el cliente.");
                txtIdCliente.Text = "000000000";
                x.Close();
                myConn.CloseConnection();
                txtCodigoProducto.Focus();
            }

            x.Close();
            myConn.CloseConnection();
        }

        private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ValidarCliente();
        }

        private int GetCorrelTicket()
        {
            var resultado = 1;
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str = "select correlticket from correls where codempresa = '" + Global.CodEmpresa + "'";

            var ds = myConn.DataReader(str);

            if (ds.HasRows)
            {
                ds.Read();
                resultado = Convert.ToInt32(ds["correlticket"]);
            }
            else
            {
                MessageBox.Show("No se logró recuperar el correlativo.");
            }

            ds.Close();
            myConn.CloseConnection();

            return resultado;
        }

        private int GetCorrelZ()
        {
            var resultado = 1;
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str = "select Z from correls where codempresa = '" + Global.CodEmpresa + "'";

            var ds = myConn.DataReader(str);

            if (ds.HasRows)
            {
                ds.Read();
                resultado = Convert.ToInt32(ds["Z"]);
            }
            else
            {
                MessageBox.Show("No se logró recuperar el correlativo.");
            }

            ds.Close();
            myConn.CloseConnection();

            return resultado;
        }

        //esto es para el correlativo de las facturas
        private int GetCorrelFact()
        {
            var resultado = 1;
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str = "select correlfact from correls where codempresa = '" + Global.CodEmpresa + "'";

            var ds = myConn.DataReader(str);

            if (ds.HasRows)
            {
                ds.Read();
                resultado = Convert.ToInt32(ds["correlfact"]);
            }
            else
            {
                MessageBox.Show("No se logró recuperar el correlativo.");
            }

            ds.Close();
            myConn.CloseConnection();

            return resultado;
        }
        //hasta aca

        //aca obtendremos el correlativo de los creditos fiscales
        private int GetCorrelccf()
        {
            var resultado = 1;
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str = "select correlccf from correls where codempresa = '" + Global.CodEmpresa + "'";

            var ds = myConn.DataReader(str);

            if (ds.HasRows)
            {
                ds.Read();
                resultado = Convert.ToInt32(ds["correlccf"]);
            }
            else
            {
                MessageBox.Show("No se logró recuperar el correlativo.");
            }

            ds.Close();
            myConn.CloseConnection();

            return resultado;
        }
        //hasta aca
        private void ImprimirCorteZ()
        {
            var msg = "Quiere imprimir el corte Z? \n\nCuando lo imprima se cerrará la venta y esta acción no puede ser revertida.";

            if (MessageBox.Show(msg,"Continuar?",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                NumCorteZ = GetCorrelZ();
                var result = GetZData();

                if (result) { 
                var printZ = new PrintDocument();
                 printZ.PrinterSettings.PrinterName = nomImpresora;

                printZ.PrintPage += PrintZ;
                if (printZ.PrinterSettings.IsValid)
                    printZ.Print();
                else
                    MessageBox.Show("No se logró obtener acceso a la impresora.", "Error de impresión",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void LimpiarImprimir()
        {
            // eliminar todo lo de grid
            while (dvDetalle.Rows.Count > 0) dvDetalle.Rows.Remove(dvDetalle.Rows[0]);
            //for (var x = 0; x < dvDetalle.RowCount; x++) dvDetalle.Rows.RemoveAt(x);

            txtTotal.Text = "0.00";
            numProductos = 0;
            totalCompra = 0.00M;
            lbldireccion.Text = "";
            lblgiro.Text = "";
            lblIdCliente.Text = "";
            lblNombreCliente.Text = "";
            label3.Text = "";
            txtIdCliente.Text = "";

            var printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = nomImpresora;

            printDocument.PrintPage += printPage;
            if (printDocument.PrinterSettings.IsValid)
                printDocument.Print();
            else
                MessageBox.Show("No se logró obtener acceso a la impresora.", "Error de impresión",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        }

        private bool TieneItems()
        {
            var resultado = dvDetalle.RowCount > 0;

            return resultado;
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

        private void printPage(object sender, PrintPageEventArgs e)
        {
            var graphics = e.Graphics;
            var pagebound = e.PageBounds;
            //var pagewidth = pagebound.Width;
            var pagewidth = 280;

            //var salto = 10;

            var regular = new Font(FontFamily.GenericSansSerif, 10.0f, FontStyle.Regular);
            var bold = new Font(FontFamily.GenericSansSerif, 10.0f, FontStyle.Bold);
            var title = new Font(FontFamily.GenericSansSerif, 12.0f, FontStyle.Bold);
            var encabezadoProd = new Font(FontFamily.GenericSansSerif, 9.0f, FontStyle.Bold);
            var detalle = new Font(FontFamily.GenericSansSerif, 8.0f, FontStyle.Regular);
            var courrier = new Font("Courier New", 10);
            var courrierItem = new Font("Courier New", 8);
            var courrierItemBold = new Font("Courier New",8,FontStyle.Bold);

            float leading = 4;
            var lineheightregular = regular.GetHeight() + leading;
            var lineheightbold = bold.GetHeight() + leading;
            var lineheighttitle = title.GetHeight() + leading;
            var lineheightencabezadoProd = encabezadoProd.GetHeight() + leading;
            var lineheightdetalle = detalle.GetHeight() + leading;
            var lineheightcourrier = courrier.GetHeight() + leading;
            var lineheightcourrieritem = courrierItem.GetHeight() + leading;
            var lineheightcourieritembold = courrierItemBold.GetHeight() + leading;

            float startX = 0;
            var startY = leading;
            float Offset = 0;
            float OffSetX = 10;

            var formatLeft = new StringFormat(StringFormatFlags.NoClip);
            var formatCenter = new StringFormat(formatLeft);
            var formatRight = new StringFormat(formatLeft);

            formatCenter.Alignment = StringAlignment.Center;
            formatRight.Alignment = StringAlignment.Far;
            formatLeft.Alignment = StringAlignment.Near;

            var layoutSize = new SizeF(pagewidth - Offset * 2, lineheighttitle);
            var layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            var brush = Brushes.Black;

            //print header
            if (Global.NombreEmpresa.Trim().Length > 25)
            {
                // Linea muy larga, dividirla en 2
                var empresa1 = Global.NombreEmpresa.Substring(0, 25);
                var empresa2 = Global.NombreEmpresa.Substring(25);

                graphics.DrawString(empresa1, title, brush, layout, formatCenter);
                Offset = Offset + lineheighttitle;
                layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

                graphics.DrawString(empresa2, title, brush, layout, formatCenter);
                Offset = Offset + lineheighttitle;
                layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            }
            else
            {
                graphics.DrawString(Global.NombreEmpresa, title, brush, layout, formatCenter);
                Offset = Offset + lineheighttitle;
                layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            }

            graphics.DrawString(Global.Representante, detalle, brush, layout, formatCenter);
            Offset = Offset + lineheightdetalle;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString(Global.Direccion.Trim(), regular, brush, layout, formatCenter);
            Offset = Offset + lineheightregular * 3;
            //var dirheight = e.Graphics.MeasureString(Global.Direccion, regular, layout).Height;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("NRC: " + Global.NRC + " NIT: " + Global.NIT, regular, brush, layout, formatCenter);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("Giro: " + Global.Giro, regular, brush, layout, formatCenter);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("".PadRight(32, '-'), courrier, brush, layout, formatLeft);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("Res: " + Global.Resolucion, regular, brush, layout, formatCenter);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("De: " + Global.DeResolucion, regular, brush, layout,
                formatCenter);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("A: " + Global.AResolucion, regular, brush, layout,
                formatCenter);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            var fechaR = DateTime.Parse(Global.FechaResolucion);
            var fechaResolucion = fechaR.ToString("dd/MM/yyyy");
            graphics.DrawString("Fecha R: " + fechaResolucion, regular, brush, layout, formatCenter);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("".PadRight(32, '-'), courrier, brush, layout, formatLeft);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX + 20, startY + Offset), layoutSize);

            graphics.DrawString("Descripción", encabezadoProd, brush, layout,
                formatLeft);
            OffSetX = OffSetX + 210;
            layout = new RectangleF(new PointF(startX + OffSetX, startY + Offset), layoutSize);

            graphics.DrawString("Precio", encabezadoProd, brush, layout,
                formatLeft);
            Offset = Offset + lineheightencabezadoProd;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("".PadRight(32, '-'), courrier, brush, layout, formatLeft);
            Offset = Offset + lineheightregular;
            OffSetX = 10;
            layout = new RectangleF(new PointF(startX + OffSetX, startY + Offset), layoutSize);

            //print items

            foreach (var item in VentaItems)
            {
                if (item.NombreProducto.Trim().Length > 30)
                {
                    //
                    var producto1 = item.NombreProducto.Substring(0, 29);
                    var producto2 = item.NombreProducto.Substring(29);

                    graphics.DrawString(producto1, courrierItemBold, brush, layout,
                        formatLeft);
                    Offset += lineheightcourieritembold;
                    layout = new RectangleF(new PointF(startX + OffSetX, startY + Offset), layoutSize);

                    graphics.DrawString(producto2 + " x" + item.Cantidad, courrierItemBold, brush, layout,
                        formatLeft);
                    OffSetX = OffSetX + 210;
                }
                else
                {
                    graphics.DrawString(item.NombreProducto + " x" + item.Cantidad, courrierItemBold, brush, layout,
                        formatLeft);
                    OffSetX = OffSetX + 210;
                }

                var z = item.PrecioUnitario.ToString();
                var newPos = 0;
                if (z.Length > 4) newPos = z.Length - 4;
                var x = startX + (OffSetX - newPos);
                layout = new RectangleF(new PointF(x, startY + Offset), layoutSize);
                graphics.DrawString(item.PrecioUnitario + "G", courrierItemBold, brush, layout, formatLeft);
                Offset += lineheightcourieritembold;
                OffSetX -= 210 - newPos;
                layout = new RectangleF(new PointF(startX + OffSetX, startY + Offset), layoutSize);
            }

            // Imprimir totales y cambio
            layout.X = 0;
            graphics.DrawString("".PadRight(32, '-'), courrier, brush, layout, formatLeft);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("SUBTOTAL: $" + totales.Total.ToString("0.00"), courrierItem, brush, layout,
                formatRight);
            Offset = Offset + lineheightcourrieritem;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("EXENTO:  $0.00", courrierItem, brush, layout, formatRight);
            Offset = Offset + lineheightcourrieritem;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("TOTAL: $" + totales.Total.ToString("0.00"), courrierItem, brush, layout, formatRight);
            Offset = Offset + lineheightcourrieritem;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("EFECTIVO: $" + totales.Efectivo.ToString("0.00"), courrierItem, brush, layout,
                formatRight);
            Offset = Offset + lineheightcourrieritem;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("CAMBIO: $" + totales.Cambio.ToString("0.00"), courrierItem, brush, layout,
                formatRight);
            Offset = Offset + lineheightcourrieritem;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            //print footer
            graphics.DrawString("".PadRight(32, '-'), courrier, brush, layout, formatLeft);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("Ticket No:" + numVenta, detalle, brush, layout, formatLeft);
            Offset = Offset + lineheightdetalle;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("Caja No: 1", detalle, brush, layout, formatLeft);

            var Fecha = DateTime.Now.ToString("dd/MM/yyyy");
            graphics.DrawString("Fecha: " + Fecha, detalle, brush, layout, formatRight);
            Offset = Offset + lineheightdetalle;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("Cajero(a): " + Global.UserName, detalle, brush, layout, formatLeft);

            var Hora = DateTime.Now.ToString("hh:mm:ss tt");
            graphics.DrawString("Hora: " + Hora, detalle, brush, layout, formatRight);
            var espacio = lineheightdetalle * 2;
            Offset += espacio;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            if (totales.Total >= 200.00M)
            {
                graphics.DrawString("Nombre:_____________________________________", detalle, brush, layout, formatLeft);
                Offset += lineheightdetalle;
                layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

                graphics.DrawString("DUI:_______________________________________", detalle, brush, layout, formatLeft);
                Offset += lineheightdetalle;
                layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            }

            graphics.DrawString("GRACIAS POR SU COMPRA", regular, brush, layout, formatCenter);

            regular.Dispose();
            bold.Dispose();
            title.Dispose();
            encabezadoProd.Dispose();
            detalle.Dispose();
            courrier.Dispose();
            courrierItem.Dispose();

            // Check to see if more pages are to be printed.
            e.HasMorePages = VentaItems.Count > 20;
        }

        private bool GetZData()
        {
            bool resultado = true;
            DataZ.Numero = NumCorteZ;

            // Obtener primer correlativo y ultimo correlativo sin Z
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str = "select top 1 numero from ventas where Z = 0 and codempresa ='" + Global.CodEmpresa + "' order by numero asc";

            var ds = myConn.DataReader(str);

            if (ds.HasRows)
            {
                ds.Read();
                DataZ.CorrelInicio = Convert.ToInt32(ds["numero"]);
            }
            else
            {
                MessageBox.Show("No hay venta para realizar corte Z.");
                Global.Logger.Debug("No hay venta para realizar corte Z, Consulta: {0}", str);
                resultado = false;
                return resultado;
            }

            ds.Close();

            str = "select top 1 cast(numero as int) as numero from ventas where Z = 0 and codempresa ='" + Global.CodEmpresa + "' order by numero desc";
            ds = myConn.DataReader(str);
            if (ds.HasRows)
            {
                ds.Read();
                DataZ.CorrelFin = Convert.ToInt32(ds["numero"]);
            }
            else
            {
                MessageBox.Show("No se logró recuperar el ultimo ticket emitido.");
                Global.Logger.Debug("No hay venta para realizar corte Z, Consulta: {0}", str);
                resultado = false;
                return resultado;
            }

            ds.Close();

            DataZ.TotalVentasNoSujetas = 0.00M;
            DataZ.TotalVentasSujetas = 0.00M;

            // Obtener el numero de tickets
            str = "select count(numero) as numtickets from ventas where Z = 0 and tipoventa = 'T' and codempresa =  '" + Global.CodEmpresa + "'";
            ds = myConn.DataReader(str);
            if (ds.HasRows)
            {
                ds.Read();
                DataZ.TicketsEmitidos = Convert.ToInt32(ds["numtickets"]);
            }
            else
            {
                MessageBox.Show("No se logró recuperar el numero de tickets emitidos.");
                Global.Logger.Debug("No se logró recuperar el numero de tickets, Consulta: {0}", str);
                resultado = false;
                return resultado;
            }

            ds.Close();

            // Obtener el total de ventas grabadas
            str = "select sum(total) as total from ventas where Z = 0 and codempresa = '" + Global.CodEmpresa + "'";
            ds = myConn.DataReader(str);
            if (ds.HasRows)
            {
                ds.Read();
                DataZ.TotalVentasGravadas = Convert.ToDecimal(ds["total"]);
            }
            else
            {
                MessageBox.Show("No se logró obtener el total de la venta.");
                Global.Logger.Debug("No se logró obtener el total de la venta, Consulta: {0}", str);
                resultado = false;
                return resultado;
            }

            ds.Close();

            myConn.CloseConnection();

            return resultado;
        }

        private void PrintZ(object sender, PrintPageEventArgs e)
        {
            var graphics = e.Graphics;
            var pagebound = e.PageBounds;
            var pagewidth = 280;

            var regular = new Font(FontFamily.GenericSansSerif, 10.0f, FontStyle.Regular);
            var bold = new Font(FontFamily.GenericSansSerif, 10.0f, FontStyle.Bold);
            var title = new Font(FontFamily.GenericSansSerif, 12.0f, FontStyle.Bold);
            var encabezadoProd = new Font(FontFamily.GenericSansSerif, 9.0f, FontStyle.Bold);
            var detalle = new Font(FontFamily.GenericSansSerif, 8.0f, FontStyle.Regular);
            var courrier = new Font("Courier New", 10);
            var courrierItem = new Font("Courier New", 8);

            float leading = 4;
            var lineheightregular = regular.GetHeight() + leading;
            var lineheightbold = bold.GetHeight() + leading;
            var lineheighttitle = title.GetHeight() + leading;
            var lineheightencabezadoProd = encabezadoProd.GetHeight() + leading;
            var lineheightdetalle = detalle.GetHeight() + leading;
            var lineheightcourrier = courrier.GetHeight() + leading;
            var lineheightcourrieritem = courrierItem.GetHeight() + leading;

            float startX = 0;
            var startY = leading;
            float Offset = 0;
            float OffSetX = 10;

            var formatLeft = new StringFormat(StringFormatFlags.NoClip);
            var formatCenter = new StringFormat(formatLeft);
            var formatRight = new StringFormat(formatLeft);

            formatCenter.Alignment = StringAlignment.Center;
            formatRight.Alignment = StringAlignment.Far;
            formatLeft.Alignment = StringAlignment.Near;

            var layoutSize = new SizeF(pagewidth - Offset * 2, lineheighttitle);
            var layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            var brush = Brushes.Black;

            //print header
            if (Global.NombreEmpresa.Trim().Length > 25)
            {
                // Linea muy larga, dividirla en 2
                var empresa1 = Global.NombreEmpresa.Substring(0, 25);
                var empresa2 = Global.NombreEmpresa.Substring(25);

                graphics.DrawString(empresa1, title, brush, layout, formatCenter);
                Offset = Offset + lineheighttitle;
                layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

                graphics.DrawString(empresa2, title, brush, layout, formatCenter);
                Offset = Offset + lineheighttitle;
                layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            }
            else
            {
                graphics.DrawString(Global.NombreEmpresa, title, brush, layout, formatCenter);
                Offset = Offset + lineheighttitle;
                layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            }

            graphics.DrawString(Global.Representante, regular, brush, layout, formatCenter);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString(Global.Direccion.Trim(), regular, brush, layout, formatCenter);
            Offset = Offset + lineheightregular * 3;
            //var dirheight = e.Graphics.MeasureString(Global.Direccion, regular, layout).Height;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("NRC: " + Global.NRC + " NIT: " + Global.NIT, regular, brush, layout, formatCenter);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("Giro: " + Global.Giro, regular, brush, layout, formatCenter);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("".PadRight(32, '-'), courrier, brush, layout, formatLeft);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("Res: " + Global.Resolucion, regular, brush, layout, formatCenter);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("De: " + Global.DeResolucion, regular, brush, layout,
                formatCenter);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("A: " + Global.AResolucion, regular, brush, layout,
                formatCenter);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            var fechaR = DateTime.Parse(Global.FechaResolucion);
            var fechaResolucion = fechaR.ToString("dd/MM/yyyy");
            graphics.DrawString("Fecha R: " + fechaResolucion, regular, brush, layout, formatCenter);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("".PadRight(32, '-'), courrier, brush, layout, formatLeft);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("Tickets emitidos: " + DataZ.TicketsEmitidos, encabezadoProd, brush, layout,
                formatLeft);
            Offset = Offset + lineheightencabezadoProd;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("".PadRight(32, '-'), courrier, brush, layout, formatLeft);
            Offset = Offset + lineheightregular;
            OffSetX = 10;
            layout = new RectangleF(new PointF(startX + OffSetX, startY + Offset), layoutSize);

            // Imprimir totales y cambio
            layout.X = 20;
            graphics.DrawString("SubTotal Extenas: $" + DataZ.TotalVentasSujetas, encabezadoProd, brush, layout,
                formatLeft);
            Offset = Offset + lineheightencabezadoProd;
            layout = new RectangleF(new PointF(startX + 20, startY + Offset), layoutSize);

            graphics.DrawString("Subtotal No Sujeto: $" + DataZ.TotalVentasNoSujetas, encabezadoProd, brush, layout,
                formatLeft);
            Offset = Offset + lineheightencabezadoProd;
            layout = new RectangleF(new PointF(startX + 20, startY + Offset), layoutSize);

            graphics.DrawString("Subtotal Gravadas: $" + DataZ.TotalVentasGravadas, encabezadoProd, brush, layout,
                formatLeft);
            Offset = Offset + lineheightencabezadoProd;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            layout.X = 0;
            graphics.DrawString("".PadRight(32, '-'), courrier, brush, layout, formatLeft);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("Total Tickets: $" + DataZ.TotalVentasGravadas, encabezadoProd, brush, layout,
                formatLeft);
            Offset = Offset + lineheightencabezadoProd;
            layout = new RectangleF(new PointF(startX + 20, startY + Offset), layoutSize);

            graphics.DrawString("No Inicio: " + DataZ.CorrelInicio, encabezadoProd, brush, layout,
                formatLeft);
            Offset = Offset + lineheightencabezadoProd;
            layout = new RectangleF(new PointF(startX + 20, startY + Offset), layoutSize);

            graphics.DrawString("No Final: " + DataZ.CorrelFin, encabezadoProd, brush, layout,
                formatLeft);
            Offset = Offset + lineheightencabezadoProd;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            //print footer
            graphics.DrawString("".PadRight(32, '-'), courrier, brush, layout, formatLeft);
            Offset = Offset + lineheightregular;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("Z No:" + DataZ.Numero, detalle, brush, layout, formatLeft);
            Offset = Offset + lineheightdetalle;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("Caja No: 1", detalle, brush, layout, formatLeft);

            var Fecha = DateTime.Now.ToString("dd/MM/yyyy");
            graphics.DrawString("Fecha: " + Fecha, detalle, brush, layout, formatRight);
            Offset = Offset + lineheightdetalle;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            graphics.DrawString("Cajero(a): " + Global.UserName, detalle, brush, layout, formatLeft);

            var Hora = DateTime.Now.ToString("hh:mm:ss tt");
            graphics.DrawString("Hora: " + Hora, detalle, brush, layout, formatRight);
            //var espacio = lineheightdetalle * 2;
            //Offset += espacio;
            //layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            regular.Dispose();
            bold.Dispose();
            title.Dispose();
            encabezadoProd.Dispose();
            detalle.Dispose();
            courrier.Dispose();
            courrierItem.Dispose();

            // Check to see if more pages are to be printed.
            e.HasMorePages = VentaItems.Count > 20;
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            ImprimirCorteZ();
            CerrarCorte();
        }

        private void CerrarCorte()
        {
            var newCorte = DataZ.Numero + 1;

            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str = "update correls set Z = '" + newCorte+"' where codempresa = '" + Global.CodEmpresa + "'";

            myConn.ExecuteQuery(str);


            str = "update ventas set Z = " + DataZ.Numero + ", fechaZ = getdate() where codempresa = '" + Global.CodEmpresa + "' and Z = 0";

            myConn.ExecuteQuery(str);

            myConn.CloseConnection();
        }

        private void btnFindClient_Click(object sender, EventArgs e)
        {
            var _buscar = new FrmBuscar();
            _buscar.Busqueda = TipoBusqueda._tipoBusqueda.Cliente;
            if (_buscar.ShowDialog() == DialogResult.OK)
            {
                // Agregar el producto
                txtIdCliente.Text = _buscar.ResultadoBusqueda;
                ValidarCliente();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblIdTipoCliente_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }



    public class Totales
    {
        public Totales(decimal total, decimal cambio, decimal efectivo)
        {
            Total = total;
            Cambio = cambio;
            Efectivo = efectivo;
        }

        public decimal Total { get; set; }
        public decimal Cambio { get; set; }
        public decimal Efectivo { get; set; }
    }
}