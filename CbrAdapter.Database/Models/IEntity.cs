namespace CbrAdapter.Database.Models
{
    public class IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime Created {  get; set; } = DateTime.UtcNow;
    }
}
