using System;
using System.Linq;
using TreeDataStructure.Helper;

namespace TreeDataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeUsingLinkedList tree = new TreeUsingLinkedList();

            while (true)
            {
                Console.WriteLine
                    ("Please select an option" +
                        Environment.NewLine + "1. Create Tree" +
                        Environment.NewLine + "2. In-order Traversal" +
                        Environment.NewLine + "3. Level-order Traversal" +
                        Environment.NewLine + "4. Generate tree from traversal" +
                        Environment.NewLine + "0. Exit"
                    );

                if (!int.TryParse(Console.ReadLine(), out int i))
                {
                    Console.WriteLine(Environment.NewLine + "Input format is not valid. Please try again." + Environment.NewLine);
                }

                if (i == 0)
                {
                    Environment.Exit(0);
                }
                else if (i == 1)
                {
                    tree.CreateTree();
                }
                else if (i == 2)
                {
                    tree.RInOrderTraversal(tree.RootNode);
                    Console.WriteLine();
                }
                else if (i == 3)
                {
                    tree.LevelOrderTrversal(tree.RootNode);
                    Console.WriteLine();
                }
                else if (i == 4)
                {
                    Console.WriteLine("Enter the tree pre-order traversal form(comma separated)");
                    int[] preOrder = Console.ReadLine().Split(',').Select(x => Convert.ToInt32(x.Trim())).ToArray(); // 4,7,9,6,3,2,5,8,1

                    Console.WriteLine("Enter the tree in-order traversal form(comma separated)");
                    int[] inOrder = Console.ReadLine().Split(',').Select(x => Convert.ToInt32(x.Trim())).ToArray(); // 7,6,9,3,4,5,8,2,1

                    tree.RootNode = tree.GenerateTreeFromTraversal(preOrder, inOrder, 0, inOrder.Length - 1);
                }
                else
                {
                    Console.WriteLine("Please select a valid option.");
                }
            }
        }
    }
}
