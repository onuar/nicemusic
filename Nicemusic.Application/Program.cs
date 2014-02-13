using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using Newtonsoft.Json;
using Nicemusic.Application.Settings;
using SystemApplication = System.Windows.Forms;

namespace Nicemusic.Application
{
    static class Program
    {
        private static List<string> _songList;
        private static IsolatedStorageAppSettings _storage;
        private static SystemApplication.NotifyIcon _systemTrayIcon;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SystemApplication.Application.EnableVisualStyles();
            SystemApplication.Application.SetCompatibleTextRenderingDefault(false);

            _systemTrayIcon = new SystemApplication.NotifyIcon();
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Nicemusic.Application.sys2.ico"))
            {
                _systemTrayIcon.Icon = new Icon(stream);
            }
            _systemTrayIcon.Visible = true;

            var menu = new SystemApplication.ContextMenu();
            menu.MenuItems.Add(new SystemApplication.MenuItem("Send to disk", SendToDiskOnClick));
            menu.MenuItems.Add(new SystemApplication.MenuItem("New list", NewListOnClick));

            //coming soon...
            //menu.MenuItems.Add("-");
            //menu.MenuItems.Add(new SystemApplication.MenuItem("Settings", SettingsOnClick));
            //menu.MenuItems.Add("-");

            menu.MenuItems.Add(new SystemApplication.MenuItem("Exit", ExitOnClick));
            _systemTrayIcon.ContextMenu = menu;

            _systemTrayIcon.MouseDoubleClick += SystemTrayIconMouseDoubleClick;

            _storage = new IsolatedStorageAppSettings("favorites.json");
            var list = _storage.Content;
            if (list == null)
            {
                _songList = new List<string>();
                _storage.Content = null;
                _storage.Save();
            }
            else
            {
                _songList = JsonConvert.DeserializeObject<List<string>>(list.ToString());
            }

            SystemApplication.Application.Run();
        }

        private static void SystemTrayIconMouseDoubleClick(object sender, SystemApplication.MouseEventArgs e)
        {
            var path = Winamp.Process.GetCurrentSongFilePath();
            if (_songList.Exists(s => s.Equals(path)))
            {
                _systemTrayIcon.BalloonTipText = "The song is already in the list.";
                _systemTrayIcon.ShowBalloonTip(500);
                return;
            }

            _songList.Add(path);

            _storage.Content = _songList;
            _storage.Save();

            _systemTrayIcon.BalloonTipText = "Song is added to list.";
            _systemTrayIcon.ShowBalloonTip(500);
        }

        private static void NewListOnClick(object sender, EventArgs eventArgs)
        {
            var messageResult = SystemApplication.MessageBox.Show("Are you sure?", "Nicemusic", SystemApplication.MessageBoxButtons.YesNo);
            if (messageResult == SystemApplication.DialogResult.No)
            {
                return;
            }

            _songList = new List<string>();
            _storage.Delete();
        }

        private static void ExitOnClick(object sender, EventArgs eventArgs)
        {
            var messageResult = SystemApplication.MessageBox.Show("Are you sure you want to exit Nicemusic?", "Nicemusic", SystemApplication.MessageBoxButtons.YesNo);
            if (messageResult == SystemApplication.DialogResult.No)
            {
                return;
            }

            SystemApplication.Application.Exit();
        }

        private static void SendToDiskOnClick(object sender, EventArgs eventArgs)
        {
            if (_songList.Count == 0)
            {
                SystemApplication.MessageBox.Show("There is no song.");
                return;
            }

            using (var form = new FormCopyToDisk(_songList))
            {
                form.StartPosition = SystemApplication.FormStartPosition.CenterScreen;
                form.ShowDialog();
            }
        }

        private static void SettingsOnClick(object sender, EventArgs eventArgs)
        {
            using (var form = new FormSettings())
            {
                form.ShowDialog();
            }
        }
    }
}