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
		public Bitmap tampon_bitmap;
		public bool showtamponform = false;
		public bool selectid = false;
		public bool selectheight = false;
		public bool selectlheight = false;

		public void settampon(TamponMode mode, int id, int height, int waterheight)
		{
			bool stop = false, tilewaschanged = false;
			SortedList<int, tile> tiles_toset = new SortedList<int, tile>();
			tile newtile = new tile(); tile oldtile;

			int mposx = (int)View_posittion.X / 16;
			int mposy = (int)View_posittion.Y / 16;
			int correctx = 16 - (int)(View_posittion.X % 16);
			int correcty = 16 - (int)(View_posittion.Y % 16);
			if (correctx < 0) correctx -= 1;
			if (correcty < 0) correcty -= 1;

			for (int dist = 0; dist < (32 * zoom); dist++) // 0 - 31
			{
				for (int x = -dist - 1; x < dist + 1; x++) // -32 - 31
				{
					for (int y = -dist - 1; y < dist + 1; y++)
					{
						int x1 = 32 + x, y1 = 32 + y;

						if (x == -dist - 1 || x == dist || y == -dist - 1 || y == dist)
						{
							int tilex = mposx + x;
							int tiley = mposy + y;
							int key = getkey(tilex, tiley);

							if (tiles_edited.ContainsKey(key))
								newtile = tiles_edited[key];

							else if (tiles.ContainsKey(key))
							{
								newtile = (tile)tiles[key].Clone();
							}


							for (int u = 0; u < 16; u++)
							{
								for (int w = 0; w < 16; w++)
								{
									int oldheight = newtile.data[u, w];
									int oldid = newtile.id[u, w];


									int tx = tampon_bitmap.Width / 2 + (int)(((tilex * 16 + u) - View_posittion.X) * (1 / zoom));
									int ty = tampon_bitmap.Height / 2 + (int)(((tiley * 16 + w) - View_posittion.Y) * (1 / zoom));

									Color tc = Color.Transparent;
									if (tx > 0 && ty > 0 && tx < tampon_bitmap.Width && ty < tampon_bitmap.Height)
										tc = tampon_bitmap.GetPixel(tx, ty);
									float density = 1f / 255f * (float)tc.A;

									if (tc.A != 0)
									{
										if (mode == TamponMode.RELOAD)
										{
											if (tiles_edited.ContainsKey(key))
												tiles_edited.Remove(key);

											if (tiles.ContainsKey(key))
												tiles.Remove(key);

											stop = true;
										}



										if (!stop)
										{

											if (mode == TamponMode.RAISE)
												newtile.data[u, w] += (int)(height * density);

											if (mode == TamponMode.LOWER)
												newtile.data[u, w] -= (int)(height * density);

											if (mode == TamponMode.FLATTEN)
											{
												int Theight = newtile.data[u, w];
												newtile.data[u, w] = (int)(Theight * (1 - density)) + ((int)(height * density));

											}

											if (waterheight > 0 && newtile.data[u, w] < waterheight)
											{
												newtile.water[u, w] = waterheight;
											}
											else
											{
												newtile.water[u, w] = -1;
											}

											if (id != -1)
											{
												newtile.id[u, w] = id;

											}


										}
									}

									if (!stop)
									{
										if (newtile.data[u, w] > 255)
											newtile.data[u, w] = 255;

										if (newtile.data[u, w] < 2)
											newtile.data[u, w] = 2;
									}

									if (oldheight != newtile.data[u, w] || oldid != newtile.id[u, w])
										tilewaschanged = true;

									if (stop) break;
								}
								if (stop) break;

							}

							if (tilewaschanged)
							{
								if (!tiles_edited.ContainsKey(key))
									tiles_edited.Add(key, newtile);

								tilewaschanged = false;
							}

						}
					}
				}
			}
			resetbitmap();
		}
	}
}
