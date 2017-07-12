using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Node<T> where T:IComparable
    {
        public T Value { get; set; }

        public Node<T> Left;

        public Node<T> Right;

        public Node(T value)
        {
            this.Value = value;
        }
    }
}
