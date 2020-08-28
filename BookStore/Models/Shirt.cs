using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Shirt
    {
        public int Id { get; set; }
        [Display(Name = "Tshirt Name")]
        [Required]
        public string Title { get; set; }
        public string Brand { get; set; }
        [DataType(DataType.Currency)]
        [Range(1, 100)]
        public decimal Price { get; set; }
        [Display(Name = "Manufacturing Date")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
    }
}
