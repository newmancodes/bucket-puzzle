using System;
using System.Collections.Generic;
using Solver;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new BucketPuzzleBuilder()
                .CanEmpty(false)
                .CanRefill(false)
                .AddFullBucket(12)
                .AddEmptyBucket(8)
                .AddEmptyBucket(5);
            var problem = builder.Build(6);
            var solver = new IterativeDeepeningSolver();
            var solution = solver.Solve(problem);

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
        }
    }
}