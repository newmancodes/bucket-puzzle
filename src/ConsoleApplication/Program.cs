using System;
using System.Collections.Generic;
using Solver;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var solver = new IterativeDeepeningSolver();
            DieHardWithAVengeance(solver);
            TonyProblemWithFilling(solver);
            TonyProblemWithoutFilling(solver);
        }

        private static void DieHardWithAVengeance(IterativeDeepeningSolver solver)
        {
            Console.WriteLine("Die Hard with a Vengeance");
            var builder = new BucketPuzzleBuilder()
                .CanEmpty(true)
                .CanRefill(true)
                .AddEmptyBucket(5)
                .AddEmptyBucket(3);
            var problem = builder.Build(4);
            var solution = solver.Solve(problem);
            DisplaySolution(solution);
        }

        private static void TonyProblemWithFilling(IterativeDeepeningSolver solver)
        {
            Console.WriteLine("Tony Brain Teaser with Filling (cheating) Allowed");
            var builder = new BucketPuzzleBuilder()
                .CanEmpty(true)
                .CanRefill(true)
                .AddFullBucket(12)
                .AddEmptyBucket(8)
                .AddEmptyBucket(5);
            var problem = builder.Build(6);
            var solution = solver.Solve(problem);
            DisplaySolution(solution);
        }

        private static void TonyProblemWithoutFilling(IterativeDeepeningSolver solver)
        {
            Console.WriteLine("Tony Brain Teaser");
            var builder = new BucketPuzzleBuilder()
                .CanEmpty(false)
                .CanRefill(false)
                .AddFullBucket(12)
                .AddEmptyBucket(8)
                .AddEmptyBucket(5);
            var problem = builder.Build(6);
            var solution = solver.Solve(problem);
            DisplaySolution(solution);
        }

        private static void DisplaySolution(BucketPuzzleSolveOutcome solution)
        {
            Console.WriteLine(solution.Classification);
            if (solution.Classification == SolutionOutcomeClassification.Solution)
            {
                var output = new List<string>();
                var step = solution.Problem;
                while (step != null)
                {
                    output.Insert(0, step.ToString());
                    step = step.Parent;
                }

                foreach (var outputItem in output)
                {
                    Console.WriteLine(outputItem);
                }
            }
            Console.WriteLine("============================================");
            Console.WriteLine();
        }
    }
}