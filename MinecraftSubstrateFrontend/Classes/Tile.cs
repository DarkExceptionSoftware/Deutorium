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
			public object Clone()
			{
				return this.MemberwiseClone();
			}
		}
	}
}
