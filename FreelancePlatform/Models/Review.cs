namespace FreelancePlatform.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; } // Від 1 до 5
        public string Comment { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ReviewerId { get; set; }
        public User Reviewer { get; set; }

        public int RevieweeId { get; set; }
        public User Reviewee { get; set; }
    }
}