using System.Windows;

namespace ClipboardQueueApp.Views;

public partial class EditWindow : Window
{
    public string ResultText { get; private set; } = string.Empty;

    public EditWindow(string initialText)
    {
        InitializeComponent();
        InputBox.Text = initialText;
        InputBox.Focus();
        InputBox.CaretIndex = InputBox.Text.Length;
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        ResultText = InputBox.Text;
        DialogResult = true;
    }
}
