using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TreeDataStructure.Model;

namespace TreeDataStructure.Helper
{
    internal class TreeUsingLinkedList
    {
        public static int index = 0;
        internal TreeNode RootNode { get; set; }

        internal void CreateTree()
        {
            Console.WriteLine("Enter the root value");
            int num = Convert.ToInt32(Console.ReadLine());

            QueueUsingLinkedList queue = new QueueUsingLinkedList();

            TreeNode treeNode = new TreeNode(num);
            queue.Enqueue(treeNode);
            RootNode = treeNode;

            while (!queue.IsEmpty())
            {
                TreeNode parentNode = queue.Dequeue();
                Console.WriteLine($"Enter the left child of {parentNode.Data}");
                num = Convert.ToInt32(Console.ReadLine());

                if (num != -1)
                {
                    treeNode = new TreeNode(num);
                    queue.Enqueue(treeNode);

                    parentNode.Lchild = treeNode;
                }

                Console.WriteLine($"Enter the right child of {parentNode.Data}");
                num = Convert.ToInt32(Console.ReadLine());

                if (num != -1)
                {
                    treeNode = new TreeNode(num);
                    queue.Enqueue(treeNode);

                    parentNode.Rchild = treeNode;
                }
            }
        }

        internal void PreOrderTraversal(TreeNode rootNode)
        {
            StackUsingLinkedList stack = new StackUsingLinkedList();

            while (rootNode != null || !stack.IsEmpty())
            {
                if (rootNode == null)
                {
                    rootNode = stack.Pop();
                    rootNode = rootNode.Rchild;
                }
                else
                {
                    Console.Write(rootNode.Data + " ");
                    stack.Push(rootNode);
                    rootNode = rootNode.Lchild;
                };
            }
        }

        internal void RPreOrderTraversal(TreeNode rootNode)
        {
            if (rootNode != null)
            {
                Console.Write(rootNode.Data + " ");
                RPreOrderTraversal(rootNode.Lchild);
                RPreOrderTraversal(rootNode.Rchild);
            }
        }

        internal void InOrderTraversal(TreeNode rootNode)
        {
            StackUsingLinkedList stack = new StackUsingLinkedList();

            while (rootNode != null || !stack.IsEmpty())
            {
                if (rootNode == null)
                {
                    rootNode = stack.Pop();
                    Console.Write(rootNode.Data + " ");
                    rootNode = rootNode.Rchild;
                }
                else
                {
                    stack.Push(rootNode);
                    rootNode = rootNode.Lchild;
                };
            }
        }

        internal void RInOrderTraversal(TreeNode rootNode)
        {
            if (rootNode != null)
            {
                RInOrderTraversal(rootNode.Lchild);
                Console.Write(rootNode.Data + " ");
                RInOrderTraversal(rootNode.Rchild);
            }
        }

        internal void RPostOrderTraversal(TreeNode rootNode)
        {
            if (rootNode != null)
            {
                RPostOrderTraversal(rootNode.Lchild);
                RPostOrderTraversal(rootNode.Rchild);
                Console.Write(rootNode.Data + " ");
            }
        }

        internal void LevelOrderTrversal(TreeNode rootNode)
        {
            QueueUsingLinkedList queue = new QueueUsingLinkedList();

            queue.Enqueue(rootNode);

            while (!queue.IsEmpty())
            {
                rootNode = queue.Dequeue();
                Console.Write(rootNode.Data + " ");
                if (rootNode.Lchild != null)
                    queue.Enqueue(rootNode.Lchild);
                if (rootNode.Rchild != null)
                    queue.Enqueue(rootNode.Rchild);
            };
        }

        internal int RCount(TreeNode rootNode)
        {
            int x, y;

            if (rootNode != null)
            {
                x = RCount(rootNode.Rchild);
                y = RCount(rootNode.Lchild);

                return x + y + 1;
            }

            return 0;
        }

        internal int RFindHeight(TreeNode rootNode)
        {
            int x, y;
            if (rootNode == null)
            {
                return -1;
            }

            x = RFindHeight(rootNode.Lchild);
            y = RFindHeight(rootNode.Rchild);

            if (x > y)
                return x + 1;
            else
                return y + 1;
        }

        internal int RCountLeafNodes(TreeNode rootNode)
        {
            if (rootNode != null)
            {
                if (rootNode.Lchild == null && rootNode.Rchild == null)
                {
                    return 1;
                }

                return RCountLeafNodes(rootNode.Lchild) + RCountLeafNodes(rootNode.Rchild);
            }

            return 0;
        }

        internal int RCountNonLeafNodes(TreeNode rootNode)
        {
            if (rootNode == null || (rootNode.Lchild == null && rootNode.Rchild == null))
            {
                return 0;
            }
            else
            {
                int x, y;

                x = RCountNonLeafNodes(rootNode.Lchild);
                y = RCountNonLeafNodes(rootNode.Rchild);

                return x + y + 1;
            }


        }

        internal TreeNode GenerateTreeFromTraversal(int[] preOrder, int[] inOrder, int low, int high)
        {
            if(low <= high)
            {
                TreeNode treeNode = new TreeNode(preOrder[index]);

                int temp = FindIndex(inOrder, preOrder[index]);

                if(low != temp)
                {
                    index++;
                    treeNode.Lchild = GenerateTreeFromTraversal(preOrder, inOrder, low, temp - 1);
                }

                if (high != temp)
                {
                    index++;
                    treeNode.Rchild = GenerateTreeFromTraversal(preOrder, inOrder, temp + 1, high);
                }
                    
                return treeNode;
            }

            return null;
        }

        private int FindIndex(int[] items, int num)
        {
            int index = 0;

            while(index < items.Length && items[index] != num)
            {
                index++;
            }

            return index;
        }
    }
}
