using System.Collections;
using System.Collections.Generic;

namespace Solver
{
    public class BucketPuzzleBuilder
    {
        private ICollection<Bucket> buckets = new List<Bucket>();
        private bool canRefill;
        private bool canEmpty;

        public BucketPuzzleBuilder AddEmptyBucket(int capacity)
        {
            this.buckets.Add(new Bucket(0, capacity));
            return this;
        }
        
        public BucketPuzzleBuilder CanRefill(bool canRefill)
        {
            this.canRefill = canRefill;
            return this;
        }

        public BucketPuzzleBuilder CanEmpty(bool canEmpty)
        {
            this.canEmpty = canEmpty;
            return this;
        }
        
        public BucketPuzzle Build(int targetVolume)
        {
            return new(this.buckets, this.canEmpty, this.canRefill, targetVolume);
        }
    }
}