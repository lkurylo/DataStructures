using System;
using System.Collections.Generic;
using Xunit;

namespace BST
{
    public class BSTTests
    {
        [Fact]
        public void create_node_with_value_provided()
        {
            TreeNode node = new TreeNode(1);

            Assert.Equal(1, node.Data);
            Assert.Null(node.Left);
            Assert.Null(node.Right);
        }

        [Fact]
        public void create_empty_tree_check_constructor_with_empty_node()
        {
            Tree tree = new Tree(null);

            Assert.Null(tree.Root);
        }

        [Fact]
        public void create_empty_tree_check_constructor_with_testing_node()
        {
            var node = new TreeNode(2);
            Tree tree = new Tree(node);

            Assert.NotNull(tree.Root);
            Assert.Equal(node, tree.Root);
            Assert.Equal(2, tree.Root.Data);
        }

        [Fact]
        public void create_left_node_from_root()
        {
            Tree tree = new Tree(10);

            tree.Insert(5);

            Assert.NotNull(tree.Root.Left);
            Assert.Null(tree.Root.Right);
            Assert.Equal(5, tree.Root.Left.Data);
        }

        [Fact]
        public void create_two_left_nodes_from_root()
        {
            Tree tree = new Tree(10);

            tree.Insert(5);
            tree.Insert(3);

            Assert.NotNull(tree.Root.Left);
            Assert.Null(tree.Root.Right);
            Assert.Equal(3, tree.Root.Left.Left.Data);
            Assert.Null(tree.Root.Left.Right);
        }

        [Fact]
        public void create_right_node_from_root()
        {
            Tree tree = new Tree(10);

            tree.Insert(15);

            Assert.NotNull(tree.Root.Right);
            Assert.Null(tree.Root.Left);
            Assert.Equal(15, tree.Root.Right.Data);
        }

        [Fact]
        public void create_two_right_nodes_from_root()
        {
            Tree tree = new Tree(10);

            tree.Insert(15);
            tree.Insert(33);

            Assert.NotNull(tree.Root.Right);
            Assert.Null(tree.Root.Left);
            Assert.Equal(33, tree.Root.Right.Right.Data);
            Assert.Null(tree.Root.Right.Left);
        }

        [Fact]
        public void check_if_all_nodes_are_properly_distributed()
        {
            Tree tree = new Tree(100);

            tree.Insert(50);
            tree.Insert(150);
            tree.Insert(25);
            tree.Insert(75);
            tree.Insert(125);
            tree.Insert(175);

            Assert.Equal(100, tree.Root.Data);
            Assert.Equal(50, tree.Root.Left.Data);
            Assert.Equal(25, tree.Root.Left.Left.Data);
            Assert.Equal(75, tree.Root.Left.Right.Data);
            Assert.Equal(150, tree.Root.Right.Data);
            Assert.Equal(125, tree.Root.Right.Left.Data);
            Assert.Equal(175, tree.Root.Right.Right.Data);
        }

        [Fact]
        public void traverse_tree_in_inorder_manner()
        {
            List<int> result = new List<int>();
            Tree tree = new Tree(10);

            tree.Insert(5);
            tree.Insert(15);
            tree.Insert(1);
            tree.Insert(6);

            tree.Inorder(x =>
            {
                result.Add(x);
            });

            Assert.Equal(5, result.Count);
            Assert.Equal(1, result[0]);
            Assert.Equal(5, result[1]);
            Assert.Equal(6, result[2]);
            Assert.Equal(10, result[3]);
            Assert.Equal(15, result[4]);

        }

        [Fact]
        public void traverse_tree_in_preorder_manner()
        {
            List<int> result = new List<int>();
            Tree tree = new Tree(10);

            tree.Insert(5);
            tree.Insert(15);
            tree.Insert(1);
            tree.Insert(6);

            tree.Preorder(x =>
            {
                result.Add(x);
            });

            Assert.Equal(5, result.Count);
            Assert.Equal(10, result[0]);
            Assert.Equal(5, result[1]);
            Assert.Equal(1, result[2]);
            Assert.Equal(6, result[3]);
            Assert.Equal(15, result[4]);
        }

        [Fact]
        public void traverse_tree_in_postorder_manner()
        {
            List<int> result = new List<int>();
            Tree tree = new Tree(10);

            tree.Insert(5);
            tree.Insert(15);
            tree.Insert(1);
            tree.Insert(6);

            tree.Postorder(x =>
            {
                result.Add(x);
            });

            Assert.Equal(5, result.Count);
            Assert.Equal(1, result[0]);
            Assert.Equal(6, result[1]);
            Assert.Equal(5, result[2]);
            Assert.Equal(15, result[3]);
            Assert.Equal(10, result[4]);
        }

        [Fact]
        public void delete_leaf_node_on_first_level()
        {
            Tree tree = new Tree(10);

            tree.Insert(5);
            tree.Insert(15);

            tree.Delete(5);

            Assert.Null(tree.Root.Left);
            Assert.NotNull(tree.Root.Right);
        }

        [Fact]
        public void delete_leaf_node_on_second_level()
        {
            Tree tree = new Tree(10);

            tree.Insert(5);
            tree.Insert(15);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(11);
            tree.Insert(16);

            tree.Delete(1);

            Assert.NotNull(tree.Root.Left);
            Assert.Null(tree.Root.Left.Left);
            Assert.NotNull(tree.Root.Left.Right);
        }

        [Fact]
        public void delete_node_with_one_child()
        {
            Tree tree = new Tree(10);

            tree.Insert(5);
            tree.Insert(15);
            tree.Insert(1);

            tree.Delete(5);

            Assert.NotNull(tree.Root.Left);
            Assert.NotNull(tree.Root.Right);
            Assert.Equal(1, tree.Root.Left.Data);
        }

        [Fact]
        public void delete_nodes_which_have_two_children_nodes()
        {
            Tree tree = new Tree(100);

            tree.Insert(50);
            tree.Insert(150);
            tree.Insert(25);
            tree.Insert(75);
            tree.Insert(125);
            tree.Insert(60);
            tree.Insert(80);
            tree.Insert(200);

            tree.Delete(50);
            tree.Delete(150);

            Assert.Equal(200, tree.Root.Right.Data);
            Assert.Equal(60, tree.Root.Left.Data);
        }

        [Fact]
        public void delete_root_without_children()
        {
            Tree tree = new Tree(10);

            tree.Delete(10);

            Assert.Null(tree.Root);
        }

        [Fact]
        public void delete_root_with_one_child()
        {
            Tree tree = new Tree(10);

            tree.Insert(15);

            tree.Delete(10);

            Assert.Equal(15, tree.Root.Data);
            Assert.Null(tree.Root.Left);
            Assert.Null(tree.Root.Right);
        }

        [Fact]
        public void delete_root_with_two_children()
        {
            Tree tree = new Tree(10);

            tree.Insert(5);
            tree.Insert(15);

            tree.Delete(10);

            Assert.Equal(15, tree.Root.Data);
            Assert.Null(tree.Root.Right);
            Assert.NotNull(tree.Root.Left);
        }

        [Fact]
        public void throws_exception_when_delete_not_existing_node()
        {
            Tree tree = new Tree(10);

            Assert.Throws<InvalidOperationException>(() => tree.Delete(100));
        }
    }
}
