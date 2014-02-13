using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using Nicemusic.Application.Settings;

namespace Nicemusic.Application
{
    public partial class FormSettings : Form
    {
        private Dictionary<string, object> _settings;
        private IsolatedStorageAppSettings _storage;

        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            _storage = new IsolatedStorageAppSettings("settings.json");
            var settingsContent = _storage.Content;
            if (_storage.Content == null)
            {
                _settings = new Dictionary<string, object>();
                _storage.Content = _settings;
                _storage.Save();
            }
            else
            {
                _settings = JsonConvert.DeserializeObject<Dictionary<string, object>>(settingsContent.ToString());
            }

            if (!_settings.ContainsKey("AllowDuplicate"))
            {
                _settings.Add("AllowDuplicate", true);
                _storage.Content = _settings;
                _storage.Save();
            }

            chcAllowDuplicate.Checked = (bool)_settings["AllowDuplicate"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_settings.ContainsKey("AllowDuplicate"))
            {
                _settings["AllowDuplicate"] = chcAllowDuplicate.Checked;
            }
            else
            {
                _settings.Add("AllowDuplicate", chcAllowDuplicate.Checked);
            }

            _storage.Content = _settings;
            _storage.Save();
            Close();
        }
    }
}