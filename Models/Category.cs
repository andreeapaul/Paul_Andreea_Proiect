using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Paul_Andreea_Proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "{0} trebuie sa aiba intre {2} si {1} caractere", MinimumLength = 4)]
        public string CategoryName { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
