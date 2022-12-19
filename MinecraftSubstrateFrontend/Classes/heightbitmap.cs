using Substrate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftSubstrateFrontend.helper
{
	public class Heightbitmap
	{
		public Color[] id_palette;
		static Bitmap bmp;
		static Bitmap minibmp;
		static Graphics gr;
		static BitmapData bmpData;
		public enum Style { gray, water, colored }

		public Heightbitmap()
		{
			id_palette = new Color[1024];
			bmp = new Bitmap(1024, 1024);
			minibmp = new Bitmap(16, 16);
			// var image = new Bitmap(MinecraftSubstrateFrontend.imagesassets.id_palette);

			Bitmap image;
			if (File.Exists("id_palette.png"))
				image = new Bitmap("id_palette.png");
			else
				image = new Bitmap(MinecraftSubstrateFrontend.imagesassets.id_palette);

			Rectangle area = new Rectangle(0, 0, image.Width, image.Height);
			BitmapData bitmapData = image.LockBits(area, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			int stride = bitmapData.Stride;
			IntPtr ptr = bitmapData.Scan0;
			int numBytes = bitmapData.Stride * image.Height;
			byte[] rgbValues = new byte[numBytes];
			Marshal.Copy(ptr, rgbValues, 0, numBytes);

			int bc = 0, r = 0, g = 0, b = 0;
			for (int i = 0; i < 1024; i++)
			{
				r = rgbValues[bc++];
				g = rgbValues[bc++];
				b = rgbValues[bc++];
				id_palette[i] = Color.FromArgb(b, g, r);
			}

			id_palette[(int)BlockType.STONE] = Color.Gray;
			id_palette[(int)BlockType.GRASS] = Color.Green;
			id_palette[(int)BlockType.DIRT] = Color.Brown;
			id_palette[(int)BlockType.COBBLESTONE] = Color.LightGray;
			id_palette[(int)BlockType.WOOD_PLANK] = Color.SaddleBrown;
			id_palette[(int)BlockType.SAPLING] = Color.SandyBrown;
			id_palette[(int)BlockType.BEDROCK] = Color.DarkSlateGray;

			id_palette[(int)BlockType.WATER] = Color.Blue;
			id_palette[(int)BlockType.STATIONARY_WATER] = Color.Blue;
			id_palette[(int)BlockType.LAVA] = Color.Red;
			id_palette[(int)BlockType.STATIONARY_LAVA] = Color.Red;
			id_palette[(int)BlockType.SAND] = Color.LightYellow;
			id_palette[(int)BlockType.GRAVEL] = Color.LightSlateGray;
			id_palette[(int)BlockType.WOOD] = Color.RosyBrown;
			id_palette[(int)BlockType.LEAVES] = Color.DarkGreen;


		}

		public byte[] idbyte(int id)
		{
			byte[] returnbyte = new byte[3];
			returnbyte[0] = id_palette[id].B;
			returnbyte[1] = id_palette[id].G;
			returnbyte[2] = id_palette[id].R;

			if (returnbyte[0] + returnbyte[1] + returnbyte[2] == 255 * 3)
				id_palette[id] = Color.FromArgb(0, 0, 0);

			return returnbyte;
		}

		byte[] returnbyte = new Byte[] { 0, 0, 0 };
		public byte[] hvbyte(int height, Style _style)
		{
			int r = 0, g = 0, b = 0;
			switch (_style)
			{
				case Style.colored:

					switch (height)
					{
						case > 767:
							r = height - 768;
							g = 255;
							b = height - 768;
							break;
						case > 511:
							r = 255 - height - 512;
							g = 255;
							b = 0;
							break;
						case > 255:
							r = 255;
							g = height - 256;
							b = 0;
							break;
						default:
							r = height;
							g = 0;
							b = 0;
							break;
					}
					break;

				case Style.gray:
					r = height / 4;
					g = height / 4;
					b = height / 4;
					break;
				case Style.water:
					r = height / 4;
					g = height / 4;
					b = 255;
					break;
			}
			returnbyte[0] = (byte)b;
			returnbyte[1] = (byte)g;
			returnbyte[2] = (byte)r;

			return returnbyte;
		}

		Style _style;

		public Bitmap ImageFromHeight(int[,] height, int[,] water, int[,] height_matrix, float zoom, bool loaded = false, bool toggle_matrix = false, bool toggle_color = true)
		{


			byte[] _data = new byte[1024 * 1024 * 4];
			int bytecount = 0;


			for (int x = 0; x < 1024; x++)
			{
				for (int y = 0; y < 1024; y++)
				{
					int r, g, b;
					float posx = x * zoom;
					float posy = y * zoom;
					float center = 512 - 512 * zoom;

					int heightvalue = height[(int)(posx + center), (int)(posy + center)] * 4;
					int heightvalue_gray = height[(int)(posx + center), (int)(posy + center)];
					int watervalue = water[(int)(posx + center), (int)(posy + center)];


					if (watervalue != -1)
					{
						_style = Style.water;
					}
					else
					{
						_style = Style.colored;
					}

					returnbyte = hvbyte(heightvalue, _style);

					_data[bytecount++] = returnbyte[0];
					_data[bytecount++] = returnbyte[1];
					_data[bytecount++] = returnbyte[2];

					_data[bytecount++] = 255;


				}
			}



			bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

			System.Runtime.InteropServices.Marshal.Copy(_data, 0, bmpData.Scan0, _data.Length);

			bmp.UnlockBits(bmpData);
			bool showmatrix = true;
			if (!true)
			{
				for (int x = 0; x < 64; x++)
				{
					for (int y = 0; y < 64; y++)
					{
						RectangleF rectf = new RectangleF(y * 16 + 1, x * 16 + 1, y * 16 + 14, x * 16 + 14);

						if (toggle_color)
							gr.DrawString("" + height_matrix[x, y], new Font("Tahoma", 12), Brushes.Gray, rectf);
						else
							gr.DrawString("" + height_matrix[x, y], new Font("Tahoma", 12), Brushes.Red, rectf);
					}
				}
				gr.Flush();
			}
			return bmp;
		}

		public Bitmap ImageFromBytes(byte[] _data)
		{
			bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
			System.Runtime.InteropServices.Marshal.Copy(_data, 0, bmpData.Scan0, _data.Length);
			bmp.UnlockBits(bmpData);
			return bmp;
		}

		public Bitmap previewImageFromBytes(byte[] _data)
		{
			bmpData = minibmp.LockBits(new Rectangle(0, 0, minibmp.Width, minibmp.Height), ImageLockMode.WriteOnly, minibmp.PixelFormat);
			System.Runtime.InteropServices.Marshal.Copy(_data, 0, bmpData.Scan0, _data.Length);
			minibmp.UnlockBits(bmpData);
			return minibmp;
		}

		public Bitmap PaletteFromBytes(byte[] _data)
		{
			Bitmap bitmap = new Bitmap(32, 32);
			bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
			System.Runtime.InteropServices.Marshal.Copy(_data, 0, bmpData.Scan0, _data.Length);
			bitmap.UnlockBits(bmpData);
			return bitmap;
		}



	}
}
