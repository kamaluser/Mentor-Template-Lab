using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace MentorInClass.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
