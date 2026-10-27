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
    public void SelfBalancingTree_StaysBalancedAndSorted()
    {
        var random = new Random(107);
        for (int trial = 0; trial < 50; trial++)
        {
            AvlNode? root = null;
            var values = Enumerable.Range(0, random.Next(1, 60)).Select(_ => random.Next(0, 100)).ToArray();
            foreach (var value in values)
            {
                root = SelfBalancingTree.Insert(root, value);
            }

            var inorder = new List<int>();
            int Check(AvlNode? node)
            {
                if (node is null)
                {
                    return -1;
                }

                int left = Check(node.Left);
                inorder.Add(node.Value);
                int right = Check(node.Right);

                Assert.InRange(left - right, -1, 1);
                Assert.Equal(1 + Math.Max(left, right), node.Height);
                return node.Height;
            }

            Check(root);
            Assert.Equal(values.Order(), inorder);
        }
    }

    [Fact]
    public void SelfBalancingTree_RotatesOnAscendingInserts()
    {
        AvlNode? root = null;
        foreach (var value in new[] { 3, 2, 4, 5, 6 })
        {
            root = SelfBalancingTree.Insert(root, value);
        }

        Assert.Equal(3, root!.Value);
        Assert.Equal(5, root.Right!.Value);
        Assert.Equal(2, root.Height);
    }

    [Fact]
    public void HuffmanDecoding_Sample()
    {
        // A = 1, B = 00, C = 01, the tree for "ABACA".
        var root = new HuffmanNode
        {
            Left = new HuffmanNode { Left = new HuffmanNode('B'), Right = new HuffmanNode('C') },
            Right = new HuffmanNode('A'),
        };

        Assert.Equal("ABACA", HuffmanDecoding.Solve(root, "1001011"));
    }

    [Fact]
    public void TopView_ShowsTopmostNodePerColumn()
    {
        Assert.Equal([1, 2, 5, 6], TopView.Solve(Build.Bst(1, 2, 5, 3, 6, 4)));
        Assert.Equal([1, 2, 4, 6, 7], TopView.Solve(Build.Bst(4, 2, 6, 1, 3, 5, 7)));
    }
}
