using System.Windows;     

namespace ClipboardQueueApp.Services;

public class TrayService
{
    private NotifyIcon _tray;

    public void Init(Window window)
    {
        _tray = new NotifyIcon
        {
            Icon = SystemIcons.Application,
            Visible = true,
            Text = "Clipboard Queue"
        };

        _tray.DoubleClick += (_, _) =>
        {
            window.Show();
            window.WindowState = WindowState.Normal;
        };
    }
    
    public void Dispose()
    {
        _tray.Visible = false;
        _tray.Dispose();
    }
}