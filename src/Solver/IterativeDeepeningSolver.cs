namespace Solver
{
    public class IterativeDeepeningSolver : ISolveBucketPuzzles{
        public BucketPuzzleSolveOutcome Solve(BucketPuzzle problem)
        {
            return new(false, problem);
        }
    }
}