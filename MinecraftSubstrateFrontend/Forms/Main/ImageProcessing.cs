using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MinecraftSubstrateFrontend.helper.Heightbitmap;
using static MinecraftSubstrateFrontend.Tile;

namespace MinecraftSubstrateFrontend
{
	public partial class Main : Form
	{
		Bitmap bitmap_preview;
		Bitmap[] perf_indicator = new Bitmap[3];
		static Bitmap result_bitmap;
		static Graphics gr;

		bool imagechanged = false;
		byte[] bytecopy = new byte[bytedim];
		byte[] byteheight = new byte[1024 * 1024 * 4];
		byte[] bytepreview = new byte[16 * 16 * 4];

		float zoom = 1f;

		public int tile_limit = -1;

		private enum pbsizemode { STRETCHED, FITWINDOW, FITHEIGHT, EXTERNAL }
		pbsizemode pbsize = pbsizemode.STRETCHED;

		public bool draw_asset(int xa, int ya, int[,] asset, bool invert)
		{
			bool isdrawn = false;
			if (xa > 0 && ya > 0 && xa < 1008 && ya < 1008)
			{
				for (int x = 0; x < 16; x++)
				{

					for (int y = 0; y < 16; y++)
					{

						if (!invert)
							height[x + xa, y + ya] = asset[x, y];
						else
							height[x + xa, y + ya] = 255 - asset[x, y];

						int bh = (y + ya) * 4096 + (x + xa) * 4;
						byte[] returnbyte = ifh.hvbyte(asset[x, y] * 4, Style.colored);

						// byteheight[bh] = 255;

						byteheight[bh] = returnbyte[0];
						byteheight[bh + 1] = returnbyte[1];
						byteheight[bh + 2] = returnbyte[2];
						byteheight[bh + 3] = 255;

					}

				}
				isdrawn = true;
			}
			return isdrawn;
		}

