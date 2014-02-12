using System;

using SystemApplication = System.Windows.Forms;

namespace Nicemusic.Application
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection;

    using Newtonsoft.Json;

    using Nicemusic.Application.Settings;

    static class Program
    {
        private static List<string> _songList;
        private static IsolatedStorageAppSettings _storage;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SystemApplication.Application.EnableVisualStyles();
            SystemApplication.Application.SetCompatibleTextRenderingDefault(false);

            var systemTrayIcon = new SystemApplication.NotifyIcon();
            //systemTrayIcon.Icon = new Icon(
            //        @"C:\Users\Onur.Aykac\Documents\visual studio 2012\Projects\Nicemusic\sys2.ico");
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Nicemusic.Application.sys2.ico"))
            {
                systemTrayIcon.Icon = new Icon(stream);
            }
            systemTrayIcon.Visible = true;

            var menu = new SystemApplication.ContextMenu();
            menu.MenuItems.Add(new SystemApplication.MenuItem("Send to disk", GonderOnClick));
            menu.MenuItems.Add(new SystemApplication.MenuItem("Exit", ExitOnClick));
            systemTrayIcon.ContextMenu = menu;

            systemTrayIcon.MouseDoubleClick += SystemTrayIconMouseDoubleClick;

            _storage = new IsolatedStorageAppSettings();
            var list = _storage["list"];
            if (list == null)
            {
                _storage["list"] = new List<string>();
                _storage.Save();
            }

            _songList = string.IsNullOrEmpty(_storage["list"].ToString()) ? new List<string>() : JsonConvert.DeserializeObject<List<string>>(_storage["list"].ToString());

            SystemApplication.Application.Run();
        }

        private static void ExitOnClick(object sender, EventArgs eventArgs)
        {
            SystemApplication.Application.Exit();
        }

        private static void GonderOnClick(object sender, EventArgs eventArgs)
        {
            using (var form = new FormCopyToDisk(_songList))
            {
                form.StartPosition = SystemApplication.FormStartPosition.CenterScreen;
                form.ShowDialog();
            }
        }

        private static void SystemTrayIconMouseDoubleClick(object sender, SystemApplication.MouseEventArgs e)
        {
            var path = Winamp.Process.GetCurrentSongFilePath();
            _songList.Add(path);

            _storage["list"] = _songList;
            _storage.Save();
        }
    }
}
