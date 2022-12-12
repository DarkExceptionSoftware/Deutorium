using MinecraftSubstrateFrontend.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MinecraftSubstrateFrontend.Tile;

namespace MinecraftSubstrateFrontend
{
	public partial class Main : Form
	{
		public bool createCache = false;

		string WorldName = "";
		string WorldPath = "";

		worldserializer ws = new worldserializer();

		void savecache()
		{
			string cachedir = "cache\\" + Path.GetFileName(WorldPath);

			DialogResult dialogResult = MessageBox.Show("Pack \"" + Path.GetFileName(WorldPath) + "\" cache?", "Save cache", MessageBoxButtons.YesNoCancel);
			if (dialogResult == DialogResult.Yes)
			{
				pictureBox1.Visible = false;
				ws.tiles = this.tiles;
				ws.tiles_edited = this.tiles_edited;
				ws.serialize(cachedir, true);
				ws.Clear();

				pictureBox1.Visible = true;
				createCache = true;
			}
			else if (dialogResult == DialogResult.No)
			{
				pictureBox1.Visible = false;

				ws.tiles = this.tiles;
				ws.tiles_edited = this.tiles_edited;
				ws.serialize(cachedir, true);
				ws.Clear();

				pictureBox1.Visible = true;
				createCache = true;
			}


		}
	}
}
