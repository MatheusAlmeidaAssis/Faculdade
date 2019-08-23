using System.Collections.Generic;
using System.Text;

namespace Dos.UI.Controls
{
    static class Utils
    {
        public static string StringListToString(List<string> aStringList, string aTextoQuebra = ", ")
        {
            StringBuilder strString = new StringBuilder(string.Empty);
            for (int i = 0; i < aStringList.Count; i++)
            {
                if (i == aStringList.Count - 1)
                    strString.Append(aStringList[i]);
                else
                    strString.Append(aStringList[i] + aTextoQuebra);
            }
            return strString.ToString();
        }
        public static string StringArrayToString(string[] aArrayString, string aTextoQuebra = ", ")
        {
            StringBuilder strString = new StringBuilder(string.Empty);
            for (int i = 0; i < aArrayString.Length; i++)
            {
                if (i == aArrayString.Length - 1)
                    strString.Append(aArrayString[i]);
                else
                    strString.Append(aArrayString[i] + aTextoQuebra);
            }
            return strString.ToString();
        }
    }
}
