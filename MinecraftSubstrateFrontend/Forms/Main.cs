using MinecraftSubstrateFrontend.Classes;
using MinecraftSubstrateFrontend.helper;
using Substrate;
using Substrate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsApplication1;
using static MinecraftSubstrateFrontend.helper.Heightbitmap;
using static MinecraftSubstrateFrontend.Tile;

namespace MinecraftSubstrateFrontend
{
	public partial class Main : Form
	{
		bool all_finished = false;
		bool changeninvertstate;
		bool loaded = false;
		bool loop_finished = false;
		bool once = true;
		bool precaching = true;

		ChunkRef chunk;

		Heightbitmap ifh = new Heightbitmap();

		int multiplyx;
		int multiplyy;
		int oxs = 0, oxd = 0, oys = 0, oyd = 0;
		int tcount = 0;
		int[,] asset_none = new int[16, 16];
		public int[,] profiler = new int[1024, 4];
		int[,] height_matrix = new int[64, 64];
		long scount = 0;

		public const int bytedim = 4194304;


		SortedList<int, ChunkRef> chunks;

		Stopwatch s = new Stopwatch();
		Stopwatch watch = new Stopwatch();
		Vector2 matrix_View_posittion = new Vector2(0, 0);

		public Main()
		{
			InitializeComponent();

			var bmp = new Bitmap(MinecraftSubstrateFrontend.imagesassets.none);
			for (int x = 0; x < 16; x++)
			{
				for (int y = 0; y < 16; y++)
				{
					asset_none[x, y] = bmp.GetPixel(x, y).R;
				}
			}

			perf_indicator[0] = SetImageColor(new Bitmap(MinecraftSubstrateFrontend.imagesassets.performance), Color.Red);
			perf_indicator[1] = SetImageColor(new Bitmap(MinecraftSubstrateFrontend.imagesassets.performance), Color.Yellow);
			perf_indicator[2] = SetImageColor(new Bitmap(MinecraftSubstrateFrontend.imagesassets.performance), Color.Green);

			s = Stopwatch.StartNew();

			toolStripProgressBar1.Maximum = 100;

			result_bitmap = new Bitmap(1024, 1024);
			tampon_bitmap = new Bitmap(1024, 1024);

			gr = Graphics.FromImage(result_bitmap);
			gr.SmoothingMode = SmoothingMode.None;
			gr.InterpolationMode = InterpolationMode.NearestNeighbor;
			gr.PixelOffsetMode = PixelOffsetMode.HighSpeed;

			//pb_preview.Image = bitmap_preview;
			bitmap_preview = new Bitmap(16, 16);


			create_sample_tile(0, 0);
			create_sample_tile(5, 5);

			this.MouseWheel += MyMouseWheel;
		}
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			timer1.Enabled = false;
			Color[] rgbvalues = ifh.id_palette;
			byte[] bytevalue = new byte[1024 * 4];
			int bc = 0;
			foreach (Color c in rgbvalues)
			{

				bytevalue[bc++] = c.B;
				bytevalue[bc++] = c.G;
				bytevalue[bc++] = c.R;
				bytevalue[bc++] = 255;

			}
			Bitmap bitmap = ifh.PaletteFromBytes(bytevalue);

			bitmap.Save("id_palette.png", ImageFormat.Png);

			if (createCache)
				savecache();

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			showPosition = true;
			formPosition = new PositionForm(this, tampon_bitmap);
			formPosition.StartPosition = FormStartPosition.Manual;
			formPosition.Height = 314;
			formPosition.Width = 178;
			formPosition.Left = this.Width - formPosition.Width - 30;
			formPosition.Top = this.Height - formPosition.Height - 30;
			formPosition.Show();
		}



		private void cb_limit_CheckedChanged(object sender, EventArgs e)
		{
			if (!cb_limit.Checked)
			{
				hs_limit.Enabled = false;
				tile_limit = -1;
				hs_limit.Value = 255;

			}
			else
			{
				hs_limit.Enabled = true;
				tile_limit = 255;
				hs_limit.Value = 255;
			}
			resetbitmap();
		}

		private void hs_limit_Scroll(object sender, ScrollEventArgs e)
		{
			tile_limit = hs_limit.Value;
			cb_limit.Text = "Limit height to " + tile_limit;
			resetbitmap();
		}

		private void pb_cm_assignid_Click(object sender, EventArgs e)
		{
			change_id_color();
		}

		private void formexternalview_FormClosed(object sender, FormClosedEventArgs e)
		{
			formexternalview.Hide();
			formexternalview.Dispose();
			panel1.Visible = true;
			showexternalviewform = false;
			this.Height = 400;
			pbsize++;
			this.WindowState = FormWindowState.Maximized;

			formexternalview = null;
			once = true;
		}

		private void Main_SizeChanged(object sender, EventArgs e)
		{
			switch (pbsize)
			{
				case pbsizemode.FITHEIGHT:
					pictureBox1.Width = pictureBox1.Height;
					pictureBox1.Left = (this.panel1.Width - pictureBox1.Width) / 2;
					pictureBox1.Top = (this.panel1.Height - pictureBox1.Height) / 2;                    //pictureBox1.Left = resizex;
					pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

					break;
				case pbsizemode.FITWINDOW:
					pictureBox1.Left = 0;

					pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
					break;
				case pbsizemode.EXTERNAL:
					showexternalviewform = true;
					if (formexternalview == null)
					{
						formexternalview = new externviewForm(this);
						formexternalview.FormClosed += new FormClosedEventHandler(formexternalview_FormClosed);
						formexternalview.Show();
						panel1.Visible = false;
						this.Size = new Size(this.Width, 120);
						this.WindowState = FormWindowState.Normal;
					}
					break;
				default:
					showexternalviewform = false;
					if (formexternalview != null)
						formexternalview.Close();
					pbsize = 0;

					this.WindowState = FormWindowState.Maximized;

					panel1.Visible = true;

					pictureBox1.Left = 0;

					pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
					pictureBox1.Size = this.panel1.Size;
					break;
			}
		}

