using System;

namespace Solver
{
    public interface ISolveBucketPuzzles
    {
        BucketPuzzleSolveOutcome Solve(BucketPuzzle problem);
    }
}