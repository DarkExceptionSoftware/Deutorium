
namespace MinecraftSubstrateFrontend
{
	partial class TamponForm
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
			this.button1 = new System.Windows.Forms.Button();
			this.tpn_btn_set = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
			this.bn_getid = new System.Windows.Forms.Button();
			this.gb_height = new System.Windows.Forms.GroupBox();
			this.bn_getheight = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.bn_getlheight = new System.Windows.Forms.Button();
			this.tb_liquid = new System.Windows.Forms.TextBox();
			this.bn_liquid = new System.Windows.Forms.Button();
			this.hs_liquid = new System.Windows.Forms.HScrollBar();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.gb_height.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.ForeColor = System.Drawing.Color.Black;
			this.button1.Location = new System.Drawing.Point(6, 62);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(138, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Mode";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tpn_btn_set
			// 
			this.tpn_btn_set.Location = new System.Drawing.Point(9, 437);
			this.tpn_btn_set.Name = "tpn_btn_set";
			this.tpn_btn_set.Size = new System.Drawing.Size(45, 23);
			this.tpn_btn_set.TabIndex = 1;
			this.tpn_btn_set.Text = "Set";
			this.tpn_btn_set.UseVisualStyleBackColor = true;
			this.tpn_btn_set.Click += new System.EventHandler(this.tpn_btn_set_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(107, 437);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(52, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "Dismiss";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Silver;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(9, 281);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(150, 150);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
			this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(52, 31);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(92, 23);
			this.comboBox1.TabIndex = 7;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(6, 31);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(43, 23);
			this.textBox1.TabIndex = 9;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(6, 33);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(43, 23);
			this.textBox2.TabIndex = 10;
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
			// 
			// hScrollBar1
			// 
			this.hScrollBar1.Location = new System.Drawing.Point(53, 33);
			this.hScrollBar1.Maximum = 255;
			this.hScrollBar1.Name = "hScrollBar1";
			this.hScrollBar1.Size = new System.Drawing.Size(92, 23);
			this.hScrollBar1.TabIndex = 13;
			this.hScrollBar1.Value = 255;
			this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
			this.hScrollBar1.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
			// 
			// bn_getid
			// 
			this.bn_getid.BackColor = System.Drawing.Color.Silver;
			this.bn_getid.BackgroundImage = global::MinecraftSubstrateFrontend.imagesassets.pipette;
			this.bn_getid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bn_getid.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bn_getid.Location = new System.Drawing.Point(132, 16);
			this.bn_getid.Margin = new System.Windows.Forms.Padding(0);
			this.bn_getid.Name = "bn_getid";
			this.bn_getid.Size = new System.Drawing.Size(12, 12);
			this.bn_getid.TabIndex = 14;
			this.bn_getid.UseVisualStyleBackColor = false;
			this.bn_getid.Click += new System.EventHandler(this.bn_getid_Click);
			// 
			// gb_height
			// 
			this.gb_height.Controls.Add(this.bn_getheight);
			this.gb_height.Controls.Add(this.textBox2);
			this.gb_height.Controls.Add(this.hScrollBar1);
			this.gb_height.Controls.Add(this.button1);
			this.gb_height.ForeColor = System.Drawing.Color.White;
			this.gb_height.Location = new System.Drawing.Point(12, 83);
			this.gb_height.Name = "gb_height";
			this.gb_height.Size = new System.Drawing.Size(150, 92);
			this.gb_height.TabIndex = 15;
			this.gb_height.TabStop = false;
			this.gb_height.Text = "Adjust Height";
			// 
			// bn_getheight
			// 
			this.bn_getheight.BackColor = System.Drawing.Color.Silver;
			this.bn_getheight.BackgroundImage = global::MinecraftSubstrateFrontend.imagesassets.pipette;
			this.bn_getheight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bn_getheight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bn_getheight.Location = new System.Drawing.Point(132, 16);
			this.bn_getheight.Margin = new System.Windows.Forms.Padding(0);
			this.bn_getheight.Name = "bn_getheight";
			this.bn_getheight.Size = new System.Drawing.Size(12, 12);
			this.bn_getheight.TabIndex = 16;
			this.bn_getheight.UseVisualStyleBackColor = false;
			this.bn_getheight.Click += new System.EventHandler(this.bn_getheight_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.bn_getid);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(9, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(150, 65);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Adjust ID";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.bn_getlheight);
			this.groupBox2.Controls.Add(this.tb_liquid);
			this.groupBox2.Controls.Add(this.bn_liquid);
			this.groupBox2.Controls.Add(this.hs_liquid);
			this.groupBox2.ForeColor = System.Drawing.Color.White;
			this.groupBox2.Location = new System.Drawing.Point(12, 181);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(150, 94);
			this.groupBox2.TabIndex = 17;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Adjust Liquids";
			// 
			// bn_getlheight
			// 
			this.bn_getlheight.BackColor = System.Drawing.Color.Silver;
			this.bn_getlheight.BackgroundImage = global::MinecraftSubstrateFrontend.imagesassets.pipette;
			this.bn_getlheight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bn_getlheight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bn_getlheight.Location = new System.Drawing.Point(132, 16);
			this.bn_getlheight.Margin = new System.Windows.Forms.Padding(0);
			this.bn_getlheight.Name = "bn_getlheight";
			this.bn_getlheight.Size = new System.Drawing.Size(12, 12);
			this.bn_getlheight.TabIndex = 17;
			this.bn_getlheight.UseVisualStyleBackColor = false;
			this.bn_getlheight.Click += new System.EventHandler(this.bn_getlheight_Click);
			// 
			// tb_liquid
			// 
			this.tb_liquid.Location = new System.Drawing.Point(6, 33);
			this.tb_liquid.Name = "tb_liquid";
			this.tb_liquid.Size = new System.Drawing.Size(43, 23);
			this.tb_liquid.TabIndex = 18;
			this.tb_liquid.TextChanged += new System.EventHandler(this.tb_liquid_TextChanged);
			// 
			// bn_liquid
			// 
			this.bn_liquid.BackColor = System.Drawing.Color.White;
			this.bn_liquid.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bn_liquid.ForeColor = System.Drawing.Color.Black;
			this.bn_liquid.Location = new System.Drawing.Point(5, 62);
			this.bn_liquid.Name = "bn_liquid";
			this.bn_liquid.Size = new System.Drawing.Size(139, 23);
			this.bn_liquid.TabIndex = 17;
			this.bn_liquid.Text = "Mode";
			this.bn_liquid.UseVisualStyleBackColor = false;
			this.bn_liquid.Click += new System.EventHandler(this.bn_liquid_Click);
			// 
			// hs_liquid
			// 
			this.hs_liquid.LargeChange = 1;
			this.hs_liquid.Location = new System.Drawing.Point(52, 33);
			this.hs_liquid.Maximum = 255;
			this.hs_liquid.Name = "hs_liquid";
			this.hs_liquid.Size = new System.Drawing.Size(92, 23);
			this.hs_liquid.TabIndex = 19;
			this.hs_liquid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hs_liquid_Scroll);
			this.hs_liquid.ValueChanged += new System.EventHandler(this.hs_liquid_ValueChanged);
			// 
			// TamponForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(171, 468);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.gb_height);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.tpn_btn_set);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TamponForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tampon";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTampon_FormClosing);
			this.Load += new System.EventHandler(this.FormTampon_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.gb_height.ResumeLayout(false);
			this.gb_height.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button tpn_btn_set;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.HScrollBar hScrollBar1;
		private System.Windows.Forms.Button bn_getid;
		private System.Windows.Forms.GroupBox gb_height;
		private System.Windows.Forms.Button bn_getheight;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox tb_liquid;
		private System.Windows.Forms.Button bn_liquid;
		private System.Windows.Forms.HScrollBar hs_liquid;
		private System.Windows.Forms.Button bn_getlheight;
	}
}