
namespace MinecraftSubstrateFrontend
{
	partial class TileInfoForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pb_id = new System.Windows.Forms.PictureBox();
			this.tb_id = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tb_height = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.pb_id)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(82, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 15);
			this.label1.TabIndex = 11;
			this.label1.Text = "Block ID";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(89, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 15);
			this.label2.TabIndex = 12;
			this.label2.Text = "Height";
			// 
			// pb_id
			// 
			this.pb_id.BackColor = System.Drawing.Color.DarkGray;
			this.pb_id.Location = new System.Drawing.Point(6, 22);
			this.pb_id.Name = "pb_id";
			this.pb_id.Size = new System.Drawing.Size(126, 126);
			this.pb_id.TabIndex = 13;
			this.pb_id.TabStop = false;
			// 
			// tb_id
			// 
			this.tb_id.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tb_id.Location = new System.Drawing.Point(6, 37);
			this.tb_id.Name = "tb_id";
			this.tb_id.Size = new System.Drawing.Size(126, 29);
			this.tb_id.TabIndex = 17;
			this.tb_id.Text = "<333,333>";
			this.tb_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tb_height);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tb_id);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(12, 177);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(138, 128);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Point Info";
			// 
			// tb_height
			// 
			this.tb_height.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tb_height.Location = new System.Drawing.Point(0, 87);
			this.tb_height.Name = "tb_height";
			this.tb_height.Size = new System.Drawing.Size(126, 29);
			this.tb_height.TabIndex = 18;
			this.tb_height.Text = "<333,333>";
			this.tb_height.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.pb_id);
			this.groupBox2.ForeColor = System.Drawing.Color.White;
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(138, 159);
			this.groupBox2.TabIndex = 19;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tile View";
			// 
			// TileInfoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(162, 317);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TileInfoForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TileInfo";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.TileInfoForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pb_id)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pb_id;
		private System.Windows.Forms.TextBox tb_id;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tb_height;
		private System.Windows.Forms.GroupBox groupBox2;
	}
}