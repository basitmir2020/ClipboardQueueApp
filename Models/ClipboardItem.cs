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

public class ClipboardItem
{
    public ClipboardType Type { get; set; }
    public ClipboardCategory Category { get; set; } = ClipboardCategory.General;
    public string Text { get; set; }
    public byte[] ImageData { get; set; }
    public bool IsPinned { get; set; }
    public DateTime CopiedAt { get; set; } = DateTime.Now;
}
