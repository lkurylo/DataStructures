using System;

namespace BST
{
    public class TreeNode
    {
        public int Data { private set; get; }
        public TreeNode Left { private set; get; }
        public TreeNode Right { private set; get; }

        protected TreeNode() { }

        public TreeNode(int data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }

        public TreeNode Insert(int data)
        {
            if (this.Data > data)
            {
                if (this.Left != null)
                {
                    return this.Left.Insert(data);
                }
                else
                {
                    this.Left = new TreeNode(data);
                    return this.Left;
                }
            }
            else if (this.Data < data)
            {
                if (this.Right != null)
                {
                    return this.Right.Insert(data);
                }
                else
                {
                    this.Right = new TreeNode(data);
                    return this.Right;
                }
            }
            else
            {
                return this;
            }
        }

        public bool DeleteLeaf(int data, out bool isRoot)
        {
            isRoot = false;

            if (this.Data == data)
            {
                if (this.Left == null && this.Right == null)
                {
                    isRoot = true;

                    return true;
                }
            }

            if (this.Left != null && this.Left.Data == data)
            {
                if (this.Left.Left == null && this.Left.Right == null)
                {
                    this.Left = null;

                    return true;
                }
            }
            else if (this.Right != null && this.Right.Data == data)
            {
                if (this.Right.Left == null && this.Right.Right == null)
                {
                    this.Right = null;

                    return true;
                }
            }

            return false;
        }

        public bool DeleteWithOneChild(int data)
        {
            if (this.Data == data)
            {
                if (this.Left == null && this.Right != null)
                {
                    this.Data = this.Right.Data;
                    this.Right = null;

                    return true;
                }

                if (this.Left != null && this.Right == null)
                {
                    this.Data = this.Left.Data;
                    this.Left = null;

                    return true;
                }
            }

            if (this.Left != null && this.Left.Data == data)
            {
                if (this.Left.Left == null && this.Left.Right != null)
                {
                    this.Left = this.Left.Right;

                    return true;
                }

                if (this.Left.Left != null && this.Left.Right == null)
                {
                    this.Left = this.Left.Left;

                    return true;
                }
            }

            if (this.Right != null && this.Right.Data == data)
            {
                if (this.Right.Left == null && this.Right.Right != null)
                {
                    this.Right = this.Right.Right;

                    return true;
                }

                if (this.Right.Left == null && this.Right.Right != null)
                {
                    this.Right = this.Right.Left;

                    return true;
                }
            }

            return false;
        }

        public bool DeleteWithTwoChildren(int data)
        {
            bool isRoot;

            if (this.Data == data)
            {
                if (this.Left != null && this.Right != null)
                {
                    int smallestChildValue = FindSmallestValue(this.Right);

                    var smallestValueNodeToRemoveParent =
                        TreeUtilities.GetParentNode(this.Right, smallestChildValue);

                    bool isDeleted = smallestValueNodeToRemoveParent.DeleteLeaf(smallestChildValue, out isRoot);

                    if (isDeleted && isRoot)
                    {
                        this.Right = null;
                    }

                    if (!isDeleted)
                    {
                        isDeleted = smallestValueNodeToRemoveParent.DeleteWithOneChild(smallestChildValue);

                        if (!isDeleted)
                        {
                            return false;
                        }
                    }

                    this.Data = smallestChildValue;

                    return true;
                }
            }

            if (this.Left != null && this.Left.Data == data)
            {
                if (this.Left.Left != null && this.Left.Right != null)
                {
                    int smallestChildValue = FindSmallestValue(this.Left.Right);

                    var smallestValueNodeToRemoveParent =
                                           TreeUtilities.GetParentNode(this.Left, smallestChildValue);

                    bool isDeleted = smallestValueNodeToRemoveParent.DeleteLeaf(smallestChildValue, out isRoot);

                    if (isDeleted && isRoot)
                    {
                        this.Left = null;
                    }

                    if (!isDeleted)
                    {
                        isDeleted = smallestValueNodeToRemoveParent.DeleteWithOneChild(smallestChildValue);

                        if (!isDeleted)
                        {
                            return false;
                        }
                    }

                    this.Left.Data = smallestChildValue;

                    return true;
                }
            }

            if (this.Right != null && this.Right.Data == data)
            {
                if (this.Right.Left != null && this.Right.Right != null)
                {
                    int smallestChildValue = FindSmallestValue(this.Right.Right);

                    var smallestValueNodeToRemoveParent =
                        TreeUtilities.GetParentNode(this.Right, smallestChildValue);

                    bool isDeleted = smallestValueNodeToRemoveParent.DeleteLeaf(smallestChildValue, out isRoot);

                    if (!isDeleted)
                    {
                        isDeleted = smallestValueNodeToRemoveParent.DeleteWithOneChild(smallestChildValue);

                        if (!isDeleted)
                        {
                            return false;
                        }
                    }

                    this.Right.Data = smallestChildValue;

                    return true;
                }
            }

            return false;
        }

