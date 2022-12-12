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

	public partial class TileInfoForm : Form
	{
		bool minimized = false;
		SortedList<int, String> IDs;

		public enum INFO { HEIGHT, ID, WATERLEVEL }

		public TileInfoForm(Main Reference)
		{
			InitializeComponent();

		}

		private void TileInfoForm_Load(object sender, EventArgs e)
		{
			List<BlockInfo> BlockId = BlockInfo.BlockTable.ToList();
			IDs = new SortedList<int, String>();

			foreach (BlockInfo b in BlockId)
			{
				IDs.Add(b.ID, b.Name);

			}
		}


		internal void Update(Bitmap bitmap_preview)
		{

			pb_id.Image = bitmap_preview;

		}


		int height = 0;
		int id = 0;
		int waterlevel = 0;
		internal void Update(INFO info, int value)
		{
			switch (info)
			{
				case INFO.HEIGHT:
					height = value;
					break;
				case INFO.ID:
					id = value;
					break;
				case INFO.WATERLEVEL:
					waterlevel = value ;
					break;
				default:
					break;
			}


			if (!minimized)
			{
				tb_height.Text = height.ToString();
			tb_id.Text = IDs[id] + "[" + id + "]";

			if (value == -1)
				tb_water.Text = "no water";
			else
				tb_water.Text = waterlevel.ToString();

			}
			else
			{
				string outText = "[H " + height + "] [ID " + id + "]";

				if (waterlevel != -1) outText += "[W " + waterlevel + "]";
				this.Text = outText;
			}
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
					this.Height = 402;
					this.Text = "TileInfo";
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
