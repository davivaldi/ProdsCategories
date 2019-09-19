using System.ComponentModel.DataAnnotations;

namespace ProdsCategories.Models
{
    public class Associations
    {
        [Key]
        public int AssociationsId {get; set;}
        public int CategoryId {get; set;}
        public int ProductId {get; set;}

        public Category Category{get; set;}
        public Product Product {get; set;}
        
    }
}