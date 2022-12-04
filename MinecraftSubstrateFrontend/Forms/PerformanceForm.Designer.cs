
namespace MinecraftSubstrateFrontend
{
	partial class PerformanceForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label_loop_pfc = new System.Windows.Forms.Label();
			this.label_loop = new System.Windows.Forms.Label();
			this.perf_loop = new System.Windows.Forms.ProgressBar();
			this.label_gfx_pfc = new System.Windows.Forms.Label();
			this.perf_gfx = new System.Windows.Forms.ProgressBar();
			this.label_gfx = new System.Windows.Forms.Label();
			this.perf_blocks = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.perf_blocks);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label_loop_pfc);
			this.groupBox1.Controls.Add(this.label_loop);
			this.groupBox1.Controls.Add(this.perf_loop);
			this.groupBox1.Controls.Add(this.label_gfx_pfc);
			this.groupBox1.Controls.Add(this.perf_gfx);
			this.groupBox1.Controls.Add(this.label_gfx);
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(118, 174);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Performance";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(6, 122);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "BPS";
			// 
			// label_loop_pfc
			// 
			this.label_loop_pfc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_loop_pfc.AutoSize = true;
			this.label_loop_pfc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label_loop_pfc.ForeColor = System.Drawing.Color.White;
			this.label_loop_pfc.Location = new System.Drawing.Point(67, 71);
			this.label_loop_pfc.Name = "label_loop_pfc";
			this.label_loop_pfc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label_loop_pfc.Size = new System.Drawing.Size(45, 13);
			this.label_loop_pfc.TabIndex = 5;
			this.label_loop_pfc.Text = "1000ms";
			// 
			// label_loop
			// 
			this.label_loop.AutoSize = true;
			this.label_loop.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label_loop.ForeColor = System.Drawing.Color.White;
			this.label_loop.Location = new System.Drawing.Point(6, 71);
			this.label_loop.Name = "label_loop";
			this.label_loop.Size = new System.Drawing.Size(33, 13);
			this.label_loop.TabIndex = 4;
			this.label_loop.Text = "Loop";
			// 
			// perf_loop
			// 
			this.perf_loop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.perf_loop.Location = new System.Drawing.Point(6, 87);
			this.perf_loop.Maximum = 1000;
			this.perf_loop.Name = "perf_loop";
			this.perf_loop.Size = new System.Drawing.Size(106, 23);
			this.perf_loop.TabIndex = 3;
			// 
			// label_gfx_pfc
			// 
			this.label_gfx_pfc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_gfx_pfc.AutoSize = true;
			this.label_gfx_pfc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label_gfx_pfc.ForeColor = System.Drawing.Color.White;
			this.label_gfx_pfc.Location = new System.Drawing.Point(67, 19);
			this.label_gfx_pfc.Name = "label_gfx_pfc";
			this.label_gfx_pfc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label_gfx_pfc.Size = new System.Drawing.Size(45, 13);
			this.label_gfx_pfc.TabIndex = 2;
			this.label_gfx_pfc.Text = "1000ms";
			// 
			// perf_gfx
			// 
			this.perf_gfx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.perf_gfx.Location = new System.Drawing.Point(6, 35);
			this.perf_gfx.Maximum = 1000;
			this.perf_gfx.Name = "perf_gfx";
			this.perf_gfx.Size = new System.Drawing.Size(106, 23);
			this.perf_gfx.TabIndex = 1;
			// 
			// label_gfx
			// 
			this.label_gfx.AutoSize = true;
			this.label_gfx.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label_gfx.ForeColor = System.Drawing.Color.White;
			this.label_gfx.Location = new System.Drawing.Point(6, 19);
			this.label_gfx.Name = "label_gfx";
			this.label_gfx.Size = new System.Drawing.Size(52, 13);
			this.label_gfx.TabIndex = 0;
			this.label_gfx.Text = "Graphics";
			// 
			// perf_blocks
			// 
			this.perf_blocks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.perf_blocks.Location = new System.Drawing.Point(6, 138);
			this.perf_blocks.Name = "perf_blocks";
			this.perf_blocks.Size = new System.Drawing.Size(106, 29);
			this.perf_blocks.TabIndex = 20;
			this.perf_blocks.Text = "0";
			this.perf_blocks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// PerformanceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(142, 198);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PerformanceForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Performance";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.PerformanceForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label_loop_pfc;
		private System.Windows.Forms.Label label_loop;
		private System.Windows.Forms.ProgressBar perf_loop;
		private System.Windows.Forms.Label label_gfx_pfc;
		private System.Windows.Forms.ProgressBar perf_gfx;
		private System.Windows.Forms.Label label_gfx;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox perf_blocks;
	}
}