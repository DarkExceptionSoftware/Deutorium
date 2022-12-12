using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MinecraftSubstrateFrontend.Tile;

namespace MinecraftSubstrateFrontend
{
	public partial class Main : Form
	{
		private void tabControl1_KeyDown(object sender, KeyEventArgs e)
		{

			switch (e.KeyCode)
			{
				case Keys.Down:
					View_posittion.Y -= 16;
					break;
				case Keys.Right:
					View_posittion.X += 16;
					break;
				case Keys.Up:
					View_posittion.Y += 16;
					break;
				case Keys.Left:
					View_posittion.X -= 16;
					break;
			}
			imagechanged = true;
			Array.Clear(height_matrix, 0, height_matrix.Length);

			e.Handled = true;
		}

	}
}
