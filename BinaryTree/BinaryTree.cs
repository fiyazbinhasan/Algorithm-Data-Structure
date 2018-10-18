using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private BinaryTreeNode<T> _head;
        private int _count;

        public void Add(T value)
        {
            if (_head == null)
                _head = new BinaryTreeNode<T>(value);
            else
                AddTo(_head, value);

            _count++;
        }

        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                    node.Left = new BinaryTreeNode<T>(value);
                else
                    AddTo(node.Left, value);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new BinaryTreeNode<T>(value);
                else
                    AddTo(node.Right, value);
            }
        }

        public BinaryTreeNode<T> Search(T value)
        {
            return TreeSearch(_head, value);
        }

        private BinaryTreeNode<T> TreeSearch(BinaryTreeNode<T> node, T value)
        {
            if (node != null)
            {
                var res = value.CompareTo(node.Value);

                if (res < 0)
                    return TreeSearch(node.Left, value);
                else if (res > 0)
                    return TreeSearch(node.Right, value);
                else
                    return node;
            }
            else
                throw new ArgumentException("Entry not found in the binary tree");
        }

        public T FindMinimum()
        {
            BinaryTreeNode<T> current = _head;
            while(current.Left != null)
            {
                current = current.Left;
            }
            return current.Value;
        }

        public T FindMaximum()
        {
            BinaryTreeNode<T> current = _head;
            while (current.Right != null)
            {
                current = current.Right;
            }
            return current.Value;
        }

        public BinaryTreeNode<T> Successor(BinaryTreeNode<T> node)
        {
            if(node.Right != null)
            {
                BinaryTreeNode<T> current = node.Right;
                while(current.Left != null)
                {
                    current = current.Left;
                }
                return current;
            }

            var parent = FindWithParent(node.Value).parent;

            while (parent != null && node == parent.Right)
            {
                node = parent;
                parent = FindWithParent(parent.Value).parent;
            }
            return parent;
        }

        public bool Contains(T value)
        {
            var (node, parent) = FindWithParent(value);
            return node == null ? false : true;
        }

        private (BinaryTreeNode<T> node, BinaryTreeNode<T> parent) FindWithParent(T value)
        {
            BinaryTreeNode<T> current = _head;
            BinaryTreeNode<T> parent = null;

            while (current != null)
            {
                var flag = value.CompareTo(current.Value);

                if (flag < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (flag > 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                    break;
            }

            return (current, parent);
        }

        // if the node does not exists: leave
        // if the node is a leaf (has no left or right): simple remove
        // if the node has no right child: promote the left child in the removed slot
        // if the node has a right child with no left child: promote the right child in the removed slot (connect the left child of the removed node with the new parent)
        // if the node has a right child with left child: promote right child's left most child node in the removed slot (connect left and right of the removed node with the new parent)
        public bool Remove(T value)
        {
            var (current, parent) = FindWithParent(value);
            if(current == null) return false; // not found

            _count--;

            if (current.Right == null)
            {
                if (parent == null)
                    _head = current.Left;
                else
                {
                    var res = value.CompareTo(parent.Value);

                    if (res < 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if (res > 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    _head = current.Right;
                }
                else
                {
                    var res = value.CompareTo(parent.Value);

                    if (res < 0)
                    {
                        parent.Left = current.Right;
                    }
                    else if (res > 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                BinaryTreeNode<T> leftmost = current.Right.Left;
                BinaryTreeNode<T> leftmostParent = current.Right;

                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                leftmost.Left = leftmost.Right;

                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                {
                    _head = leftmost;
                }
                else
                {
                    var res = value.CompareTo(parent.Value);
                    
                    if(res < 0)
                    {
                        parent.Left = leftmost;
                    }
                    else if(res > 0)
                    {
                        parent.Right = leftmost;
                    }
                }
            }
            
            return true;
        }

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, _head);
        }

        private void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, _head);
        }

        private void InOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PreOrderTraversal(action, node.Left);
                action(node.Value);
                PreOrderTraversal(action, node.Right);
            }
        }

        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, _head);
        }

        private void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }

        public IEnumerator<T> InOrderTraversal()
        {
            if(_head != null)
            {
                 Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> current = _head;

                bool goLeftNext = true;
                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    
                    yield return current.Value;
                    
                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count { get { return _count; } }

        public void Clear()
        {
            _head = null;
            _count = 0;
        }
    }
}
