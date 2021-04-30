using System;
using System.Collections.Generic;

namespace Knewin.InfoCity.WebApi.Infrastructure
{
    public class Helper
    {
        public static List<string> ToList(string[] arrayNames)
        {
            try
            {
                return new List<string>(arrayNames);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
