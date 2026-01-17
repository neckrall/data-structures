using DataStructures.Models.LinkedLists;

namespace DataStructures.Tests;

public abstract class LinkedListsTests<TItem> where TItem : LinkedListItemBase<int?>
{
    protected const int DefaultValue = 8;
    protected const int FirstValue = 1;
    protected const int LastValue = 2;
    protected const int ExpectedSingleItemCount = 1;
    protected const int ExpectedTwoItemsCount = 2;

    #region Helpers
    protected abstract LinkedListBase<TItem, int?> InitializeList();

    protected LinkedListBase<TItem, int?> GetEmptyList() => InitializeList();

    protected LinkedListBase<TItem, int?> GetOneItemList() 
    { 
        var list = InitializeList();
        list.Add(FirstValue);
        return list;
    }

    protected LinkedListBase<TItem, int?> GetTwoItemsList() 
    {
        var list = InitializeList();
        list.Add(FirstValue);
        list.Add(LastValue);
        return list;
    }

    protected void AssertSingleItemListState(LinkedListBase<TItem, int?> list) 
    {
        Assert.NotNull(list.First);
        Assert.NotNull(list.Last);
        Assert.Same(list.First, list.Last);
        Assert.Equal(ExpectedSingleItemCount, list.Count);

        // Each successor implements links in nodes in its own way.
        Assert.True(CheckOneItemListReferences(list));
    }

    protected abstract bool CheckOneItemListReferences(LinkedListBase<TItem, int?> list);

    protected void AssertTwoItemsListState(LinkedListBase<TItem, int?> list, int? expectedFirstValue, int? expectedLastValue) 
    {
        Assert.Equal(expectedFirstValue, list.First!.Value);
        Assert.Equal(expectedLastValue, list.Last!.Value);
        Assert.Equal(ExpectedTwoItemsCount, list.Count);
    }
    #endregion

    #region Add
    [Fact]
    public void Add_WhenListIsEmpty_ShouldSetFirstAndLastToSameItem() 
    {
        // Arrange
        var list = GetEmptyList();

        // Act
        list.Add(DefaultValue);

        // Assert
        AssertSingleItemListState(list);
    }

    [Fact]
    public void Add_WhenListIsNotEmpty_ShouldAppendItemToEnd() 
    {
        // Arrange
        var list = GetOneItemList();

        // Act
        list.Add(DefaultValue);

        // Assert
        AssertTwoItemsListState(list, FirstValue, DefaultValue);
    }
    #endregion

    #region AddToBegin
    [Fact]
    public void AddToBegin_WhenListIsEmpty_ShouldSetFirstAndLastToSameItem() 
    {
        // Arrange
        var list = GetEmptyList();

        // Act
        list.AddToBegin(DefaultValue);

        // Assert
        AssertSingleItemListState(list);
    }

    [Fact]
    public void AddToBegin_WhenListIsNotEmpty_ShouldPrependItem() 
    {
        // Arrange
        var list = GetOneItemList();

        // Act
        list.AddToBegin(DefaultValue);

        // Assert
        AssertTwoItemsListState(list, DefaultValue, FirstValue);
    }
    #endregion

    #region AddAfter
    // For the purposes of this project, tests assume that a valid list item is passed as a parameter.
    [Fact]
    public void AddAfter_WhenListHasOneItem_ShouldKeepFirstAndUpdateLast() { }

    [Fact]
    public void AddAfter_WhenTargetItemIsValid_ShouldIncreaseCountAndKeepBoundaries() { }

    [Fact]
    public void AddAfter_WhenTargetIsInMiddle_ShouldIncreaseCountAndKeepBoundaries() { }
    #endregion

    #region AddBefore
    // For the purposes of this project, tests assume that a valid list item is passed as a parameter.
    [Fact]
    public void AddBefore_WhenListHasOneItem_ShouldUpdateFirstAndKeepLast() { }

    [Fact]
    public void AddBefore_WhenTargetItemIsValid_ShouldIncreaseCountAndKeepBoundaries() { }

    [Fact]
    public void AddBefore_WhenTargetIsInMiddle_ShouldIncreaseCountAndKeepBoundaries() { }
    #endregion

    #region Find
    [Fact]
    public void Find_WhenValueIsNotPresent_ShouldReturnNull() { }

    [Fact]
    public void Find_WhenValueIsPresent_ShouldReturnMatchingItem() { }

    [Fact]
    public void Find_WhenValueIsNull_ShouldFindNullItem() { }
    #endregion

    #region RemoveFirst
    [Fact]
    public void RemoveFirst_WhenListIsEmpty_ShouldReturnFalse() { }

    [Fact]
    public void RemoveFirst_WhenListHasOneItem_ShouldRemoveItemAndReturnTrue() { }

    [Fact]
    public void RemoveFirst_WhenListHasTwoItems_ShouldRemoveFirstItemAndReturnTrue() { }
    #endregion

    #region RemoveLast
    [Fact]
    public void RemoveLast_WhenListIsEmpty_ShouldReturnFalse() { }

    [Fact]
    public void RemoveLast_WhenListHasOneItem_ShouldRemoveItemAndReturnTrue() { }

    [Fact]
    public void RemoveLast_WhenListHasTwoItems_ShouldRemoveLastItemAndReturnTrue() { }
    #endregion

    #region Remove(TItem item)
    /*
     Remove(TItem item) assumes that the provided item belongs to the list.
     Passing an item from another list results in undefined behavior.
     */
    [Fact]
    public void Remove_WhenListHasOneItem_ShouldClearListAndReturnTrue() { }

    [Fact]
    public void Remove_WhenRemovingFirstItem_ShouldUpdateFirst() { }

    [Fact]
    public void Remove_WhenRemovingLastItem_ShouldUpdateLast() { }

    [Fact]
    public void Remove_WhenRemovingMiddleItem_ShouldKeepBoundaries() { }
    #endregion

    #region Remove(TValue value)
    [Fact]
    public void RemoveByValue_WhenListIsEmpty_ShouldReturnFalse() { }

    [Fact]
    public void RemoveByValue_WhenValueIsNotFound_ShouldReturnFalse() { }

    [Fact]
    public void RemoveByValue_WhenListHasOneItem_ShouldClearListAndReturnTrue() { }

    [Fact]
    public void RemoveByValue_WhenRemovingFirstItem_ShouldUpdateFirst() { }

    [Fact]
    public void RemoveByValue_WhenRemovingLastItem_ShouldUpdateLast() { }

    [Fact]
    public void RemoveByValue_WhenRemovingMiddleItem_ShouldKeepBoundaries() { }
    #endregion
}
