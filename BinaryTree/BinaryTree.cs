using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        public Node<T> Root;
        private int length;

        public Traversals Traversal { get; set; }
        public BinaryTree()
        {
            this.Root = null;
            this.Traversal = Traversals.PreOrderTraversal;
        }

        public void AddElement(T value)
        {
            try
            {
                AddElement(ref Root, value);
                this.length++;

            }
            catch(Exception)
            {
                throw;
            }
        }

        private void AddElement(ref Node<T> rootNode, T value)
        {
            if (rootNode != null)
            {
                if (value.CompareTo(rootNode.Value) > 0)
                {
                    AddElement(ref rootNode.Right, value);
                }
                else if (value.CompareTo(rootNode.Value) < 0)
                {
                    AddElement(ref rootNode.Left, value);
                }
                else
                {
                    throw new ArgumentException("Element with same value already exists in list");
                }
            }
            else
            {
                rootNode = new Node<T>(value);
            }
        }

        public void RemoveElement(T value)
        {
            if (RemoveNode(Root, value) != null)
            {
                length--;
            }

        }

        private Node<T> RemoveNode(Node<T> root, T value)
        {
            if (root == null)
            {
                return root;
            }
            var compareTo = value.CompareTo(root.Value);
            if (compareTo < 0)
            {
                root.Left = RemoveNode(root.Left, value);
            }
            else if (compareTo > 0)
            {
                root.Right = RemoveNode(root.Right, value);
            }
            else
            {
                if (root.Left == null)
                {
                    root = root.Right;
                }
                else if (root.Right == null)
                {
                    root = root.Left;
                }
                else
                {
                    var min = FindSmallest(root.Right);
                    root.Value = min.Value;
                    root.Right = RemoveNode(root.Right, min.Value);
                }

            }
            return root;
        }

        public int Count
        {
            get
            {
                return length;
            }
        }
        public bool Contains(T value)
        {
            return ContainsRecursive(Root, value);
        }

        private bool ContainsRecursive(Node<T> root, T value)
        {
            if (root == null)
            {
                return false;
            }
            else
            {
                var compareTo = value.CompareTo(root.Value);
                if (compareTo > 0)
                {
                    return ContainsRecursive(root.Right, value);
                }
                else if (compareTo < 0)
                {
                    return ContainsRecursive(root.Left, value);
                }
                else
                {
                    return true;
                }
            }
        }
        private Node<T> FindSmallest(Node<T> node)
        {
            var tmp = node;
            while (tmp.Left != null)
            {
                tmp = tmp.Left;
            }
            return tmp;
        }

        private IEnumerable<T> PreOrderTraversal(Node<T> printNode)
        {
            if (printNode != null)
            {
                if (printNode.Left != null)
                {
                    yield return printNode.Left.Value;
                    foreach (var item in PreOrderTraversal(printNode.Left))
                    {
                        yield return item;
                    }

                }
                if (printNode.Right != null)
                {
                    yield return printNode.Right.Value;
                    foreach (var item in PreOrderTraversal(printNode.Right))
                    {
                        yield return item;
                    }
                }
            }

        }

        private IEnumerable<T> InOrderTraversal(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }
            foreach (var item in InOrderTraversal(node.Left))
            {
                yield return item;
            }
            yield return node.Value;

            foreach (var item in InOrderTraversal(node.Right))
            {
                yield return item;
            }
        }

        private IEnumerable<T> PostOrderTraversal(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            foreach (var item in PostOrderTraversal(node.Left))
            {
                yield return item;
            }

            foreach (var item in PostOrderTraversal(node.Right))
            {
                yield return item;
            }
            yield return node.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Traversal == Traversals.PreOrderTraversal)
            {


                if (Root != null)
                {
                    yield return Root.Value;

                }
                foreach (var item in PreOrderTraversal(Root))
                {
                    yield return item;
                }
            }
            else if (Traversal == Traversals.InOrderTraversal)
            {
                foreach (var item in InOrderTraversal(Root))
                {
                    yield return item;
                }
            }
            else
            {
                foreach (var item in PostOrderTraversal(Root))
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
