using System;
using System.Windows.Forms;
using GestiPlus.Database;
using GestiPlus.Utils;

namespace GestiPlus
{
    public partial class FrmUpgrade : Form
    {
        private bool finalizado;

        public FrmUpgrade()
        {
            InitializeComponent();
        }

        private void FrmUpgrade_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void Actualizar()
        {
            // Obtener el archivo de actualizacion de SQL
            lblEstado.Text = "Obteniendo los cambios... (Esto puede tardar un momento)";
            var x = new Downloader();
            var rutaArchivo = x.GetSQLFile();

            lblEstado.Text = "Preparando para aplicar los cambios...";

            //Thread.Sleep(60000);

            lblEstado.Text = "Aplicando cambios, favor no cierre la ventana... (Esto puede tardar un momento)";

            var z = new DbConnection();
            z.OpenConnection();
            var result = z.ExecuteScript(rutaArchivo);
            z.CloseConnection();

            if (!result)
            {
                MessageBox.Show("Ocurrio un error al actualizar, contacte con soporte tecnico");
                DialogResult = DialogResult.Cancel;
            }

            finalizado = true;
            DialogResult = DialogResult.OK;
        }

        private void FrmUpgrade_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!finalizado)
                DialogResult = DialogResult.Cancel;
        }
    }
}