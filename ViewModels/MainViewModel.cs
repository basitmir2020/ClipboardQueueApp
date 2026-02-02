using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;
using System.Threading.Tasks;
using ClipboardQueueApp.Models;

namespace ClipboardQueueApp.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<ClipboardItem> Items { get; }
    public ICollectionView FilteredItems { get; }

    private string _search;
    public string Search
    {
        get => _search;
        set
        {
            _search = value;
            OnPropertyChanged();
            FilteredItems.Refresh();
        }
    }

    public ICommand DeleteCommand { get; }
    public ICommand PinCommand { get; }
    public ICommand ClearAllCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand CopyCommand { get; }

    private string _statusMessage;
    public string StatusMessage
    {
        get => _statusMessage;
        set { _statusMessage = value; OnPropertyChanged(); }
    }

    private bool _isStatusVisible;
    public bool IsStatusVisible
    {
        get => _isStatusVisible;
        set { _isStatusVisible = value; OnPropertyChanged(); }
    }

    public MainViewModel()
    {
        Items = new ObservableCollection<ClipboardItem>();
        FilteredItems = CollectionViewSource.GetDefaultView(Items);
        FilteredItems.Filter = Filter;

        // Custom sorting: Pinned items first, then by Date descending
        FilteredItems.SortDescriptions.Add(new SortDescription(nameof(ClipboardItem.IsPinned), ListSortDirection.Descending));
        FilteredItems.SortDescriptions.Add(new SortDescription(nameof(ClipboardItem.CopiedAt), ListSortDirection.Descending));

        DeleteCommand = new ClipboardQueueApp.Commands.RelayCommand(Delete);
        PinCommand = new ClipboardQueueApp.Commands.RelayCommand(Pin);
        ClearAllCommand = new ClipboardQueueApp.Commands.RelayCommand(ClearAll);
        EditCommand = new ClipboardQueueApp.Commands.RelayCommand(Edit);
        CopyCommand = new ClipboardQueueApp.Commands.RelayCommand(Copy);
    }

    private async void ShowStatus(string message)
    {
        StatusMessage = message;
        IsStatusVisible = true;
        await Task.Delay(3000);
        IsStatusVisible = false;
    }

    private void Copy(object? parameter)
    {
         if (parameter is ClipboardItem item && !string.IsNullOrEmpty(item.Text))
        {
            try
            {
                System.Windows.Clipboard.SetText(item.Text);
                ShowStatus("Copied to clipboard");
            }
            catch { ShowStatus("Failed to copy"); }
        }
    }

    private void Edit(object? parameter)
    {
        if (parameter is ClipboardItem item)
        {
            var dialog = new ClipboardQueueApp.Views.EditWindow(item.Text)
            {
                Owner = System.Windows.Application.Current.MainWindow
            };
            
            if (dialog.ShowDialog() == true)
            {
                item.Text = dialog.ResultText;
                ShowStatus("Item updated");
            }
        }
    }

    private void Delete(object? parameter)
    {
        if (parameter is ClipboardItem item)
        {
            Items.Remove(item);
            ShowStatus("Item deleted");
        }
    }

    private void Pin(object? parameter)
    {
        if (parameter is ClipboardItem item)
        {
            item.IsPinned = !item.IsPinned;
            FilteredItems.Refresh(); // Re-sort
            ShowStatus(item.IsPinned ? "Item pinned" : "Item unpinned");
        }
    }

    private void ClearAll(object? parameter)
    {
        Items.Clear();
        ShowStatus("All items cleared");
    }

    private bool Filter(object obj)
    {
        if (obj is not ClipboardItem item) return false;

        return string.IsNullOrWhiteSpace(Search)
               || item.Text?.Contains(Search, StringComparison.OrdinalIgnoreCase) == true;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}