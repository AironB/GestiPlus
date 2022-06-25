using System.IO;
using System.Net;

namespace GestiPlus.Utils
{
    public static class AppInfo
    {
        public static string GetWebVersion()
        {
            var client = new WebClient();
            var stream = client.OpenRead("http://williamsorellana.rocks/gestiplus/version.txt");
            var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();

            return content;
        }
    }
}