		public bool draw_tile_asset(int xb, int yb, int xa, int ya, int limit = -1, bool preview = false)
		{
			int median = 255;
			chunk = null;
			tile Tile = new tile();
			int calls = 0;
			bool exact = false;

			if (loop_finished)
				exact = true;

			// tile Tile = tiles.Find(c => (c.x == xb) && (c.y == yb));
			int key = getkey(xb, yb);
			int chunkey = ((xb + 1000) + (yb + 1000) * 2000);

			if (tiles.ContainsKey(key) && loop_finished && !view_dragging)
			{
				if (tiles[key].exact == false) tiles.Remove(key);
			}

			if (!tiles.ContainsKey(key)) // no cached tile
			{
				Tile.x = xb;
				Tile.y = yb;

				if (loop_finished) Tile.exact = true;
				else Tile.exact = false;


				Tile.id = new int[16, 16];
				Tile.data = new int[16, 16];
				Tile.water = new int[16, 16];

				if (chunks.ContainsKey(chunkey)) // tile is in world data
				{
					chunk = chunks[chunkey];

					if (chunk != null && chunk.Blocks != null) // tile is good
					{
						int ydim = chunk.Blocks.YDim;
						if (limit != -1 && limit < ydim - 1) ydim = limit;
						if (ydim - 1 < median) median = ydim - 1;
						int newmedian = median;
						int highestmedian = -1;
						for (int x = 0; x < 16; x++)
						{
							for (int y = 0; y < 16; y++)
							{
								int water = -1;
								if (!Tile.exact)
								{
									if (highestmedian != -1) newmedian = highestmedian + 4;
									if (newmedian > ydim - 1) newmedian = ydim - 1;
									for (int yh = newmedian; yh > -1; yh--)
									{

										calls++;
										int id = chunk.Blocks.GetID(x, yh, y);
										if ((id == 8 || id == 9) && water == -1) water = yh;
										Tile.water[x, y] = water;
										if (id != 0 && id != 8 && id != 9)
										{
											if (yh == newmedian)
											{
												yh += 4;
												newmedian += 4;

												if (yh > ydim - 1) yh = ydim - 1;
												if (newmedian > ydim - 1) newmedian = ydim - 1;
											}

											Tile.data[x, y] = yh;
											Tile.id[x, y] = id;

											if (highestmedian < yh) highestmedian = yh;



											break;
										}
									}

								}
								else
								{


									for (int yh = ydim - 1; yh > -1; yh--)
									{
										calls++;
										int id = chunk.Blocks.GetID(x, yh, y);

										if ((id == 8 || id == 9) && water == -1)
										{
											water = yh;

										}
										Tile.water[x, y] = water;

										if (id != 0 && id != 8 && id != 9)
										{
											Tile.data[x, y] = yh;
											Tile.id[x, y] = id;

											break;
										}
									}
									Tile.exact = true;
								}
							}
						}

						tiles[key] = Tile;
						//label_position.Text = "" + calls;
					}
					else // tile is bad
					{
						// if (!toggle_matrix.Checked)
						draw_asset(xa, ya, asset_none, false);
					}
				}
				else // tile NOT in world data
				{
					//if (!toggle_matrix.Checked)
					draw_asset(xa, ya, asset_none, true);
				}
			}

			if (tiles.ContainsKey(key))
			{
				// cached tile
				Tile = tiles[key];

				if (tiles_edited.ContainsKey(key))
					Tile = tiles_edited[key];


				for (int x = 0; x < 16; x++)
				{
					for (int y = 0; y < 16; y++)
					{
						if (xa > -1 && ya > -1 && xa < 1009 && ya < 1009)
						{
							height[x + xa, y + ya] = Tile.data[x, y];

							int bh;
							if (preview) bh = y * 64 + x * 4;
							else bh = (y + ya) * 4096 + (x + xa) * 4;

							Style _style = Style.gray;

							if (Tile.exact)
								_style = Style.colored;

							if (Tile.water[x, y] != -1 && showcolor)
								_style = Style.water;

							byte[] returnbyte;
							if (showid)
							{
								if (_style == Style.water)
									returnbyte = ifh.hvbyte(Tile.data[x, y] * 4, _style);
								else
									returnbyte = ifh.idbyte(Tile.id[x, y]);
							}
							else
								returnbyte = ifh.hvbyte(Tile.data[x, y] * 4, _style);

							// byteheight[bh] = 255;
							if (preview)
							{
								bytepreview[bh] = returnbyte[0];
								bytepreview[bh + 1] = returnbyte[1];
								bytepreview[bh + 2] = returnbyte[2];
								bytepreview[bh + 3] = 255;
							}
							else
							{
								byteheight[bh] = returnbyte[0];
								byteheight[bh + 1] = returnbyte[1];
								byteheight[bh + 2] = returnbyte[2];
								byteheight[bh + 3] = 255;
							}

						}
					}
				}
			}
			if (exact) return true;
			else return false;
		}
		private void resetbitmap(bool noblack = false)
		{
			Array.Clear(height_matrix, 0, height_matrix.Length);

			if (!noblack)
				gr.Clear(Color.Black);
			imagechanged = true;
			update_image(true);
			loop_finished = false;
		}

		public Bitmap SetImageColor(Bitmap image, Color color)
		{
			for (int x = 0; x < image.Width; x++)
			{
				for (int y = 0; y < image.Width; y++)
				{
					Color value = image.GetPixel(x, y);
					if (value.A > 0)
						image.SetPixel(x, y, color);
				}
			}

			return image;
		}

