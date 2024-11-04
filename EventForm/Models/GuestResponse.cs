namespace EventForm.Models
{
    public class GuestResponse
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public bool? WillAttend { get; set; }

    }
}
