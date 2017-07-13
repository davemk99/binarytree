# Binary Tree
Binary tree implementation with C#

Here is some example of using program.Output is 
```
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
```

And you will get this output 
```
f,b,a,d,c,e,i,h,g,k,j
```

Program enumarerates it with pre order traversal method by default.
Also you can change traversal method.
There are three methods,in order traversal,pre order traversal and post order traversal.
Here is Post order traversal example.
```
binaryTree.Traversal = Traversals.PostOrderTraversal;
```
