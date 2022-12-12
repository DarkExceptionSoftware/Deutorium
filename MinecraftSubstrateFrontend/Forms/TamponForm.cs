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
	public enum LiquidMode { DRY, WATER, LAVA }

	public partial class TamponForm : Form
	{
		Bitmap tamponBitmap;
		Main fr;
		SortedList<int, String> IDs;
		TamponMode tMode;
		LiquidMode lMode;
		int lAmount;
		int amount;


		public TamponForm(Main Reference, Bitmap TamponBitmap)
		{
			InitializeComponent();
			this.amount = 10;
			int lAmount = 0;
			this.fr = Reference;
			this.tamponBitmap = TamponBitmap;
			this.tMode = TamponMode.FLATTEN;
			this.lMode = LiquidMode.DRY;
		}

		public void select_height(int value)
		{
			amount = value;
			textBox2.Text = value.ToString();
			hScrollBar1.Value = value;

		}

		public void select_id(int value)
		{
			textBox1.Text = value.ToString();
		}

		public void select_water(int value)
		{
			tb_liquid.Text = value.ToString();
		}

		private void FormTampon_Load(object sender, EventArgs e)
		{
			pictureBox1.Image = tamponBitmap;
			textBox2.Text = "255";
			hScrollBar1.Value = amount;
			hs_liquid.Value = lAmount;
			button1.Text = tMode.ToString();
			bn_liquid.Text = lMode.ToString();
			List<BlockInfo> BlockId = BlockInfo.BlockTable.ToList();
			IDs = new SortedList<int, String>();

			foreach (BlockInfo b in BlockId)
			{
				IDs.Add(b.ID, b.Name);

			}

			comboBox1.Items.Add("Dont Change");
			comboBox1.Text = "Dont Change";
			foreach (KeyValuePair<int, String> s in IDs)
				comboBox1.Items.Add(s.Value);


		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void FormTampon_FormClosing(object sender, FormClosingEventArgs e)
		{
			fr.showtamponform = false;
			reset_selection();

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
			fr.settampon(tMode, result, amount, lAmount);
			reset_selection();

		}



		private void button1_Click(object sender, EventArgs e)
		{
			if ((int)tMode == 3) tMode = 0;
			else tMode++;
			button1.Text = tMode.ToString();
			reset_selection();

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
				amount = Int32.Parse(textBox2.Text);
				if (amount > 255) amount = 255;

				hScrollBar1.Value = amount;
			}
			catch
			{
				amount = 0;
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
			reset_selection();

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
					fr.tampon_bitmap = tamponBitmap;
				}
			}
			reset_selection();

		}

		private void hScrollBar1_ValueChanged(object sender, EventArgs e)
		{
			amount = hScrollBar1.Value;
			textBox2.Text = amount.ToString();
		}



		private void bn_getheight_Click(object sender, EventArgs e)
		{
			reset_selection();
			fr.selectheight = true;
			bn_getheight.BackColor = Color.Red;
		}

		internal void select_lheight(int v)
		{
			tb_liquid.Text = v.ToString();
		}

		private void bn_getid_Click(object sender, EventArgs e)
		{
			reset_selection();
			fr.selectid = true;
			bn_getid.BackColor = Color.Red;
		}

		public void reset_selection()
		{
			fr.selectheight = false;
			fr.selectlheight = false;
			fr.selectid = false;
			bn_getid.BackColor = Color.Silver;
			bn_getheight.BackColor = Color.Silver;
			bn_getlheight.BackColor = Color.Silver;
		}

		private void bn_liquid_Click(object sender, EventArgs e)
		{
			if ((int)lMode == 2) lMode = 0;
			else lMode++;

			if (lMode == LiquidMode.DRY)
			{
				lAmount = 0;
				hs_liquid.Value = lAmount;
				tb_liquid.Text = "";
				bn_liquid.Text = lMode.ToString();
				bn_liquid.BackColor = Color.White;
				bn_liquid.ForeColor = Color.Black;

			}

			if (lMode == LiquidMode.WATER)
			{
				lAmount = 62;
				hs_liquid.Value = lAmount;
				tb_liquid.Text = lAmount.ToString();
				bn_liquid.Text = lMode.ToString();
				bn_liquid.BackColor = Color.Blue;
				bn_liquid.ForeColor = Color.White;

			}

			if (lMode == LiquidMode.LAVA)
			{
				lAmount = 62;
				hs_liquid.Value = lAmount;
				tb_liquid.Text = lAmount.ToString();
				bn_liquid.Text = lMode.ToString();
				bn_liquid.BackColor = Color.Red;
				bn_liquid.ForeColor = Color.Yellow;

			}

			bn_liquid.Text = lMode.ToString();
			reset_selection();
		}

		private void tb_liquid_TextChanged(object sender, EventArgs e)
		{
			try
			{
				int result = Int32.Parse(tb_liquid.Text);
				if (result > 255) result = 255;
				hs_liquid.Value = result;
			}
			catch
			{
				tb_liquid.Text = "";
				hs_liquid.Value = 0;
				lMode = LiquidMode.DRY;
				bn_liquid.Text = lMode.ToString();
			}
		}

		private void hs_liquid_Scroll(object sender, ScrollEventArgs e)
		{

		}

		private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
		{

		}

		private void hs_liquid_ValueChanged(object sender, EventArgs e)
		{
			lAmount = hs_liquid.Value;

			if (lAmount > 0)
			{
				tb_liquid.Text = lAmount.ToString();
				if (lMode == LiquidMode.DRY)
				{
					lMode = LiquidMode.WATER;
					bn_liquid.Text = lMode.ToString();
					bn_liquid.BackColor = Color.Blue;
					bn_liquid.ForeColor = Color.White;

				}
			}
			else
			{
				tb_liquid.Text = "";
				lMode = LiquidMode.DRY;
				bn_liquid.Text = lMode.ToString();
				bn_liquid.BackColor = Color.White;
				bn_liquid.ForeColor = Color.Black;
			}


		}

		private void bn_getlheight_Click(object sender, EventArgs e)
		{
			reset_selection();
			fr.selectlheight = true;
			bn_getlheight.BackColor = Color.Red;

		}

		private void pictureBox1_Click_1(object sender, EventArgs e)
		{

		}
	}
}
