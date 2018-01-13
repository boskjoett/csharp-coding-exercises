using System;

namespace CodingExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance;

            // Prompt user for distance
            Console.Write("Enter distance: ");
            string s = Console.ReadLine();
            distance = int.Parse(s);

            FrogExercise frogExercise = new FrogExercise(distance);
            frogExercise.PrintSolution();
        }
    }
}
