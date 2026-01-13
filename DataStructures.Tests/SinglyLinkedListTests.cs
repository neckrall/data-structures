using DataStructures.Models.LinkedLists;

namespace DataStructures.Tests;

public sealed class SinglyLinkedListTests : LinkedListsTests<SinglyLinkedListItem<int>>
{
    protected override LinkedListBase<SinglyLinkedListItem<int>, int> CreateList() => new SinglyLinkedList<int>();
}
