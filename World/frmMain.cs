using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace World
{
    public partial class frmMain : Form
    {
        World world;

        public frmMain() { InitializeComponent(); hideASCIIWorld(); }

        private void btnCreate_Click(object sender, EventArgs e) { CreateWorld(); }

        private void chkASCIIWorld_CheckedChanged(object sender, EventArgs e) { hideASCIIWorld(); }

        private void hideASCIIWorld()
        {
            if (chkASCIIWorld.Checked) { txtWorld.Visible = true; this.Height = 688; }
            else { txtWorld.Visible = false; this.Height = 688 - txtWorld.Height; }
        }

        private void pbWorld_MouseHover(object sender, EventArgs e)
        {            
         
        }

        private void pbWorld_MouseMove(object sender, MouseEventArgs e) { CursorMovedTo(e.Location.X, e.Location.Y); }

        private void CursorMovedTo(int x, int y)
        {
            if (world == null) { return; }
            x /= (int)nudZoom.Value;
            y /= (int)nudZoom.Value;
            int cushion = 0;
            foreach (City c in world.cityList)
            {
                if (c.X - cushion <= x &&
                    c.X + cushion >= x &&
                    c.Y - cushion <= y &&
                    c.Y + cushion >= y)
                {
                    txtCity.Clear();
                    txtCity.AppendText(c.ToString());
                    txtCity.AppendText(world.WorldTradeReport());                    
                    txtCity.SelectionStart = 0; txtCity.ScrollToCaret();                    
                }                
            }            
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfdMain.Filter = "World Files|*.world|All Files|*.*";
            sfdMain.ShowDialog();
        }

        private void sfdMain_FileOk(object sender, CancelEventArgs e) { world.SaveTheWorld(sfdMain.FileName); }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofdMain.Filter = "World Files|*.world|All Files|*.*";
            ofdMain.ShowDialog();
        }

        private void ofdMain_FileOk(object sender, CancelEventArgs e) { LoadWorld(); }

        private void CreateWorld()
        {
            world = new World();
            world.Rows = (int)nudRows.Value;
            world.Columns = (int)nudColumns.Value;
            world.BrushSize = (int)nudBrush.Value;
            world.ColorCount = (int)nudColors.Value;
            world.Zoom = (int)nudZoom.Value;
            world.HighContrast = chkHighContrast.Checked;
            world.ShowASCII = chkASCIIWorld.Checked;
            world.CityCount = (int)nudCities.Value;
            world.MinCityDistance = 2;
            world.Generate();
            world.ShowWorld(pbWorld, txtWorld);
        }

        private void LoadWorld()
        {
            world = new World();
            world.LoadTheWorld(ofdMain.FileName);
            nudRows.Value = world.Rows;
            nudColumns.Value = world.Columns;
            nudColors.Value = world.ColorCount;
            nudCities.Value = world.CityCount;
            nudBrush.Value = world.BrushSize;
            nudZoom.Value = world.Zoom;
            world.ShowWorld(pbWorld, txtWorld);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) { CreateWorld(); }
    }
}