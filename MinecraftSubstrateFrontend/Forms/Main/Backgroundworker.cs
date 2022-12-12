using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftSubstrateFrontend
{
	public partial class Main : Form
	{
		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			int tcounted = 0;
			float progress = 0;
			do
			{
				handle_pending();
				tcounted += tcount;
				tcount = 0;
				progress = 100f / 4096 * (float)tcounted;
				if (backgroundWorker1.CancellationPending == true)
					break;
				backgroundWorker1.ReportProgress((int)progress);
			} while (tcounted < 4096);
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			precaching = false;
			timer1.Enabled = true;
			runthrough = true;
			update_image();
			loop_finished = false;
			formProgress.Close();

		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			toolStripProgressBar1.Value = e.ProgressPercentage;
			formProgress.update(progressUpdate.PROGRESS, e.ProgressPercentage);

			if (showPerformanceForm)
				formPerformance.update(pfc.BLOCKS, tcount);
		}
	}
}