        private int FindSmallestValue(TreeNode parent)
        {
            var node = parent;

            while (node.Left != null)
            {
                node = node.Left;
            }

            return node.Data;
        }
    }

    public class Tree
    {
        public TreeNode Root { private set; get; }

        public Tree(TreeNode root)
        {
            this.Root = root;
        }

        public Tree(int data)
        {
            this.Root = new TreeNode(data);
        }

        public TreeNode Insert(int data)
        {
            return this.Root.Insert(data);
        }

        public void Inorder(Action<int> action)
        {
            InorderHelper(this.Root, action);
        }

        private void InorderHelper(TreeNode node, Action<int> action)
        {
            if (node != null)
            {
                InorderHelper(node.Left, action);
                action(node.Data);
                InorderHelper(node.Right, action);
            }
        }

        public void Preorder(Action<int> action)
        {
            PreorderHelper(this.Root, action);
        }

        private void PreorderHelper(TreeNode node, Action<int> action)
        {
            if (node != null)
            {
                action(node.Data);
                PreorderHelper(node.Left, action);
                PreorderHelper(node.Right, action);
            }
        }

        public void Postorder(Action<int> action)
        {
            PostorderHelper(this.Root, action);
        }

        private void PostorderHelper(TreeNode node, Action<int> action)
        {
            if (node != null)
            {
                PostorderHelper(node.Left, action);
                PostorderHelper(node.Right, action);
                action(node.Data);
            }
        }

        public void Delete(int data)
        {
            var parent = TreeUtilities.GetParentNode(this.Root, data);

            if (parent == null)
            {
                parent = this.Root;
            }

            if (parent != null)
            {
                bool isRoot;
                bool deleted = parent.DeleteLeaf(data, out isRoot);

                if (deleted && isRoot)
                {
                    this.Root = null;
                }

                if (!deleted)
                {
                    deleted = parent.DeleteWithOneChild(data);

                    if (!deleted)
                    {
                        deleted = parent.DeleteWithTwoChildren(data);

                        if (!deleted)
                        {
                            throw new InvalidOperationException(
                                "Cannot remove node for value: " + data);
                        }
                    }
                }
            }
        }
    }

    internal static class TreeUtilities
    {
        public static TreeNode GetParentNode(TreeNode node, int data)
        {
            if (node != null)
            {
                if (node.Data == data)
                {
                    return node;
                }

                if (node.Left != null && node.Left.Data == data)
                {
                    return node;
                }

                if (node.Right != null && node.Right.Data == data)
                {
                    return node;
                }

                var leftSubtree = TreeUtilities.GetParentNode(node.Left, data);
                var rightSubtree = TreeUtilities.GetParentNode(node.Right, data);

                return leftSubtree ?? rightSubtree;
            }

            return null;
        }
    }
}
