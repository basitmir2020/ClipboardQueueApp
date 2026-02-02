using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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
            // Simple dedup
            if (_vm.Items.Count > 0 &&
                _vm.Items[0].Text == item.Text)
                return;

            _vm.Items.Insert(0, item);
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
    
    private void ClipboardItem_DoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (sender is not ListBox listBox)
            return;

        var element = e.OriginalSource as DependencyObject;

        while (element != null && element is not ListBoxItem)
            element = VisualTreeHelper.GetParent(element);

        if (element is not ListBoxItem itemContainer)
            return;

        if (itemContainer.DataContext is not ClipboardItem item)
            return;

        _clipboardService.SetClipboardText(item.Text);
    }


    protected override void OnClosed(EventArgs e)
    {
        _trayService.Dispose();     // cleanup tray icon
        _hotkeyService.Unregister(); // unregister global hotkey
        base.OnClosed(e);
    }
}