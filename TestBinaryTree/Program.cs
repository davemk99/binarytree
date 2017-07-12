using BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<char> binaryTree = new BinaryTree<char>();
            binaryTree.AddElement('f');
            binaryTree.AddElement('b');
            binaryTree.AddElement('a');
            binaryTree.AddElement('d');
            binaryTree.AddElement('c');
            binaryTree.AddElement('e');
            binaryTree.AddElement('i');
            binaryTree.AddElement('h');
            binaryTree.AddElement('k');
            binaryTree.AddElement('j');
            binaryTree.AddElement('g');
            Console.WriteLine(string.Join(",", binaryTree));
        }
    }
}
