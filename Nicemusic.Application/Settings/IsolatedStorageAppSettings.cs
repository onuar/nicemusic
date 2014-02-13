using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using Newtonsoft.Json;

namespace Nicemusic.Application.Settings
{
    /// <summary>
    /// https://github.com/Blind-Striker/infinityfiction
    /// </summary>
    public class IsolatedStorageAppSettings
    {
        private readonly string _settingsFileName;
        private object _content;

        public IsolatedStorageAppSettings(string settingFileName)
        {
            _settingsFileName = settingFileName;
            _content = Load();
        }

        public object Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }

        public void Save()
        {
            try
            {
                IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
                using (var stream = new IsolatedStorageFileStream(_settingsFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, storage))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        string serializedSettings = JsonConvert.SerializeObject(_content);
                         writer.Write(serializedSettings);
                    }
                }
            }
            catch
            {
                throw new IsolatedStorageException();
            }
        }

        public void Delete()
        {
            var storage = IsolatedStorageFile.GetUserStoreForAssembly();
            storage.DeleteFile(_settingsFileName);
        }

        private object Load()
        {
            try
            {
                IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();

                if (!storage.FileExists(_settingsFileName))
                {
                    return null;
                }

                using (var stream = new IsolatedStorageFileStream(_settingsFileName, FileMode.Open, FileAccess.Read, storage))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();

                        return JsonConvert.DeserializeObject<object>(json);
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