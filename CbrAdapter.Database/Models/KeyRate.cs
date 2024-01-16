namespace CbrAdapter.Database.Models
{
    public class KeyRate : IEntity
    {
        public DateTime Date {  get; set; }

        public double Value { get; set; } 
    }
}
