using System;
using System.Linq;
using System.Windows.Forms;

namespace GestiPlus
{
    public partial class FrmPreVenta : Form
    {
        public Totales _totales;
        public string TipoPago;
        public string Total;

        public FrmPreVenta()
        {
            InitializeComponent();
        }

        public void onlynumwithsinglepoint(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.')) e.Handled = true;
            var txtEfectivo = sender as TextBox;
            if (e.KeyChar == '.' && txtEfectivo.Text.Contains(".")) e.Handled = true;
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void FrmPreVenta_Load(object sender, EventArgs e)
        {
            txtTotal.Text = Total;
            txtEfectivo.Focus();
            txtCambio.Text = "0.00";
            _totales = new Totales(0.00M, 0.00M, 0.00M);
        }

        private void ActualizarCambio()
        {
            var tot = Convert.ToDecimal(txtTotal.Text);
            decimal cambio;
            if (!string.IsNullOrEmpty(txtEfectivo.Text))
            {
                var efectivo = Convert.ToDecimal(txtEfectivo.Text);
                cambio = efectivo - tot;
            }
            else
            {
                cambio = 0.00M;
            }

            txtCambio.Text = cambio.ToString();
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            ActualizarCambio();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var seleccionado = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name;

            switch (seleccionado)
            {
                case "rbEfectivo":
                    TipoPago = "EFE";
                    break;

                case "rbTarjeta":
                    TipoPago = "TAR";
                    break;

                case "rbBitcoin":
                    TipoPago = "BTC";
                    break;
            }

            if (string.IsNullOrEmpty(txtEfectivo.Text))
                txtEfectivo.Text = txtTotal.Text;

            _totales.Efectivo = decimal.Parse(txtEfectivo.Text);
            _totales.Cambio = decimal.Parse(txtCambio.Text);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}