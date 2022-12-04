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
	enum pfc { GRAPHIC, LOOP, BLOCKS }
	public partial class PerformanceForm : Form
	{

		public PerformanceForm(Main Reference, Bitmap TamponBitmap)
		{
			InitializeComponent();

		}

		internal void update(pfc Pfc, int ms)
		{
			switch (Pfc)
			{
				case pfc.BLOCKS:
					perf_blocks.Text = ms.ToString();
					break;
				case pfc.GRAPHIC:
					perf_gfx.Value = ms;
					label_gfx_pfc.Text = perf_gfx.Value + "ms";
					break;
				case pfc.LOOP:
					perf_loop.Value = ms;
					label_loop_pfc.Text = perf_loop.Value + "ms";
					break;
				default:
					break;
			}
		}

		private void PerformanceForm_Load(object sender, EventArgs e)
		{

		}
	}
}
