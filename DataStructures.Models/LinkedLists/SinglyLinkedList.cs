namespace DataStructures.Models.LinkedLists;

public sealed class SinglyLinkedList<T> : LinkedListBase<SinglyLinkedListItem<T>, T>
{
    #region public API methods 
    public override void Add(T value)
    {
        var item = new SinglyLinkedListItem<T>(value);

        if (IsEmpty)
            SetFirstAndLast(item);
        else
            AddToLast(item);
    }

    public override SinglyLinkedListItem<T> AddAfter(SinglyLinkedListItem<T> targetItem, T value)
    {
        var item = new SinglyLinkedListItem<T>(value);

        item.Next = targetItem.Next;
        targetItem.Next = item;

        if (ReferenceEquals(targetItem, Last))
            Last = item;

        Count++;
        return item;
    }

    public override SinglyLinkedListItem<T> AddBefore(SinglyLinkedListItem<T> targetItem, T value)
    {
        throw new NotImplementedException();
    }

    public override void AddToBegin(T value)
    {
        var item = new SinglyLinkedListItem<T>(value);

        if (IsEmpty)
            SetFirstAndLast(item);
        else
            AddToBeginInternal(item);
    }

    public override SinglyLinkedListItem<T>? Find(T value)
    {
        var current = First;

        while (current is not null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
                return current;

            current = current.Next;
        }

        return null;
    }

    public override bool Remove(T value)
    {
        var item = Find(value);

        if (item is null)
            return false;

        Remove(item);
        return true;
    }

    public override bool Remove(SinglyLinkedListItem<T> item)
    {
        if (IsEmpty)
            return false;

        if (Count == 1)
            Reset();
        else if (ReferenceEquals(item, First))
            RemoveFirstInternal();
        else if (ReferenceEquals(item, Last))
            RemoveLastInternal();
        else
            RemoveInternal(item);

        return true;
    }

    public override bool RemoveFirst()
    {
        if (IsEmpty)
            return false;

        if (Count == 1)
            Reset();
        else
            RemoveFirstInternal();

        return true;
    }

    public override bool RemoveLast()
    {
        if (IsEmpty)
            return false;

        if (Count == 1)
            Reset();
        else
            RemoveLastInternal();

        return true;
    }
    #endregion

    #region Internal methods
    private void SetFirstAndLast(SinglyLinkedListItem<T> item) 
    { 
        First = Last = item;
        Count = 1;
    }

    private void AddToLast(SinglyLinkedListItem<T> item) 
    { 
        Last!.Next = item;
        Last = item;
        Count++;
    }

    private void AddToBeginInternal(SinglyLinkedListItem<T> item)
    {
        item.Next = First;
        First = item;
        Count++;
    }

    private void Reset() 
    {
        First = Last = null;
        Count = 0;
    }

    private void RemoveFirstInternal() 
    {
        First = First!.Next;
        Count--;
    }

    private void RemoveLastInternal() 
    {
        Last = FindPrevious(Last!);
        Last.Next = null;
        Count--;
    }

    private void RemoveInternal(SinglyLinkedListItem<T> item) 
    {
        var previous = FindPrevious(item);

        previous.Next = item.Next;
        Count--;
    }

    private SinglyLinkedListItem<T> FindPrevious(SinglyLinkedListItem<T> item) 
    {
        var current = First;

        while (current!.Next is not null) 
        {
            if (ReferenceEquals(current.Next, item))
                return current;

            current = current.Next;
        }

        throw new InvalidOperationException("The specified item is not in the list.");
    }
    #endregion
}

public sealed class SinglyLinkedListItem<T> : LinkedListItemBase<T>
{
    public SinglyLinkedListItem(T value) : base(value) { }

    public SinglyLinkedListItem<T>? Next { get; set; }
}
