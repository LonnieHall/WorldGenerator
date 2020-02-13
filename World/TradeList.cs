using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace World
{
    class TradeList
    {
        public List<TradeGood> TradeGoods { get; set; }

        public TradeList(Random rnd)
        {
            TradeGoods = new List<TradeGood>();
            TradeGoods.Add(new TradeGood("Fish", 10, rnd.Next(100) + 1, rnd.Next(100) + 1));
            TradeGoods.Add(new TradeGood("Sugar", 20, rnd.Next(100) + 1, rnd.Next(100) + 1));
            TradeGoods.Add(new TradeGood("Wool", 30, rnd.Next(100) + 1, rnd.Next(100) + 1));
            TradeGoods.Add(new TradeGood("Silver", 40, rnd.Next(100) + 1, rnd.Next(100) + 1));
            TradeGoods.Add(new TradeGood("Gold", 50, rnd.Next(100) + 1, rnd.Next(100) + 1));            
        }

        public TradeList(string dataFromFile, string delimiter)
        {
            TradeGoods = new List<TradeGood>();
            LoadDataFromSave(dataFromFile, delimiter);
        }

        public string GetDataToSave(string delimiter)
        {
            var buf = "";
            foreach (TradeGood tg in TradeGoods) 
            {
                buf += tg.Name + delimiter;
                buf += tg.Supply.ToString() + delimiter;
                buf += tg.Demand.ToString() + delimiter;
                buf += tg.BaseValue.ToString() + delimiter;
                buf += tg.BuyPrice.ToString() + delimiter;
                buf += tg.SellPrice.ToString() + delimiter;
                buf += Environment.NewLine;
            }
            return buf;
        }

        public void LoadDataFromSave(string data, string delimiter)
        {            
            while (data.Length > 2) 
            {                
                var name = Tools.NextStringFromSaveData(ref data, delimiter);
                var supply = Tools.NextIntFromSaveData(ref data, delimiter);
                var demand = Tools.NextIntFromSaveData(ref data, delimiter);
                var basevalue = Tools.NextIntFromSaveData(ref data, delimiter);
                var tg = new TradeGood(name, basevalue, supply, demand);
                tg.BuyPrice = Tools.NextIntFromSaveData(ref data, delimiter);
                tg.SellPrice = Tools.NextIntFromSaveData(ref data, delimiter);
                TradeGoods.Add(tg);
            }
        }
        
    }

    class TradeGood
    {
        public string Name { get; set; }
        public int Supply { get; set; }
        public int Demand { get; set; }
        public int BaseValue { get; set; }
        public int BuyPrice { get; set; } // You Buy from the city at this price
        public int SellPrice { get; set; } // You Sell to the city at this price

        public TradeGood(string name, int baseValue, int supply = 50, int demand = 50)
        {
            Name = name;
            BaseValue = baseValue;
            Supply = supply;
            Demand = demand;
        }

        public int CalculateBuyPrice() { return BaseValue * (Demand + BaseValue) / (Supply + BaseValue); }
        public int CalculateSellPrice(int buyPrice) { return Convert.ToInt32(buyPrice * .85); }
    }    
}
