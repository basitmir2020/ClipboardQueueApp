namespace ClipboardQueueApp.Models;

/// <summary>
/// Defines the type of content stored in the clipboard item.
/// </summary>
public enum ClipboardType
{
    Text,
    RichText,
    Image
}

/// <summary>
/// Categorizes clipboard items for organization.
/// </summary>
public enum ClipboardCategory
{
    General,
    Code,
    Work,
    Personal
}

/// <summary>
/// Represents a single entry in the clipboard history.
/// </summary>
public class ClipboardItem : System.ComponentModel.INotifyPropertyChanged
{
    public ClipboardType Type { get; set; }
    public ClipboardCategory Category { get; set; } = ClipboardCategory.General;
    
    public string Text { get; set; }
    public byte[] ImageData { get; set; }

    private bool _isPinned;
    /// <summary>
    /// Gets or sets whether the item is pinned to the top of the list.
    /// </summary>
    public bool IsPinned
    {
        get => _isPinned;
        set
        {
            if (_isPinned != value)
            {
                _isPinned = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime CopiedAt { get; set; } = DateTime.Now;

    public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));
}
