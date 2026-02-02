using System;
using System.Windows;

namespace ClipboardQueueApp.Services;

public class ThemeService
{
    public static void SetTheme(string theme)
    {
        System.Windows.Application.Current.Resources.MergedDictionaries.Clear();

        System.Windows.Application.Current.Resources.MergedDictionaries.Add(
            new ResourceDictionary
            {
                Source = new Uri($"pack://application:,,,/Themes/{theme}.xaml")
            });
    }
}