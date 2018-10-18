using System;

namespace BinaryTree
{
    public class BinaryTreeNode<T> : IComparable<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Left { get; set; }
    
        public BinaryTreeNode<T> Right { get; set; }

        public T Value { get; private set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }
    }
}
