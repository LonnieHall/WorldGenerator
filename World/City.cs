using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace World
{
    class City
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }        
        public int Population { get; set; }
        public int Wealth { get; set; }
        public int Culture { get; set; }
        public int WaterAccess { get; set; }
        public int WaterDistance { get; set; }
        public Region RegionData { get; set; }
        public TradeList TradeListData { get; set; }

        public Point Location() { return new Point(X, Y); }

        public City(Random rnd, Point p, Region region)
        {
            X = p.X;
            Y = p.Y;
            RegionData = region;
            int popSeed = rnd.Next(1000) + 1;
            Population = popSeed * popSeed * (rnd.Next(1000) + 1);
            Wealth = rnd.Next(100) + 1;
            Wealth = (Wealth + RegionData.Wealth) / 2;
            Culture = rnd.Next(100) + 1;
            Culture = (Culture + RegionData.Culture) / 2;

            TradeListData = new TradeList(rnd);
            for (int i = 0; i < TradeListData.TradeGoods.Count; i++)
            {
                var tg = TradeListData.TradeGoods[i];
                var rtg = RegionData.TradeListData.TradeGoods[i];
                float wealthModifier = (Wealth + 150) / 200.0f ;
                TradeListData.TradeGoods[i].Supply = (tg.Supply + rtg.Supply) / 2;
                TradeListData.TradeGoods[i].Demand = (tg.Demand + rtg.Demand) / 2;
                TradeListData.TradeGoods[i].BuyPrice = Convert.ToInt32(tg.CalculateBuyPrice() * wealthModifier);
                TradeListData.TradeGoods[i].SellPrice = tg.CalculateSellPrice(tg.BuyPrice);
            }
            Name = RandomCityName(rnd);            
        }

        public void RandomizeName(Random rnd) { Name = RandomCityName(rnd); }

        public string RandomCityName(Random rnd) { return Tools.GetRandomName(rnd, "CityNames"); }

        public override string ToString()
        {
            string s;
            s = "Name: " + Name + Environment.NewLine;
            s += "Region: " + RegionData.Name + Environment.NewLine;
            s += "Location: " + X.ToString() + ", " + Y.ToString() + Environment.NewLine;
            s += "Population: " + QualitativePopulation() + Environment.NewLine; 
            //s += "Population: " + Population.ToString() + Environment.NewLine;
            s += "Wealth: " + Wealth.ToString() + Environment.NewLine;
            s += "Culture: " + Culture.ToString() + Environment.NewLine;
            s += "Water Access: " + WaterAccess.ToString() + Environment.NewLine;
            s += "Water Distance: " + WaterDistance.ToString() + Environment.NewLine;
            s += "---Trade Goods--" + Environment.NewLine;
            foreach (TradeGood tg in TradeListData.TradeGoods) 
            {
                s += tg.Name + ":";
                if (tg.Supply >= 50) { s += " Buy: " + tg.BuyPrice.ToString(); }
                if (tg.Demand >= 1) { s += " Sell: " + tg.SellPrice.ToString(); }
                s += Environment.NewLine;
            }
            return s;
        }

        public string QualitativePopulation()
        {
            float estimate = Population;
            string result = "";
            if (Population > 1000000000) { estimate = Population / 1000000000f; result = "B"; }
            else if (Population > 1000000) { estimate = Population / 1000000f; result = "M"; }
            else if (Population > 1000) { estimate = Population / 1000f; result = "K"; }
            else { estimate = Population; }
            result = estimate.ToString("0.00") + result;
            return result;

        }

        public string GetDataToSave(string delimiter)
        {
            var buf = "";
            buf += Name + delimiter;
            buf += X.ToString() + delimiter;
            buf += Y.ToString() + delimiter;
            buf += Population.ToString() + delimiter;
            buf += Wealth.ToString() + delimiter;
            buf += Culture.ToString() + delimiter;
            buf += WaterAccess.ToString() + delimiter;
            buf += WaterDistance.ToString() + delimiter;
            buf += RegionData.DataValue.ToString() + delimiter;
            buf += Environment.NewLine + TradeListData.GetDataToSave(delimiter);
            return buf;
        }
    }
}
