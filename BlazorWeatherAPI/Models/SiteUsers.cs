using System.ComponentModel.DataAnnotations;
namespace BlazorWeatherAPI.Models
{
    public class SiteUser
    {
        [Required]
        public string UserName { get; set; }
        [Required] 
        public string Password { get; set; }
    }
}
