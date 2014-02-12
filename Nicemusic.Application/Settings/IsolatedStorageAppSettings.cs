namespace Nicemusic.Application.Settings
{
    using System.Collections.Generic;
    using System.IO;
    using System.IO.IsolatedStorage;

    using Newtonsoft.Json;

    /// <summary>
    /// https://github.com/Blind-Striker/infinityfiction
    /// </summary>
    public class IsolatedStorageAppSettings 
    {
        private const string SettingsFileName = "setting.json";
        private Dictionary<string, object> _settings;

        public IsolatedStorageAppSettings()
        {
            _settings = Load();
        }

        public object this[string key]
        {
            get
            {
                object value;
                _settings.TryGetValue(key, out value);
                return value;
            }
            set
            {
                if (_settings.ContainsKey(key))
                {
                    _settings[key] = value;
                }
                else
                {
                    _settings.Add(key, value);
                }
            }
        }

        public void Save()
        {
            try
            {
                IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
                using (var stream = new IsolatedStorageFileStream(SettingsFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, storage))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        string serializedSettings = JsonConvert.SerializeObject(_settings);
                        writer.Write(serializedSettings);
                    }
                }

            }
            catch
            {
            }
        }

        private Dictionary<string, object> Load()
        {
            try
            {
                IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();

                if (!storage.FileExists(SettingsFileName))
                {
                    return new Dictionary<string, object>();
                }

                using (var stream = new IsolatedStorageFileStream(SettingsFileName, FileMode.Open, FileAccess.Read, storage))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();

                        return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                    }
                }
            }
            catch
            {
                return new Dictionary<string, object>();
            }
        }
    }
}