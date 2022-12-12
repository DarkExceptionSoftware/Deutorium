using Substrate;
using Substrate.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Numerics;
using System.Windows.Forms;
using static MinecraftSubstrateFrontend.Tile;

namespace MinecraftSubstrateFrontend
{
	public partial class Main : Form
	{
		private bool showcolor = false;
		private bool showexternalviewform = false;
		private bool showid = false;
		private bool showmatrix = false;
		private bool showPerformanceForm = false;
		private bool showPosition = false;
		private bool showtTileInfoForm = false;
		private externviewForm formexternalview;
		private PerformanceForm formPerformance;
		private PositionForm formPosition;
		private ProgressForm formProgress = new ProgressForm();
		private TamponForm formtampon;
		private TileInfoForm formTileInfo;

		private void ts_build_Click(object sender, EventArgs e)
		{
			if (showtTileInfoForm)
				formTileInfo.Close();

			if (showPerformanceForm)
				formPerformance.Close();

			if (showtamponform)
				formtampon.Close();

			if (showexternalviewform)
				if (formexternalview != null)
					formexternalview.Hide();

			showtTileInfoForm = false;
			showPerformanceForm = false;
			showtamponform = false;

			OpenWorldForm formOpenworld = new OpenWorldForm(this);
			DialogResult result = formOpenworld.ShowDialog();
			formOpenworld.Size = new Size(646, 359);
			if (backgroundWorker1.IsBusy)
				backgroundWorker1.CancelAsync();

			if (result == DialogResult.OK)
			{
				formProgress = new ProgressForm();
				formProgress.update(progressUpdate.INTENTION, (int)progressbarIntention.SAVING);
				formProgress.update(progressUpdate.END, tiles_edited.Count);
				formProgress.Show();


				string folderPath = formOpenworld.SelectedPath;

				AnvilWorld world = AnvilWorld.Open(folderPath);
				BlockManager bm = world.GetBlockManager();

				int progress = 0;
				foreach (KeyValuePair<int, tile> v in tiles_edited)
				{
					formProgress.update(progressUpdate.PROGRESS, progress++);

					tile t_build = v.Value;
					tile t_base = tiles[v.Key];

					for (int x = 0; x < 16; x++)
					{
						for (int y = 0; y < 16; y++)
						{
							int t_build_value = t_build.data[x, y];
							int t_base_value = t_base.data[x, y];
							int t_water_value = t_build.water[x, y];


							if (t_build_value == t_base_value) // hit the ground
								bm.SetID(x + t_build.x * 16, t_build_value, y + t_build.y * 16, t_build.id[x, y]);

							if (t_build_value > t_base_value) // build a hill
							{
								for (int z = t_build_value; z > t_base_value - 1; z--)
								{
									
									int checkforair = bm.GetID(x + t_build.x * 16, z + 1, y + t_build.y * 16);

									if (z == t_build_value) // set the hill
										bm.SetID(x + t_build.x * 16, z, y + t_build.y * 16, t_build.id[x, y]);
									else // fill the hill
										bm.SetID(x + t_build.x * 16, z, y + t_build.y * 16, (int)BlockType.STONE);

								}

								// fill water above hill
								if (t_build_value < t_water_value)
								{
									for (int z = t_build_value + 1; z < t_water_value + 1; z++)
									{
										bm.SetID(x + t_build.x * 16, z, y + t_build.y * 16, (int)BlockType.WATER);
									}
								}
							}

							if (t_build_value < t_base_value) // build a hole
							{
								for (int z = t_base_value; z > t_build_value - 1; z--)
								{
									if (z == t_build_value)
									{
										// hit the ground
										bm.SetID(x + t_build.x * 16, z, y + t_build.y * 16, t_build.id[x, y]);

									}
									else
									{
										// fill water or air
										if (z <= t_water_value)
											bm.SetID(x + t_build.x * 16, z, y + t_build.y * 16, (int)BlockType.WATER);
										else
											bm.SetID(x + t_build.x * 16, z, y + t_build.y * 16, (int)BlockType.AIR);

									}

								}
							}
						}
					}
				}
				formProgress.Close();


				RegionChunkManager cm = world.GetChunkManager();
				cm.RelightDirtyChunks();

				world.Save();

				if (showexternalviewform)
					if (formexternalview != null)
						formexternalview.Show();

				once = true;
				formOpenworld.Dispose();
				formOpenworld = null;
				tiles.Clear();
				tiles_edited.Clear();
				resetbitmap();
			}
		}


