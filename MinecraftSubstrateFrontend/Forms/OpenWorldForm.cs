using Substrate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftSubstrateFrontend
{

	public partial class OpenWorldForm : Form
	{
		TableLayoutPanel panel = new TableLayoutPanel();
		Label lb_levelname;
		public string SelectedPath = "";
		int lastrow = 0;
		public string folderPath;
		public List<string> WorldsList;
		Bitmap bitmap_trash;

		public OpenWorldForm(Main Reference)
		{
			InitializeComponent();
			this.fr = Reference;

		}
		Main fr;
		private void OpenWorldForm_Load(object sender, EventArgs e)
		{
			folderPath = Properties.Settings.Default.Path;
			tb_path.Text = folderPath;
			setuptable();
			update_Directory();
			setuplabels();
			bitmap_trash = new Bitmap(MinecraftSubstrateFrontend.imagesassets.none);
			this.Size = new Size(646, 359);

		}

		private void setuplabels()
		{
			lb_levelname = new Label();
			lb_levelname.AutoSize = false;
			lb_levelname.Dock = DockStyle.Fill;
		}


		private void tb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btn_browse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

			folderBrowser.SelectedPath = Properties.Settings.Default.Path + "\\";

			if (folderBrowser.ShowDialog() == DialogResult.OK)
			{
				if (folderBrowser.SelectedPath != "")
				{
					folderPath = folderBrowser.SelectedPath;
					Properties.Settings.Default.Path = folderPath;
					Properties.Settings.Default.Save();
					tb_path.Text = folderPath;
					update_Directory();

				}
			}
		}
		public bool createCache = true;

		private void update_Directory(string path = "")
		{


			WorldsList = new List<string>();

			if (path.Equals(""))
				path = folderPath;

			if (Directory.Exists(path))
			{
				var directories = Directory.GetDirectories(path);

				foreach (string subdir in directories)
					if (File.Exists(subdir + "\\level.dat"))
					{
						string foldername = Path.GetFileName(Path.GetDirectoryName(subdir + "\\"));
						WorldsList.Add(subdir);
					}

				string key = "";

				panel.Visible = false;
				foreach (var file in WorldsList)
				{

					NbtWorld world = NbtWorld.Open(file);

					panel.RowCount = panel.RowCount + 1;
					panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
					Label b = new Label();
					b.Name = "LevelNameLabel" + (panel.RowCount - 1).ToString();
					b.Text = world.Level.LevelName;
					b.Dock = DockStyle.Fill;
					b.TextAlign = ContentAlignment.MiddleLeft;
					b.Click += new EventHandler(MyButtonHandler);
					b.DoubleClick += new EventHandler(MyDoubleClickHandler);
					panel.Controls.Add(b, 0, panel.RowCount - 1);
					panel.Controls.Add(new Label() { Text = world.Level.Version.ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 1, panel.RowCount - 1);
					panel.Controls.Add(new Label() { Text = world.Level.GameType.ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 2, panel.RowCount - 1);

					string foldername = Path.GetFileName(Path.GetDirectoryName(file + "\\"));

					string cachedir = "cache\\" + foldername;
					if (Directory.Exists(cachedir))
					{
						Button bn = new Button(); bn.Text = "";
						bn.Name = "LevelNameButton" + (panel.RowCount - 1).ToString();
						bn.BackgroundImage = new Bitmap(MinecraftSubstrateFrontend.imagesassets.trash);
						bn.BackgroundImageLayout = ImageLayout.Stretch;
						bn.Click += new EventHandler(TrashButtonHandler);
						bn.Tag = (panel.RowCount - 1);
						bn.Size = new Size(20, 20);
						panel.Controls.Add(bn, 3, panel.RowCount - 1);

					}
					else
					{
						panel.Controls.Add(new Label() { Text = "" }, 3, panel.RowCount - 1);

					}




					// tb_info.Text = world.Level.LevelName;
					world = null;

				}
				panel.Visible = true;
			}
		}



		void TrashButtonHandler(object sender, EventArgs e)
		{
			Button b = (Button)sender;
			int row = Int32.Parse(b.Name.Substring(15));
			string foldername = Path.GetFileName(WorldsList[row - 1]);

			if (Directory.Exists("cache\\" + foldername))
			{
				this.Hide();

				DialogResult dialogResult = MessageBox.Show("Remove \"" + foldername + "\" cache?", "Delete cache", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					Directory.Delete("cache\\" + foldername, true);
					b.Visible = false;
				}

				this.Show();

			}
		}

		void MyButtonHandler(object sender, EventArgs e)
		{
			Label l = (Label)sender;
			int row = Int32.Parse(l.Name.Substring(14));
			tb_cancel.Text = l.Text;

			this.panel.GetControlFromPosition(0, row).BackColor = Color.LightBlue;
			this.panel.GetControlFromPosition(1, row).BackColor = Color.LightBlue;
			this.panel.GetControlFromPosition(2, row).BackColor = Color.LightBlue;
			this.panel.GetControlFromPosition(3, row).BackColor = Color.LightBlue;

			if (Directory.Exists("screenshots\\" + l.Text))
			{
				DirectoryInfo d = new DirectoryInfo("screenshots\\" + l.Text); //Assuming Test is your Folder

				FileInfo[] Files = d.GetFiles("*.png"); //Getting Text files
				filelist = new List<string>();

				foreach (FileInfo file in Files)
				{
					filelist.Add(file.Name);
				}

				this.Size = new Size(921, 359);
				this.pictureBox1.Visible = true;
				picturedir = "screenshots\\" + l.Text + "\\";
				this.pictureBox1.Image = new Bitmap(picturedir + filelist[0]);
			}
			else
			{
				this.Size = new Size(646, 359);
				this.pictureBox1.Visible = false;

			}

			if (lastrow != row)
			{
				this.panel.GetControlFromPosition(0, lastrow).BackColor = Color.White;
				this.panel.GetControlFromPosition(1, lastrow).BackColor = Color.White;
				this.panel.GetControlFromPosition(2, lastrow).BackColor = Color.White;
				this.panel.GetControlFromPosition(3, lastrow).BackColor = Color.White;
			}

			lastrow = row;
		}
		string picturedir;
		List<string> filelist = new List<string>();

		void MyDoubleClickHandler(object sender, EventArgs e)
		{
			MouseEventArgs test = (MouseEventArgs)e;
			if (test.Button == System.Windows.Forms.MouseButtons.Left)
			{
				Label l = (Label)sender;
				int row = Int32.Parse(l.Name.Substring(14)) - 1;

				this.Hide();
				SelectedPath = WorldsList[row];
				this.DialogResult = DialogResult.OK;
				fr.createCache = createCache;


				this.Close();
			}
		}

		private void lb_files_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		public void setuptable()
		{
			panel = new TableLayoutPanel();
			panel.Top = 43;
			panel.Left = 12;
			panel.Size = new Size(610, 229);
			panel.MaximumSize = new Size(610, 229);
			panel.AutoScroll = true;
			panel.BackColor = Color.White;
			panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			// TableLayoutPanel Initialization
			panel.ColumnCount = 4;
			panel.RowCount = 1;
			panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
			panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
			panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
			panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
			panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
			panel.Controls.Add(new Label() { Text = "Name" }, 0, 0);
			panel.Controls.Add(new Label() { Text = "Version" }, 1, 0);
			panel.Controls.Add(new Label() { Text = "Game Mode" }, 2, 0);
			panel.Controls.Add(new Label() { Text = "Cache" }, 3, 0);

			// For Add New Row (Loop this code for add multiple rows)
			this.Controls.Add(panel);
		}


		private void tp_files_Paint(object sender, PaintEventArgs e)
		{
		}

		private void cb_cache_CheckedChanged(object sender, EventArgs e)
		{
			if (cb_cache.Checked) createCache = true;
			else createCache = false;

		}

		int piccount = 0;
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			piccount++;
			if (piccount < filelist.Count())
			{

			}
			else
			{
				piccount = 0;
			}
			this.pictureBox1.Image = new Bitmap(picturedir + filelist[piccount]);

		}
	}
}
