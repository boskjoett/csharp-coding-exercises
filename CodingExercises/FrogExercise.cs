using System;

namespace CodingExercises
{
    /// <summary>
    /// Solution to this coding exercise:
    /// 
    /// A frog can either take a step or jump.
    /// If a step is one inch long and a jump is two inches long in how many 
    /// ways can a frog move the distance N in inches?
    /// 
    /// Write a program that prints all the possible combinations of steps and jumps that
    /// will move a frog a given distance.
    /// 
    /// Example with a distance of 3 inches:
    /// step step step
    /// step jump
    /// jump step
    /// 
    /// https://www.testdome.com/questions/c-sharp/frog/660
    /// </summary>
    class FrogExercise
    {
        const int InchesPerStep = 1;
        const int InchesPerJump = 2;
        int nodeId;
        int combinations;
        int distance;

        public FrogExercise(int distance)
        {
            this.distance = distance;
        }

        public void PrintSolution()
        {
            // Create root node in binary tree
            TreeNode root = new TreeNode()
            {
                UniqueId = nodeId++,
                RemainingDistance = distance,
                Action = "root"
            };

            Console.WriteLine("\nTree nodes");

            // Populate binary tree with possible actions for each node and travelled distance.
            // Each node in the tree represents a travelled distance and a point where the frog 
            // can either take a step or make a jump (if remaining distance is at least one jump long).
            InsertTreeNodeChildren(root);

            Console.WriteLine("----------------------");
            Console.WriteLine($"Possible ways to move {distance} inches:\n");

            // Traverse and print tree nodes
            TraverseAllNodesAndPrintLeafNodeActionsToRoot(root);

            Console.WriteLine("\nNumber of combinations: " + combinations);
            Console.WriteLine("");
        }

        private void InsertTreeNodeChildren(TreeNode node)
        {
            Console.WriteLine($"Id: {node.UniqueId}, Action: {node.Action}, Remaining distance: {node.RemainingDistance}");

            if (node.RemainingDistance >= InchesPerStep)
            {
                node.Step = new TreeNode { UniqueId = nodeId++, Action = "step", RemainingDistance = node.RemainingDistance - InchesPerStep, Parent = node };
                InsertTreeNodeChildren(node.Step);
            }

            if (node.RemainingDistance >= InchesPerJump)
            {
                node.Jump = new TreeNode { UniqueId = nodeId++, Action = "jump", RemainingDistance = node.RemainingDistance - InchesPerJump, Parent = node };
                InsertTreeNodeChildren(node.Jump);
            }
        }

        private void TraverseAllNodesAndPrintLeafNodeActionsToRoot(TreeNode node)
        {
            if (node.Step != null)
            {
                TraverseAllNodesAndPrintLeafNodeActionsToRoot(node.Step);

                if (node.Jump != null)
                {
                    TraverseAllNodesAndPrintLeafNodeActionsToRoot(node.Jump);
                }
            }
            else
            {
                // We have reached a leaf node.
                // Print the actions along the path to the root node.
                PrintActionsToRoot(node);

                combinations++;
            }
        }

        private void PrintActionsToRoot(TreeNode node)
        {
            Console.Write(node.Action + " ");

            if (node.Parent.Action != "root")
            {
                PrintActionsToRoot(node.Parent);
            }
            else
            {
                Console.WriteLine("");
            }
        }

        private class TreeNode
        {
            public TreeNode Parent { get; set; }
            public TreeNode Step { get; set; }
            public TreeNode Jump { get; set; }

            public int UniqueId { get; set; }
            public string Action { get; set; }
            public int RemainingDistance { get; set; }

            public override string ToString()
            {
                return $"Id: {UniqueId}, Action: {Action}, HasStep; {Step != null}, HasJump: {Jump != null}";
            }
        }
    }
}
