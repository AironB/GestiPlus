using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using GestiPlus.Database;
using GestiPlus.Session;

namespace GestiPlus.Utils
{
    public class TipoBusqueda
    {
        public enum _tipoBusqueda : ushort
        {
            Producto = 0,
            Proveedor = 1,
            Cliente = 2
        }

        public _tipoBusqueda TipoABuscar;
    }

    public class Proveedor
    {
        public int IdProveedor { set; get; }
        public string Nombre { set; get; }
        public int Activo { set; get; }
        public string Direccion { get; set; }
        public int IdCategoria { get; set; }
        public string NIT { get; set; }
        public string NRC { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }

        public bool Guardar()
        {
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str =
                "INSERT INTO proveedores (nombre,NIT,NRC,idcategoria,direccion,contacto,activo,codempresa,telefono) values ('" +
                Nombre + "','" + NIT + "','" + NRC + "'," + IdCategoria + ",'" + Direccion + "','" + Contacto + "'," +
                Activo + ",'" + Global.CodEmpresa.Trim() + "','" + Telefono + "')";

            var result = myConn.ExecuteQuery(str);

            myConn.CloseConnection();

            var exito = result == 1;
            return exito;
        }

        public bool Actualizar()
        {
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str = "update proveedores set nombre = '" + Nombre + "', NIT = '" + NIT + "', NRC = '" + NRC +
                      "', idcategoria = " + IdCategoria + ", direccion = '" + Direccion + "', contacto = '" + Contacto +
                      "', telefono = '" + Telefono + "', activo = " + Activo + " where idproveedor = " + IdProveedor +
                      " and codempresa = '" + Global.CodEmpresa.Trim() + "'";

            var result = myConn.ExecuteQuery(str);

            myConn.CloseConnection();

            var exito = result == 1;
            return exito;
        }
    }

    public class Cliente
    {
        public string giro;

        public int IdCliente { set; get; }
        public string Nombre { set; get; }
        public int Activo { set; get; }
        public string NIT { set; get; }
        public string NRC { set; get; }
        public int TipoCliente { get; set; }
        public string Direccion { set; get; }
        public string Contacto { set; get; }
        public string Telefono { get; set; }

        public bool Guardar()
        {
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str =
                "INSERT INTO clientes (nombre,NIT,NRC,idtipocliente,direccion,contacto,activo,telefono, codempresa) values ('" +
                Nombre + "','" + NIT + "','" + NRC + "'," + TipoCliente + ",'" + Direccion + "','" + Contacto + "'," +
                Activo + ",'" + Telefono + "','" + Global.CodEmpresa.Trim() + "')";

            var result = myConn.ExecuteQuery(str);

            myConn.CloseConnection();

            var exito = result == 1;
            return exito;
        }

        public bool Actualizar()
        {
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str = "update clientes set nombre = '" + Nombre + "', NIT = '" + NIT + "', NRC = '" + NRC +
                      "', idtipocliente = " + TipoCliente + ", direccion = '" + Direccion + "', contacto = '" +
                      Contacto + "', telefono = '" + Telefono + "', activo = " + Activo + " where idcliente = " +
                      IdCliente + " and codempresa = '" + Global.CodEmpresa.Trim() + "'";

            var result = myConn.ExecuteQuery(str);

            myConn.CloseConnection();

            var exito = result == 1;
            return exito;
        }
    }

    public class Producto
    {
        public int IdProducto { set; get; }
        public string Codigo { set; get; }
        public string Nombre { set; get; }
        public int Activo { set; get; }
        public int IdPresentacion { set; get; }
        public int IdDetallePrecio { set; get; }
        public decimal preciodetalle { set; get; }
        public decimal preciofrecuente { set; get; }
        public decimal preciomayoreo { set; get; }
        public decimal stock { set; get; }

