using FluentAssertions;
using Xunit;

namespace Solver.Tests
{
    public class IterativeDeepeningSolverTests
    {
        [Fact]
        public void Already_Solved_Puzzle_Can_Be_Solved()
        {
            // Arrange
            var problem = new BucketPuzzleBuilder()
                .AddFullBucket(5)
                .AddEmptyBucket(3)
                .CanRefill(true)
                .CanEmpty(true)
                .Build(5);
            var solver = new IterativeDeepeningSolver();

            // Act
            var solveOutcome = solver.Solve(problem);

            // Assert
            solveOutcome.Classification.Should().Be(SolutionOutcomeClassification.Solution);
            solveOutcome.Problem.Should().BeSameAs(problem);
        }

        [Fact]
        public void Impossible_Scenario_Cant_Be_Solved()
        {
            // Arrange
            var problem = new BucketPuzzleBuilder()
                .AddEmptyBucket(2)
                .AddEmptyBucket(4)
                .CanRefill(true)
                .CanEmpty(true)
                .Build(1);
            var solver = new IterativeDeepeningSolver();

            // Act
            var solveOutcome = solver.Solve(problem);

            // Assert
            solveOutcome.Classification.Should().Be(SolutionOutcomeClassification.CutOff);
            solveOutcome.RootProblem.Should().BeSameAs(problem);
        }

        [Fact]
        public void Simple_Scenario_Can_Be_Solved()
        {
            // Arrange
            var problem = new BucketPuzzleBuilder()
                .AddFullBucket(5)
                .AddEmptyBucket(3)
                .CanRefill(false)
                .CanEmpty(false)
                .Build(3);
            var solver = new IterativeDeepeningSolver();

            // Act
            var solveOutcome = solver.Solve(problem);

            // Assert
            solveOutcome.Classification.Should().Be(SolutionOutcomeClassification.Solution);
            solveOutcome.RootProblem.Should().BeSameAs(problem);
        }

        [Fact]
        public void Die_Hard_with_a_Vengeance_Puzzle_Can_Be_Solved()
        {
            // Arrange
            var problem = new BucketPuzzleBuilder()
                .AddEmptyBucket(5)
                .AddEmptyBucket(3)
                .CanRefill(true)
                .CanEmpty(true)
                .Build(4);
            var solver = new IterativeDeepeningSolver();

            // Act
            var solveOutcome = solver.Solve(problem);

            // Assert
            solveOutcome.Classification.Should().Be(SolutionOutcomeClassification.Solution);
            solveOutcome.RootProblem.Should().BeSameAs(problem);
        }

        [Fact]
        public void Tonys_Puzzle_Can_Be_Solved()
        {
            // Arrange
            var problem = new BucketPuzzleBuilder()
                .AddFullBucket(12)
                .AddEmptyBucket(8)
                .AddEmptyBucket(5)
                .CanRefill(true)
                .CanEmpty(true)
                .Build(6);
            var solver = new IterativeDeepeningSolver();

            // Act
            var solveOutcome = solver.Solve(problem);

            // Assert
            solveOutcome.Classification.Should().Be(SolutionOutcomeClassification.Solution);
            solveOutcome.RootProblem.Should().BeSameAs(problem);
        }

        [Fact]
        public void Tonys_Puzzle_Can_Be_Solved_Strictly()
        {
            // Arrange
            var problem = new BucketPuzzleBuilder()
                .AddFullBucket(12)
                .AddEmptyBucket(8)
                .AddEmptyBucket(5)
                .CanRefill(false)
                .CanEmpty(false)
                .Build(6);
            var solver = new IterativeDeepeningSolver();

            // Act
            var solveOutcome = solver.Solve(problem);

            // Assert
            solveOutcome.Classification.Should().Be(SolutionOutcomeClassification.Solution);
            solveOutcome.RootProblem.Should().BeSameAs(problem);
        }
    }
}