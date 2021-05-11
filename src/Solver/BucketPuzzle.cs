using System.Collections.Generic;
using System.Linq;

namespace Solver
{
    public class BucketPuzzle
    {
        public IEnumerable<Bucket> Buckets { get; }
        
        public bool CanEmpty { get; }
        
        public bool CanRefill { get; }
        
        public int TargetVolume { get; }
        
        private int Depth { get; }
        
        private BucketPuzzle Parent { get; }
        
        private string Action { get; }

        public BucketPuzzle(IEnumerable<Bucket> buckets, bool canEmpty, bool canRefill, int targetVolume)
        {
            this.Buckets = buckets;
            this.CanEmpty = canEmpty;
            this.CanRefill = canRefill;
            this.TargetVolume = targetVolume;
            this.Depth = 0;
            this.Parent = null;
            this.Action = null;
        }
        
        private BucketPuzzle(IEnumerable<Bucket> buckets, bool canEmpty, bool canRefill, int targetVolume, int depth, BucketPuzzle parent, string action)
        {
            this.Buckets = buckets;
            this.CanEmpty = canEmpty;
            this.CanRefill = canRefill;
            this.TargetVolume = targetVolume;
            this.Depth = depth;
            this.Parent = parent;
            this.Action = action;
        }

        public bool IsASolution => this.Buckets.Any(b => b.Volume == this.TargetVolume);

        public IEnumerable<BucketPuzzle> Expand(int limit)
        {
            if (this.Depth >= limit)
            {
                return Enumerable.Empty<BucketPuzzle>();
            }

            var expanded = new List<BucketPuzzle>();
            foreach (var bucket in this.Buckets)
            {
                if (this.CanEmpty && !bucket.IsEmpty)
                {
                    expanded.Add(this.Empty(bucket));
                }

                if (this.CanRefill && !bucket.IsFull)
                {
                    expanded.Add(this.Fill(bucket));
                }

                if (!bucket.IsEmpty)
                {
                    foreach (var otherBucket in this.Buckets)
                    {
                        if (bucket == otherBucket
                            || otherBucket.IsFull)
                        {
                            continue;
                        }
                        
                        expanded.Add(this.Pour(bucket, otherBucket));
                    }
                }
            }

            return expanded;
        }

        private BucketPuzzle Empty(Bucket bucket)
        {
            return new(
                this.Buckets.Select(b => b == bucket ? bucket.Empty() : bucket),
                this.CanEmpty,
                this.CanRefill,
                this.TargetVolume,
                this.Depth + 1,
                this,
                $"Empty bucket {bucket.Id}");
        }

        private BucketPuzzle Fill(Bucket bucket)
        {
            return new(
                this.Buckets.Select(b => b == bucket ? bucket.Fill() : b),
                this.CanEmpty,
                this.CanRefill,
                this.TargetVolume,
                this.Depth + 1,
                this,
                $"Fill bucket {bucket.Id}");
        }

        private BucketPuzzle Pour(Bucket from, Bucket into)
        {
            var pourAmount = into.RemainingCapacity;
            if (pourAmount > from.Volume)
            {
                pourAmount = from.Volume;
            }
            
            return new(
                this.Buckets.Select(b => b == from ? from.Pour(pourAmount) : b == into ? into.Fill(pourAmount) : b),
                this.CanEmpty,
                this.CanRefill,
                this.TargetVolume,
                this.Depth + 1,
                this,
                $"Pour {pourAmount} from bucket {from.Id} into bucket {into.Id}");
        }

        public bool IsSame(BucketPuzzle that)
        {
            var thisState = this.Buckets.Select(b => (b.Id, b.Volume, b.Capacity)).OrderBy(b => b.Id).ToList();
            var thatState = that.Buckets.Select(b => (b.Id, b.Volume, b.Capacity)).OrderBy(b => b.Id).ToList();

            return thisState.SequenceEqual(thatState);
        }
    }
}