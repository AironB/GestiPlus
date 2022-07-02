using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace clsfactura
{
    internal class CreaTicket
    {
        public static StringBuilder line = new StringBuilder();
        string ticket = "";
        string parte1, parte2;

        public static int max = 75;
        int cort;

        public object RawPrinterHelper { get; private set; }

        internal void TextoIzquierda(string par1)
        {

            max = par1.Length;
            if (max > 75)                                 // **********
            {
                cort = max - 75;
                parte1 = par1.Remove(75, cort);        // si es mayor que 40 caracteres, lo corta
            }
            else { parte1 = par1; }                      // **********
            line.AppendLine(ticket = parte1);
        }

        internal void TextoDerecha(string par1)
        {
            ticket = "";
            max = par1.Length;
            if (max > 75)                                 // **********
            {
                cort = max - 75;
                parte1 = par1.Remove(75, cort);           // si es mayor que 40 caracteres, lo corta
            }
            else { parte1 = par1; }                      // **********
            max = 75 - par1.Length;                     // obtiene la cantidad de espacios para llegar a 40
            for (int i = 0; i < max; i++)
            {
                ticket += " ";                          // agrega espacios para alinear a la derecha
            }
            line.AppendLine(ticket += parte1 + "\n");                //Agrega el texto
        }

       

        internal void AgregaArticulo(string Articulo, double precio, int cant, double subtotal)
        {
            if (cant.ToString().Length <= 3 && precio.ToString("c").Length <= 10 && subtotal.ToString("c").Length <= 11) // valida que cant precio y total esten dentro de rango
            {
                string elementos = "", espacios = "";
                bool bandera = false;
                int nroEspacios = 0;

                if (Articulo.Length > 40)                                 // **********
                {
                    //cort = max - 16;
                    //parte1 = Articulo.Remove(16, cort);          // corta a 16 la descripcion del articulo
                    nroEspacios = (3 - cant.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elementos += espacios + cant.ToString();

                    // colocamos el precio a la derecha
                    nroEspacios = (10 - precio.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elementos += espacios + precio.ToString();

                    //colocar el subtotal a la dercha
                    nroEspacios = (11 - subtotal.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elementos += espacios + subtotal.ToString();

                    int CaracterActual = 0;// indica en que caracter se quedo
                    for (int Longtext = Articulo.Length; Longtext > 16; Longtext++)
                    {
                        if (bandera == false)
                        {
                            line.AppendLine(Articulo.Substring(CaracterActual, 16) + elementos);
                            bandera = true;
                        }
                        else
                        {
                            line.AppendLine(Articulo.Substring(CaracterActual, 16));

                        }
                        CaracterActual += 16;
                    }
                    line.AppendLine(Articulo.Substring(CaracterActual, Articulo.Length - CaracterActual));


                }
                else
                {
                    for (int i = 0; i < (16 - Articulo.Length); i++)
                    {
                        espacios += " ";

                    }
                    elementos = Articulo + espacios;
                    nroEspacios = (3 - cant.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elementos += espacios + cant.ToString();

                    // colocamos el precio a la derecha
                    nroEspacios = (10 - precio.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elementos += espacios + precio.ToString();

                    //colocar el subtotal a la dercha
                    nroEspacios = (11 - subtotal.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elementos += espacios + subtotal.ToString();
                    line.AppendLine(elementos);

                }
            }
            else
            {
                //  MessageBox.Show("Valores fuera de rango");

            }
        }

        internal void AgregaTotales(string v1, double v2)
        {
            throw new NotImplementedException();
        }

        internal void ImprimirTiket(string stringimpresora)
        {
            RawPrinterHelper.SendStringToPrinter(stringimpresora, line.ToString());
            line = new StringBuilder();
        }

        internal static void EncabezadoVenta()
        {
            string LineEncavesado = "Prod                         Cant                  Precio        Total";   // agrega lineas de  encabezados
            line.AppendLine(LineEncavesado); throw new NotImplementedException();
        }

        internal static void LineasGuion()
        {
            string LineaGuion = " ";   // agrega lineas separadoras -

            return line.AppendLine(LineaGuion).ToString();
        }
    }
}