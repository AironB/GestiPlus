using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using GestiPlus.Database;
using GestiPlus.Session;
using GestiPlus.Utils;

namespace GestiPlus
{
    public partial class FrmConfiguracion : Form
    {
        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            // Obtener las impresoras
            var datasourceTicket = new List<Impresores>();
            var datasourceFac = new List<Impresores>();
            foreach (var printer in PrinterSettings.InstalledPrinters)
            {
                datasourceTicket.Add(new Impresores { Name = printer.ToString(), Cod = printer.ToString() });
                datasourceFac.Add(new Impresores { Name = printer.ToString(), Cod = printer.ToString() });
            }

            kcbConfigTicketPrinter.DataSource = datasourceTicket;
            kcbConfigTicketPrinter.DisplayMember = "Name";
            kcbConfigTicketPrinter.ValueMember = "Cod";

            kcbConfigFacPrinter.DataSource = datasourceFac;
            kcbConfigFacPrinter.DisplayMember = "Name";
            kcbConfigFacPrinter.ValueMember = "Cod";

            var x = new DbConnection();

            x.OpenConnection();
            var sql = "Select TicketPrinter from Configuraciones where codempresa = '" + Global.CodEmpresa + "'";
            var rd = x.DataReader(sql);
            if (rd.HasRows)
            {
                rd.Read();
                var z = rd["TicketPrinter"].ToString();
                kcbConfigTicketPrinter.SelectedValue = z;
            }

            rd.Close();
            x.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var printer = kcbConfigTicketPrinter.SelectedValue;

            var sql = "update Configuraciones set TicketPrinter = '" + printer + "'";

            var x = new DbConnection();

            x.OpenConnection();

            var result = x.ExecuteQuery(sql);
            x.CloseConnection();

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}