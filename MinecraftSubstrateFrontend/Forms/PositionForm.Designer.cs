
namespace MinecraftSubstrateFrontend
{
	partial class PositionForm
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
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tb_world = new System.Windows.Forms.TextBox();
			this.tb_mworld = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tb_mltile = new System.Windows.Forms.TextBox();
			this.tb_mtile = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(78, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 12);
			this.label3.TabIndex = 13;
			this.label3.Text = "World";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(104, 76);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 15);
			this.label4.TabIndex = 14;
			this.label4.Text = "Tile";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(69, 135);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 17);
			this.label5.TabIndex = 15;
			this.label5.Text = "Tile Local";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tb_world
			// 
			this.tb_world.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tb_world.Location = new System.Drawing.Point(6, 22);
			this.tb_world.Name = "tb_world";
			this.tb_world.Size = new System.Drawing.Size(126, 29);
			this.tb_world.TabIndex = 16;
			this.tb_world.Text = "<333,333>";
			this.tb_world.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tb_mworld
			// 
			this.tb_mworld.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tb_mworld.Location = new System.Drawing.Point(6, 34);
			this.tb_mworld.Name = "tb_mworld";
			this.tb_mworld.Size = new System.Drawing.Size(126, 29);
			this.tb_mworld.TabIndex = 17;
			this.tb_mworld.Text = "<333,333>";
			this.tb_mworld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tb_mltile);
			this.groupBox1.Controls.Add(this.tb_mtile);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tb_mworld);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(12, 72);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(138, 196);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mouse Position";
			// 
			// tb_mltile
			// 
			this.tb_mltile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tb_mltile.Location = new System.Drawing.Point(6, 155);
			this.tb_mltile.Name = "tb_mltile";
			this.tb_mltile.Size = new System.Drawing.Size(126, 29);
			this.tb_mltile.TabIndex = 19;
			this.tb_mltile.Text = "<333,333>";
			this.tb_mltile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tb_mtile
			// 
			this.tb_mtile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tb_mtile.Location = new System.Drawing.Point(6, 94);
			this.tb_mtile.Name = "tb_mtile";
			this.tb_mtile.Size = new System.Drawing.Size(126, 29);
			this.tb_mtile.TabIndex = 18;
			this.tb_mtile.Text = "<333,333>";
			this.tb_mtile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tb_world);
			this.groupBox2.ForeColor = System.Drawing.Color.White;
			this.groupBox2.Location = new System.Drawing.Point(12, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(138, 63);
			this.groupBox2.TabIndex = 19;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "World Position";
			// 
			// Position
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(162, 275);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Position";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Position";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Position_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tb_world;
		private System.Windows.Forms.TextBox tb_mworld;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tb_mltile;
		private System.Windows.Forms.TextBox tb_mtile;
		private System.Windows.Forms.GroupBox groupBox2;
	}
}