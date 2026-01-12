using DataStructures.Models.LinkedLists;

namespace DataStructures.Tests;

public abstract class LinkedListsTests<TItem> where TItem : LinkedListItemBase<int>
{
    protected abstract LinkedListBase<TItem, int> CreateList();

    #region Add
    [Fact]
    public void Add_WhenListIsEmpty_ShouldSetFirstAndLastToSameItem() 
    {
        // Arrange
        var list = CreateList();
        var value = 8;
        var count = 1;

        // Act
        list.Add(value);

        // Assert
        Assert.NotNull(list.First);
        Assert.NotNull(list.Last);

        Assert.Equal(value, list.First.Value);
        Assert.Equal(value, list.Last.Value);
        Assert.Equal(count, list.Count);

        Assert.Same(list.First, list.Last);
    }

    [Fact]
    public void Add_WhenListIsNotEmpty_ShouldAppendItemToEnd() 
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var lastValue = 2;
        var count = 2;

        list.Add(firstValue);

        // Act
        list.Add(lastValue);

        // Assert
        Assert.NotNull(list.First);
        Assert.NotNull(list.Last);

        Assert.Equal(firstValue, list.First.Value);
        Assert.Equal(lastValue, list.Last.Value);
        Assert.Equal(count, list.Count);
    }
    #endregion
}
