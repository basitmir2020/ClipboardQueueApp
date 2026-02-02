namespace ClipboardQueueApp.Models;

public enum ClipboardType
{
    Text,
    RichText,
    Image
}

public enum ClipboardCategory
{
    General,
    Code,
    Work,
    Personal
}

public class ClipboardItem : System.ComponentModel.INotifyPropertyChanged
{
    public ClipboardType Type { get; set; }
    public ClipboardCategory Category { get; set; } = ClipboardCategory.General;
    
    public string Text { get; set; }
    public byte[] ImageData { get; set; }

    private bool _isPinned;
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
