using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T>:IEnumerable<T> where T:IComparable
    {
        public Node<T> Root;
        private int length;
        public BinaryTree()
        {
            this.Root = null;
        }

        public void AddElement(T value)
        {
            AddElement(ref Root, value);
        }

        private void AddElement(ref Node<T> rootNode,T value)
        {
            if (rootNode!=null)
            {
                if (value.CompareTo(rootNode.Value)>0)
                {
                    AddElement(ref rootNode.Right,value);
                }
                else if (value.CompareTo(rootNode.Value)<0)
                {
                    AddElement(ref rootNode.Left,value);
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
            this.length++;
        }

        public void RemoveElement(T value)
        {
            RemoveNode(Root, value);
        }

        private Node<T> RemoveNode(Node<T> root, T value)
        {
            if (root==null)
            {
                return root;
            }
            var compareTo = value.CompareTo(root.Value);
            if (compareTo<0)
            {
                root.Left = RemoveNode(root.Left, value);
            }
            else if (compareTo>0)
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

        private Node<T> FindSmallest(Node<T> node)
        {
            var tmp = node;
            while (tmp.Left!=null)
            {
                tmp = tmp.Left;
            }
            return tmp;
        }

        private IEnumerable<T> PreOrderTraversal(Node<T> printNode)
        {
            if (printNode!=null)
            {
                if (printNode.Left!=null)
                {
                    yield return printNode.Left.Value;
                    foreach (var item in PreOrderTraversal(printNode.Left))
                    {
                        yield return item;
                    }
                 
                }
                if (printNode.Right!=null)
                {
                    yield return printNode.Right.Value;
                    foreach (var item in PreOrderTraversal(printNode.Right))
                    {
                        yield return item;
                    }
                }
            }
            
        }

        public IEnumerator<T> GetEnumerator()
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
