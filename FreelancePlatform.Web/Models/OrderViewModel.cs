using System.ComponentModel.DataAnnotations;
using FreelancePlatform.Web.Attributes;

namespace FreelancePlatform.Web.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Назва проєкту є обов'язковою.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Назва має бути від 5 до 100 символів.")]
        [CapitalLetter(ErrorMessage = "Назва проєкту повинна починатися з великої літери (кастомна валідація!).")]
        [Display(Name = "Назва проєкту")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Опис завдання є обов'язковим.")]
        [StringLength(2000, MinimumLength = 15, ErrorMessage = "Опис має містити не менше 15 символів.")]
        [Display(Name = "Опис завдання")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Бюджет є обов'язковим.")]
        [Range(10, 10000, ErrorMessage = "Бюджет має бути в межах від 10$ до 10000$.")]
        [Display(Name = "Бюджет ($)")]
        public decimal Budget { get; set; }
    }
}