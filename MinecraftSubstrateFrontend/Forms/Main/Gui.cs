using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MinecraftSubstrateFrontend.Tile;

namespace MinecraftSubstrateFrontend
{
	public partial class Main : Form
	{
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

			if (showtamponform)
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
	}
}
