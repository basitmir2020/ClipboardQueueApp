using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace ClipboardQueueApp.Services;

public class HotkeyService
{
    private const int HOTKEY_ID = 9000;
    private const int WM_HOTKEY = 0x0312;

    private IntPtr _handle;

    public void Register(Window window)
    {
        var helper = new WindowInteropHelper(window);
        _handle = helper.Handle; // Cache the handle

        RegisterHotKey(
            _handle,
            HOTKEY_ID,
            MOD_CONTROL | MOD_ALT,
            0x56 // V key
        );

        var source = HwndSource.FromHwnd(_handle);
        source?.AddHook(WndProc);
    }

    private IntPtr WndProc(
        IntPtr hwnd,
        int msg,
        IntPtr wParam,
        IntPtr lParam,
        ref bool handled)
    {
        if (msg == WM_HOTKEY && wParam.ToInt32() == HOTKEY_ID)
        {
            var window = System.Windows.Application.Current.MainWindow;

            if (window != null)
            {
                window.Show();
                window.WindowState = WindowState.Normal;
                window.Activate();
            }

            handled = true;
        }

        return IntPtr.Zero;
    }

    private const int MOD_CONTROL = 0x2;
    private const int MOD_ALT = 0x1;

    [DllImport("user32.dll")]
    private static extern bool RegisterHotKey(
        IntPtr hWnd,
        int id,
        int fsModifiers,
        int vk);
    
    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    public void Unregister()
    {
        if (_handle != IntPtr.Zero)
        {
            UnregisterHotKey(_handle, HOTKEY_ID);
            _handle = IntPtr.Zero;
        }
    }

}