using System.Collections.Generic;

namespace FreelancePlatform.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // "Client" або "Freelancer"
        public float Rating { get; set; } = 0.0f;

        // Навігаційні властивості
        public ICollection<Order> PostedOrders { get; set; }
        public ICollection<Order> CompletedOrders { get; set; }
        public ICollection<Review> GivenReviews { get; set; }
        public ICollection<Review> ReceivedReviews { get; set; }
    }
}