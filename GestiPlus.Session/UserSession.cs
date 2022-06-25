namespace GestiPlus.Session
{
    public class UserSession
    {
        public string username { get; set; }
        public string codempresa { get; set; }
        public string nrc { get; set; }
        public string nit { get; set; }
        public string representante { get; set; }
        public string giro { get; set; }
        public string direccion { get; set; }
        public string resolucion { get; set; }
        public string deresolucion { get; set; }
        public string aresolucion { get; set; }
        public string fecharesolucion { get; set; }
    }

    public static class Global
    {
        public static string UserName { get; set; } = "";
        public static string CodEmpresa { get; set; } = "";
        public static string NombreEmpresa { get; set; } = "";
        public static string NRC { get; set; } = "";
        public static string NIT { get; set; } = "";
        public static string Representante { get; set; } = "";
        public static string Giro { get; set; } = "";
        public static string Direccion { get; set; } = "";
        public static string Resolucion { get; set; } = "";
        public static string DeResolucion { get; set; } = "";
        public static string AResolucion { get; set; } = "";
        public static string FechaResolucion { get; set; } = "";

        public static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
    }
}