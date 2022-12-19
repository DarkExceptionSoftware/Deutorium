
namespace MinecraftSubstrateFrontend
{
	partial class ProfilerForm
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
			this.pb_profile = new System.Windows.Forms.PictureBox();
			this.bn_x = new System.Windows.Forms.Button();
			this.bn_y = new System.Windows.Forms.Button();
			this.bn_close = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pb_profile)).BeginInit();
			this.SuspendLayout();
			// 
			// pb_profile
			// 
			this.pb_profile.BackColor = System.Drawing.Color.White;
			this.pb_profile.Location = new System.Drawing.Point(8, 12);
			this.pb_profile.Name = "pb_profile";
			this.pb_profile.Size = new System.Drawing.Size(512, 128);
			this.pb_profile.TabIndex = 0;
			this.pb_profile.TabStop = false;
			// 
			// bn_x
			// 
			this.bn_x.Location = new System.Drawing.Point(8, 146);
			this.bn_x.Name = "bn_x";
			this.bn_x.Size = new System.Drawing.Size(75, 23);
			this.bn_x.TabIndex = 1;
			this.bn_x.Text = "X-Line";
			this.bn_x.UseVisualStyleBackColor = true;
			this.bn_x.Click += new System.EventHandler(this.bn_x_Click);
			// 
			// bn_y
			// 
			this.bn_y.Location = new System.Drawing.Point(89, 146);
			this.bn_y.Name = "bn_y";
			this.bn_y.Size = new System.Drawing.Size(75, 23);
			this.bn_y.TabIndex = 2;
			this.bn_y.Text = "Y-Line";
			this.bn_y.UseVisualStyleBackColor = true;
			// 
			// bn_close
			// 
			this.bn_close.Location = new System.Drawing.Point(445, 146);
			this.bn_close.Name = "bn_close";
			this.bn_close.Size = new System.Drawing.Size(75, 23);
			this.bn_close.TabIndex = 3;
			this.bn_close.Text = "Close";
			this.bn_close.UseVisualStyleBackColor = true;
			// 
			// ProfilerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(527, 176);
			this.ControlBox = false;
			this.Controls.Add(this.bn_close);
			this.Controls.Add(this.bn_y);
			this.Controls.Add(this.bn_x);
			this.Controls.Add(this.pb_profile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProfilerForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Profiler";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.ProfilerForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pb_profile)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pb_profile;
		private System.Windows.Forms.Button bn_x;
		private System.Windows.Forms.Button bn_y;
		private System.Windows.Forms.Button bn_close;
	}
}