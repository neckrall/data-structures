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

    #region AddToBegin
    [Fact]
    public void AddToBegin_WhenListIsEmpty_ShouldSetFirstAndLastToSameItem() 
    {
        // Arrange
        var list = CreateList();
        var value = 8;
        var count = 1;

        // Act
        list.AddToBegin(value);

        // Assert
        Assert.NotNull(list.First);
        Assert.NotNull(list.Last);

        Assert.Equal(value, list.First.Value);
        Assert.Equal(value, list.Last.Value);
        Assert.Equal(count, list.Count);

        Assert.Same(list.First, list.Last);
    }

    [Fact]
    public void AddToBegin_WhenListIsNotEmpty_ShouldPrependItem() 
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var lastValue = 2;
        var count = 2;

        list.Add(firstValue);

        // Act
        list.AddToBegin(lastValue);

        // Assert
        Assert.NotNull(list.First);
        Assert.NotNull(list.Last);

        Assert.Equal(lastValue, list.First.Value);
        Assert.Equal(firstValue, list.Last.Value);
        Assert.Equal(count, list.Count);
    }
    #endregion

    #region AddAfter
    /*
    For simplicity, item ownership is not tracked.
    As a result, passing an item that does not belong to the list leads to undefined behavior.
    Tracking item ownership would allow O(1) validation but would introduce additional complexity and invariants.
     */
    [Fact]
    public void AddAfter_WhenTargetItemIsValid_ShouldIncreaseCountAndKeepBoundaries()
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;
        var count = 3;

        list.Add(firstValue);
        list.Add(lastValue);

        // Act
        var middle = list.AddAfter(list.First!, middleValue);

        // Assert
        // The exact positioning of the inserted item is validated in implementation-specific tests.
        Assert.NotNull(list.First);
        Assert.NotNull(middle);
        Assert.NotNull(list.Last);

        Assert.Equal(firstValue, list.First.Value);
        Assert.Equal(lastValue, list.Last.Value);
        Assert.Equal(count, list.Count);
    }
    #endregion

    #region AddBefore
    /*
    For simplicity, item ownership is not tracked.
    As a result, passing an item that does not belong to the list leads to undefined behavior.
    Tracking item ownership would allow O(1) validation but would introduce additional complexity and invariants.
     */
    [Fact]
    public void AddBefore_WhenTargetItemIsValid_ShouldIncreaseCountAndPreserveBoundaries() 
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;
        var count = 3;

        list.Add(firstValue);
        list.Add(lastValue);

        // Act
        var middle = list.AddBefore(list.Last!, middleValue);

        // Assert
        // The exact positioning of the inserted item is validated in implementation-specific tests.
        Assert.NotNull(list.First);
        Assert.NotNull(middle);
        Assert.NotNull(list.Last);

        Assert.Equal(firstValue, list.First.Value);
        Assert.Equal(lastValue, list.Last.Value);
        Assert.Equal(count, list.Count);
    }
    #endregion

    #region Find
    [Fact]
    public void Find_WhenValueIsNotPresent_ShouldReturnNull() 
    {
        // Arrange
        var emptyList = CreateList();
        var list = CreateList();
        var valueToAdd = 1;
        var valueToFind = 2;

        list.Add(valueToAdd);

        // Act
        var emptyListResult = emptyList.Find(valueToFind);
        var listResult = list.Find(valueToFind);

        // Assert
        Assert.Null(emptyListResult);
        Assert.Null(listResult);
    }
    [Fact]
    public void Find_WhenValueIsPresent_ShouldReturnMatchingItem() 
    {
        // Arrange
        var list = CreateList();
        var value = 8;

        list.Add(value);

        // Act
        var result = list.Find(value);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result, list.First);
    }
    #endregion

    #region RemoveFirst
    [Fact]
    public void RemoveFirst_WhenListIsEmpty_ShouldReturnFalse() 
    {
        // Arrange
        var list = CreateList();
        var expectedResult = false;
        var count = 0;

        // Act
        var result = list.RemoveFirst();

        // Assert
        Assert.Null(list.First);
        Assert.Null(list.Last);

        Assert.Equal(expectedResult, result);
        Assert.Equal(count, list.Count);
    }

    [Fact]
    public void RemoveFirst_WhenListHasOneItem_ShouldRemoveItemAndReturnTrue() 
    {
        // Arrange
        var list = CreateList();
        var value = 8;
        var expectedResult = true;
        var expectedCount = 0;

        list.Add(value);

        // Act
        var result = list.RemoveFirst();

        // Assert
        Assert.Null(list.First);
        Assert.Null(list.Last);

        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedCount, list.Count);
    }

    [Fact]
    public void RemoveFirst_WhenListHasTwoItems_ShouldRemoveFirstItemAndReturnTrue()
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var lastValue = 2;
        var expectedResult = true;
        var expectedCount = 1;

        list.Add(firstValue);
        list.Add(lastValue);

        // Act
        var result = list.RemoveFirst();

        // Assert
        Assert.NotNull(list.First);
        Assert.NotNull(list.Last);

        Assert.Same(list.First, list.Last);

        Assert.Equal(lastValue, list.First.Value);
        Assert.Equal(lastValue, list.Last.Value);
        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedCount, list.Count);
    }
    #endregion

    #region RemoveLast
    [Fact]
    public void RemoveLast_WhenListIsEmpty_ShouldReturnFalse() 
    {
        // Arrange
        var list = CreateList();
        var expectedResult = false;
        var count = 0;

        // Act
        var result = list.RemoveLast();

        // Assert
        Assert.Null(list.First);
        Assert.Null(list.Last);

        Assert.Equal(expectedResult, result);
        Assert.Equal(count, list.Count);
    }

    [Fact]
    public void RemoveLast_WhenListHasOneItem_ShouldRemoveItemAndReturnTrue() 
    {
        // Arrange
        var list = CreateList();
        var value = 8;
        var expectedResult = true;
        var expectedCount = 0;

        list.Add(value);

        // Act
        var result = list.RemoveLast();

        // Assert
        Assert.Null(list.First);
        Assert.Null(list.Last);

        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedCount, list.Count);
    }

    [Fact]
    public void RemoveLast_WhenListHasTwoItems_ShouldRemoveLastItemAndReturnTrue()
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var lastValue = 2;
        var expectedResult = true;
        var expectedCount = 1;

        list.Add(firstValue);
        list.Add(lastValue);

        // Act
        var result = list.RemoveLast();

        // Assert
        Assert.NotNull(list.First);
        Assert.NotNull(list.Last);

        Assert.Same(list.First, list.Last);

        Assert.Equal(firstValue, list.First.Value);
        Assert.Equal(firstValue, list.Last.Value);
        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedCount, list.Count);
    }
    #endregion
}
