using Substrate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftSubstrateFrontend
{

	public partial class ProfilerForm : Form
	{
		Main fr;
		public ProfilerForm(Main Reference)
		{
			InitializeComponent();
			this.fr = Reference;
		}

		private void ProfilerForm_Load(object sender, EventArgs e)
		{

		}

		private void bn_x_Click(object sender, EventArgs e)
		{
			Bitmap profile = new Bitmap(1024, 256);
			Pen blackPen = new Pen(Color.Black, 1);
			Pen bluePen = new Pen(Color.Blue, 1);
			using (var graphics = Graphics.FromImage(profile))
			{
				graphics.Clear(Color.DimGray);

				for (int i = 0; i < 1024; i++)
				{
					if (fr.profiler[i, 1] != -1)
						graphics.DrawLine(bluePen, i, 256 - fr.profiler[i, 1], i, 256 - fr.profiler[i, 0]);

					graphics.DrawLine(blackPen, i, 256 - fr.profiler[i, 0], i, 256);
					graphics.DrawLine(blackPen, i, 256 -  (int)(256f /1024f * (float)i), i, 256);

				}
			}
			pb_profile.SizeMode = PictureBoxSizeMode.StretchImage;
			pb_profile.Image = profile;

		}
	}
}
