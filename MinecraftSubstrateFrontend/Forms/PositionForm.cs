using Substrate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftSubstrateFrontend
{

	public partial class PositionForm : Form
	{
		bool minimized = false;
		public PositionForm(Main Reference, Bitmap TamponBitmap)
		{
			InitializeComponent();
			
		}

		internal void Update(Vector2 view_posittion, Point mousePos, Point mouseTilePos, Point mouseLocalTilePos)
		{
			tb_world.Text = view_posittion.ToString();
			tb_mworld.Text = mousePos.ToString();
			tb_mtile.Text = mouseTilePos.ToString();
			tb_mltile.Text = mouseLocalTilePos.ToString();

			if (minimized)
			{
				this.Text = view_posittion.ToString();
			}
			else
			{
				this.Text = "Position";
			}
		}

		private void Position_Load(object sender, EventArgs e)
		{

		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			const int WM_NCLBUTTONDBLCLK = 0x00A3;    // this constant int is different

			if (m.Msg == WM_NCLBUTTONDBLCLK)
			{
				this.OnResizeEnd(EventArgs.Empty);
				if (minimized)
				{
					minimized = false;
					this.Height = 314;
				}
				else
				{
					minimized = true;
					this.Height = 0;
				}
			}
		}
	}
}
