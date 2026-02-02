using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using ClipboardQueueApp.Models;

namespace ClipboardQueueApp.Services;

public class ClipboardService
{
    public event Action<ClipboardItem>? ClipboardCaptured;

    private bool _internalClipboardChange;

    public void Start(Window window)
    {
        var source = HwndSource.FromHwnd(
            new WindowInteropHelper(window).Handle);

        source.AddHook(WndProc);
        AddClipboardFormatListener(source.Handle);
    }

    private const int WM_CLIPBOARDUPDATE = 0x031D;

    private IntPtr WndProc(
        IntPtr hwnd,
        int msg,
        IntPtr wParam,
        IntPtr lParam,
        ref bool handled)
    {
        if (msg != WM_CLIPBOARDUPDATE)
            return IntPtr.Zero;

        // Ignore clipboard changes made by THIS app
        if (_internalClipboardChange)
        {
            _internalClipboardChange = false;
            return IntPtr.Zero;
        }

        System.Windows.Application.Current.Dispatcher.Invoke(() =>
        {
            if (System.Windows.Clipboard.ContainsText())
            {
                ClipboardCaptured?.Invoke(new ClipboardItem
                {
                    Type = ClipboardType.Text,
                    Text = System.Windows.Clipboard.GetText()
                });
            }
        });

        return IntPtr.Zero;
    }

    /// <summary>
    /// Use this method when YOUR app sets clipboard content
    /// </summary>
    public void SetClipboardText(string text)
    {
        try
        {
            _internalClipboardChange = true;
            System.Windows.Clipboard.SetText(text);
        }
        catch (COMException)
        {
            // Clipboard is busy or unavailable
        }
    }

    [DllImport("user32.dll")]
    private static extern bool AddClipboardFormatListener(IntPtr hwnd);
}