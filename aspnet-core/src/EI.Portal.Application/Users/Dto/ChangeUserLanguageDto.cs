using System.ComponentModel.DataAnnotations;

namespace EI.Portal.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}