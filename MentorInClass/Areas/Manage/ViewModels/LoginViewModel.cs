using System.ComponentModel.DataAnnotations;

namespace MentorInClass.Areas.Manage.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        public string UserName { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(25)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
