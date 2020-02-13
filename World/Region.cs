using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    class Region
    {
        public string Name { get; set; }        
        public int Wealth { get; set; }
        public int Culture { get; set; }
        public int DataValue { get; set; }
        public TradeList TradeListData { get; set; }

        public Region(Random rnd, int dataValue, string name)
        { 
            DataValue = dataValue;
            Name = name;
            Wealth = rnd.Next(100) + 1;
            Culture = rnd.Next(100) + 1;
            TradeListData = new TradeList(rnd);
        }

        public string GetDataToSave(string delimiter)
        {
            var buf = "";
            buf += Name + delimiter;
            buf += Wealth.ToString() + delimiter;
            buf += Culture.ToString() + delimiter;
            buf += DataValue.ToString() + delimiter;
            buf += Environment.NewLine + TradeListData.GetDataToSave(delimiter);
            return buf;
        }
    }
}
