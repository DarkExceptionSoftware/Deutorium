
namespace MinecraftSubstrateFrontend
{
	partial class OpenWorldForm
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
			this.tb_path = new System.Windows.Forms.TextBox();
			this.btn_browse = new System.Windows.Forms.Button();
			this.tb_cancel = new System.Windows.Forms.Button();
			this.cb_cache = new System.Windows.Forms.CheckBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// tb_path
			// 
			this.tb_path.Enabled = false;
			this.tb_path.Location = new System.Drawing.Point(93, 14);
			this.tb_path.Name = "tb_path";
			this.tb_path.Size = new System.Drawing.Size(529, 23);
			this.tb_path.TabIndex = 0;
			// 
			// btn_browse
			// 
			this.btn_browse.Location = new System.Drawing.Point(12, 13);
			this.btn_browse.Name = "btn_browse";
			this.btn_browse.Size = new System.Drawing.Size(75, 24);
			this.btn_browse.TabIndex = 1;
			this.btn_browse.Text = "Browse";
			this.btn_browse.UseVisualStyleBackColor = true;
			this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
			// 
			// tb_cancel
			// 
			this.tb_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tb_cancel.Location = new System.Drawing.Point(818, 285);
			this.tb_cancel.Name = "tb_cancel";
			this.tb_cancel.Size = new System.Drawing.Size(75, 23);
			this.tb_cancel.TabIndex = 3;
			this.tb_cancel.Text = "Cancel";
			this.tb_cancel.UseVisualStyleBackColor = true;
			this.tb_cancel.Click += new System.EventHandler(this.tb_cancel_Click);
			// 
			// cb_cache
			// 
			this.cb_cache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cb_cache.AutoSize = true;
			this.cb_cache.Checked = true;
			this.cb_cache.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cb_cache.ForeColor = System.Drawing.Color.White;
			this.cb_cache.Location = new System.Drawing.Point(735, 285);
			this.cb_cache.Name = "cb_cache";
			this.cb_cache.Size = new System.Drawing.Size(81, 19);
			this.cb_cache.TabIndex = 4;
			this.cb_cache.Text = "Use Cache";
			this.cb_cache.UseVisualStyleBackColor = true;
			this.cb_cache.CheckedChanged += new System.EventHandler(this.cb_cache_CheckedChanged);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(628, 14);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(265, 265);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// OpenWorldForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(905, 320);
			this.ControlBox = false;
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.cb_cache);
			this.Controls.Add(this.tb_cancel);
			this.Controls.Add(this.btn_browse);
			this.Controls.Add(this.tb_path);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OpenWorldForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "World Browser";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.OpenWorldForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tb_path;
		private System.Windows.Forms.Button btn_browse;
		private System.Windows.Forms.Button tb_cancel;
		private System.Windows.Forms.CheckBox cb_cache;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}