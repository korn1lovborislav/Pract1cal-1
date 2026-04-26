using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineServiceLibrary.Serialization
{
    public class JsonSerializer<T> where T : class
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _options;

        public JsonSerializer(string filePath)
        {
            _filePath = filePath;
            _options = new JsonSerializerOptions { WriteIndented = true };
        }

        public async Task<List<T>> LoadAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<T>();
            }

            string json = await File.ReadAllTextAsync(_filePath);
            return System.Text.Json.JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public async Task SaveAsync(List<T> items)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(items, _options);
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}