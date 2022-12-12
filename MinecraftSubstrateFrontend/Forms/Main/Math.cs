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
		public static int straighten(int value)
		{
			if (value < 0) value -= 16;
			value -= value % 16;
			return value;
		}

		public static float straighten(float value)
		{
			if (value < 0) value -= 16;
			value -= value % 16;
			return value;
		}
	}
}
