
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
			this.pb_context = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.pb_cm_assignid = new System.Windows.Forms.ToolStripMenuItem();
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
			this.ts_cache = new System.Windows.Forms.ToolStripButton();
			this.ts_screenshot = new System.Windows.Forms.ToolStripButton();
			this.ts_removeedited = new System.Windows.Forms.ToolStripButton();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.cb_limit = new System.Windows.Forms.CheckBox();
			this.hs_limit = new System.Windows.Forms.HScrollBar();
			this.ts_build = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.pb_context.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.ContextMenuStrip = this.pb_context;
			this.pictureBox1.Location = new System.Drawing.Point(12, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(1545, 820);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			// 
			// pb_context
			// 
			this.pb_context.BackColor = System.Drawing.Color.DimGray;
			this.pb_context.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pb_cm_assignid});
			this.pb_context.Name = "pb_context";
			this.pb_context.Size = new System.Drawing.Size(168, 26);
			// 
			// pb_cm_assignid
			// 
			this.pb_cm_assignid.BackColor = System.Drawing.Color.Tomato;
			this.pb_cm_assignid.BackgroundImage = global::MinecraftSubstrateFrontend.imagesassets.precaching;
			this.pb_cm_assignid.ForeColor = System.Drawing.Color.DarkGray;
			this.pb_cm_assignid.Image = global::MinecraftSubstrateFrontend.imagesassets.none;
			this.pb_cm_assignid.Name = "pb_cm_assignid";
			this.pb_cm_assignid.Size = new System.Drawing.Size(167, 22);
			this.pb_cm_assignid.Text = "Assign color to ID";
			this.pb_cm_assignid.Click += new System.EventHandler(this.pb_cm_assignid_Click);
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
			this.statusStrip1.Location = new System.Drawing.Point(0, 908);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1569, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(1452, 17);
			this.toolStripStatusLabel1.Spring = true;
			this.toolStripStatusLabel1.Text = "Cache status";
			this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			this.panel1.Size = new System.Drawing.Size(1569, 850);
			this.panel1.TabIndex = 3;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.BackColor = System.Drawing.Color.Black;
			this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel2.Controls.Add(this.toolStrip3);
			this.flowLayoutPanel2.Location = new System.Drawing.Point(122, 2);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(524, 53);
			this.flowLayoutPanel2.TabIndex = 2;
			this.flowLayoutPanel2.Visible = false;
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
            this.ts_perf,
            this.ts_cache,
            this.ts_screenshot,
            this.ts_removeedited,
            this.ts_build});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(507, 50);
			this.toolStrip3.Stretch = true;
			this.toolStrip3.TabIndex = 2;
			this.toolStrip3.Text = "toolStrip3";
			// 
			// toolStripButton17
			// 
			this.toolStripButton17.AutoSize = false;
			this.toolStripButton17.BackColor = System.Drawing.Color.Transparent;
			this.toolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton17.Image = global::MinecraftSubstrateFrontend.imagesassets.stempel;
			this.toolStripButton17.ImageTransparentColor = System.Drawing.Color.DarkMagenta;
			this.toolStripButton17.Name = "toolStripButton17";
			this.toolStripButton17.Size = new System.Drawing.Size(44, 44);
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
			this.toolStripButton18.Size = new System.Drawing.Size(44, 44);
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
			this.toolStripButton20.Size = new System.Drawing.Size(44, 44);
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
			this.ts_heightid.Size = new System.Drawing.Size(44, 44);
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
			this.ts_water.Size = new System.Drawing.Size(44, 44);
			this.ts_water.Text = "toolStripButton6";
			this.ts_water.ToolTipText = "Wasser";
			this.ts_water.Click += new System.EventHandler(this.ts_water_click);
			// 
			// ts_perf
			// 
			this.ts_perf.AutoSize = false;
			this.ts_perf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ts_perf.Image = global::MinecraftSubstrateFrontend.imagesassets.performance;
			this.ts_perf.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_perf.Margin = new System.Windows.Forms.Padding(3);
			this.ts_perf.Name = "ts_perf";
			this.ts_perf.Size = new System.Drawing.Size(44, 44);
			this.ts_perf.Text = "toolStripButton8";
			this.ts_perf.Click += new System.EventHandler(this.ts_perf_click);
			// 
			// ts_cache
			// 
			this.ts_cache.AutoSize = false;
			this.ts_cache.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ts_cache.Image = global::MinecraftSubstrateFrontend.imagesassets.cache;
			this.ts_cache.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_cache.Name = "ts_cache";
			this.ts_cache.Size = new System.Drawing.Size(44, 44);
			this.ts_cache.Text = "toolStripButton1";
			this.ts_cache.ToolTipText = "Save Cache";
			this.ts_cache.Click += new System.EventHandler(this.ts_cache_Click);
			// 
			// ts_screenshot
			// 
			this.ts_screenshot.AutoSize = false;
			this.ts_screenshot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ts_screenshot.Image = global::MinecraftSubstrateFrontend.imagesassets.screenshot;
			this.ts_screenshot.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_screenshot.Margin = new System.Windows.Forms.Padding(3);
			this.ts_screenshot.Name = "ts_screenshot";
			this.ts_screenshot.Size = new System.Drawing.Size(44, 44);
			this.ts_screenshot.Text = "toolStripButton1";
			this.ts_screenshot.ToolTipText = "take screenshot";
			this.ts_screenshot.Click += new System.EventHandler(this.ts_screenshot_Click);
			// 
			// ts_removeedited
			// 
			this.ts_removeedited.AutoSize = false;
			this.ts_removeedited.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ts_removeedited.Image = global::MinecraftSubstrateFrontend.imagesassets.remove;
			this.ts_removeedited.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_removeedited.Margin = new System.Windows.Forms.Padding(3);
			this.ts_removeedited.Name = "ts_removeedited";
			this.ts_removeedited.Size = new System.Drawing.Size(44, 44);
			this.ts_removeedited.Text = "toolStripButton1";
			this.ts_removeedited.ToolTipText = "Remove edited tiles";
			this.ts_removeedited.Click += new System.EventHandler(this.ts_removeedited_Click);
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
			this.flowLayoutPanel1.Size = new System.Drawing.Size(113, 52);
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
			this.toolStrip2.Size = new System.Drawing.Size(104, 50);
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
			this.toolStripButton11.Margin = new System.Windows.Forms.Padding(3);
			this.toolStripButton11.Name = "toolStripButton11";
			this.toolStripButton11.Size = new System.Drawing.Size(44, 44);
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
			this.toolStripButton15.Margin = new System.Windows.Forms.Padding(3);
			this.toolStripButton15.Name = "toolStripButton15";
			this.toolStripButton15.Size = new System.Drawing.Size(36, 44);
			this.toolStripButton15.Text = "toolStripButton7";
			this.toolStripButton15.ToolTipText = "Welt laden";
			this.toolStripButton15.Click += new System.EventHandler(this.ts_openworld);
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.BackColor = System.Drawing.Color.Black;
			this.flowLayoutPanel3.Controls.Add(this.cb_limit);
			this.flowLayoutPanel3.Controls.Add(this.hs_limit);
			this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel3.Location = new System.Drawing.Point(652, 3);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(188, 52);
			this.flowLayoutPanel3.TabIndex = 6;
			this.flowLayoutPanel3.Visible = false;
			this.flowLayoutPanel3.WrapContents = false;
			// 
			// cb_limit
			// 
			this.cb_limit.BackColor = System.Drawing.Color.Silver;
			this.cb_limit.Location = new System.Drawing.Point(3, 0);
			this.cb_limit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.cb_limit.Name = "cb_limit";
			this.cb_limit.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.cb_limit.Size = new System.Drawing.Size(136, 27);
			this.cb_limit.TabIndex = 6;
			this.cb_limit.Text = "Limit Height to 255";
			this.cb_limit.UseVisualStyleBackColor = false;
			this.cb_limit.CheckedChanged += new System.EventHandler(this.cb_limit_CheckedChanged);
			// 
			// hs_limit
			// 
			this.hs_limit.LargeChange = 1;
			this.hs_limit.Location = new System.Drawing.Point(3, 27);
			this.hs_limit.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.hs_limit.Maximum = 255;
			this.hs_limit.Minimum = 2;
			this.hs_limit.Name = "hs_limit";
			this.hs_limit.Size = new System.Drawing.Size(136, 23);
			this.hs_limit.TabIndex = 7;
			this.hs_limit.Value = 255;
			this.hs_limit.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hs_limit_Scroll);
			// 
			// ts_build
			// 
			this.ts_build.AutoSize = false;
			this.ts_build.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ts_build.Image = global::MinecraftSubstrateFrontend.imagesassets.build;
			this.ts_build.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_build.Margin = new System.Windows.Forms.Padding(3);
			this.ts_build.Name = "ts_build";
			this.ts_build.Size = new System.Drawing.Size(44, 44);
			this.ts_build.Text = "toolStripButton1";
			this.ts_build.Click += new System.EventHandler(this.ts_build_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(1569, 930);
			this.Controls.Add(this.flowLayoutPanel3);
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
			this.pb_context.ResumeLayout(false);
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
			this.flowLayoutPanel3.ResumeLayout(false);
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
		private System.Windows.Forms.ToolStripButton ts_cache;
		private System.Windows.Forms.ToolStripButton ts_screenshot;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
		private System.Windows.Forms.CheckBox cb_limit;
		private System.Windows.Forms.HScrollBar hs_limit;
		private System.Windows.Forms.ContextMenuStrip pb_context;
		private System.Windows.Forms.ToolStripMenuItem pb_cm_assignid;
		private System.Windows.Forms.ToolStripButton ts_removeedited;
		private System.Windows.Forms.ToolStripButton ts_build;
	}
}

