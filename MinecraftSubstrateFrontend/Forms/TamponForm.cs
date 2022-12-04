using Substrate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftSubstrateFrontend
{
	public enum TamponMode { FLATTEN, RAISE, LOWER, RELOAD }

	public partial class TamponForm : Form
	{
		Bitmap tamponBitmap;
		Main fr;
		SortedList<int, String> IDs;
		TamponMode tMode;

		int amount;


		public TamponForm(Main Reference, Bitmap TamponBitmap)
		{
			InitializeComponent();
			this.amount = 255;
			this.fr = Reference;
			this.tamponBitmap = TamponBitmap;
			this.tMode = TamponMode.FLATTEN;
		}

		private void FormTampon_Load(object sender, EventArgs e)
		{
			pictureBox1.Image = tamponBitmap;
			textBox2.Text = "255";
			hScrollBar1.Value = amount;
			button1.Text = tMode.ToString();
			List<BlockInfo> BlockId = BlockInfo.BlockTable.ToList();
			IDs = new SortedList<int, String>();

			foreach (BlockInfo b in BlockId)
			{
				IDs.Add(b.ID, b.Name);

			}

			comboBox1.Items.Add("Dont Change");
			comboBox1.Text = "Dont Change";
			foreach ( KeyValuePair<int, String> s in IDs)
				comboBox1.Items.Add(s.Value);


		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void FormTampon_FormClosing(object sender, FormClosingEventArgs e)
		{
			fr.tampon = false;

		}

		private void tpn_btn_set_Click(object sender, EventArgs e)
		{
			int result;
			try
			{
				result = Int32.Parse(textBox1.Text);
			}
			catch
			{
				result = -1;
			}
			fr.settampon(tMode, result, amount);
		}



		private void button1_Click(object sender, EventArgs e)
		{
			if ((int)tMode == 3) tMode = 0;
			else tMode++;
			button1.Text = tMode.ToString();
		}

		private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
		{

		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			String IdName = comboBox1.Text;

			if (IdName.Equals("Dont Change"))
			{
				textBox1.Text = "";
			}
			else
			{
				int index = IDs.IndexOfValue(IdName);
				int id = IDs.IndexOfKey(index);
				textBox1.Text = "" + id;
			}
				
				

		}

		private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			try
			{
				int result = Int32.Parse(textBox1.Text);
				if (IDs.ContainsKey(result))
					comboBox1.Text = IDs[result];
			}
			catch
			{
				comboBox1.Text = "Dont Change";
			}


		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			try
			{
				int result = Int32.Parse(textBox2.Text);
				hScrollBar1.Value = result;
			}
			catch
			{
				textBox2.Text = "0";
				hScrollBar1.Value = 0;

			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Clicks >= 2)
			{

			}
		}


		private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				dlg.Title = "Open Image";
				dlg.Filter = "png files (*.png)|*.png";

				if (dlg.ShowDialog() == DialogResult.OK)
				{

					// Create a new Bitmap object from the picture file on disk,
					// and assign that to the PictureBox.Image property
					tamponBitmap = new Bitmap(dlg.FileName);
					pictureBox1.Image = tamponBitmap;

				}
			}
		}

		private void hScrollBar1_ValueChanged(object sender, EventArgs e)
		{
			amount = hScrollBar1.Value;
			textBox2.Text = amount.ToString();
		}
	}
}
