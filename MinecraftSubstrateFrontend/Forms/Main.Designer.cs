
namespace MinecraftSubstrateFrontend
{
	partial class Main
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.panel1 = new System.Windows.Forms.Panel();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton17 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton18 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton20 = new System.Windows.Forms.ToolStripButton();
			this.ts_heightid = new System.Windows.Forms.ToolStripButton();
			this.ts_water = new System.Windows.Forms.ToolStripButton();
			this.ts_perf = new System.Windows.Forms.ToolStripButton();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Location = new System.Drawing.Point(4, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(899, 435);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
			this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			// 
			// timer1
			// 
			this.timer1.Interval = 40;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 493);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(902, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(785, 17);
			this.toolStripStatusLabel1.Spring = true;
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.Color.Black;
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Location = new System.Drawing.Point(0, 55);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(902, 435);
			this.panel1.TabIndex = 3;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.BackColor = System.Drawing.Color.Black;
			this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel2.Controls.Add(this.toolStrip3);
			this.flowLayoutPanel2.Location = new System.Drawing.Point(114, 1);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(386, 52);
			this.flowLayoutPanel2.TabIndex = 2;
			this.flowLayoutPanel2.Visible = false;
			this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
			// 
			// toolStrip3
			// 
			this.toolStrip3.BackColor = System.Drawing.Color.Silver;
			this.toolStrip3.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton17,
            this.toolStripButton18,
            this.toolStripButton20,
            this.ts_heightid,
            this.ts_water,
            this.ts_perf});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(272, 50);
			this.toolStrip3.Stretch = true;
			this.toolStrip3.TabIndex = 2;
			this.toolStrip3.Text = "toolStrip3";
			// 
			// toolStripButton17
			// 
			this.toolStripButton17.BackColor = System.Drawing.Color.Transparent;
			this.toolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton17.Image = global::MinecraftSubstrateFrontend.imagesassets.stempel;
			this.toolStripButton17.ImageTransparentColor = System.Drawing.Color.DarkMagenta;
			this.toolStripButton17.Name = "toolStripButton17";
			this.toolStripButton17.Size = new System.Drawing.Size(36, 47);
			this.toolStripButton17.Text = "toolStripButton1";
			this.toolStripButton17.ToolTipText = "Stempel";
			this.toolStripButton17.Click += new System.EventHandler(this.ts_tampon);
			// 
			// toolStripButton18
			// 
			this.toolStripButton18.AutoSize = false;
			this.toolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton18.Image = global::MinecraftSubstrateFrontend.imagesassets.info;
			this.toolStripButton18.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton18.Name = "toolStripButton18";
			this.toolStripButton18.Size = new System.Drawing.Size(47, 47);
			this.toolStripButton18.Text = "toolStripButton2";
			this.toolStripButton18.ToolTipText = "TileInfo";
			this.toolStripButton18.Click += new System.EventHandler(this.ts_info);
			// 
			// toolStripButton20
			// 
			this.toolStripButton20.AutoSize = false;
			this.toolStripButton20.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton20.Image = global::MinecraftSubstrateFrontend.imagesassets.matrix;
			this.toolStripButton20.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton20.Name = "toolStripButton20";
			this.toolStripButton20.Size = new System.Drawing.Size(47, 47);
			this.toolStripButton20.Text = "toolStripButton4";
			this.toolStripButton20.ToolTipText = "Zeige Matrix";
			this.toolStripButton20.Click += new System.EventHandler(this.ts_matrix);
			// 
			// ts_heightid
			// 
			this.ts_heightid.AutoSize = false;
			this.ts_heightid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ts_heightid.Image = global::MinecraftSubstrateFrontend.imagesassets.landscape;
			this.ts_heightid.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_heightid.Name = "ts_heightid";
			this.ts_heightid.Size = new System.Drawing.Size(47, 47);
			this.ts_heightid.Text = "toolStripButton5";
			this.ts_heightid.ToolTipText = "Höhe / ID";
			this.ts_heightid.Click += new System.EventHandler(this.ts_heightid_click);
			// 
			// ts_water
			// 
			this.ts_water.AutoSize = false;
			this.ts_water.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ts_water.Image = global::MinecraftSubstrateFrontend.imagesassets.water;
			this.ts_water.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_water.Name = "ts_water";
			this.ts_water.Size = new System.Drawing.Size(47, 47);
			this.ts_water.Text = "toolStripButton6";
			this.ts_water.ToolTipText = "Wasser";
			this.ts_water.Click += new System.EventHandler(this.ts_water_click);
			// 
			// ts_perf
			// 
			this.ts_perf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ts_perf.Image = global::MinecraftSubstrateFrontend.imagesassets.performance;
			this.ts_perf.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_perf.Name = "ts_perf";
			this.ts_perf.Size = new System.Drawing.Size(36, 47);
			this.ts_perf.Text = "toolStripButton8";
			this.ts_perf.Click += new System.EventHandler(this.ts_perf_click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
			this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel1.Controls.Add(this.toolStrip2);
			this.flowLayoutPanel1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 1);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(128, 52);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// toolStrip2
			// 
			this.toolStrip2.BackColor = System.Drawing.Color.Silver;
			this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton11,
            this.toolStripButton15});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(95, 50);
			this.toolStrip2.TabIndex = 2;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// toolStripButton11
			// 
			this.toolStripButton11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton11.AutoSize = false;
			this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton11.Image = global::MinecraftSubstrateFrontend.imagesassets.teset;
			this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton11.Name = "toolStripButton11";
			this.toolStripButton11.Size = new System.Drawing.Size(47, 47);
			this.toolStripButton11.Text = "toolStripButton3";
			this.toolStripButton11.ToolTipText = "Reset";
			this.toolStripButton11.Click += new System.EventHandler(this.ts_reset);
			// 
			// toolStripButton15
			// 
			this.toolStripButton15.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton15.Image = global::MinecraftSubstrateFrontend.imagesassets.openworld;
			this.toolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton15.Name = "toolStripButton15";
			this.toolStripButton15.Size = new System.Drawing.Size(36, 47);
			this.toolStripButton15.Text = "toolStripButton7";
			this.toolStripButton15.ToolTipText = "Welt laden";
			this.toolStripButton15.Click += new System.EventHandler(this.ts_openworld);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(902, 515);
			this.Controls.Add(this.flowLayoutPanel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.statusStrip1);
			this.Name = "Main";
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripButton toolStripButton11;
		private System.Windows.Forms.ToolStripButton toolStripButton15;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.ToolStrip toolStrip3;
		private System.Windows.Forms.ToolStripButton toolStripButton17;
		private System.Windows.Forms.ToolStripButton toolStripButton18;
		private System.Windows.Forms.ToolStripButton toolStripButton20;
		private System.Windows.Forms.ToolStripButton toolStripButton21;
		private System.Windows.Forms.ToolStripButton ts_water;
		private System.Windows.Forms.ToolStripButton ts_perf;
		private System.Windows.Forms.ToolStripButton ts_id;
		private System.Windows.Forms.ToolStripButton ts_heightid;
	}
}

