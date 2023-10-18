using System.ComponentModel.DataAnnotations;

namespace HM4_M6.Models
{
    public class CarViewModel
    {
        [Required(ErrorMessage = "ID Not Specified")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Neme Not Specified")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The name must be from 3 to 20 characters")]
        public string? Name { get; set; }
        [StringLength(20, ErrorMessage = "The name must be to 20 characters")]
        public string? Model { get; set; }
        [Range(10000,1000000)]
        public int Price { get; set; }
        public string? imgLink { get; set; }

    }
}
