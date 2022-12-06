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

	public enum progressUpdate { INTENTION, PROGRESS, END}
	public enum progressbarIntention { LOADING, SAVING, CACHING, ZIPPING , UNZIPPING }

	public partial class ProgressForm : Form
	{
		public string intention_text = "";
		public ProgressForm()
		{
			InitializeComponent();

		}

		public void update(progressUpdate pu,int value)
		{
			switch (pu)
			{
				case progressUpdate.INTENTION:
					if (value == 0) intention_text = "LOADING CACHE...";
					if (value == 1) intention_text = "SAVING CACHE...";
					if (value == 2) intention_text = "PRECACHING...";
					if (value == 3) intention_text = "ZIPPING...";
					if (value == 4) intention_text = "UNZIPPING...";
					this.Text = intention_text;

					break;
				case progressUpdate.END:
					progressBar1.Maximum = value;
					break;
				case progressUpdate.PROGRESS:
					progressBar1.Value = value;
					this.Text = intention_text + "(" + progressBar1.Value + " / " + progressBar1.Maximum + ")";
					break;
				default:
					break;
			}
		}

		private void progressBar1_Click(object sender, EventArgs e)
		{

		}

		private void ProgressForm_Load(object sender, EventArgs e)
		{

		}
	}
}
