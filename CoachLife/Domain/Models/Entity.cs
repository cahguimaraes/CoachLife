namespace CoachLife.Domain.Models
{
    public class Entity : ISoftDeleteEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }

    public interface ISoftDeleteEntity
    {
        public DateTime? DeletedAt { get; set; }
    }
}
