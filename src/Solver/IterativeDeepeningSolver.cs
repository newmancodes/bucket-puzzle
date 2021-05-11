using System.Collections.Generic;
using System.Linq;

namespace Solver
{
    public class IterativeDeepeningSolver : ISolveBucketPuzzles{
        public BucketPuzzleSolveOutcome Solve(BucketPuzzle problem)
        {
            const int depthLimit = 256; // Give up after so many iterations.
            for (var depth = 0; depth < depthLimit; depth++)
            {
                var outcome = this.Solve(problem, depth);
                if (outcome.Classification != SolutionOutcomeClassification.CutOff)
                {
                    return outcome;
                }
            }

            return BucketPuzzleSolveOutcome.CutOff(problem);
        }

        private BucketPuzzleSolveOutcome Solve(BucketPuzzle problem, int limit)
        {
            var frontier = new Stack<BucketPuzzle>();
            frontier.Push(problem);

            var explored = new List<BucketPuzzle>();

            do
            {
                var candidate = frontier.Pop();
                if (candidate.IsASolution)
                {
                    return BucketPuzzleSolveOutcome.Solution(candidate);
                }

                explored.Add(candidate);
                var childStates = candidate.Expand(limit);
                foreach (var childState in childStates)
                {
                    if (!explored.Any(e => e.IsSame(childState))
                        && !frontier.Any(f => f.IsSame(childState)))
                    {
                        frontier.Push(childState);
                    }
                }
            } while (frontier.Count > 0);
            
            return BucketPuzzleSolveOutcome.CutOff(problem);
        }
    }
}