		private void ts_tampon(object sender, EventArgs e)
		{
			if (!Directory.Exists("tampons\\"))
				Directory.CreateDirectory("tampons");

			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				dlg.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "tampons\\";

				dlg.Title = "Open Image HURENSOHN";
				dlg.Filter = "png files (*.png)|*.png";

				if (dlg.ShowDialog() == DialogResult.OK && !showtamponform)
				{
					// Create a new Bitmap object from the picture file on disk,
					// and assign that to the PictureBox.Image property
					tampon_bitmap = new Bitmap(dlg.FileName);

					showtamponform = true;
					formtampon = new TamponForm(this, tampon_bitmap);
					formtampon.Show();
				}
			}
		}


		private void ts_info(object sender, EventArgs e)
		{
			if (!showtTileInfoForm)
			{
				showtTileInfoForm = true;
				formTileInfo = new TileInfoForm(this);
				formTileInfo.StartPosition = FormStartPosition.Manual;
				formTileInfo.Height = 402;
				formTileInfo.Width = 178;
				formTileInfo.Left = 30;
				formTileInfo.Top = this.Height - formPosition.Height - 30;
				formTileInfo.Show();
			}
			else
			{
				showtTileInfoForm = false;
				formTileInfo.Close();
			}
		}

		private void ts_reset(object sender, EventArgs e)
		{
			tiles.Clear();
			Array.Clear(height_matrix, 0, 64 * 64);
			View_posittion = Vector2.Zero;
			resetbitmap();
		}

		private void ts_removeedited_Click(object sender, EventArgs e)
		{
			tiles_edited.Clear();
			resetbitmap();
		}

		private void ts_matrix(object sender, EventArgs e)
		{
			if (showmatrix)
				showmatrix = false;
			else
				showmatrix = true;
		}

		private void ts_heightid_click(object sender, EventArgs e)
		{
			if (showid)
			{
				showid = false;
				ts_heightid.Image = new Bitmap(MinecraftSubstrateFrontend.imagesassets.height);
			}
			else
			{
				showid = true;
				ts_heightid.Image = new Bitmap(MinecraftSubstrateFrontend.imagesassets.landscape);
			}

			resetbitmap(true);
		}

		private void ts_water_click(object sender, EventArgs e)
		{
			if (showcolor)
				showcolor = false;
			else
				showcolor = true;

			resetbitmap();
		}

