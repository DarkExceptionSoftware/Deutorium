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
		public SortedList<int, tile> tiles;
		public SortedList<int, tile> tiles_edited;

		private System.ComponentModel.BackgroundWorker backgroundWorker1;

		public bool openfile(string path)
		{
			ProgressForm formProgress = new ProgressForm();
			formProgress.update(progressUpdate.INTENTION, (int)progressbarIntention.LOADING);

			bool pack = true;
			Stream dest = new MemoryStream();

			if (!File.Exists(path + "\\tiles.zlb"))
				return false;

			using (Stream source = File.OpenRead(path + "\\tiles.zlb"))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				pack = (bool)binaryFormatter.Deserialize(source);

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
			Object o, o2;
			formProgress.update(progressUpdate.INTENTION, (int)progressbarIntention.UNZIPPING);

			if (pack)
				using (var gZipStream = new GZipStream(dest, CompressionMode.Decompress, CompressionLevel.BestSpeed, true))
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					// gZipStream.Position = 0;
					this.tiles = (SortedList<int, tile>)binaryFormatter.Deserialize(gZipStream);

					if (gZipStream.Position != gZipStream.TotalOut)
						this.tiles_edited = (SortedList<int, tile>)binaryFormatter.Deserialize(gZipStream);

					gZipStream.Close();
				}
			else
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				this.tiles = (SortedList<int, tile>)binaryFormatter.Deserialize(dest);
				if (dest.Position != dest.Length)
					this.tiles_edited = (SortedList<int, tile>)binaryFormatter.Deserialize(dest);

			}

			formProgress.Close();

			return true;
		}

		public void serialize(string path, bool pack = false)
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
				if (pack)
					using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestSpeed))
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						binaryFormatter.Serialize(gZipStream, this.tiles);

						if (this.tiles_edited != null)
							binaryFormatter.Serialize(gZipStream, this.tiles_edited);

						gZipStream.Flush();
					}
				else
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					binaryFormatter.Serialize(memoryStream, this.tiles);
					if (this.tiles_edited != null)
						binaryFormatter.Serialize(memoryStream, this.tiles_edited);


				}

				memoryarray = memoryStream.ToArray();

			}

			formProgress.update(progressUpdate.INTENTION, (int)progressbarIntention.SAVING);

			using (var fs = new FileStream(path + "\\tiles.zlb", FileMode.Create, System.IO.FileAccess.Write))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();

				binaryFormatter.Serialize(fs, pack);
				fs.Write(memoryarray, 0, memoryarray.Length);
				fs.Close();
			}
		}

		public void Clear()
		{
			this.tiles = null;
			this.tiles_edited = null;
		}
	}
}