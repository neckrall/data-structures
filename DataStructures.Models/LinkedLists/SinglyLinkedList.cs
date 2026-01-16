namespace DataStructures.Models.LinkedLists;

public sealed class SinglyLinkedList<T> : LinkedListBase<SinglyLinkedListItem<T>, T>
{
    public override void Add(T value)
    {
        if (IsEmpty)
            SetFirstAndLast(new SinglyLinkedListItem<T>(value));
        else
            AddToLast(new SinglyLinkedListItem<T>(value));
    }

    public override SinglyLinkedListItem<T> AddAfter(SinglyLinkedListItem<T> targetItem, T value)
    {
        throw new NotImplementedException();
    }

    public override SinglyLinkedListItem<T> AddBefore(SinglyLinkedListItem<T> targetItem, T value)
    {
        throw new NotImplementedException();
    }

    public override void AddToBegin(T value)
    {
        if (IsEmpty)
            SetFirstAndLast(new SinglyLinkedListItem<T>(value));
        else
            AddToBeginInternal(new SinglyLinkedListItem<T>(value));
    }

    public override SinglyLinkedListItem<T>? Find(T value)
    {
        throw new NotImplementedException();
    }

    public override bool Remove(T value)
    {
        throw new NotImplementedException();
    }

    public override bool Remove(SinglyLinkedListItem<T> item)
    {
        throw new NotImplementedException();
    }

    public override bool RemoveFirst()
    {
        throw new NotImplementedException();
    }

    public override bool RemoveLast()
    {
        throw new NotImplementedException();
    }

    private void SetFirstAndLast(SinglyLinkedListItem<T> item) 
    { 
        First = item;
        Last = item;
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
}

public sealed class SinglyLinkedListItem<T> : LinkedListItemBase<T>
{
    public SinglyLinkedListItem(T value) : base(value) { }

    public SinglyLinkedListItem<T>? Next { get; set; }
}