        public bool Guardar()
        {
            var myConn = new DbConnection();
            myConn.OpenConnection();

            // Guardando primero el producto para obtener el id

            var str =
                "INSERT INTO productos (codigo, nombre, activo, idpresentacion, iddetalleprecio, codempresa) output INSERTED.idproducto values ('" +
                Codigo + "','" +
                Nombre + "'," + Activo + "," + IdPresentacion + "," + IdDetallePrecio + ",'" +
                Global.CodEmpresa.Trim() +
                "')";

            var _idProducto = myConn.ExecuteScalar(str);

            str =
                "INSERT INTO precios (idproducto, preciodetalle, preciofrecuente, preciomayoreo, codempresa) output INSERTED.idprecio values (" +
                _idProducto + "," + preciodetalle + "," + preciofrecuente + "," + preciomayoreo + ",'" +
                Global.CodEmpresa.Trim() + "')";

            var _idPrecio = myConn.ExecuteScalar(str);

            str = "UPDATE productos SET iddetalleprecio = " + _idPrecio + " WHERE idproducto = " + _idProducto +
                  " AND codempresa = '" + Global.CodEmpresa.Trim() + "'";

            var result = myConn.ExecuteQuery(str);

            myConn.CloseConnection();

            var exito = result == 1;
            return exito;
        }

        public bool Actualizar()
        {
            var myConn = new DbConnection();
            myConn.OpenConnection();

            var str = "update productos set codigo = '" + Codigo.Trim() + "', nombre = '" + Nombre.Trim() +
                      "', activo = " + Activo +
                      ", idpresentacion = " + IdPresentacion +
                      " where idproducto = " +
                      IdProducto + " and codempresa = '" + Global.CodEmpresa.Trim() + "'";

            var result = myConn.ExecuteQuery(str);

            str = "update precios set preciodetalle = " + preciodetalle + ", preciofrecuente = " + preciofrecuente +
                  ", preciomayoreo = " + preciomayoreo + " where idprecio = " + IdDetallePrecio + " and idproducto = " +
                  IdProducto + " and codempresa = '" + Global.CodEmpresa.Trim() + "'";

            result = myConn.ExecuteQuery(str);

            myConn.CloseConnection();

            var exito = result == 1;
            return exito;
        }
    }

    public class TipoDocumento
    {
        public TipoDocumento(int tipo, string nombre)
        {
            IdDocumento = tipo;
            NombreDocumento = nombre;
        }

        public int IdDocumento { set; get; }
        public string NombreDocumento { set; get; }
    }

    public class EncabezadoCompra
    {
        public EncabezadoCompra(string tipoCompra, string numero, int idproveedor, DateTime fecha, decimal subtotal,
            decimal iva, decimal total, List<DetalleCompra> detalleCompras)
        {
            TipoCompra = tipoCompra;
            Numero = numero;
            IdProveedor = idproveedor;
            Fecha = fecha;
            SubTotal = subtotal;
            IVA = iva;
            Total = total;
            DetallesCompra = detalleCompras;
        }

        public string TipoCompra { get; set; }
        public string Numero { get; set; }
        public int IdProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }

        //public DetalleCompra[] DetallesCompra { get; set; }
        public List<DetalleCompra> DetallesCompra { get; set; }

