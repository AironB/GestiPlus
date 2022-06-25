using System;
using System.Configuration;
using System.Windows.Forms;
using GestiPlus.Utils;
using GestiPlus.Session;

namespace GestiPlus
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var version = string.Empty;
            try
            {
                version = AppInfo.GetWebVersion();
                Global.Logger.Info("Version: {0}", version);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Global.Logger.Error(e, "Error: {0}", e);
            }

            /* Verificar si la version instalada es igual a la version en linea */
            // TODO: Agregar la logica

            // Obtener version local de la base de datos.
            ConfigurationManager.AppSettings.AllKeys.Length.ToString();
            var dbversion = ConfigurationManager.AppSettings.Get("DBVersion");

            Application.Run(new FrmMain());

            /*if (!string.IsNullOrEmpty(version)) {
                if (dbversion != version)
                {
                    // Hay una nueva version, actualizar cambios en tablas si los hubieran
                    // llamar al formulario para actualizar
                    var frmUpgrade = new FrmUpgrade();
                    if (frmUpgrade.ShowDialog() == DialogResult.OK)
                    {
                        // Actualizar la info local de la version de la BD
                        ConfigurationManager.AppSettings.Set("DBVersion", version);
                        // Actualizacion correcta
                        Application.Run(new FrmMain());
                    }
                    else
                    {
                        MessageBox.Show("No se logro actualizar, contacte con soporte tecnico.");
                        Application.Exit();
                    }
                }
                else
                {
                    // Ya esta la ultima version, seguir con el sistema
                    Application.Run(new FrmMain());
                }

            }*/
        }
    }
}