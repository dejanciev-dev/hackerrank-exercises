using HackerRank.Solutions.DataStructures;

namespace HackerRank.Solutions.Tests;

public class TreeTests
{
    [Fact]
    public void BstInsertion_KeepsInorderSorted()
    {
        var root = Build.Bst(4, 2, 3, 1, 7);
        root = BstInsertion.Solve(root, 6);

        Assert.Equal(4, root.Data);
        Assert.Equal([1, 2, 3, 4, 6, 7], TreeTraversals.Inorder(root));
    }

    [Fact]
    public void TreeHeight_CountsEdges()
    {
        Assert.Equal(3, TreeHeight.Solve(Build.Bst(3, 5, 2, 1, 4, 6, 7)));
        Assert.Equal(0, TreeHeight.Solve(Build.Bst(15)));
    }

    [Fact]
    public void LevelOrderTraversal_VisitsByLevel() =>
        Assert.Equal([1, 2, 5, 3, 6, 4], LevelOrderTraversal.Solve(Build.Bst(1, 2, 5, 3, 6, 4)));

    [Fact]
    public void TreeTraversals_VisitInEachOrder()
    {
        var root = Build.Bst(1, 2, 5, 3, 6, 4);

        Assert.Equal([1, 2, 5, 3, 4, 6], TreeTraversals.Preorder(root));
        Assert.Equal([1, 2, 3, 4, 5, 6], TreeTraversals.Inorder(root));
        Assert.Equal([4, 3, 6, 5, 2, 1], TreeTraversals.Postorder(root));
    }

    [Theory]
    [InlineData(1, 7, 4)]
    [InlineData(1, 3, 2)]
    [InlineData(6, 7, 7)]
    public void BstLowestCommonAncestor_Samples(int v1, int v2, int expected) =>
        Assert.Equal(expected, BstLowestCommonAncestor.Solve(Build.Bst(4, 2, 3, 1, 7, 6), v1, v2).Data);

    [Fact]
    public void IsBinarySearchTree_AcceptsValidTree() =>
        Assert.True(IsBinarySearchTree.Solve(Build.Bst(4, 2, 6, 1, 3, 5, 7)));

    [Fact]
    public void IsBinarySearchTree_RejectsViolationDeeperThanParent()
    {
        // 4 is a valid right child of 2, but it sits in the left subtree of 3.
        var root = new Node(3)
        {
            Left = new Node(2) { Left = new Node(1), Right = new Node(4) },
            Right = new Node(5),
        };

        Assert.False(IsBinarySearchTree.Solve(root));
    }

    [Fact]
    public void IsBinarySearchTree_RejectsDuplicates()
    {
        var root = new Node(2) { Right = new Node(2) };
        Assert.False(IsBinarySearchTree.Solve(root));
    }

    [Fact]
    public void TopView_ShowsTopmostNodePerColumn()
    {
        Assert.Equal([1, 2, 5, 6], TopView.Solve(Build.Bst(1, 2, 5, 3, 6, 4)));
        Assert.Equal([1, 2, 4, 6, 7], TopView.Solve(Build.Bst(4, 2, 6, 1, 3, 5, 7)));
    }
}
