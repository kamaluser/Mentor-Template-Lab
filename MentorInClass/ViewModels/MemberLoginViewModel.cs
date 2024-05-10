using System.ComponentModel.DataAnnotations;

namespace MentorInClass.ViewModels
{
    public class MemberLoginViewModel
    {
        [EmailAddress]
        [MinLength(10)]
        [MaxLength(40)]
        [Required]
        public string Email { get; set; }
        [MinLength(8)]
        [MaxLength(25)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
