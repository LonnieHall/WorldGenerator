using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace World
{
    public static class Tools
    {
        //public static List<string> GetNamesFromXMLData(string parentElement, string xmlPath = @"E:\World2\World\XMLData.xml")
        public static List<string> GetNamesFromXMLData(string parentElement, string xmlPath = "XMLData.xml")
        {
            XDocument xdoc = XDocument.Load(xmlPath);
            List<string> c = new List<string>();

            foreach (XElement xe in xdoc.Descendants(parentElement))
            {
                foreach (XElement child in xe.Descendants())
                { c.Add(child.Value); }                
            }
            return c;
        }

        public static string GetRandomName(Random rnd, string parentElement)
        {
            List<string> randomNames = Tools.GetNamesFromXMLData(parentElement);
            int index = rnd.Next(randomNames.Count);
            return randomNames[index];
        }

        public static string NextStringFromSaveData(ref string data, string delimiter)
        {
            var i = data.IndexOf(delimiter);
            var result = data.Substring(0, i);
            data = data.Substring(i + 2, data.Length - i - 2);
            i = data.IndexOf(delimiter);
            return result;
        }

        public static int NextIntFromSaveData(ref string data, string delimiter) 
        {            
            var result = NextStringFromSaveData(ref data, delimiter);
            result = result.Replace(" ", "");
            return Convert.ToInt32(result);            
        }
    }
}
