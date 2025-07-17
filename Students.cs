using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace CrudUsingADONet.Models
{
    public class Students
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(16, 80, ErrorMessage = "Age can be between 16 to 80")]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string City { get; set; }

        //public enum Gender
        //{
        //    Male = 0,
        //    Female = 1
        //}

    }
}
