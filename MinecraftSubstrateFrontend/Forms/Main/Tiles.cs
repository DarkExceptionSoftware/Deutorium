using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MinecraftSubstrateFrontend.Tile;

namespace MinecraftSubstrateFrontend
{
	public partial class Main : Form
	{
		SortedList<int, tile> tiles = new SortedList<int, tile>();
		SortedList<int, tile> tiles_edited = new SortedList<int, tile>();

		public int getkey(int x, int y)
		{
			int limit = 255;
			if (tile_limit != -1)
				limit = tile_limit;

			int key = (((x + 1000) + ((y + 1000) * 2000)) * limit);

			return key;
		}

		public void create_sample_tile(int tilex, int tiley)
		{
			tile Tile = new tile();
			Tile.water = new int[16, 16];
			Tile.id = new int[16, 16];

			for (int x = 0; x < 16; x++)
				for (int y = 0; y < 16; y++)
				{
					Tile.water[x, y] = -1;
					Tile.id[x, y] = 1;

				}

			Tile.x = tilex; Tile.y = tiley; Tile.data = asset_none; Tile.exact = false;
			//int key = (Tile.x + 1000) + (Tile.y + 1000) * 2000;
			int key = getkey(Tile.x, Tile.y);

			if (tiles.ContainsKey(key))
				tiles.Remove(key);

			tiles[key] = Tile;
		}

		private void handle_pending()
		{
			bool stop = false;
			int mposx = (int)View_posittion.X / 16;
			int mposy = (int)View_posittion.Y / 16;
			int correctx = 16 - (int)(View_posittion.X % 16);
			int correcty = 16 - (int)(View_posittion.Y % 16);
			if (correctx < 0) correctx -= 1;
			if (correcty < 0) correcty -= 1;

			bool success;


			Point mp = MouseTilePos;

			for (int dist = 0; dist < (32); dist++) // 0 - 31
			{
				for (int x = -dist - 1; x < dist + 1; x++) // -32 - 31
				{
					for (int y = -dist - 1; y < dist + 1; y++)
					{
						int x1 = 32 + x, y1 = 32 + y;

						if (x == -dist - 1 || x == dist || y == -dist - 1 || y == dist)
						{

							if (height_matrix[x1, y1] == 0 || height_matrix[x1, y1] == 1 && loop_finished)
							{
								success = draw_tile_asset(mposx + x, mposy + y, correctx + 16 * (x1 - 1), correcty + 16 * (y1 - 1), tile_limit);

								if (success) height_matrix[x1, y1] = 2;
								else height_matrix[x1, y1] = 1;

								tcount++;

								if (!precaching)
								{
									int worktime = 25;
									timer1.Interval = 50;

									bool test = false;
									if (!s.IsRunning)
										test = true; // somethings wrong

									if (s.ElapsedMilliseconds > worktime)
									{
										stop = true;
										 imagechanged = true;
										if (showPerformanceForm)
											formPerformance.update(pfc.BLOCKS, tcount);

										tcount = 0;
									}

								}
								else
								{

									if (tcount > 50)
									{
										stop = true;
										imagechanged = true;
									}
								}
							}
						}
						if (stop) break;
					}
					if (stop) break;
				}
				if (stop) break;
			}

			if (loop_finished && !stop)
				all_finished = true;

			if (!precaching && !stop) loop_finished = true;
		}

	}
}