		public Bitmap SetImageOpacity(Bitmap image, float opacity)
		{
			try
			{
				//create a Bitmap the size of the image provided  
				Bitmap bmp = new Bitmap(image.Width, image.Height);

				//create a graphics object from the image  
				using (Graphics gfx = Graphics.FromImage(bmp))
				{

					//create a color matrix object  
					ColorMatrix matrix = new ColorMatrix();

					//set the opacity  
					matrix.Matrix33 = opacity;

					//create image attributes  
					ImageAttributes attributes = new ImageAttributes();

					//set the color(opacity) of the image  
					attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

					//now draw the image  
					gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
				}
				return bmp;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
		}

		private void update_image(bool nopending = false)
		{
			watch.Start();
			if (imagechanged)
			{


				int diffx = (int)(View_posittion.X - old_View_posittion.X);
				int diffy = (int)(View_posittion.Y - old_View_posittion.Y);
				int xd = 0, xs = 0, yd = 0, ys = 0;
				float zoomstate = 1f;
				if (diffx > 0)
				{
					xd = (int)(diffx * zoomstate);
				}
				else if (diffx < 0)
				{
					xs = Math.Abs((int)(diffx * zoomstate));
				}

				if (diffy > 0)
				{
					yd = (int)(diffy * zoomstate);
				}
				else if (diffy < 0)
				{
					ys = Math.Abs((int)(diffy * zoomstate));
				}


				byte[] bytecopy = new byte[bytedim];

				Array.Copy(byteheight, xd * 4 + yd * 4 * 1024, bytecopy, xs * 4 + ys * 4 * 1024, bytedim - xs * 4 - xd * 4 - yd * 4 * 1024 - ys * 4 * 1024);
				byteheight = bytecopy;
			}

			if (!nopending)
				handle_pending();


			if (imagechanged)
			{


				Bitmap bitmap = ifh.ImageFromBytes(byteheight);

				Rectangle destRegion = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				Rectangle srcRegion = new Rectangle(512 - (int)(512 * zoom), 512 - (int)(512 * zoom), (int)(1024 * zoom), (int)(1024 * zoom));
				gr.DrawImage(bitmap, destRegion, srcRegion, GraphicsUnit.Pixel);
				gr.Flush();
				drawfont(result_bitmap);
				drawgui(result_bitmap);

				if (!showexternalviewform)
				{
					pictureBox1.Image = result_bitmap;
					// else pictureBox1.Invalidate();

				}
				else
				{
					if (formexternalview != null)
						formexternalview.Update(result_bitmap);

				}

				loaded = true;
			}
			watch.Stop();

			if (watch.ElapsedMilliseconds < 1000 && showPerformanceForm)
				formPerformance.update(pfc.GRAPHIC, (int)watch.ElapsedMilliseconds);

			//perf_gfx.Value = (int)watch.ElapsedMilliseconds;
			watch.Reset();
			once = false;

		}

		private void update_preview(int x, int y, int key)
		{
			int height = 0, id = 0, waterlevel = 0;

			if (tiles_edited.ContainsKey(key))
			{
				height = tiles_edited[key].data[MouseLocalTilePos.X, MouseLocalTilePos.Y];
				id = tiles_edited[key].id[MouseLocalTilePos.X, MouseLocalTilePos.Y];
				waterlevel = tiles_edited[key].water[MouseLocalTilePos.X, MouseLocalTilePos.Y];

			}
			else
			{
				 height = tiles[key].data[MouseLocalTilePos.X, MouseLocalTilePos.Y];
				 id = tiles[key].id[MouseLocalTilePos.X, MouseLocalTilePos.Y];
				waterlevel = tiles[key].water[MouseLocalTilePos.X, MouseLocalTilePos.Y];

			}




			Color bcolor = ifh.id_palette[id];
			draw_tile_asset(x, y, 0, 0, tile_limit, true);
			bitmap_preview = ifh.previewImageFromBytes(bytepreview);

			if (showtTileInfoForm)
			{
				Bitmap b = new Bitmap(128, 128);
				using (Graphics g = Graphics.FromImage(b))
				{
					g.InterpolationMode = InterpolationMode.NearestNeighbor;
					g.PixelOffsetMode = PixelOffsetMode.Half;
					g.Clear(bcolor);
					g.DrawImage(bitmap_preview, new Rectangle(6, 6, 114, 114));
				}

				formTileInfo.Update(b);
				formTileInfo.Update(TileInfoForm.INFO.HEIGHT, height);
				formTileInfo.Update(TileInfoForm.INFO.ID, id);
				formTileInfo.Update(TileInfoForm.INFO.WATERLEVEL, waterlevel);
			}
		}
	}
}
