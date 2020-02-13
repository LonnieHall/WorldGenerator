using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace World
{
    class World
    {
        public int[,] WorldData;
        Random rnd = new Random();
        List<Color> colors = new List<Color>();
        List<SolidBrush> brushes = new List<SolidBrush>();
        public List<City> cityList = new List<City>();
        public List<Region> regionList = new List<Region>();
        public List<string> availableCityNames = new List<string>();
        public List<string> availableRegionNames = new List<string>();
        Color clearColor = Color.Blue;
        Color cityColor = Color.White;
        SolidBrush clearBrush;
        SolidBrush cityBrush;

        public int Columns { get; set; }
        public int Rows { get; set; }
        public int ColorCount { get; set; }
        public int CityCount { get; set; }
        public int MinCityDistance { get; set; }
        public int BrushSize { get; set; }
        public int Zoom { get; set; }
        public bool HighContrast { get; set; }
        public bool ShowASCII { get; set; }

        public World()
        {
            availableCityNames = Tools.GetNamesFromXMLData("CityNames");
            availableRegionNames = Tools.GetNamesFromXMLData("RegionNames");
        }

        private void ClearWorldData()
        {
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                { WorldData[i, j] = 0; }
            }
        }

        private void CreatePallette()
        {
            colors.Clear();
            brushes.Clear();
            clearBrush = new SolidBrush(clearColor);
            cityBrush = new SolidBrush(cityColor);
            if (HighContrast)
            {
                colors.Add(Color.Black);
                colors.Add(Color.Blue);
                colors.Add(Color.Yellow);
                colors.Add(Color.Red);
                colors.Add(Color.White);
                colors.Add(Color.Orange);
                colors.Add(Color.Pink);

            }
            for (int i = 0; i < ColorCount; i++)
            {
                int r = rnd.Next(256);
                int g = rnd.Next(256);
                int b = rnd.Next(256);
                colors.Add(Color.FromArgb(r, g, b));
                if (colors.Contains(clearColor))
                {
                    colors.Remove(clearColor);
                    i--; continue;
                }
                if (colors.Contains(cityColor))
                {
                    colors.Remove(cityColor);
                    i--; continue;
                }
                brushes.Add(new SolidBrush(colors[i]));
            }
        }

        public void Generate()
        {
            WorldData = new int[Columns, Rows];
            CreatePallette();
            ClearWorldData();
            CreateRegions();

            for (int i = 0; i < Rows; i++)
            { SetRandomArea(rnd.Next(ColorCount) + 1); }

            for (int i = 0; i < Rows / 5; i++)
            { SetRandomArea(0); }

            CreateCities();
        }

        public Point RandomPoint(int magnify = 1)
        {
            var x = rnd.Next(Columns) * magnify;
            var y = rnd.Next(Rows) * magnify;
            var p = new Point(x, y);
            return p;
        }

        private List<Point> RandomArea()
        {
            var p = RandomPoint();
            List<Point> pList = new List<Point>();
            int result = rnd.Next(10);            
            switch(result)
            {
                //case 0: pList = SquareArea(p, pList); break;
                case 1: pList = DiamondArea(p, pList); break;                
                default: pList = CircleArea(p, pList); break;
            }
            return pList;
        }

        private List<Point> SquareArea(Point p, List<Point> pList)
        {
            for (int i = p.Y - BrushSize; i <= p.Y + BrushSize && i < Rows && i > 0; i++)
            {
                for (int j = p.X - BrushSize; j <= p.X + BrushSize && j < Columns && j > 0; j++)
                { pList.Add(new Point(j, i)); }
            }
            return pList;
        }

        private List<Point> DiamondArea(Point p, List<Point> pList)
        {
            for (int i = p.Y - BrushSize; i <= p.Y + BrushSize && i < Rows && i > 0; i++)
            {
                for (int j = p.X - BrushSize; j <= p.X + BrushSize && j < Columns && j > 0; j++)
                {
                    if (Math.Abs(i - p.Y) + Math.Abs(j - p.X) <= BrushSize)
                    { pList.Add(new Point(j, i)); }
                }
            }
            return pList;
        }

        private List<Point> CircleArea(Point p, List<Point> pList)
        {
            for (int i = BrushSize * -1; i <= BrushSize; i++)
            {
                for (int j = BrushSize * -1; j <= BrushSize; j++)
                {
                    var x = j + p.X;
                    var y = i + p.Y;
                    if (x < 0 || y < 0) { continue; } //Skip if the point is off the side to the left or top
                    if (x > Columns - 1 || y > Rows - 1) { continue; } //Skip if the point is off the side to the right or bottom
                  
                    var ls = j * j;
                    var rs = i * i;
                    var bss = BrushSize * BrushSize;

                    if (ls + rs <= bss) { pList.Add(new Point(x, y)); }                                        
                }
            }


            return pList;
        }

        private void SetRandomArea(int value = 1)
        {
            foreach (var p in RandomArea())
            { UpdateWorldDataPoint(p, value); }
        }

        private void UpdateWorldDataPoint(Point p, int value = 1)
        { WorldData[p.X, p.Y] = value; }

        public void ShowWorld(System.Windows.Forms.PictureBox pbWorld, System.Windows.Forms.TextBox txtWorld)
        {
            if (ShowASCII) { ShowWorldAsText(txtWorld); }
            ShowWorldAsImage(pbWorld);
        }

        private void ShowWorldAsText(System.Windows.Forms.TextBox txtWorld)
        {
            txtWorld.Clear();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    int data = WorldData[j, i];
                    if (data == 0) { txtWorld.AppendText(" "); }
                    else { txtWorld.AppendText(data.ToString()); }

                }
                txtWorld.AppendText(Environment.NewLine);
            }
        }

        private void ShowWorldAsImage(System.Windows.Forms.PictureBox pbWorld)
        {
            int width = Columns * Zoom;
            int height = Rows * Zoom;
            using (var bmp = new Bitmap(width, height))
            {
                using (var g = Graphics.FromImage(bmp))
                {
                    pbWorld.Size = new Size(width, height);
                    Rectangle rect = new Rectangle(new Point(0,0), pbWorld.Size);
                    g.FillRectangle(clearBrush, rect);
                    
                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Columns; j++)
                        {
                            int data = WorldData[j, i];
                            if (data == 0) { }
                            else
                            {
                                rect = new Rectangle(new Point(j * Zoom, i * Zoom), new Size(Zoom, Zoom));
                                g.FillRectangle(brushes[data - 1], rect);
                            }
                        }
                    }

                    foreach (City c in cityList)
                    {
                        rect = new Rectangle(new Point(c.X * Zoom, c.Y * Zoom), new Size(Zoom, Zoom));
                        g.FillRectangle(cityBrush, rect);

                        //rect = new Rectangle(new Point(c.Y * Zoom, c.X * Zoom), new Size(Zoom, Zoom));
                        //g.FillRectangle(cityBrush, rect);
                    }

                    pbWorld.Image = bmp;
                    pbWorld.Update();
                }
            }
        }

        private void CreateCities() { for (int i = 0; i < CityCount; i++) { CreateCity(); } }

        private void CreateCity()
        {
            Point p;
            p = RandomPoint();
            while (!IsOnLand(p) || !FarFromCities(p))
            { p = RandomPoint(); }

            Region r = regionList[WorldData[p.X, p.Y] - 1];
            City c = new City(rnd, p, r);

            while (UsedCityName(c.Name))
            { c.Name = c.RandomCityName(rnd); }

            c.WaterAccess = CalculateWaterAccess(p);
            c.WaterDistance = CalculateWaterDistance(p);
            EvaluateFishingGoods(c);
            cityList.Add(c);
        }

        private void EvaluateFishingGoods(City c)
        {
            for (int i = 0; i < c.TradeListData.TradeGoods.Count; i++)
            {
                var tg = c.TradeListData.TradeGoods[i];
                if (tg.Name == "Fish")
                {
                    int result = 0;
                    if (c.WaterAccess == 0) { result = tg.Supply / 2; }
                    else if (c.WaterAccess >= 10) { result = tg.Supply / 5 + 80; }
                    else { result = tg.Supply / 2 + 50; }
                    c.TradeListData.TradeGoods[i].Supply = result;
                    c.TradeListData.TradeGoods[i].BuyPrice = tg.CalculateBuyPrice();
                    c.TradeListData.TradeGoods[i].SellPrice = tg.CalculateSellPrice(tg.BuyPrice);
                }
            }            
        }

        private int CalculateWaterAccess(Point p, int range = 3, bool atariFactor = false)
        {
            int waterCount = 0;            
            for (int y = -1 * range; y < range; y++ ) 
            {
                for (int x = -1 * range; x < range; x++ ) 
                {
                    var worldX = p.X + x;
                    var worldY = p.Y + y;
                    if (worldX < 0 && atariFactor) { worldX = Columns + worldX - 1; }                    
                    if (worldY < 0 && atariFactor) { worldY = Rows + worldY - 1; }
                    if (worldX >= Columns && atariFactor) { worldX = worldX - Columns; }
                    if (worldY >= Columns && atariFactor) { worldY = worldY - Rows; }
                    if (worldX < 0 || worldY < 0 || worldX >= Columns || worldY >= Rows) { continue; }
                    if (WorldData[worldX, worldY] == 0) { waterCount++; }                    
                }
            }
            return waterCount;
        }

        private int CalculateWaterDistance(Point p, bool atariFactor = false)
        {
            int distance = 1;
            while (distance < Rows || distance < Columns) 
            {
                for (int y = -1 * distance; y < distance; y++)
                {
                    for (int x = -1 * distance; x < distance; x++)
                    {
                        var worldX = p.X + x;
                        var worldY = p.Y + y;
                        if (worldX < 0 && atariFactor) { worldX = Columns + worldX - 1; }
                        if (worldY < 0 && atariFactor) { worldY = Rows + worldY - 1; }
                        if (worldX >= Columns && atariFactor) { worldX = worldX - Columns; }
                        if (worldY >= Columns && atariFactor) { worldY = worldY - Rows; }
                        if (worldX < 0 || worldY < 0 || worldX >= Columns || worldY >= Rows) { continue; }
                        if (WorldData[worldX, worldY] == 0) { return distance; }
                    }
                }
                distance++;
            }
            return -1;
        }

        public string WorldTradeReport()
        {
            string rpt = Environment.NewLine + "--World Trade Report--" + Environment.NewLine;

            for (int i = 0; i < cityList[0].TradeListData.TradeGoods.Count; i++)
            {
                var tg = cityList[0].TradeListData.TradeGoods[i];
                string buyCity = cityList[0].Name;
                string sellCity = cityList[0].Name;
                int buyLowest = tg.BuyPrice;
                int sellHighest = tg.SellPrice;
                
                foreach (City c in cityList)
                {
                    var ctg = c.TradeListData.TradeGoods[i];
                    if (ctg.BuyPrice < buyLowest) { buyLowest = ctg.BuyPrice; buyCity = c.Name; }
                    if (ctg.SellPrice > sellHighest) { sellHighest = ctg.SellPrice; sellCity = c.Name; }
                }
                rpt += tg.Name + " is best bought in " + buyCity + " for " + buyLowest.ToString() + " and sold in " + sellCity + " for " + sellHighest.ToString() + Environment.NewLine;
            }            
            return rpt;
        }

        private bool UsedCityName(string name)
        {
            foreach (City c in cityList)
            { if (c.Name == name) { return true; } }
            return false;
        }

        private void CreateRegions() { for (int i = 0; i < ColorCount; i++) { CreateRegion(i+1); } }

        private void CreateRegion(int dataValue) 
        {
            Region r = new Region(rnd, dataValue, RandomRegionName(rnd));
            regionList.Add(r);
            //string newTerritoryName = RandomRegionName(rnd);
            //while (regionList.Contains(newTerritoryName))
            //{ newTerritoryName = RandomRegionName(rnd); }
            //regionList.Add(RandomRegionName(rnd)); 
        }

        private bool IsOnLand(Point p)
        {
            if (WorldData[p.X, p.Y] == 0) { return false; }            
            return true;
        }

        private bool FarFromCities(Point p)
        { 
            foreach (City c in cityList)
            {
                if (Math.Abs(c.X - p.X) <= MinCityDistance && 
                    Math.Abs(c.Y - p.Y) <= MinCityDistance) 
                { return false; }
            }
            return true;
        }

        public string RandomRegionName(Random rnd) 
        {
            if (availableRegionNames.Count < 1) 
            { availableRegionNames = Tools.GetNamesFromXMLData("RegionNames"); }
            int index = rnd.Next(availableRegionNames.Count);
            string result = availableRegionNames[index];
            availableRegionNames.RemoveAt(index);
            return result;            
        }

        public void SaveTheWorld(string fileName, string delimiter = ", ")
        {            
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                var buf = "";
                buf += Rows.ToString() + delimiter;
                buf += Columns.ToString() + delimiter;
                buf += ColorCount.ToString() + delimiter;
                buf += CityCount.ToString() + delimiter;
                buf += BrushSize.ToString() + delimiter;
                buf += Zoom.ToString() + delimiter;
                buf += cityList[0].TradeListData.TradeGoods.Count.ToString() + delimiter;
                sw.WriteLine(buf); buf = "";

                for (int y = 0; y < Rows; y++)
                {
                    for (int x = 0; x < Columns; x++)
                    { buf += WorldData[x, y].ToString() + delimiter; }
                    sw.WriteLine(buf); buf = "";
                }

                sw.WriteLine(GetColorDataToSave(delimiter));

                foreach (Region r in regionList) { sw.WriteLine(r.GetDataToSave(delimiter)); }
                foreach (City c in cityList) { sw.WriteLine(c.GetDataToSave(delimiter)); }

                sw.Flush();
            }

        }

        public void LoadTheWorld(string fileName, string delimiter = ", ")
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                var buf = sr.ReadLine();

                Rows = Tools.NextIntFromSaveData(ref buf, delimiter);
                Columns = Tools.NextIntFromSaveData(ref buf, delimiter);
                ColorCount = Tools.NextIntFromSaveData(ref buf, delimiter);
                CityCount = Tools.NextIntFromSaveData(ref buf, delimiter);
                BrushSize = Tools.NextIntFromSaveData(ref buf, delimiter);
                Zoom = Tools.NextIntFromSaveData(ref buf, delimiter);
                var tradeGoodCount = Tools.NextIntFromSaveData(ref buf, delimiter);

                WorldData = new int[Columns, Rows];

                for (int y = 0; y < Rows; y++)
                {
                    buf = sr.ReadLine();
                    for (int x = 0; x < Columns; x++)
                    { WorldData[x, y] = Tools.NextIntFromSaveData(ref buf, delimiter); }                    
                }

                colors.Clear();
                brushes.Clear();
                buf = sr.ReadLine();                               
                clearColor = Color.FromArgb(Tools.NextIntFromSaveData(ref buf, delimiter));
                cityColor = Color.FromArgb(Tools.NextIntFromSaveData(ref buf, delimiter));
                clearBrush = new SolidBrush(clearColor);
                cityBrush = new SolidBrush(cityColor);
                                                
                for (int i = 0; i < ColorCount; i++)
                {
                    Color c = Color.FromArgb(Tools.NextIntFromSaveData(ref buf, delimiter));
                    colors.Add(c);
                    brushes.Add(new SolidBrush(c));
                }

                cityList.Clear();
                regionList.Clear();
                
                for (int i = 0; i < ColorCount; i++) 
                {
                    buf = sr.ReadLine(); while (buf == "") { buf = sr.ReadLine(); }
                    var name = Tools.NextStringFromSaveData(ref buf, delimiter);
                    var wealth = Tools.NextIntFromSaveData(ref buf, delimiter);
                    var culture = Tools.NextIntFromSaveData(ref buf, delimiter);
                    var dataValue = Tools.NextIntFromSaveData(ref buf, delimiter);
                    Region r = new Region(rnd, dataValue, name);
                    r.Wealth = wealth;
                    r.Culture = culture;

                    buf = "";
                    r.TradeListData.TradeGoods.Clear();
                    for (int j = 0; j < tradeGoodCount; j++) { buf += sr.ReadLine(); }
                    r.TradeListData.LoadDataFromSave(buf, delimiter);

                    regionList.Add(r);
                }

                for (int i = 0; i < CityCount; i++)
                {
                    buf = sr.ReadLine(); while (buf == "") { buf = sr.ReadLine(); }
                    var name = Tools.NextStringFromSaveData(ref buf, delimiter);
                    var cx = Tools.NextIntFromSaveData(ref buf, delimiter);
                    var cy = Tools.NextIntFromSaveData(ref buf, delimiter);
                    var population = Tools.NextIntFromSaveData(ref buf, delimiter);
                    var wealth = Tools.NextIntFromSaveData(ref buf, delimiter);
                    var culture = Tools.NextIntFromSaveData(ref buf, delimiter);
                    var waterAccess = Tools.NextIntFromSaveData(ref buf, delimiter);
                    var waterDistance = Tools.NextIntFromSaveData(ref buf, delimiter);
                    var regionDataValue = Tools.NextIntFromSaveData(ref buf, delimiter);
                    City c = new City(rnd, new Point(cx, cy), regionList[regionDataValue - 1]);
                    c.Population = population;
                    c.Wealth = wealth;
                    c.Culture = culture;
                    c.WaterAccess = waterAccess;
                    c.WaterDistance = waterDistance;                    

                    buf = "";
                    c.TradeListData.TradeGoods.Clear();
                    for (int j = 0; j < 5; j++) { buf += sr.ReadLine(); }
                    c.TradeListData.LoadDataFromSave(buf, delimiter);

                    cityList.Add(c);
                }
            }
        }

        public string GetColorDataToSave(string delimiter)
        {
            var buf = "";
            buf += clearColor.ToArgb().ToString() + delimiter;
            buf += cityColor.ToArgb().ToString() + delimiter;
            foreach (Color c in colors) { buf += c.ToArgb().ToString() + delimiter; }
            return buf;            
        }
    }
}
