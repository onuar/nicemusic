using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nicemusic.Application
{
    using System.IO;

    public partial class FormCopyToDisk : Form
    {
        private readonly List<string> _songList;

        public FormCopyToDisk(List<string> SongList)
        {
            InitializeComponent();

            _songList = SongList;
        }

        private void FormCopyToDiskLoad(object sender, EventArgs e)
        {
            foreach (var song in _songList)
            {
                chkFavoriteList.Items.Add(song, true);
            }
        }

        private void BrowseClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = dialogDestinationDisk.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            var destinationPath = dialogDestinationDisk.SelectedPath;
            txtDestinationPath.Text = destinationPath;
        }

        private void SendButtonClicked(object sender, EventArgs e)
        {
            var destinationPath = txtDestinationPath.Text;
            foreach (var songPath in chkFavoriteList.CheckedItems)
            {
                var sourcePath = songPath.ToString();
                var file = new FileInfo(sourcePath);
                File.Copy(sourcePath, Path.Combine(destinationPath, file.Name));
            }

            MessageBox.Show("Ok");
        }
    }
}
