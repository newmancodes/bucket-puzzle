using System.Collections.Generic;

namespace Solver
{
    public record BucketPuzzle(IEnumerable<Bucket> Buckets, bool CanEmpty, bool CanRefill, int TargetVolume)
    {
    }
}