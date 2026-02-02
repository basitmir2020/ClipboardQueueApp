using System;
using System.Windows;

namespace ClipboardQueueApp.Services;

/// <summary>
/// Manages the application's visual theme (Light/Dark).
/// </summary>
public class ThemeService
{
    /// <summary>
    /// Switches the application theme by loading the corresponding ResourceDictionary.
    /// </summary>
    /// <param name="theme">The name of the theme (e.g., "Light" or "Dark").</param>
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