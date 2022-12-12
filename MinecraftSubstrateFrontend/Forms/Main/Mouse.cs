using Substrate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsApplication1;

namespace MinecraftSubstrateFrontend
{
	public partial class Main : Form
	{
		bool view_dragging = false;

		float movespeed = 1f;

		int MouseSpeedMax;

		Point MouseLocalTilePos;
		Point MousePos;
		Point MouseTilePos;

		Vector2 MOldPos;
		Vector2 old_View_posittion = new Vector2(0, 0);
		Vector2 View_posittion = new Vector2(0, 0);

		private enum XY { WORLD, TILE, TILELOCAL }

		private void change_id_color()
		{
			int key = getkey(MouseTilePos.X, MouseTilePos.Y);

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

		public void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			switch (e.Button)
			{
				case MouseButtons.Left:
					if (showtamponform)
					{
						formtampon.reset_selection();
					}

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

		public void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			MousePos = mousexy(me.Location);
			MouseTilePos = mousexy(me.Location, XY.TILE);
			MouseLocalTilePos = mousexy(me.Location, XY.TILELOCAL);



			if (showPosition)
				formPosition.Update(View_posittion, MousePos, MouseTilePos, MouseLocalTilePos);


			int key = getkey(MouseTilePos.X, MouseTilePos.Y);
			if (tiles.ContainsKey(key) && showtTileInfoForm && !precaching)
				if (tiles[key].id != null)
				{
					update_preview(MouseTilePos.X, MouseTilePos.Y, key);

				}


			if (showtamponform && tiles.ContainsKey(key))
			{
				if (selectheight )
				{
					int v = tiles[key].data[MouseLocalTilePos.X, MouseLocalTilePos.Y];

					formtampon.select_height(v);
				}

				if (selectlheight)
				{
					int v = tiles[key].water[MouseLocalTilePos.X, MouseLocalTilePos.Y];

					formtampon.select_lheight(v);
				}

				if (selectid)
				{
					int v = tiles[key].id[MouseLocalTilePos.X, MouseLocalTilePos.Y];
					formtampon.select_id(v);
				}
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

	}
}