		private void ts_profiler_Click(object sender, EventArgs e)
		{
			ts_profiler_toggle(sender, e);
		}

		long mTotal = 0;

		bool runthrough = true;

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (runthrough)
			{
				runthrough = false;

				toolStripStatusLabel1.Text = "[CACHE: " + tiles.Count + "] [EDITED: " + tiles_edited.Count + "]";
				if (all_finished)
					ts_perf.Image = perf_indicator[2];
				else if (loop_finished)
					ts_perf.Image = perf_indicator[1];
				else
					ts_perf.Image = perf_indicator[0];

				all_finished = false;
				s = Stopwatch.StartNew();

				if (old_View_posittion != View_posittion)
				{
					int diffx = (int)(View_posittion.X - old_View_posittion.X);
					int diffy = (int)(View_posittion.Y - old_View_posittion.Y);

					int mdiffx = (int)(View_posittion.X - matrix_View_posittion.X);
					int mdiffy = (int)(View_posittion.Y - matrix_View_posittion.Y);

					int[,] copy = new int[1024, 1024];
					bool changed = false;

					int xs = 0, xd = 0, ys = 0, yd = 0;

					int m_xs = 0, m_xd = 0, m_ys = 0, m_yd = 0;

					int dim_m = 64 * 64;

					bool step = false;

					bool clearleft = false; bool clearright = false;
					bool clearup = false; bool cleardown = false;
					int clm = 0;



					if (Math.Abs(mdiffx) > 15)
					{
						int multiply = mdiffx / 16;
						matrix_View_posittion.X = View_posittion.X;

						if (mdiffx > 0)
						{
							m_xs = 0;
							m_xd = multiply;

							clm = multiply;
							cleardown = true;
						}

						if (mdiffx < 0)
						{
							multiply = Math.Abs(multiply);
							if (multiply > 63)
								multiply = 63;
							m_xs = multiply;

							m_xd = 0;
							clm = multiply;
							clearup = true;
						}
						step = true;
					}

					if (Math.Abs(mdiffy) > 15)
					{
						int multiply = mdiffy / 16;
						matrix_View_posittion.Y = View_posittion.Y;

						if (mdiffy > 0)
						{
							m_ys = 0;
							m_yd = multiply;

							clearright = true;
							clm = multiply;
						}

						if (mdiffy < 0)
						{
							multiply = Math.Abs(multiply);
							if (multiply > 63)
								multiply = 63;

							m_ys = multiply;
							m_yd = 0;

							clearleft = true; clm = multiply;
						}
						step = true;
					}

					if (step)
					{
						int[,] copy_matrix = new int[64, 64];
						Array.Copy(height_matrix, m_yd + m_xd * 64, copy_matrix, m_ys + m_xs * 64, dim_m - m_ys - m_yd - m_xs * 64 - m_xd * 64);
						height_matrix = copy_matrix;
					}
					clm += 8;
					if (clearleft)
						for (int i = 0; i < 64; i++)
							Array.Clear(height_matrix, i * 64, clm );

					if (clearright)
						for (int i = 0; i < 64; i++)
							Array.Clear(height_matrix, (i + 1) * 64 - clm , clm  );
					
					if (clearup)
						Array.Clear(height_matrix, 0, clm * 64);

					if (cleardown)
						Array.Clear(height_matrix, 64 * (64 - clm), 64 * clm);
					
					if (diffx > 0)
					{
						xd = diffx;
						m_xd = xd / 16;
						int multiple = (oxd + m_xd) / 16;
						oxd = (oxd + m_xd) - multiple * 16;
						changed = true;
					}

					if (diffx < 0)
					{
						xs = Math.Abs(diffx);
						m_xs = (oxs + xs) / 16;
						int multiple = (oxs + m_xs) / 16;
						oxs = (oxs + m_xs) - multiple * 16;
						changed = true;
					}

					if (diffy > 0)
					{
						yd = 1024 * diffy;
						m_yd = 64 * (diffy / 16);
						int multiply = (oyd + m_yd) / 16;
						oyd = (oyd + m_yd) - multiply * 16;
						changed = true;
					}

					if (diffy < 0)
					{
						ys = 1024 * Math.Abs(diffy);
						m_ys = 64 * (Math.Abs(diffy) / 16);
						int multiply = (oys + m_ys) / 16;
						oys = (oys + m_ys) - multiply * 16;
						changed = true;
					}

					if (!true)
					{
						multiplyx = (int)(matrix_View_posittion.X - View_posittion.X) * -1;
						multiplyy = (int)(matrix_View_posittion.Y - View_posittion.Y) * -1;

						if (Math.Abs(matrix_View_posittion.X - View_posittion.X) > 15)
							matrix_View_posittion.X = View_posittion.X;

						if (Math.Abs(matrix_View_posittion.Y - View_posittion.Y) > 15)
							matrix_View_posittion.Y = View_posittion.Y;
					}
				}

				// (!view_dragging)
				//	handle_pending();

				if (true) //if (imagechanged)

				{
					update_image();
					imagechanged = false;
				}

				s.Stop();
				old_View_posittion = View_posittion;
				if (showPerformanceForm)
				{
					if (s.ElapsedMilliseconds < 1000 && showPerformanceForm)
						formPerformance.update(pfc.LOOP, (int)s.ElapsedMilliseconds);


				}

				s.Reset();
				// scount = s.ElapsedMilliseconds;

			}
			runthrough = true;

		}
	}
}
