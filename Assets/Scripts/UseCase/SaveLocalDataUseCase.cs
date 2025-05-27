using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace UseCase
{
    public class SaveLocalDataUseCase : IDisposable
    {
        public static void Save<T>(T data, string path)
        {
            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            var writer = new StreamWriter(path, false);
            writer.WriteLine(jsonData);
            writer.Flush();
            writer.Close();
        }

        public static T Load<T>(string path)
        {
            if (!File.Exists(path))
            {
                Debug.LogError($"File not found: {path}");
                return default;
            }

            var reader = new StreamReader(path);
            var jsonData = reader.ReadToEnd();
            var result = JsonConvert.DeserializeObject<T>(jsonData);
            reader.Close();
            return result;
        }

        public static bool ExitFile(string path)
        {
            return File.Exists(path);
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}