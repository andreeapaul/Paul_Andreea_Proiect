using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paul_Andreea_Proiect.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        public string Color { get; set; }


        [Range(1, 2500)]
        [Column(TypeName ="decimal(6,2)")]
        public decimal Price { get; set; }

        public string Brand { get; set; }
        public int Size { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int SellerID { get; set; }

        public Seller Seller { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
