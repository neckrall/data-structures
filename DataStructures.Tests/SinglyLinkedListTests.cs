using DataStructures.Models.LinkedLists;

namespace DataStructures.Tests;

public sealed class SinglyLinkedListTests : LinkedListsTests<SinglyLinkedListItem<int?>>
{
    protected override LinkedListBase<SinglyLinkedListItem<int?>, int?> CreateList() => new SinglyLinkedList<int?>();

    #region Add
    [Fact]
    public void Add_WhenListIsEmpty_ShouldSetNextToNull() 
    {
        // Arrange
        var list = CreateList();
        var value = 8;

        // Act
        list.Add(value);

        // Assert
        Assert.Null(list.First!.Next);
        Assert.Null(list.Last!.Next);
    }

    [Fact]
    public void Add_WhenListIsNotEmpty_LastNextShouldBeNullAndPreviousShouldPointToIt() 
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var lastValue = 2;

        list.Add(firstValue);

        // Act
        list.Add(lastValue);

        // Assert
        Assert.Same(list.First!.Next, list.Last);
        Assert.Null(list.Last!.Next);
    }
    #endregion

    #region AddToBegin
    [Fact]
    public void AddToBegin_WhenListIsEmpty_ShouldSetNextToNull()
    {
        // Arrange
        var list = CreateList();
        var value = 8;

        // Act
        list.AddToBegin(value);

        // Assert
        Assert.Null(list.First!.Next);
        Assert.Null(list.Last!.Next);
    }

    [Fact]
    public void AddToBegin_WhenListIsNotEmpty_ShouldPrependItemAndLinkNodesCorrectly()
    {
        // Arrange
        var list = CreateList();
        var oldFirstValue = 1;
        var newFirstValue = 2;

        list.Add(oldFirstValue);

        var oldFirstItem = list.First;

        // Act
        list.AddToBegin(newFirstValue);

        // Assert
        Assert.Same(list.First!.Next, oldFirstItem);
        Assert.Null(list.Last!.Next);
    }
    #endregion

    #region RemoveLast
    [Fact]
    public void RemoveLast_WhenListHasTwoItems_ShouldSetLastNextToNull() 
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var lastValue = 2;

        list.Add(firstValue);
        list.Add(lastValue);

        // Act
        list.RemoveLast();

        // Assert
        Assert.Null(list.Last!.Next);
    }

    [Fact]
    public void RemoveLast_WhenListHasMultipleItems_ShouldRelinkLastCorrectly() 
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;

        list.Add(firstValue);
        list.Add(middleValue);
        list.Add(lastValue);

        var expectedLast = list.Find(middleValue);

        // Act
        list.RemoveLast();

        // Assert
        Assert.Same(expectedLast, list.Last);
        Assert.Null(list.Last!.Next);
    }
    #endregion

    #region Remove
    [Fact]
    public void Remove_WhenRemovingFirst_ShouldRelinkFirstCorrectly() 
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;

        list.Add(firstValue);
        list.Add(middleValue);
        list.Add(lastValue);

        var oldFirst = list.First;
        var newFirst = oldFirst!.Next;

        // Act
        list.Remove(oldFirst);

        // Assert
        Assert.Same(newFirst, list.First);
    }

    [Fact]
    public void Remove_WhenRemovingLast_ShouldSetLastNextToNull() 
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;

        list.Add(firstValue);
        list.Add(middleValue);
        list.Add(lastValue);

        // Act
        list.Remove(list.Last!);

        // Assert
        Assert.Null(list.Last!.Next);
    }

    [Fact]
    public void Remove_WhenRemovingMiddle_ShouldRelinkNeighbors() 
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;

        list.Add(firstValue);
        list.Add(middleValue);
        list.Add(lastValue);

        var middleItem = list.Find(middleValue);

        // Act
        list.Remove(middleItem!);

        // Assert
        Assert.Same(list.Last, list.First!.Next);
    }
    #endregion
}
