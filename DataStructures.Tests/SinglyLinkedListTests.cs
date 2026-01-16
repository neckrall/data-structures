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
}
