namespace DataStructures.Models.LinkedLists;

public abstract class LinkedListBase<TItem, TValue> where TItem : LinkedListItemBase<TValue>
{
    // State
    public TItem? First { get; protected set; }
    public TItem? Last { get; protected set; }
    public int Count { get; protected set; }

    // Contracts
    public abstract void Add(TValue value);
    public abstract void AddToBegin(TValue value);
    public abstract TItem AddAfter(TItem targetItem, TValue value);
    public abstract TItem AddBefore(TItem targetItem, TValue value);
    public abstract TItem? Find(TValue value);
    public abstract void RemoveFirst();
    public abstract void RemoveLast();
    public abstract bool Remove(TValue value);
    public abstract bool Remove(TItem item);
}

public abstract class LinkedListItemBase<T> 
{
    protected LinkedListItemBase(T value) => Value = value;

    public T? Value { get; init; }
}
