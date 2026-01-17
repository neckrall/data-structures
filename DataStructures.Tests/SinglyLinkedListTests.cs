using DataStructures.Models.LinkedLists;

namespace DataStructures.Tests;

public sealed class SinglyLinkedListTests : LinkedListsTests<SinglyLinkedListItem<int?>>
{
    protected override LinkedListBase<SinglyLinkedListItem<int?>, int?> InitializeList() => new SinglyLinkedList<int?>();

    #region Add
    [Fact]
    public void Add_WhenListIsEmpty_ShouldSetNextToNull() 
    {
        // Arrange
        var list = InitializeList();
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
        var list = InitializeList();
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
        var list = InitializeList();
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
        var list = InitializeList();
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
        var list = InitializeList();
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
        var list = InitializeList();
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
        var list = InitializeList();
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
        var list = InitializeList();
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
        var list = InitializeList();
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

    #region AddAfter
    [Fact]
    public void AddAfter_WhenTargetIsInMiddle_ShouldRelinkNextCorrectly()
    {
        // Arrange
        var list = InitializeList();
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;
        var newValue = 8;

        list.Add(firstValue);
        list.Add(middleValue);
        list.Add(lastValue);

        var target = list.Find(middleValue)!;
        var oldNext = target.Next;

        // Act
        var insertedItem = list.AddAfter(target, newValue);

        // Assert
        Assert.Same(insertedItem, target.Next);
        Assert.Same(oldNext, insertedItem.Next);
    }

    [Fact]
    public void AddAfter_WhenTargetIsLast_ShouldUpdateLastAndSetNextToNull()
    {
        // Arrange
        var list = InitializeList();
        var firstValue = 1;
        var lastValue = 2;
        var newValue = 99;

        list.Add(firstValue);
        list.Add(lastValue);

        var target = list.Last!;

        // Act
        var insertedItem = list.AddAfter(target, newValue);

        // Assert
        Assert.Same(insertedItem, list.Last);
        Assert.Null(insertedItem.Next);
        Assert.Same(insertedItem, target.Next);
    }

    [Fact]
    public void AddAfter_WhenListHasOneItem_ShouldKeepFirstAndUpdateLastLink()
    {
        // Arrange
        var list = InitializeList();
        var value = 1;
        var newValue = 2;

        list.Add(value);

        var target = list.First!;

        // Act
        var insertedItem = list.AddAfter(target, newValue);

        // Assert
        Assert.Same(target, list.First);
        Assert.Same(insertedItem, list.Last);
        Assert.Same(insertedItem, target.Next);

        Assert.Null(insertedItem.Next);
    }
    #endregion

    #region AddBefore
    [Fact]
    public void AddBefore_WhenTargetIsInMiddle_ShouldRelinkNextCorrectly()
    {
        // Arrange
        var list = InitializeList();
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;
        var newValue = 8;

        list.Add(firstValue);
        list.Add(middleValue);
        list.Add(lastValue);

        var target = list.Find(middleValue);
        var previous = list.Find(firstValue);

        // Act
        var insertedItem = list.AddBefore(target!, newValue);

        // Assert
        Assert.Same(insertedItem, previous!.Next);
        Assert.Same(target, insertedItem.Next);
    }

    [Fact]
    public void AddBefore_WhenTargetIsFirst_ShouldUpdateFirstAndLinkCorrectly()
    {
        // Arrange
        var list = InitializeList();
        var firstValue = 1;
        var newValue = 2;

        list.Add(firstValue);

        var target = list.First;

        // Act
        var insertedItem = list.AddBefore(target!, newValue);

        // Assert
        Assert.Same(insertedItem, list.First);
        Assert.Same(target, insertedItem.Next);
    }

    [Fact]
    public void AddBefore_WhenTargetIsLast_ShouldLinkPreviousToNewItem()
    {
        // Arrange
        var list = InitializeList();
        var firstValue = 1;
        var lastValue = 2;
        var newValue = 3;

        list.Add(firstValue);
        list.Add(lastValue);

        var target = list.Last;
        var previous = list.First;

        // Act
        var insertedItem = list.AddBefore(target!, newValue);

        // Assert
        Assert.Same(insertedItem, previous!.Next);
        Assert.Same(target, insertedItem.Next);
        Assert.Same(target, list.Last);
    }
    #endregion
}
