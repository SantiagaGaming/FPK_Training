using System.Collections.Generic;

namespace AosSdk.Core.Utils
{
    public class CommandList<T> : List<T>
    {
        public delegate void ItemAddHandler(T item);
        
        public event ItemAddHandler OnItemAdded;

        public new void Add(T item)
        {
            OnItemAdded?.Invoke(item);
            base.Add(item);
        } 
    }
}