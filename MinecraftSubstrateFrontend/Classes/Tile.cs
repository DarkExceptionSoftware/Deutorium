using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftSubstrateFrontend
{
	[Serializable]
	public class Tile
	{
		[Serializable]
		public struct tile
		{
			public int x;
			public int y;
			public int[,] data;
			public int[,] water;
			public int[,] id;
			public bool exact;
			public tile Clone()
			{
				tile clone = new tile() { x = this.x, y = this.y, exact = this.exact };
				clone.data = new int[16, 16];
				clone.water = new int[16, 16];
				clone.id = new int[16, 16];
				Array.Copy(this.data, clone.data, 256);
				Array.Copy(this.water, clone.water, 256);
				Array.Copy(this.id, clone.id, 256);
				return clone;
			}
		}
	}
}
