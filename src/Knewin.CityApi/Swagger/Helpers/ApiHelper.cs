using System.Diagnostics;

namespace Knewin.Swagger.Helpers
{
    public static class ApiHelper
    {
        public static string ProductName => FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductName;
        public static string CompanyName => FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).CompanyName;
    }
}
