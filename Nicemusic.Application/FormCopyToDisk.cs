using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Nicemusic.Application
{
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
            label1.Text = "# " + _songList.Count.ToString();
            long totalFileSize = 0;
            foreach (var song in _songList)
            {
                chkFavoriteList.Items.Add(song, true);
                totalFileSize += new FileInfo(song).Length;
            }

            var mb = (totalFileSize / 1024f) / 1024f;
            lblCountFileSize.Text = mb.ToString("F") + " MB";
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

            MessageBox.Show("Copied.");
        }

        private void FormCopyToDiskClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDestinationPath.Text))
            {
                return;
            }

            var messageResult = MessageBox.Show(
                "There are lists that are not saved, are you sure you want to close?", "Nicemusic", MessageBoxButtons.YesNo);
            if (messageResult == DialogResult.Yes)
            {
                return;
            }

            e.Cancel = true;
        }

        private void ChkFavoriteListSelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkFavoriteList.SelectedItem == null)
            {
                return;
            }

            txtSelectedSong.Text = chkFavoriteList.SelectedItem.ToString();
        }
    }
}
