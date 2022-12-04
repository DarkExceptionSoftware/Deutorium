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

		public TileInfoForm(Main Reference, Bitmap TamponBitmap)
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

		internal void Update(Bitmap bitmap_preview, int h, int id)
		{
			if (!minimized)
			{
				pb_id.Image = bitmap_preview;
				tb_height.Text = h.ToString();
				tb_id.Text = IDs[id] + "[" + id + "]";
			}
			else
			{
				this.Text = "[H " + h + "] [ID " + id + "]";
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
					this.Height = 356;
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
