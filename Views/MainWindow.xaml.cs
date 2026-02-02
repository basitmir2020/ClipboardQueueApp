using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Linq;
using ClipboardQueueApp.Models;
using ClipboardQueueApp.Services;
using ClipboardQueueApp.ViewModels;
using WpfKeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace ClipboardQueueApp.Views;

public partial class MainWindow : Window
{
    private readonly ClipboardService _clipboardService = new();
    private readonly MainViewModel _vm = new();
    private readonly HotkeyService _hotkeyService = new();
    private readonly TrayService _trayService = new();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = _vm;

        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        _trayService.Init(this);
        _hotkeyService.Register(this);
        _clipboardService.Start(this);

        _clipboardService.ClipboardCaptured += item =>
        {
            var existingItem = _vm.Items.FirstOrDefault(i => i.Text == item.Text);

            if (existingItem != null)
            {
                _vm.Items.Remove(existingItem);
                existingItem.CopiedAt = DateTime.Now;
                _vm.Items.Insert(0, existingItem);
            }
            else
            {
                _vm.Items.Insert(0, item);
            }
        };
    }
    
    private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D)
        {
            ThemeService.SetTheme("Dark");
            e.Handled = true;
        }

        if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.L)
        {
            ThemeService.SetTheme("Light");
            e.Handled = true;
        }
    }

    protected override void OnStateChanged(EventArgs e)
    {
        if (WindowState == WindowState.Minimized)
            Hide();

        base.OnStateChanged(e);
    }
    
    private void OnItemDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (sender is ListBoxItem { DataContext: ClipboardItem item } && !string.IsNullOrEmpty(item.Text))
        {
            _clipboardService.SetClipboardText(item.Text);
        }
    }


    protected override void OnClosed(EventArgs e)
    {
        _trayService.Dispose();     // cleanup tray icon
        _hotkeyService.Unregister(); // unregister global hotkey
        base.OnClosed(e);
    }
}