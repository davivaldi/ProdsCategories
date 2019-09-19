using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ProdsCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get; set;}


        [Required(ErrorMessage="Name is required")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public int Price {get; set;}
        public DateTime CreatedAt { get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public List<Associations> Associations {get;set;}
    }
}