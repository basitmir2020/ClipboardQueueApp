using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;
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
    }

    private void Delete(object? parameter)
    {
        if (parameter is ClipboardItem item)
        {
            Items.Remove(item);
        }
    }

    private void Pin(object? parameter)
    {
        if (parameter is ClipboardItem item)
        {
            item.IsPinned = !item.IsPinned;
            FilteredItems.Refresh(); // Re-sort
        }
    }

    private void ClearAll(object? parameter)
    {
        Items.Clear();
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