		private void ts_openworld(object sender, EventArgs e)
		{
			if (showtTileInfoForm)
				formTileInfo.Close();

			if (showPerformanceForm)
				formPerformance.Close();

			if (showtamponform)
				formtampon.Close();

			if (showexternalviewform)
				if (formexternalview != null)
					formexternalview.Hide();

			showtTileInfoForm = false;
			showPerformanceForm = false;
			showtamponform = false;

			OpenWorldForm formOpenworld = new OpenWorldForm(this);
			DialogResult result = formOpenworld.ShowDialog();
			formOpenworld.Size = new Size(646, 359);
			if (backgroundWorker1.IsBusy)
				backgroundWorker1.CancelAsync();

			if (result == DialogResult.OK)
			{
				string folderPath = formOpenworld.SelectedPath;
				string folderupPath = Path.GetDirectoryName(folderPath);
				WorldPath = folderPath;

				if (folderPath != "")
				{
					Properties.Settings.Default.Path = folderupPath;
					Properties.Settings.Default.Save();
				}

				NbtWorld world = NbtWorld.Open(folderPath);
				IChunkManager cm = world.GetChunkManager();
				this.Text = world.Level.LevelName + "[" + world.Level.Version + "] [" + world.Level.GameType + "]";
				int[] countBlocks = new int[1000];

				chunks = new SortedList<int, ChunkRef>();

				// chunks = cm.ToList();
				foreach (ChunkRef cr in cm)
				{
					chunks.Add((cr.X + 1000) + (cr.Z + 1000) * 2000, cr);
				}

				timer1.Enabled = false;
				tiles.Clear();
				string cachedir = "cache\\" + Path.GetFileName(WorldPath);

				if (createCache && ws.openfile(cachedir))
				{
					pictureBox1.Visible = false;


					if (ws.tiles != null)
					{
						tiles = ws.tiles;

					}

					if (ws.tiles_edited != null)
					{
						tiles_edited = ws.tiles_edited;

					}

					ws.Clear();


					pictureBox1.Visible = true;

					timer1.Enabled = true;
					runthrough = true;
				}
				else
				{
					precaching = true;
				}

				Array.Clear(height_matrix, 0, 256);
				Array.Clear(byteheight, 0, 4194304);
				pictureBox1.Image = null;
				backgroundWorker1.WorkerSupportsCancellation = true;
				backgroundWorker1.RunWorkerAsync();

				formProgress = new ProgressForm();
				formProgress.update(progressUpdate.INTENTION, (int)progressbarIntention.CACHING);
				formProgress.update(progressUpdate.END, 100);
				formProgress.Show();

				if (!showexternalviewform)
				{
					pictureBox1.Image = new Bitmap(MinecraftSubstrateFrontend.imagesassets.precaching);
				}
				else
				{
					if (formexternalview != null)
						formexternalview.Update(new Bitmap(MinecraftSubstrateFrontend.imagesassets.precaching));
				}

				if (formOpenworld.createCache)
				{
					if (!Directory.Exists("cache\\"))
						Directory.CreateDirectory("cache");

					if (!Directory.Exists(cachedir))
						Directory.CreateDirectory(cachedir);
				}

				flowLayoutPanel2.Visible = true;
				flowLayoutPanel3.Visible = true;

				if (showexternalviewform)
					if (formexternalview != null)
						formexternalview.Show();

				once = true;
				formOpenworld.Dispose();
				formOpenworld = null;
			}
		}

		private void ts_perf_click(object sender, EventArgs e)
		{
			if (!showPerformanceForm)
			{
				showPerformanceForm = true;
				formPerformance = new PerformanceForm(this, tampon_bitmap);

				formPerformance.StartPosition = FormStartPosition.Manual;
				formPerformance.Height = 237;
				formPerformance.Width = 158;
				formPerformance.Left = 30;
				formPerformance.Top = this.Height - formPerformance.Height - 30;

				formPerformance.Show();
			}
			else
			{
				showPerformanceForm = false;
				formPerformance.Close();
			}
		}

		private void ts_cache_Click(object sender, EventArgs e)
		{
			savecache();
		}

		private void ts_screenshot_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists("screenshots"))
				Directory.CreateDirectory("screenshots");

			if (!Directory.Exists("screenshots" + "\\" + Path.GetFileName(WorldPath)))
				Directory.CreateDirectory("screenshots" + "\\" + Path.GetFileName(WorldPath));

			string cachedir;
			int number = 0;
			bool done = false;
			do
			{
				cachedir = "screenshots\\" + Path.GetFileName(WorldPath) + "\\" + number++ + ".png";

				if (!File.Exists(cachedir))
				{
					result_bitmap.Save(cachedir, ImageFormat.Png);
					done = true;
				}
			} while (!done);

			DialogResult dialogResult = MessageBox.Show("Screenshot saved!\nOpen Directory?", "Save Screenshot", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				string dir = AppDomain.CurrentDomain.BaseDirectory + "screenshots\\" + Path.GetFileName(WorldPath);
				Process.Start("explorer.exe", dir);
			}
		}
	}
}