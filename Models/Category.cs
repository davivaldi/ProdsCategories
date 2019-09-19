using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ProdsCategories.Models
{
    public class Category
    {
        [Key]
         public int CategoryId {get; set;}
        [Required(ErrorMessage="Name is required")]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public List<Associations> Associations {get;set;}
    }
}