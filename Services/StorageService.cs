using System.IO;
using System.Text.Json;
using ClipboardQueueApp.Models;

namespace ClipboardQueueApp.Services;

/// <summary>
/// Handles persistence of clipboard history to disk using JSON serialization.
/// </summary>
public class StorageService
{
    private readonly string _file =
        Path.Combine(Path.GetTempPath(), "clipboard.json");

    /// <summary>
    /// Saves the current list of clipboard items to a JSON file.
    /// </summary>
    /// <param name="items">The collection of items to save.</param>
    public void Save(IEnumerable<ClipboardItem> items)
    {
        File.WriteAllText(_file,
            JsonSerializer.Serialize(items));
    }

    /// <summary>
    /// Loads clipboard items from the JSON file.
    /// </summary>
    /// <returns>A list of saved clipboard items, or an empty list if no file exists.</returns>
    public List<ClipboardItem> Load()
    {
        if (!File.Exists(_file)) return new();
        return JsonSerializer.Deserialize<List<ClipboardItem>>(
            File.ReadAllText(_file)) ?? new();
    }

    /// <summary>
    /// Deletes the persistence file, effectively clearing saved history.
    /// </summary>
    public void Clear()
    {
        if (File.Exists(_file))
            File.Delete(_file);
    }
}