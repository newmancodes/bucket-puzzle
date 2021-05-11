namespace Solver
{
    public record BucketPuzzleSolveOutcome(SolutionOutcomeClassification Classification, BucketPuzzle Problem)
    {
        public BucketPuzzle RootProblem => this.Problem.Root;

        public static BucketPuzzleSolveOutcome Solution(BucketPuzzle problem) =>
            new(SolutionOutcomeClassification.Solution, problem);
        
        public static BucketPuzzleSolveOutcome CutOff(BucketPuzzle problem) =>
            new(SolutionOutcomeClassification.CutOff, problem);
    }
}