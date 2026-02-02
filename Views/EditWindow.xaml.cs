using System.Windows;

namespace ClipboardQueueApp.Views;

/// <summary>
/// Interaction logic for EditWindow.xaml.
/// Provides a simple dialog to edit clipboard text.
/// </summary>
public partial class EditWindow : Window
{
    /// <summary>
    /// Gets the text entered by the user.
    /// </summary>
    public string ResultText { get; private set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the EditWindow.
    /// </summary>
    /// <param name="initialText">The text to initialize the editor with.</param>
    public EditWindow(string initialText)
    {
        InitializeComponent();
        InputBox.Text = initialText;
        InputBox.Focus();
        InputBox.CaretIndex = InputBox.Text.Length;
    }

    /// <summary>
    /// Handles the Save button click.
    /// </summary>
    private void Save_Click(object sender, RoutedEventArgs e)
    {
        ResultText = InputBox.Text;
        DialogResult = true;
    }
}
