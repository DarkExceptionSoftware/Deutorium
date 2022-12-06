using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Substrate;
using Substrate.Core;
using static MinecraftSubstrateFrontend.Tile;
using static MinecraftSubstrateFrontend.helper.Heightbitmap;
using MinecraftSubstrateFrontend.helper;
using WindowsApplication1;
using System.Reflection;
using MinecraftSubstrateFrontend.Classes;

namespace MinecraftSubstrateFrontend
{
	public partial class Main : Form
	{
		int[,] height = new int[1024, 1024];
		byte[] byteheight = new byte[1024 * 1024 * 4];
		byte[] bytepreview = new byte[16 * 16 * 4];

		int[,] height_matrix = new int[64, 64];

		int[,] asset_none = new int[16, 16];

		int multiplyx;
		int multiplyy;
		static Graphics gr; static Bitmap result_bitmap;
		static Bitmap tampon_bitmap;
		bool loaded = false;
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
		Bitmap[] perf_indicator = new Bitmap[3];

		public void MyMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Delta < 0)
			{
				if (zoom < 1f)
					zoom += 0.1f;
			}
			else
			{
				if (zoom > 0.1f)
					zoom -= 0.1f;
			}
			if (!precaching) resetbitmap();
		}


		Bitmap bitmap_preview;
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
			int key = (Tile.x + 1000) + (Tile.y + 1000) * 2000;

			if (tiles.ContainsKey(key))
				tiles.Remove(key);

			tiles[key] = Tile;

		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			int tcounted = 0;
			float progress = 0;
			do
			{
				handle_pending();
				tcounted += tcount;
				tcount = 0;
				progress = 100f / 4096 * (float)tcounted;
				if (backgroundWorker1.CancellationPending == true)
					break;
				backgroundWorker1.ReportProgress((int)progress);
			} while (tcounted < 3072);
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			precaching = false;
			timer1.Enabled = true;
			update_image();
			loop_finished = false;
			formProgress.Close();

		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			toolStripProgressBar1.Value = e.ProgressPercentage;
			formProgress.update(progressUpdate.END, e.ProgressPercentage);

			if (showPerformanceForm)
				formPerformance.update(pfc.BLOCKS, tcount);
		}

		SortedList<int, ChunkRef> chunks;

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void tabPage1_Click(object sender, EventArgs e)
		{

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

		PositionForm formPosition;
		bool showPosition = false;

		private void tabControl1_TabIndexChanged(Object sender, EventArgs e)
		{
			pictureBox1.Visible = false;
		}

		private void button3_Click(object sender, EventArgs e)
		{

		}

		public bool tampon = false;
		TamponForm formtampon;

		private void button4_Click(object sender, EventArgs e)
		{
		}
		bool showtTileInfoForm = false;
		TileInfoForm formTileInfo;

		Stopwatch watch = new Stopwatch();

		private void update_image()
		{


			watch.Start();
			int diffx = (int)(View_posittion.X - old_View_posittion.X);
			int diffy = (int)(View_posittion.Y - old_View_posittion.Y);
			int xd = 0, xs = 0, yd = 0, ys = 0;
			bool changed = false;
			float zoomstate = 1f;
			if (diffx > 0)
			{
				xd = (int)(diffx * zoomstate);
				changed = true;
			}
			else if (diffx < 0)
			{
				xs = Math.Abs((int)(diffx * zoomstate));
				changed = true;
			}

			if (diffy > 0)
			{
				yd = (int)(diffy * zoomstate);
				changed = true;
			}
			else if (diffy < 0)
			{
				ys = Math.Abs((int)(diffy * zoomstate));
				changed = true;
			}


			Array.Copy(byteheight, xd * 4 + yd * 4 * 1024, bytecopy, xs * 4 + ys * 4 * 1024, bytedim - xs * 4 - xd * 4 - yd * 4 * 1024 - ys * 4 * 1024);
			byteheight = bytecopy;


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
			watch.Stop();

			if (watch.ElapsedMilliseconds < 1000 && showPerformanceForm)
				formPerformance.update(pfc.GRAPHIC, (int)watch.ElapsedMilliseconds);

			//perf_gfx.Value = (int)watch.ElapsedMilliseconds;
			watch.Reset();
			once = false;

		}
		public const int bytedim = 4194304;
		byte[] bytecopy = new byte[bytedim];

		bool once = true;
		float zoom = 1f;
		Heightbitmap ifh = new Heightbitmap();

		Boolean view_dragging = false;
		public void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			switch (e.Button)
			{
				case MouseButtons.Left:
					view_dragging = true;
					loop_finished = false;
					break;
				case MouseButtons.Right:
					Point MousePos = mousexy(me.Location);
					Point MouseTilePos = mousexy(me.Location, XY.TILE);

					create_sample_tile(MouseTilePos.Y, MouseTilePos.X);
					resetbitmap(true);
					break;
			}
		}

		public enum XY { WORLD, TILE, TILELOCAL }

		private Point mousexy(Point coordinates, XY xy = XY.WORLD)
		{
			Point Tile = new Point();
			float factorx = 1, factory = 1;
			if (pictureBox1.SizeMode == PictureBoxSizeMode.StretchImage)
			{
				factorx = 100f / pictureBox1.Width * 1024 / 100;
				factory = 100f / pictureBox1.Height * 1024 / 100;
			}

			coordinates.X = (int)View_posittion.X + (int)((coordinates.X - pictureBox1.Width / 2) * zoom * factorx);
			coordinates.Y = (int)View_posittion.Y + (int)((coordinates.Y - pictureBox1.Height / 2) * zoom * factory);

			if (xy == XY.TILE)
			{

				if (coordinates.Y < 0)
					Tile.Y = -(Math.Abs(coordinates.Y) / 16) - 1;
				else
					Tile.Y = (coordinates.Y / 16);

				if (coordinates.X < 0)
					Tile.X = -(Math.Abs(coordinates.X) / 16) - 1;
				else
					Tile.X = (coordinates.X / 16);
			}

			if (xy == XY.TILELOCAL)
			{
				int clx = coordinates.X / 16;

				int tlx = coordinates.X - clx * 16;
				if (tlx < 0)
					tlx += 16;

				int cly = coordinates.Y / 16;

				int tly = coordinates.Y - cly * 16;
				if (tly < 0)
					tly += 16;
				return new Point(tlx, tly);
			}

			if (xy == XY.TILE)
				return Tile;

			return coordinates;
		}

		private void drawgui(Bitmap bmp)
		{
			Graphics graphics = Graphics.FromImage(bmp);
			graphics.SmoothingMode = SmoothingMode.None;
			graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
			Pen blackPen = new Pen(Color.Black, 1);
			Pen redPen = new Pen(Color.Red, 3);

			PointF point1 = new PointF(512 - (View_posittion.X - straighten(MousePos.X)) * (1 / zoom),
										512 - (View_posittion.Y - straighten(MousePos.Y)) * (1 / zoom));

			if (tampon)
			{
				float opacity = 0.3f;

				if (!view_dragging) opacity = 0.8f;
				Bitmap b = SetImageOpacity(tampon_bitmap, opacity);
				gr.DrawImage(b,
					new Rectangle(512 - tampon_bitmap.Width / 2, 512 - tampon_bitmap.Height / 2,
									tampon_bitmap.Width, tampon_bitmap.Height));
			}
			//GraphicsUnit.Pixel); ; 
			int size = (int)(15 * (1 / zoom));
			graphics.DrawLines(redPen, new PointF[] {
				new PointF(point1.X , point1.Y),
				new PointF(point1.X + size , point1.Y),
				new PointF(point1.X + size , point1.Y + size),
				new PointF(point1.X  , point1.Y + size),
				new PointF(point1.X , point1.Y ),

			});
			graphics.Flush();

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
		public static int straighten(int value)
		{
			if (value < 0) value -= 16;
			value -= value % 16;
			return value;
		}

		public static float straighten(float value)
		{
			if (value < 0) value -= 16;
			value -= value % 16;
			return value;
		}

		bool showmatrix = false;

		private void drawfont(Bitmap bmp)
		{
			Graphics graphics = Graphics.FromImage(bmp);
			graphics.SmoothingMode = SmoothingMode.None;
			graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
			if (showmatrix)
			{
				int x1 = 31 - (int)(31 * zoom);
				int x2 = 32 + (int)(32 * zoom);
				RectangleF rectf, rectf2; Font font = new Font("Tahoma", 12);


				for (int x = x1; x < x2; x++)
				{
					for (int y = x1; y < x2; y++)
					{
						rectf2 = new RectangleF(x * 16 + 3, y * 16 + 3, x * 16 + 16, y * 16 + 16);
						rectf = new RectangleF(x * 16 + 1, y * 16 + 1, x * 16 + 14, y * 16 + 14);

						graphics.DrawString("" + height_matrix[x, y], font, Brushes.Black, rectf2);
						graphics.DrawString("" + height_matrix[x, y], font, Brushes.White, rectf);
					}
				}
				graphics.Flush();
			}
		}

		public void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			switch (e.Button)
			{
				case MouseButtons.Left:
					view_dragging = false;
					MOldPos = Vector2.Zero;
					resetbitmap(true);
					break;
				case MouseButtons.Right:
					// Right click
					break;
			}
		}

		int MouseSpeedMax;
		float movespeed = 1f;

		private void update_preview(int x, int y, int key)
		{
			int height = tiles[key].data[MouseLocalTilePos.X, MouseLocalTilePos.Y];
			int id = tiles[key].id[MouseLocalTilePos.X, MouseLocalTilePos.Y];

			Color bcolor = ifh.id_palette[id];
			draw_tile_asset(x, y, 0, 0, true);
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

				formTileInfo.Update(b, height, id);
			}




		}
		Point MouseTilePos;
		Point MousePos;
		Point MouseLocalTilePos;

		public void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			MousePos = mousexy(me.Location);
			MouseTilePos = mousexy(me.Location, XY.TILE);
			MouseLocalTilePos = mousexy(me.Location, XY.TILELOCAL);

			if (showPosition)
				formPosition.Update(View_posittion, MousePos, MouseTilePos, MouseLocalTilePos);


			int key = (MouseTilePos.X + 1000) + (MouseTilePos.Y + 1000) * 2000;

			if (tiles.ContainsKey(key) && showtTileInfoForm && !precaching)
				if (tiles[key].id != null)
				{
					update_preview(MouseTilePos.X, MouseTilePos.Y, key);

				}


			if (view_dragging)
			{
				// label_position.Text = "working";
				// Array.Clear(height_matrix, 0, 64 * 64);


				imagechanged = true;

				Vector2 MPos = new Vector2(e.X, e.Y);
				if (MOldPos != Vector2.Zero)
				{
					Vector2 Distance;
					Distance.X = -MPos.X + MOldPos.X;
					Distance.Y = -MPos.Y + MOldPos.Y;

					View_posittion.X = View_posittion.X + Distance.X * zoom;
					View_posittion.Y = View_posittion.Y + Distance.Y * zoom;



					int MouseSpeed = (int)Vector2.Distance(MPos, MOldPos);
					if (MouseSpeed > MouseSpeedMax)
						MouseSpeedMax = MouseSpeed;
				}

				MOldPos = MPos;

			}
		}

		Vector2 View_posittion = new Vector2(0, 0);
		Vector2 matrix_View_posittion = new Vector2(0, 0);
		Vector2 old_View_posittion = new Vector2(0, 0);
		Vector2 MOldPos;
		int oxs = 0, oxd = 0, oys = 0, oyd = 0;
		Stopwatch s = new Stopwatch();

		void formexternalview_FormClosed(object sender, FormClosedEventArgs e)
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

		private void timer1_Tick(object sender, EventArgs e)
		{
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
				int m_dxs = 0, m_dxd = 0, m_dys = 0, m_dyd = 0;

				int dim = 1024 * 1024, dim_m = 64 * 64;

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
						//clearup = true;
					}

					if (mdiffx < 0)
					{
						multiply = Math.Abs(multiply);
						if (multiply > 63)
							multiply = 63;
						m_xs = multiply;

						m_xd = 0;
						clm = multiply;
						//clearleft = true;
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

				if (clearleft)
					for (int i = 0; i < 64; i++)
						Array.Clear(height_matrix, i * 64, clm + 2);

				if (clearright)
					for (int i = 0; i < 64; i++)
						Array.Clear(height_matrix, (i + 1) * 64 - clm - 2, clm + 2);

				if (clearup)
					Array.Clear(height_matrix, 0, 8 * 64);

				if (cleardown)
					Array.Clear(height_matrix, 64 * (64 - 8), 64 * 8);

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

				if (changed)
				{
					multiplyx = (int)(matrix_View_posittion.X - View_posittion.X) * -1;
					multiplyy = (int)(matrix_View_posittion.Y - View_posittion.Y) * -1;

					if (Math.Abs(matrix_View_posittion.X - View_posittion.X) > 15)
						matrix_View_posittion.X = View_posittion.X;

					if (Math.Abs(matrix_View_posittion.Y - View_posittion.Y) > 15)
						matrix_View_posittion.Y = View_posittion.Y;
				}
			}

			if (!view_dragging) // (!view_dragging)
				handle_pending();

			if (imagechanged)
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
			kicked = -1;
		}
		bool imagechanged = false;
		int tcount = 0;
		long scount = 0;
		bool changeninvertstate;
		bool precaching = true;

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
								success = draw_tile_asset(mposx + x, mposy + y, correctx + 16 * (x1 - 1), correcty + 16 * (y1 - 1));

								if (success) height_matrix[x1, y1] = 2;
								else height_matrix[x1, y1] = 1;

								tcount++;

								if (!precaching)
								{
									int worktime = 25;
									timer1.Interval = 50;

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

		bool all_finished = false;

		bool loop_finished = false;
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

		public void settampon(TamponMode mode, int id, int height)
		{
			bool stop = false;
			int mposx = (int)View_posittion.X / 16;
			int mposy = (int)View_posittion.Y / 16;
			int correctx = 16 - (int)(View_posittion.X % 16);
			int correcty = 16 - (int)(View_posittion.Y % 16);
			if (correctx < 0) correctx -= 1;
			if (correcty < 0) correcty -= 1;

			bool success;

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
							int key = (tilex + 1000) + (tiley + 1000) * 2000;

							if (tiles.ContainsKey(key))
							{
								for (int u = 0; u < 16; u++)
								{
									for (int w = 0; w < 16; w++)
									{
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
												tiles.Remove(key);
												stop = true;
											}



											if (!stop)
											{

												if (mode == TamponMode.RAISE)
													tiles[key].data[u, w] += (int)(height * density);

												if (mode == TamponMode.LOWER)
													tiles[key].data[u, w] -= (int)(height * density);

												if (mode == TamponMode.FLATTEN)
												{
													int Theight = tiles[key].data[u, w];
													tiles[key].data[u, w] = (int)(Theight * (1 - density)) + ((int)(height * density));

												}


												if (id != -1)
													tiles[key].id[u, w] = id;

											}
										}

										if (!stop)
										{
											if (tiles[key].data[u, w] > 255)
												tiles[key].data[u, w] = 255;

											if (tiles[key].data[u, w] < 0)
												tiles[key].data[u, w] = 0;
										}

										if (stop) break;
									}
									if (stop) break;

								}

							}
						}
					}
				}
			}
			resetbitmap();
		}

		SortedList<int, tile> tiles = new SortedList<int, tile>();






		ChunkRef chunk;

		private void button_zoomin_Click(object sender, EventArgs e)
		{
			zoom -= 0.1f;
			if (zoom < 0.1) zoom = 0.1f;
			resetbitmap();

		}

		private void button_zoomout_Click(object sender, EventArgs e)
		{
			zoom += 0.1f;
			if (zoom > 1) zoom = 1;
			resetbitmap();
		}

		private void resetbitmap(bool noblack = false)
		{
			Array.Clear(height_matrix, 0, height_matrix.Length);

			if (!noblack)
				gr.Clear(Color.Black);
			imagechanged = true;
			update_image();
			loop_finished = false;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{


		}

		private void progressBar1_Click(object sender, EventArgs e)
		{

		}



		public bool draw_tile_asset(int xb, int yb, int xa, int ya, bool preview = false)
		{
			int median = 255;
			chunk = null;
			tile Tile = new tile();
			int calls = 0;
			bool exact = false;

			if (loop_finished)
				exact = true;

			// tile Tile = tiles.Find(c => (c.x == xb) && (c.y == yb));
			int key = (xb + 1000) + (yb + 1000) * 2000;
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

				bool success = false;

				if (chunks.ContainsKey(key)) // tile is in world data
				{
					chunk = chunks[key];

					if (chunk.Blocks != null) // tile is good
					{
						int ydim = chunk.Blocks.YDim;
						if (ydim - 1 < median) median = ydim - 1;
						int newmedian = median;
						int highestmedian = -1;
						bool poob = false;
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

												poob = true;
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
								//if (recalc) break;

							}
							//if (recalc) break;

						}

						success = true;
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

		private void toggle_color_CheckedChanged(object sender, EventArgs e)
		{

		}
		bool showcolor = false;

		private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
		{

		}

		enum pbsizemode { STRETCHED, FITWINDOW, FITHEIGHT, EXTERNAL }
		pbsizemode pbsize = pbsizemode.STRETCHED;

		private void pictureBox1_DoubleClick(object sender, EventArgs e)
		{
			MouseEventArgs test = (MouseEventArgs)e;
			if (test.Button == System.Windows.Forms.MouseButtons.Left)
			{
				pbsize++;
				Main_SizeChanged(sender, e);
				this.Text = pbsize.ToString();

			}


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
		bool showexternalviewform = false;
		externviewForm formexternalview;

		private void toggle_id_CheckedChanged(object sender, EventArgs e)
		{
			resetbitmap(true);
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

		void savecache()
		{
			string cachedir = "cache\\" + Path.GetFileName(WorldPath);

			DialogResult dialogResult = MessageBox.Show("Save \"" + Path.GetFileName(WorldPath) + "\" cache?", "Save cache", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{

				pictureBox1.Visible = false;
				ws.serialize(cachedir, tiles);
				pictureBox1.Visible = true;
				createCache = true;
			}

		}

		worldserializer ws = new worldserializer();




		private void cmpbinfo_Click(object sender, EventArgs e)
		{
			int key = (MouseTilePos.X + 1000) + (MouseTilePos.Y + 1000) * 2000;

			int res = Convert.ToInt32(BlockType.WATER);


			int id = tiles[key].id[MouseLocalTilePos.X, MouseLocalTilePos.Y];
			ColorDialogEx colorDlg = new ColorDialogEx(BlockInfo.BlockTable[id].Name + "[" + id + "]")
			{
				AllowFullOpen = true,
				AnyColor = true,
				SolidColorOnly = false,
				Color = ifh.id_palette[id]
			};
			if (colorDlg.ShowDialog() == DialogResult.OK)
			{
				ifh.id_palette[id] = colorDlg.Color;


			}
		}

		private void tabPage3_Click(object sender, EventArgs e)
		{

		}

		private void ts_tampon(object sender, EventArgs e)
		{
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				dlg.Title = "Open Image";
				dlg.Filter = "png files (*.png)|*.png";

				if (dlg.ShowDialog() == DialogResult.OK && !tampon)
				{

					// Create a new Bitmap object from the picture file on disk,
					// and assign that to the PictureBox.Image property
					tampon_bitmap = new Bitmap(dlg.FileName);

					tampon = true;
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
				formTileInfo = new TileInfoForm(this, tampon_bitmap);
				formTileInfo.StartPosition = FormStartPosition.Manual;
				formTileInfo.Height = 356;
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

		private void ts_matrix(object sender, EventArgs e)
		{
			if (showmatrix)
				showmatrix = false;
			else
				showmatrix = true;
		}

		private void toggle_matrix_CheckedChanged(object sender, EventArgs e)
		{

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
		bool showid = false;
		private void ts_water_click(object sender, EventArgs e)
		{
			if (showcolor)
				showcolor = false;
			else
				showcolor = true;

			resetbitmap();

		}

		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		string WorldName = "";
		public string WorldPath = "";
		ProgressForm formProgress = new ProgressForm();

		private void ts_openworld(object sender, EventArgs e)
		{
			if (showtTileInfoForm)
				formTileInfo.Close();

			if (showPerformanceForm)
				formPerformance.Close();

			if (tampon)
				formtampon.Close();

			if (showexternalviewform)
				if (formexternalview != null)
					formexternalview.Hide();

			showtTileInfoForm = false;
			showPerformanceForm = false;
			tampon = false;






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

				if (createCache && Directory.Exists(cachedir))
				{
					pictureBox1.Visible = false;

					tiles = ws.deserialize(cachedir);
					pictureBox1.Visible = true;

					timer1.Enabled = true;

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

				if (showexternalviewform)
					if (formexternalview != null)
						formexternalview.Show();

				once = true;
				formOpenworld.Dispose();
				formOpenworld = null;


			}

		}
		
		public bool createCache = false;

		bool showPerformanceForm = false;
		PerformanceForm formPerformance;
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

		private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void toolStripButton15_Click(object sender, EventArgs e)
		{

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

		int kicked = -1;

		private void button5_Click(object sender, EventArgs e)
		{

		}




		private void tabControl1_KeyDown(object sender, KeyEventArgs e)
		{

			switch (e.KeyCode)
			{
				case Keys.Down:
					View_posittion.Y -= 16;
					break;
				case Keys.Right:
					View_posittion.X += 16;
					break;
				case Keys.Up:
					View_posittion.Y += 16;
					break;
				case Keys.Left:
					View_posittion.X -= 16;
					break;
			}
			imagechanged = true;
			Array.Clear(height_matrix, 0, height_matrix.Length);

			e.Handled = true;
		}
	}
}
