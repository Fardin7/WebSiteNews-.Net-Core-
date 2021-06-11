using System.Globalization;

namespace Site.Helper
{
    public class CultureHelper
    {
   

        public static string EnumLocalizeValueToName(string value,CultureInfo cultureInfo )
        {
          
            var enumerator = Resource.Resource.ResourceManager.GetResourceSet(cultureInfo, false, false).GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Value.ToString() == value)
                {
                    return enumerator.Key.ToString();
                }

            }
            return value;

        }
        public static string EnumLocalize(string name,CultureInfo cultureInfo)
        {
            return Resource.Resource.ResourceManager.GetString(name, cultureInfo);

        }

    }
}