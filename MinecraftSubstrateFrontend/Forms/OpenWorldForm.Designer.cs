
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
			this.tb_cancel.Location = new System.Drawing.Point(547, 282);
			this.tb_cancel.Name = "tb_cancel";
			this.tb_cancel.Size = new System.Drawing.Size(75, 23);
			this.tb_cancel.TabIndex = 3;
			this.tb_cancel.Text = "Cancel";
			this.tb_cancel.UseVisualStyleBackColor = true;
			this.tb_cancel.Click += new System.EventHandler(this.tb_cancel_Click);
			// 
			// OpenWorldForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(634, 317);
			this.ControlBox = false;
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tb_path;
		private System.Windows.Forms.Button btn_browse;
		private System.Windows.Forms.Button tb_cancel;
	}
}