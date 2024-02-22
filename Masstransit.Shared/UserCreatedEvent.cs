namespace Masstransit.Shared
{
    public record UserCreatedEvent
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}