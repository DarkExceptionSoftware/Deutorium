using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using static MinecraftSubstrateFrontend.Tile;
using static System.Net.Mime.MediaTypeNames;

namespace MinecraftSubstrateFrontend.Classes
{
	//using System.Runtime.Serialization.Formatters.Binary;

	public class worldserializer
	{
		SortedList<int, tile> tiles = new SortedList<int, tile>();
		private System.ComponentModel.BackgroundWorker backgroundWorker1;

		public SortedList<int, tile> deserialize(string path)
		{
			ProgressForm formProgress = new ProgressForm();
			formProgress.update(progressUpdate.INTENTION, (int)progressbarIntention.LOADING);
			tiles.Clear();

			Stream dest = new MemoryStream();
			using (Stream source = File.OpenRead(path + "\\tiles.zlb"))
			{
				formProgress.update(progressUpdate.END, (int)source.Length);
				formProgress.Show();
				byte[] buffer = new byte[2048];
				int bytesRead;
				while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
				{
					formProgress.update(progressUpdate.PROGRESS, (int)source.Position);
					dest.Write(buffer, 0, bytesRead);
				}
			}
			dest.Position = 0;
			Object o;
			formProgress.update(progressUpdate.INTENTION, (int)progressbarIntention.UNZIPPING);

			using (var gZipStream = new GZipStream(dest, CompressionMode.Decompress, true))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				// gZipStream.Position = 0;
				o = binaryFormatter.Deserialize(gZipStream);
				gZipStream.Close();
			}
			formProgress.Close();

			return (SortedList<int, tile>)o;
		}

		public void serialize(string path, SortedList<int, tile> tiles)
		{
			ProgressForm formProgress = new ProgressForm();

			formProgress.update(progressUpdate.INTENTION, (int)progressbarIntention.ZIPPING);
			formProgress.Show();
			tile _tile = new tile(); ;
			_tile.x = 2;
			_tile.y = 2;
			byte[] memoryarray;

			using (var memoryStream = new System.IO.MemoryStream())
			{
				using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					binaryFormatter.Serialize(gZipStream, tiles);
					gZipStream.Flush();
				}
				memoryarray = memoryStream.ToArray();

			}

			formProgress.update(progressUpdate.INTENTION, (int)progressbarIntention.SAVING);

			using (var fs = new FileStream(path + "\\tiles.zlb", FileMode.Create, System.IO.FileAccess.Write))
			{
				fs.Write(memoryarray, 0, memoryarray.Length);
				fs.Close();
			}
		}
	}
}