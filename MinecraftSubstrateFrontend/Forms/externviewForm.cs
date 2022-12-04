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

	public partial class externviewForm : Form
	{
		Main fr;
		public externviewForm(Main Reference)
		{
			InitializeComponent();
			this.fr = Reference;
			this.MouseWheel += fr.MyMouseWheel;

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox1_DoubleClick(object sender, EventArgs e)
		{
			this.Close();
		}

		internal void Update(Bitmap result_bitmap)
		{
			if (pictureBox1.Image != null)
				pictureBox1.Invalidate();
			else
				pictureBox1.Image = result_bitmap;

		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			fr.pictureBox1_MouseMove(sender, e);
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			fr.pictureBox1_MouseDown(sender, e);
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			fr.pictureBox1_MouseUp(sender, e);

		}
	}
}