        public bool Guardar()
        {
            var myConn = new DbConnection();
            myConn.OpenConnection();

            // Guardando primero el encabezado de la comprar para obtener el id

            var format = "yyyy-MM-dd HH:mm:ss";

            var str =
                "INSERT INTO compras (tipocompra, numero, idproveedor, fecha, subtotal, iva, total, codempresa) output INSERTED.idcompra values ('" +
                TipoCompra + "','" +
                Numero + "'," + IdProveedor + ",'" + Fecha.ToString(format) + "'," + SubTotal + "," + IVA + "," +
                Total + ",'" +
                Global.CodEmpresa.Trim() +
                "')";

            var _idCompra = myConn.ExecuteScalar(str);

            str =
                "INSERT INTO comprasd (idcompra, idproducto, cantidad, preciounitario, iva, total, codempresa) values ";

            var x = 0;
            foreach (var detalle in DetallesCompra)
            {
                if (x != 0)
                    str += ", ";

                str +=
                    "(" +
                    _idCompra + "," + detalle.IdProducto + "," + detalle.Cantidad + "," +
                    detalle.PrecioUnitario + ",0," + detalle.Total + ",'" +
                    Global.CodEmpresa.Trim() + "')";

                x++;
            }

            var result = myConn.ExecuteQuery(str);

            myConn.CloseConnection();

            var exito = result != 0;
            return exito;
        }
    }

    public class DetalleCompra
    {
        public DetalleCompra(int idProducto, string nombreProducto, decimal cantidad, decimal precioUnitario,
            decimal iva,
            decimal total,
            string codigoEmpresa)
        {
            IdProducto = idProducto;
            NombreProducto = nombreProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            IVA = iva;
            Total = total;
            CodigoEmpresa = codigoEmpresa;
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public string CodigoEmpresa { get; set; }
    }

    // Venta
    public class EncabezadoVenta
    {
        public EncabezadoVenta(string tipoVenta, string numero, int idcliente, DateTime fecha, decimal subtotal,
            decimal iva, decimal total, List<DetalleVenta> detalleVentas, string tipoPago)
        {
            TipoVenta = tipoVenta;
            Numero = numero;
            IdCliente = idcliente;
            Fecha = fecha;
            SubTotal = subtotal;
            IVA = iva;
            Total = total;
            DetallesVenta = detalleVentas;
            TipoPago = tipoPago;
        }

        public string TipoVenta { get; set; }
        public string Numero { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public string TipoPago { get; set; }

        //public DetalleCompra[] DetallesCompra { get; set; }
        public List<DetalleVenta> DetallesVenta { get; set; }

        public bool Guardar()
        {
            var myConn = new DbConnection();
            var result = 0;
            myConn.OpenConnection();

            // Guardando primero el encabezado de la venta para obtener el id

            var format = "yyyy-MM-dd HH:mm:ss";

            var str =
                "INSERT INTO ventas (tipoventa, numero, idcliente, fecha, subtotal, iva, total, codempresa, tipopago) output INSERTED.idventa values ('" +
                TipoVenta + "','" +
                Numero + "'," + IdCliente + ",'" + Fecha.ToString(format) + "'," + SubTotal + "," + IVA + "," +
                Total + ",'" +
                Global.CodEmpresa.Trim() +
                "','"+TipoPago+"')";

            var _idVenta = myConn.ExecuteScalar(str);

            str =
                "INSERT INTO ventasd (idventa, idproducto, cantidad, preciounitario, iva, total, codempresa) values ";

            var x = 0;
            foreach (var detalle in DetallesVenta)
            {
                if (x != 0)
                    str += ", ";

                str +=
                    "(" +
                    _idVenta + "," + detalle.IdProducto + "," + detalle.Cantidad + "," +
                    detalle.PrecioUnitario + ",0," + detalle.Total + ",'" +
                    Global.CodEmpresa.Trim() + "')";

                x++;
            }

            // Guardar el detalle de la venta
            var detalleGuardado = myConn.ExecuteQuery(str);

            // Si se guardo el detalle, aumentar el correlativo del ticket
            if (detalleGuardado != 0)
            {
                // Aumentar correlativo
                var newCorrel = Convert.ToInt32(Numero) + 1;
                str = "update correls set correlticket = " + newCorrel + " where codempresa = '" + Global.CodEmpresa +
                      "'";

                result = myConn.ExecuteQuery(str);
            }

            myConn.CloseConnection();

            var exito = result != 0;
            return exito;
        }

        public bool GuardarFactura()
        {
            var myConn = new DbConnection();
            var result = 0;
            myConn.OpenConnection();

            // Guardando primero el encabezado de la venta para obtener el id

            var format = "yyyy-MM-dd HH:mm:ss";

            var str =
                "INSERT INTO ventas (tipoventa, numero, idcliente, fecha, subtotal, iva, total, codempresa, tipopago) output INSERTED.idventa values ('" +
                TipoVenta + "','" +
                Numero + "'," + IdCliente + ",'" + Fecha.ToString(format) + "'," + SubTotal + "," + IVA + "," +
                Total + ",'" +
                Global.CodEmpresa.Trim() +
                "','" + TipoPago + "')";

            var _idVenta = myConn.ExecuteScalar(str);

            str =
                "INSERT INTO ventasd (idventa, idproducto, cantidad, preciounitario, iva, total, codempresa) values ";

            var x = 0;
            foreach (var detalle in DetallesVenta)
            {
                if (x != 0)
                    str += ", ";

                str +=
                    "(" +
                    _idVenta + "," + detalle.IdProducto + "," + detalle.Cantidad + "," +
                    detalle.PrecioUnitario + ",0," + detalle.Total + ",'" +
                    Global.CodEmpresa.Trim() + "')";

                x++;
            }

            // Guardar el detalle de la venta
            var detalleGuardado = myConn.ExecuteQuery(str);

            // Si se guardo el detalle, aumentar el correlativo de factura
            if (detalleGuardado != 0)
            {
                // Aumentar correlativo
                var newCorrel = Convert.ToInt32(Numero) + 1;
                str = "update correls set correlfact = " + newCorrel + " where codempresa = '" + Global.CodEmpresa +
                      "'";

                result = myConn.ExecuteQuery(str);
            }

            myConn.CloseConnection();

            var exito = result != 0;
            return exito;
        }
        public bool GuardarCCF()
        {
            var myConn = new DbConnection();
            var result = 0;
            myConn.OpenConnection();

            // Guardando primero el encabezado de la venta para obtener el id

            var format = "yyyy-MM-dd HH:mm:ss";

            var str =
                "INSERT INTO ventas (tipoventa, numero, idcliente, fecha, subtotal, iva, total, codempresa, tipopago) output INSERTED.idventa values ('" +
                TipoVenta + "','" +
                Numero + "'," + IdCliente + ",'" + Fecha.ToString(format) + "'," + SubTotal + "," + IVA + "," +
                Total + ",'" +
                Global.CodEmpresa.Trim() +
                "','" + TipoPago + "')";

            var _idVenta = myConn.ExecuteScalar(str);

            str =
                "INSERT INTO ventasd (idventa, idproducto, cantidad, preciounitario, iva, total, codempresa) values ";

            var x = 0;
            foreach (var detalle in DetallesVenta)
            {
                if (x != 0)
                    str += ", ";

                str +=
                    "(" +
                    _idVenta + "," + detalle.IdProducto + "," + detalle.Cantidad + "," +
                    detalle.PrecioUnitario + ",0," + detalle.Total + ",'" +
                    Global.CodEmpresa.Trim() + "')";

                x++;
            }

            // Guardar el detalle de la venta
            var detalleGuardado = myConn.ExecuteQuery(str);

            // Si se guardo el detalle, aumentar el correlativo de factura
            if (detalleGuardado != 0)
            {
                // Aumentar correlativo
                var newCorrel = Convert.ToInt32(Numero) + 1;
                str = "update correls set correlccf = " + newCorrel + " where codempresa = '" + Global.CodEmpresa +
                      "'";

                result = myConn.ExecuteQuery(str);
            }

            myConn.CloseConnection();

            var exito = result != 0;
            return exito;
        }

    }



    public class DetalleVenta
    {
        public DetalleVenta(int idProducto, string nombreProducto, decimal cantidad, decimal precioUnitario,
            decimal iva,
            decimal total,
            string codigoEmpresa)
        {
            IdProducto = idProducto;
            NombreProducto = nombreProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            IVA = iva;
            Total = total;
            CodigoEmpresa = codigoEmpresa;
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public string CodigoEmpresa { get; set; }
    }

    public class Impresores
    {
        public string Name { get; set; }
        public string Cod { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Downloader
    {
        public string GetSQLFile()
        {
            var currentDir = Path.GetDirectoryName(Application.ExecutablePath);
            var nameFile = "update_sql_" + AppInfo.GetWebVersion() + ".sql";

            var subdir = currentDir + "\\temp";
            var saveFile = currentDir + "\\temp\\" + nameFile;

            // Verificar si la ruta del archivo existe
            var attributes = File.GetAttributes(currentDir);

            switch (attributes)
            {
                case FileAttributes.Directory:
                    if (Directory.Exists(subdir))
                    {
                        // El directorio existe, no hacer nada
                    }
                    else
                    {
                        // El directorio no existe, entonces hay que crearlo
                        if (!Directory.Exists(subdir)) Directory.CreateDirectory(subdir);
                    }

                    break;
            }

            using (var wc = new WebClient())
            {
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new Uri("http://williamsorellana.rocks/gestiplus/" + nameFile),
                    // Param2 = Path to save
                    saveFile
                );
            }

            return saveFile;
        }
    }

    public class CorteZ
    {
        public int Numero {get; set; }
        public int TicketsEmitidos { get; set;}
        public decimal TotalVentasSujetas { get; set;}
        public decimal TotalVentasNoSujetas { get; set;}
        public decimal TotalVentasGravadas { get; set;}
        public decimal TotalTickets { get; set;}

        public int CorrelInicio { get; set;}
        public int CorrelFin { get; set;}

    }
}