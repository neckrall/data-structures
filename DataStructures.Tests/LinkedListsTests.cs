using DataStructures.Models.LinkedLists;

namespace DataStructures.Tests;

public abstract class LinkedListsTests<TItem> where TItem : LinkedListItemBase<int?>
{
    protected abstract LinkedListBase<TItem, int?> CreateList();

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
    // For the purposes of this project, tests assume that a valid list item is passed as a parameter.
    [Fact]
    public void AddAfter_WhenListHasOneItem_ShouldKeepFirstAndUpdateLast() 
    {
        // Arrange
        var list = CreateList();
        var value = 1;
        var newValue = 2;
        var count = 2;

        list.Add(value);

        var target = list.First;

        // Act
        var newItem = list.AddAfter(target!, newValue);

        // Assert
        Assert.Same(target, list.First);
        Assert.Same(newItem, list.Last);

        Assert.Equal(count, list.Count);
    }

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

        var target = list.First!;

        // Act
        var middleItem = list.AddAfter(target, middleValue);

        // Assert
        Assert.NotNull(list.First);
        Assert.NotNull(middleItem);
        Assert.NotNull(list.Last);

        Assert.Equal(firstValue, list.First.Value);
        Assert.Equal(lastValue, list.Last.Value);
        Assert.Equal(count, list.Count);
    }

    [Fact]
    public void AddAfter_WhenTargetIsInMiddle_ShouldIncreaseCountAndKeepBoundaries() 
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;
        var count = 3;

        list.Add(firstValue);
        list.Add(lastValue);

        var target = list.First;

        // Act
        var middle = list.AddAfter(target!, middleValue);

        // Assert
        Assert.Same(list.Find(firstValue), list.First);
        Assert.Same(list.Find(lastValue), list.Last);

        Assert.Equal(count, list.Count);
    }
    #endregion

    #region AddBefore
    // For the purposes of this project, tests assume that a valid list item is passed as a parameter.
    [Fact]
    public void AddBefore_WhenListHasOneItem_ShouldUpdateFirstAndKeepLast() 
    {
        // Arrange
        var list = CreateList();
        var value = 1;
        var newValue = 2;
        var count = 2;

        list.Add(value);

        var target = list.First;

        // Act
        var newItem = list.AddBefore(target!, newValue);

        // Assert
        Assert.Same(newItem, list.First);
        Assert.Same(target, list.Last);

        Assert.Equal(count, list.Count);
    }

    [Fact]
    public void AddBefore_WhenTargetItemIsValid_ShouldIncreaseCountAndKeepBoundaries() 
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;
        var count = 3;

        list.Add(firstValue);
        list.Add(lastValue);

        var target = list.Last!;

        // Act
        var middleItem = list.AddBefore(target, middleValue);

        // Assert
        Assert.NotNull(list.First);
        Assert.NotNull(middleItem);
        Assert.NotNull(list.Last);

        Assert.Equal(firstValue, list.First.Value);
        Assert.Equal(lastValue, list.Last.Value);
        Assert.Equal(count, list.Count);
    }

    [Fact]
    public void AddBefore_WhenTargetIsInMiddle_ShouldIncreaseCountAndKeepBoundaries()
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;
        var count = 3;

        list.Add(firstValue);
        list.Add(lastValue);

        var target = list.Last!;

        // Act
        var middleItem = list.AddBefore(target, middleValue);

        // Assert
        Assert.Same(list.Find(firstValue), list.First);
        Assert.Same(list.Find(lastValue), list.Last);

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
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;

        list.Add(firstValue);
        list.Add(middleValue);
        list.Add(lastValue);

        // Act
        var firstItem = list.Find(firstValue);
        var middleItem = list.Find(middleValue);
        var lastItem = list.Find(lastValue);

        // Assert
        Assert.NotNull(firstItem);
        Assert.NotNull(middleItem);
        Assert.NotNull(lastItem);

        Assert.Equal(firstValue, firstItem.Value);
        Assert.Equal(middleValue, middleItem.Value);
        Assert.Equal(lastValue, lastItem.Value);
    }
    [Fact]
    public void Find_WhenValueIsNull_ShouldFindNullItem()
    {
        // Arrange
        var list = CreateList();
        list.Add(null);

        // Act
        var result = list.Find(null);

        // Assert
        Assert.NotNull(result);
        Assert.Null(result.Value);
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

    #region Remove(TItem item)
    /*
     Remove(TItem item) assumes that the provided item belongs to the list.
     Passing an item from another list results in undefined behavior.
     */
    [Fact]
    public void Remove_WhenListHasOneItem_ShouldClearListAndReturnTrue()
    {
        // Arrange
        var list = CreateList();
        var value = 8;
        var expectedResult = true;
        var expectedCount = 0;

        list.Add(value);

        // Act
        var item = list.Find(value);
        var result = list.Remove(item!);

        // Assert
        Assert.Null(list.First);
        Assert.Null(list.Last);

        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedCount, list.Count);
    }

    [Fact]
    public void Remove_WhenRemovingFirstItem_ShouldUpdateFirst()
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;
        var expectedResult = true;
        var expectedCount = 2;

        list.Add(firstValue);
        list.Add(middleValue);
        list.Add(lastValue);

        // Act
        var item = list.Find(firstValue);
        var result = list.Remove(item!);

        // Assert
        Assert.NotNull(list.First);
        Assert.NotNull(list.Last);

        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedCount, list.Count);
        Assert.Equal(middleValue, list.First.Value);
        Assert.Equal(lastValue, list.Last.Value);

        Assert.Same(list.Find(middleValue), list.First);
        Assert.Same(list.Find(lastValue), list.Last);
    }

    [Fact]
    public void Remove_WhenRemovingLastItem_ShouldUpdateLast()
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;
        var expectedResult = true;
        var expectedCount = 2;

        list.Add(firstValue);
        list.Add(middleValue);
        list.Add(lastValue);

        // Act
        var item = list.Find(lastValue);
        var result = list.Remove(item!);

        // Assert
        Assert.NotNull(list.First);
        Assert.NotNull(list.Last);

        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedCount, list.Count);
        Assert.Equal(firstValue, list.First.Value);
        Assert.Equal(middleValue, list.Last.Value);

        Assert.Same(list.Find(firstValue), list.First);
        Assert.Same(list.Find(middleValue), list.Last);
    }

    [Fact]
    public void Remove_WhenRemovingMiddleItem_ShouldKeepBoundaries()
    {
        // Arrange
        var list = CreateList();
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;
        var expectedResult = true;
        var expectedCount = 2;

        list.Add(firstValue);
        list.Add(middleValue);
        list.Add(lastValue);

        // Act
        var item = list.Find(middleValue);
        var result = list.Remove(item!);

        // Assert
        Assert.NotNull(list.First);
        Assert.NotNull(list.Last);

        Assert.Null(list.Find(middleValue));

        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedCount, list.Count);
        Assert.Equal(firstValue, list.First.Value);
        Assert.Equal(lastValue, list.Last.Value);

        Assert.Same(list.Find(firstValue), list.First);
        Assert.Same(list.Find(lastValue), list.Last);
    }
    #endregion

    #region Remove(TValue value)
    [Fact]
    public void RemoveByValue_WhenListIsEmpty_ShouldReturnFalse()
    {
        // Arrange
        var list = CreateList();
        var expectedResult = false;
        var expectedCount = 0;
        var value = 8;

        // Act
        var result = list.Remove(value);

        // Assert
        Assert.Null(list.First);
        Assert.Null(list.Last);

        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedCount, list.Count);
    }

    [Fact]
    public void RemoveByValue_WhenValueIsNotFound_ShouldReturnFalse()
    {
        // Arrange
        var list = CreateList();
        var expectedResult = false;
        var expectedCount = 2;
        var firstValue = 1;
        var lastValue = 2;
        var valueToRemove = 3;

        list.Add(firstValue);
        list.Add(lastValue);

        // Act
        var result = list.Remove(valueToRemove);

        // Assert
        Assert.NotNull(list.First);
        Assert.NotNull(list.Last);

        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedCount, list.Count);
    }

    [Fact]
    public void RemoveByValue_WhenListHasOneItem_ShouldClearListAndReturnTrue()
    {
        // Arrange
        var list = CreateList();
        var expectedResult = true;
        var expectedCount = 0;
        var value = 8;

        list.Add(value);

        // Act
        var result = list.Remove(value);

        // Assert
        Assert.Null(list.First);
        Assert.Null(list.Last);

        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedCount, list.Count);
    }

    [Fact]
    public void RemoveByValue_WhenRemovingFirstItem_ShouldUpdateFirst()
    {
        // Arrange
        var list = CreateList();
        var expectedResult = true;
        var expectedCount = 2;
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;

        list.Add(firstValue);
        list.Add(middleValue);
        list.Add(lastValue);

        // Act
        var result = list.Remove(1);

        // Assert
        Assert.NotNull(list.First);
        Assert.NotNull(list.Last);

        Assert.Same(list.Find(middleValue), list.First);
        Assert.Same(list.Find(lastValue), list.Last);

        Assert.Equal(middleValue, list.First.Value);
        Assert.Equal(lastValue, list.Last.Value);
        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedCount, list.Count);
    }

    [Fact]
    public void RemoveByValue_WhenRemovingLastItem_ShouldUpdateLast()
    {
        // Arrange
        var list = CreateList();
        var expectedResult = true;
        var expectedCount = 2;
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;

        list.Add(firstValue);
        list.Add(middleValue);
        list.Add(lastValue);

        // Act
        var result = list.Remove(lastValue);

        // Assert
        Assert.NotNull(list.First);
        Assert.NotNull(list.Last);

        Assert.Same(list.Find(firstValue), list.First);
        Assert.Same(list.Find(middleValue), list.Last);

        Assert.Equal(firstValue, list.First.Value);
        Assert.Equal(middleValue, list.Last.Value);
        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedCount, list.Count);
    }

    [Fact]
    public void RemoveByValue_WhenRemovingMiddleItem_ShouldKeepBoundaries()
    {
        // Arrange
        var list = CreateList();
        var expectedResult = true;
        var expectedCount = 2;
        var firstValue = 1;
        var middleValue = 2;
        var lastValue = 3;

        list.Add(firstValue);
        list.Add(middleValue);
        list.Add(lastValue);

        // Act
        var result = list.Remove(middleValue);

        // Assert
        Assert.NotNull(list.First);
        Assert.NotNull(list.Last);

        Assert.Null(list.Find(middleValue));

        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedCount, list.Count);
        Assert.Equal(firstValue, list.First.Value);
        Assert.Equal(lastValue, list.Last.Value);

        Assert.Same(list.Find(firstValue), list.First);
        Assert.Same(list.Find(lastValue), list.Last);
    }
    #endregion
}
