using System.ComponentModel.DataAnnotations;

namespace Solver
{
    public record Bucket(int Id, int Volume, int Capacity)
    {
        public bool IsEmpty => Volume == 0;

        public bool IsFull => Volume == Capacity;
        
        public int RemainingCapacity => this.Capacity - this.Volume;

        public Bucket Empty()
        {
            return this with { Volume = 0 };
        }

        public Bucket Fill()
        {
            return this.Fill(this.RemainingCapacity);
        }

        public Bucket Empty(int pourAmount)
        {
            return this with { Volume = Volume - pourAmount };
        }

        public Bucket Fill(int fillAmount)
        {
            return this with { Volume = Volume + fillAmount };
        }
    }
}