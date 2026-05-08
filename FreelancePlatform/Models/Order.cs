namespace FreelancePlatform.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public string Status { get; set; } // "Open", "InProgress", "Completed"

        // Зовнішні ключі
        public int ClientId { get; set; }
        public User Client { get; set; }

        public int? FreelancerId { get; set; } // Може бути null, поки нікого не обрано
        public User Freelancer { get; set; }
    }
}