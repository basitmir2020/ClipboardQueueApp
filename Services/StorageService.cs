using System.IO;
using System.Text.Json;
using ClipboardQueueApp.Models;

namespace ClipboardQueueApp.Services;

public class StorageService
{
    private readonly string _file =
        Path.Combine(Path.GetTempPath(), "clipboard.json");

    public void Save(IEnumerable<ClipboardItem> items)
    {
        File.WriteAllText(_file,
            JsonSerializer.Serialize(items));
    }

    public List<ClipboardItem> Load()
    {
        if (!File.Exists(_file)) return new();
        return JsonSerializer.Deserialize<List<ClipboardItem>>(
            File.ReadAllText(_file));
    }

    public void Clear()
    {
        if (File.Exists(_file))
            File.Delete(_file);
    }
}