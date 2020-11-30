using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace AssemblyBrowser.Models
{
    public class CustomObservableCollection<T> : Collection<T>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void AddElement(T element)
        {
            Add(element);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
