using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hirlea_Grigore2_Proiect.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Product")]
        public string Name { get; set; }
        public string Brand { get; set; }
        [RegularExpression(@"^(?i)[a-z0-9\s]+$", ErrorMessage = "La plesneala!"), Required,
StringLength(500, MinimumLength = 25)]
        //^ marcheaza inceputul sirului de caractere
        //[A-Z][a-z]+ prenumele -litera mare urmata de oricate litere mici
        //\s spatiu
        //[A-Z][a-z]+ numele- litera mare urmata de oricate litere mici
        //$ marcheaza sfarsitul sirului de caractere
        public string Description { get; set; }
        public string Barcode { get; set; }
        [Range(1, 1000)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }
        public int StorageID { get; set; }
        public Storage Storage { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
