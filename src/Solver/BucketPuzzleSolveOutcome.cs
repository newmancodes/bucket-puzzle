namespace Solver
{
    public record BucketPuzzleSolveOutcome(SolutionOutcomeClassification Classification, BucketPuzzle Problem)
    {
        public static BucketPuzzleSolveOutcome Solution(BucketPuzzle problem) =>
            new(SolutionOutcomeClassification.Solution, problem);
        
        public static BucketPuzzleSolveOutcome CutOff(BucketPuzzle problem) =>
            new(SolutionOutcomeClassification.CutOff, problem);

        public static BucketPuzzleSolveOutcome Failure(BucketPuzzle problem) =>
            new(SolutionOutcomeClassification.Failure, problem);

    }
}