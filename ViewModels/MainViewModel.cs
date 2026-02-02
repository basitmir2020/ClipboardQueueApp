using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
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

    public MainViewModel()
    {
        Items = new ObservableCollection<ClipboardItem>();
        FilteredItems = CollectionViewSource.GetDefaultView(Items);
        FilteredItems.Filter = Filter;
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