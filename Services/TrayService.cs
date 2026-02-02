using System.Windows;     

namespace ClipboardQueueApp.Services;

/// <summary>
/// Manages the system tray icon and its interactions.
/// </summary>
public class TrayService
{
    private NotifyIcon _tray;

    /// <summary>
    /// Initializes the tray icon and its double-click behavior.
    /// </summary>
    /// <param name="window">The main application window.</param>
    public void Init(Window window)
    {
        _tray = new NotifyIcon
        {
            Icon = SystemIcons.Application,
            Visible = true,
            Text = "ClipFlow"
        };

        _tray.DoubleClick += (_, _) =>
        {
            window.Show();
            window.WindowState = WindowState.Normal;
        };
    }
    
    /// <summary>
    /// Disposes the tray icon, removing it from the system tray.
    /// </summary>
    public void Dispose()
    {
        if (_tray != null)
        {
            _tray.Visible = false;
            _tray.Dispose();
        }
    }
}